-- ============================================================
--  Urban Fleet and Maintenance Hub – UPGRADED SCHEMA
--  Adds: DEPOT full columns, VEHICLE mileage/year,
--        MECHANIC name/specialization, MAINTENANCE_LOG full
--        lifecycle columns, LOG_PARTS bridge, and brand-new
--        INSPECTION_SCHEDULE table.
--  Run this ONCE on top of your existing database.
-- ============================================================

USE Urban_fleet_and_Maintenance_hub;
GO

-- ============================================================
--  1. DEPOT  – add NAME, LOCATION, CAPACITY, MANAGER
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DEPOT') AND name = 'NAME')
    ALTER TABLE DEPOT ADD NAME VARCHAR(100) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DEPOT') AND name = 'LOCATION')
    ALTER TABLE DEPOT ADD LOCATION VARCHAR(150) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DEPOT') AND name = 'CAPACITY')
    ALTER TABLE DEPOT ADD CAPACITY INT NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DEPOT') AND name = 'MANAGER')
    ALTER TABLE DEPOT ADD MANAGER VARCHAR(100) NULL;
GO

-- ============================================================
--  2. VEHICLE – add MILEAGE, MANUFACTURE_YEAR
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('VEHICLE') AND name = 'MILEAGE')
    ALTER TABLE VEHICLE ADD MILEAGE INT NULL DEFAULT 0;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('VEHICLE') AND name = 'MANUFACTURE_YEAR')
    ALTER TABLE VEHICLE ADD MANUFACTURE_YEAR INT NULL;
GO

-- ============================================================
--  3. MECHANIC – add NAME, SPECIALIZATION, PHONE
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('MECHANIC') AND name = 'NAME')
    ALTER TABLE MECHANIC ADD NAME VARCHAR(100) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('MECHANIC') AND name = 'SPECIALIZATION')
    ALTER TABLE MECHANIC ADD SPECIALIZATION VARCHAR(100) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('MECHANIC') AND name = 'PHONE')
    ALTER TABLE MECHANIC ADD PHONE VARCHAR(30) NULL;
GO

-- ============================================================
--  4. MAINTENANCE_LOG – rebuild to proper lifecycle shape
--     Original PK is a compound varchar; we need an INT
--     identity LOG_ID as the primary surrogate.
--     We drop and recreate the table if the new columns don't exist.
-- ============================================================

-- Check if the modern shape already exists
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('MAINTENANCE_LOG') AND name = 'STATUS')
BEGIN
    -- Drop old table (data loss acceptable during schema migration)
    IF OBJECT_ID('LOG_PARTS','U') IS NOT NULL DROP TABLE LOG_PARTS;
    DROP TABLE MAINTENANCE_LOG;

    CREATE TABLE MAINTENANCE_LOG (
        LOG_ID       INT IDENTITY(1,1) NOT NULL,
        VEHICLE_ID   VARCHAR(50)       NOT NULL,
        DEPOT_ID     VARCHAR(50)       NOT NULL,
        MECHANIC_ID  VARCHAR(50)       NOT NULL,
        OPEN_DATE    DATE              NOT NULL DEFAULT GETDATE(),
        CLOSE_DATE   DATE              NULL,
        STATUS       VARCHAR(20)       NOT NULL DEFAULT 'Open'
                         CHECK (STATUS IN ('Open','Closed')),
        DESCRIPTION  VARCHAR(500)      NULL,
        TOTAL_COST   DECIMAL(12,2)     NULL DEFAULT 0,
        CONSTRAINT PK_MAINTENANCE_LOG PRIMARY KEY (LOG_ID),
        CONSTRAINT FK_ML_VEHICLE  FOREIGN KEY (DEPOT_ID, VEHICLE_ID)
            REFERENCES VEHICLE (DEPOT_ID, VEHICLE_ID),
        CONSTRAINT FK_ML_MECHANIC FOREIGN KEY (DEPOT_ID, MECHANIC_ID)
            REFERENCES MECHANIC (DEPOT_ID, MECHANIC_ID)
    );
END
GO

-- ============================================================
--  5. LOG_PARTS – spare parts consumed per maintenance log
-- ============================================================
IF OBJECT_ID('LOG_PARTS','U') IS NULL
BEGIN
    CREATE TABLE LOG_PARTS (
        LOG_ID    INT          NOT NULL,
        PART_ID   VARCHAR(50)  NOT NULL,
        QUANTITY  INT          NOT NULL DEFAULT 1,
        UNIT_COST DECIMAL(12,2) NOT NULL DEFAULT 0,
        CONSTRAINT PK_LOG_PARTS PRIMARY KEY (LOG_ID, PART_ID),
        CONSTRAINT FK_LP_LOG  FOREIGN KEY (LOG_ID)  REFERENCES MAINTENANCE_LOG (LOG_ID) ON DELETE CASCADE,
        CONSTRAINT FK_LP_PART FOREIGN KEY (PART_ID) REFERENCES SPARE_PARTS (PART_ID)
    );
END
GO

-- ============================================================
--  6. INSPECTION_SCHEDULE  (brand-new table)
-- ============================================================
IF OBJECT_ID('INSPECTION_SCHEDULE','U') IS NULL
BEGIN
    CREATE TABLE INSPECTION_SCHEDULE (
        INSPECTION_ID    INT IDENTITY(1,1) NOT NULL,
        VEHICLE_ID       VARCHAR(50)       NOT NULL,
        DEPOT_ID         VARCHAR(50)       NOT NULL,
        SCHEDULED_DATE   DATE              NOT NULL,
        INSPECTION_TYPE  VARCHAR(50)       NOT NULL DEFAULT 'Routine'
                             CHECK (INSPECTION_TYPE IN ('Routine','Mileage-Based','Age-Based','Safety')),
        TRIGGER_TYPE     VARCHAR(20)       NOT NULL DEFAULT 'Mileage'
                             CHECK (TRIGGER_TYPE IN ('Mileage','Age','Manual')),
        MILEAGE_TRIGGER  INT               NULL,   -- km at which inspection is due
        AGE_TRIGGER_DAYS INT               NULL,   -- days since last inspection
        STATUS           VARCHAR(20)       NOT NULL DEFAULT 'Pending'
                             CHECK (STATUS IN ('Pending','Completed','Overdue','Cancelled')),
        NOTES            VARCHAR(500)      NULL,
        COMPLETED_DATE   DATE              NULL,
        CONSTRAINT PK_INSPECTION_SCHEDULE PRIMARY KEY (INSPECTION_ID),
        CONSTRAINT FK_INSP_VEHICLE FOREIGN KEY (DEPOT_ID, VEHICLE_ID)
            REFERENCES VEHICLE (DEPOT_ID, VEHICLE_ID) ON DELETE CASCADE
    );
END
GO

-- ============================================================
--  7. Stored procedure: refresh MAINTENANCE_LOG.TOTAL_COST
-- ============================================================
IF OBJECT_ID('SP_REFRESH_LOG_COST','P') IS NOT NULL DROP PROCEDURE SP_REFRESH_LOG_COST;
GO
CREATE PROCEDURE SP_REFRESH_LOG_COST
    @LogId INT
AS
BEGIN
    UPDATE MAINTENANCE_LOG
    SET    TOTAL_COST = (
               SELECT ISNULL(SUM(QUANTITY * UNIT_COST), 0)
               FROM   LOG_PARTS
               WHERE  LOG_ID = @LogId
           )
    WHERE  LOG_ID = @LogId;
END
GO

-- ============================================================
--  8. View: overdue inspections (for dashboard badge)
-- ============================================================
IF OBJECT_ID('V_OVERDUE_INSPECTIONS','V') IS NOT NULL DROP VIEW V_OVERDUE_INSPECTIONS;
GO
CREATE VIEW V_OVERDUE_INSPECTIONS AS
    SELECT I.INSPECTION_ID, I.VEHICLE_ID, I.DEPOT_ID,
           I.SCHEDULED_DATE, I.INSPECTION_TYPE, I.STATUS,
           V.MODEL, V.MILEAGE
    FROM   INSPECTION_SCHEDULE I
    JOIN   VEHICLE V ON V.DEPOT_ID = I.DEPOT_ID AND V.VEHICLE_ID = I.VEHICLE_ID
    WHERE  I.STATUS = 'Pending'
      AND  I.SCHEDULED_DATE < CAST(GETDATE() AS DATE);
GO

PRINT 'Schema upgrade complete.';
