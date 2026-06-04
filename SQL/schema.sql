CREATE DATABASE Urban_fleet_and_Maintenance_hub;
GO

USE Urban_fleet_and_Maintenance_hub;
GO

/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     08/05/2026 04:38:28 ?                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ELECTRIC_BUS') and o.name = 'FK_ELECTRIC_INHERITAN_VEHICLE')
alter table ELECTRIC_BUS
   drop constraint FK_ELECTRIC_INHERITAN_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ELECTRIC_MECHANIC') and o.name = 'FK_ELECTRIC_INHERITAN_MECHANIC')
alter table ELECTRIC_MECHANIC
   drop constraint FK_ELECTRIC_INHERITAN_MECHANIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMERGENCY_DEPOT') and o.name = 'FK_EMERGENC_INHERITAN_DEPOT')
alter table EMERGENCY_DEPOT
   drop constraint FK_EMERGENC_INHERITAN_DEPOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ENGINE_MECHANIC') and o.name = 'FK_ENGINE_M_INHERITAN_MECHANIC')
alter table ENGINE_MECHANIC
   drop constraint FK_ENGINE_M_INHERITAN_MECHANIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LIGHT_RAIL_CAR') and o.name = 'FK_LIGHT_RA_INHERITAN_VEHICLE')
alter table LIGHT_RAIL_CAR
   drop constraint FK_LIGHT_RA_INHERITAN_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MAINTENANCE_DEPOT') and o.name = 'FK_MAINTENA_INHERITAN_DEPOT')
alter table MAINTENANCE_DEPOT
   drop constraint FK_MAINTENA_INHERITAN_DEPOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MAINTENANCE_LOG') and o.name = 'FK_MAINTENA_CREATES_MECHANIC')
alter table MAINTENANCE_LOG
   drop constraint FK_MAINTENA_CREATES_MECHANIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MAINTENANCE_LOG') and o.name = 'FK_MAINTENA_HAS_VEHICLE')
alter table MAINTENANCE_LOG
   drop constraint FK_MAINTENA_HAS_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MECHANIC') and o.name = 'FK_MECHANIC_EMPLOYS_DEPOT')
alter table MECHANIC
   drop constraint FK_MECHANIC_EMPLOYS_DEPOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PART_USAGE') and o.name = 'FK_PART_USA_PART_USAG_MECHANIC')
alter table PART_USAGE
   drop constraint FK_PART_USA_PART_USAG_MECHANIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PART_USAGE') and o.name = 'FK_PART_USA_PART_USAG_SPARE_PA')
alter table PART_USAGE
   drop constraint FK_PART_USA_PART_USAG_SPARE_PA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VEHICLE') and o.name = 'FK_VEHICLE_MANAGES_DEPOT')
alter table VEHICLE
   drop constraint FK_VEHICLE_MANAGES_DEPOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WORKS_ON') and o.name = 'FK_WORKS_ON_WORKS_ON_MECHANIC')
alter table WORKS_ON
   drop constraint FK_WORKS_ON_WORKS_ON_MECHANIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WORKS_ON') and o.name = 'FK_WORKS_ON_WORKS_ON2_VEHICLE')
alter table WORKS_ON
   drop constraint FK_WORKS_ON_WORKS_ON2_VEHICLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPOT')
            and   type = 'U')
   drop table DEPOT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ELECTRIC_BUS')
            and   type = 'U')
   drop table ELECTRIC_BUS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ELECTRIC_MECHANIC')
            and   type = 'U')
   drop table ELECTRIC_MECHANIC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMERGENCY_DEPOT')
            and   type = 'U')
   drop table EMERGENCY_DEPOT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENGINE_MECHANIC')
            and   type = 'U')
   drop table ENGINE_MECHANIC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LIGHT_RAIL_CAR')
            and   type = 'U')
   drop table LIGHT_RAIL_CAR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MAINTENANCE_DEPOT')
            and   type = 'U')
   drop table MAINTENANCE_DEPOT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MAINTENANCE_LOG')
            and   name  = 'CREATES_FK'
            and   indid > 0
            and   indid < 255)
   drop index MAINTENANCE_LOG.CREATES_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MAINTENANCE_LOG')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index MAINTENANCE_LOG.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MAINTENANCE_LOG')
            and   type = 'U')
   drop table MAINTENANCE_LOG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MECHANIC')
            and   name  = 'EMPLOYS_FK'
            and   indid > 0
            and   indid < 255)
   drop index MECHANIC.EMPLOYS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MECHANIC')
            and   type = 'U')
   drop table MECHANIC
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PART_USAGE')
            and   name  = 'PART_USAGE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PART_USAGE.PART_USAGE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PART_USAGE')
            and   name  = 'PART_USAGE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PART_USAGE.PART_USAGE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PART_USAGE')
            and   type = 'U')
   drop table PART_USAGE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SPARE_PARTS')
            and   type = 'U')
   drop table SPARE_PARTS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VEHICLE')
            and   name  = 'MANAGES_FK'
            and   indid > 0
            and   indid < 255)
   drop index VEHICLE.MANAGES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VEHICLE')
            and   type = 'U')
   drop table VEHICLE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('WORKS_ON')
            and   name  = 'WORKS_ON2_FK'
            and   indid > 0
            and   indid < 255)
   drop index WORKS_ON.WORKS_ON2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('WORKS_ON')
            and   name  = 'WORKS_ON_FK'
            and   indid > 0
            and   indid < 255)
   drop index WORKS_ON.WORKS_ON_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WORKS_ON')
            and   type = 'U')
   drop table WORKS_ON
go

/*==============================================================*/
/* Table: DEPOT                                                 */
/*==============================================================*/
create table DEPOT (
   DEPOT_ID             varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   constraint PK_DEPOT primary key (DEPOT_ID)
)
go

/*==============================================================*/
/* Table: ELECTRIC_BUS                                          */
/*==============================================================*/
create table ELECTRIC_BUS (
   DEPOT_ID             varchar(50)         not null,
   VEHICLE_ID           varchar(50)         not null,
   MODEL                varchar(50)         null,
   OPERATIONAL_STATUS   varchar(50)         null,
   VEHICLE_TYPE         varchar(50)         null,
   FUEL_TYPE            varchar(50)          null,
   MAX_PASS             int                  null,
   LINE_NO              int                  null,
   constraint PK_ELECTRIC_BUS primary key (DEPOT_ID, VEHICLE_ID)
)
go

/*==============================================================*/
/* Table: ELECTRIC_MECHANIC                                     */
/*==============================================================*/
create table ELECTRIC_MECHANIC (
   DEPOT_ID             varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   SPECIALIZATION       varchar(50)         null,
   constraint PK_ELECTRIC_MECHANIC primary key (DEPOT_ID, MECHANIC_ID)
)
go

/*==============================================================*/
/* Table: EMERGENCY_DEPOT                                       */
/*==============================================================*/
create table EMERGENCY_DEPOT (
   DEPOT_ID             varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   TYPE                 varchar(50)          null,
   EMERGENCY_NUMBER     varchar(50)         null,
   constraint PK_EMERGENCY_DEPOT primary key (DEPOT_ID)
)
go

/*==============================================================*/
/* Table: ENGINE_MECHANIC                                       */
/*==============================================================*/
create table ENGINE_MECHANIC (
   DEPOT_ID             varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   SPECIALIZATION       varchar(50)         null,
   constraint PK_ENGINE_MECHANIC primary key (DEPOT_ID, MECHANIC_ID)
)
go

/*==============================================================*/
/* Table: LIGHT_RAIL_CAR                                        */
/*==============================================================*/
create table LIGHT_RAIL_CAR (
   DEPOT_ID             varchar(50)         not null,
   VEHICLE_ID           varchar(50)         not null,
   MODEL                varchar(50)         null,
   OPERATIONAL_STATUS   varchar(50)         null,
   VEHICLE_TYPE         varchar(50)         null,
   FUEL_TYPE            varchar(50)          null,
   LINE_NO              int                  null,
   MAX_SPEED            varchar(50)          null,
   constraint PK_LIGHT_RAIL_CAR primary key (DEPOT_ID, VEHICLE_ID)
)
go

/*==============================================================*/
/* Table: MAINTENANCE_DEPOT                                     */
/*==============================================================*/
create table MAINTENANCE_DEPOT (
   DEPOT_ID             varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   CREW                 varchar(50)         null,
   CALL_NO              varchar(50)          null,
   constraint PK_MAINTENANCE_DEPOT primary key (DEPOT_ID)
)
go

/*==============================================================*/
/* Table: MAINTENANCE_LOG                                       */
/*==============================================================*/
create table MAINTENANCE_LOG (
   DEPOT_ID             varchar(50)         not null,
   VEHICLE_ID           varchar(50)         not null,
   MEC_DEPOT_ID         varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   LOG_ID               varchar(50)         not null,
   DATE                 datetime             null,
   constraint PK_MAINTENANCE_LOG primary key (MEC_DEPOT_ID, DEPOT_ID, VEHICLE_ID, MECHANIC_ID, LOG_ID)
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/




create nonclustered index HAS_FK on MAINTENANCE_LOG (DEPOT_ID ASC,
  VEHICLE_ID ASC)
go

/*==============================================================*/
/* Index: CREATES_FK                                            */
/*==============================================================*/




create nonclustered index CREATES_FK on MAINTENANCE_LOG (MEC_DEPOT_ID ASC,
  MECHANIC_ID ASC)
go

/*==============================================================*/
/* Table: MECHANIC                                              */
/*==============================================================*/
create table MECHANIC (
   DEPOT_ID             varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   PART_NAME            varchar(50)         null,
   constraint PK_MECHANIC primary key (DEPOT_ID, MECHANIC_ID)
)
go

/*==============================================================*/
/* Index: EMPLOYS_FK                                            */
/*==============================================================*/




create nonclustered index EMPLOYS_FK on MECHANIC (DEPOT_ID ASC)
go

/*==============================================================*/
/* Table: PART_USAGE                                            */
/*==============================================================*/
create table PART_USAGE (
   DEPOT_ID             varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   PART_ID              varchar(50)         not null,
   constraint PK_PART_USAGE primary key (DEPOT_ID, MECHANIC_ID, PART_ID)
)
go

/*==============================================================*/
/* Index: PART_USAGE_FK                                         */
/*==============================================================*/




create nonclustered index PART_USAGE_FK on PART_USAGE (DEPOT_ID ASC,
  MECHANIC_ID ASC)
go

/*==============================================================*/
/* Index: PART_USAGE2_FK                                        */
/*==============================================================*/




create nonclustered index PART_USAGE2_FK on PART_USAGE (PART_ID ASC)
go

/*==============================================================*/
/* Table: SPARE_PARTS                                           */
/*==============================================================*/
create table SPARE_PARTS (
   PART_ID              varchar(50)         not null,
   COST                 float                null,
   PART_NAME            varchar(50)         null,
   CATEGORY             varchar(50)          null,
   constraint PK_SPARE_PARTS primary key (PART_ID)
)
go

/*==============================================================*/
/* Table: VEHICLE                                               */
/*==============================================================*/
create table VEHICLE (
   DEPOT_ID             varchar(50)         not null,
   VEHICLE_ID           varchar(50)         not null,
   MODEL                varchar(50)         null,
   OPERATIONAL_STATUS   varchar(50)         null,
   VEHICLE_TYPE         varchar(50)         null,
   FUEL_TYPE            varchar(50)          null,
   constraint PK_VEHICLE primary key (DEPOT_ID, VEHICLE_ID)
)
go

/*==============================================================*/
/* Index: MANAGES_FK                                            */
/*==============================================================*/




create nonclustered index MANAGES_FK on VEHICLE (DEPOT_ID ASC)
go

/*==============================================================*/
/* Table: WORKS_ON                                              */
/*==============================================================*/
create table WORKS_ON (
   MEC_DEPOT_ID         varchar(50)         not null,
   MECHANIC_ID          varchar(50)         not null,
   DEPOT_ID             varchar(50)         not null,
   VEHICLE_ID           varchar(50)         not null,
   constraint PK_WORKS_ON primary key (MEC_DEPOT_ID, DEPOT_ID, MECHANIC_ID, VEHICLE_ID)
)
go

/*==============================================================*/
/* Index: WORKS_ON_FK                                           */
/*==============================================================*/




create nonclustered index WORKS_ON_FK on WORKS_ON (MEC_DEPOT_ID ASC,
  MECHANIC_ID ASC)
go

/*==============================================================*/
/* Index: WORKS_ON2_FK                                          */
/*==============================================================*/




create nonclustered index WORKS_ON2_FK on WORKS_ON (DEPOT_ID ASC,
  VEHICLE_ID ASC)
go

alter table ELECTRIC_BUS
   add constraint FK_ELECTRIC_INHERITAN_VEHICLE foreign key (DEPOT_ID, VEHICLE_ID)
      references VEHICLE (DEPOT_ID, VEHICLE_ID)
go

alter table ELECTRIC_MECHANIC
   add constraint FK_ELECTRIC_INHERITAN_MECHANIC foreign key (DEPOT_ID, MECHANIC_ID)
      references MECHANIC (DEPOT_ID, MECHANIC_ID)
go

alter table EMERGENCY_DEPOT
   add constraint FK_EMERGENC_INHERITAN_DEPOT foreign key (DEPOT_ID)
      references DEPOT (DEPOT_ID)
go

alter table ENGINE_MECHANIC
   add constraint FK_ENGINE_M_INHERITAN_MECHANIC foreign key (DEPOT_ID, MECHANIC_ID)
      references MECHANIC (DEPOT_ID, MECHANIC_ID)
go

alter table LIGHT_RAIL_CAR
   add constraint FK_LIGHT_RA_INHERITAN_VEHICLE foreign key (DEPOT_ID, VEHICLE_ID)
      references VEHICLE (DEPOT_ID, VEHICLE_ID)
go

alter table MAINTENANCE_DEPOT
   add constraint FK_MAINTENA_INHERITAN_DEPOT foreign key (DEPOT_ID)
      references DEPOT (DEPOT_ID)
go

alter table MAINTENANCE_LOG
   add constraint FK_MAINTENA_CREATES_MECHANIC foreign key (MEC_DEPOT_ID, MECHANIC_ID)
      references MECHANIC (DEPOT_ID, MECHANIC_ID)
go

alter table MAINTENANCE_LOG
   add constraint FK_MAINTENA_HAS_VEHICLE foreign key (DEPOT_ID, VEHICLE_ID)
      references VEHICLE (DEPOT_ID, VEHICLE_ID)
go

alter table MECHANIC
   add constraint FK_MECHANIC_EMPLOYS_DEPOT foreign key (DEPOT_ID)
      references DEPOT (DEPOT_ID)
go

alter table PART_USAGE
   add constraint FK_PART_USA_PART_USAG_MECHANIC foreign key (DEPOT_ID, MECHANIC_ID)
      references MECHANIC (DEPOT_ID, MECHANIC_ID)
go

alter table PART_USAGE
   add constraint FK_PART_USA_PART_USAG_SPARE_PA foreign key (PART_ID)
      references SPARE_PARTS (PART_ID)
go

alter table VEHICLE
   add constraint FK_VEHICLE_MANAGES_DEPOT foreign key (DEPOT_ID)
      references DEPOT (DEPOT_ID)
go

alter table WORKS_ON
   add constraint FK_WORKS_ON_WORKS_ON_MECHANIC foreign key (MEC_DEPOT_ID, MECHANIC_ID)
      references MECHANIC (DEPOT_ID, MECHANIC_ID)
go

alter table WORKS_ON
   add constraint FK_WORKS_ON_WORKS_ON2_VEHICLE foreign key (DEPOT_ID, VEHICLE_ID)
      references VEHICLE (DEPOT_ID, VEHICLE_ID)
go




/* Fixing foreign keys to include ON DELETE CASCADE for better data integrity and easier maintenance */

/*==============================================================*/
/* DROP OLD FOREIGN KEYS                                        */
/*==============================================================*/

ALTER TABLE MAINTENANCE_LOG
DROP CONSTRAINT FK_MAINTENANCE_LOG_VEHICLE;
GO

ALTER TABLE MAINTENANCE_LOG
DROP CONSTRAINT FK_MAINTENANCE_LOG_MECHANIC;
GO

ALTER TABLE WORKS_ON
DROP CONSTRAINT FK_WORKS_ON_VEHICLE;
GO

ALTER TABLE WORKS_ON
DROP CONSTRAINT FK_WORKS_ON_MECHANIC;
GO

ALTER TABLE PART_USAGE
DROP CONSTRAINT FK_PART_USAGE_MECHANIC;
GO

ALTER TABLE PART_USAGE
DROP CONSTRAINT FK_PART_USAGE_SPARE_PARTS;
GO

/*==============================================================*/
/* RECREATE WITH CASCADE                                        */
/*==============================================================*/

ALTER TABLE MAINTENANCE_LOG
ADD CONSTRAINT FK_MAINTENANCE_LOG_VEHICLE
FOREIGN KEY (DEPOT_ID, VEHICLE_ID)
REFERENCES VEHICLE (DEPOT_ID, VEHICLE_ID)
ON DELETE CASCADE;
GO

ALTER TABLE MAINTENANCE_LOG
ADD CONSTRAINT FK_MAINTENANCE_LOG_MECHANIC
FOREIGN KEY (MEC_DEPOT_ID, MECHANIC_ID)
REFERENCES MECHANIC (DEPOT_ID, MECHANIC_ID)
ON DELETE CASCADE;
GO

ALTER TABLE WORKS_ON
ADD CONSTRAINT FK_WORKS_ON_VEHICLE
FOREIGN KEY (DEPOT_ID, VEHICLE_ID)
REFERENCES VEHICLE (DEPOT_ID, VEHICLE_ID)
ON DELETE CASCADE;
GO

ALTER TABLE WORKS_ON
ADD CONSTRAINT FK_WORKS_ON_MECHANIC
FOREIGN KEY (MEC_DEPOT_ID, MECHANIC_ID)
REFERENCES MECHANIC (DEPOT_ID, MECHANIC_ID)
ON DELETE CASCADE;
GO

ALTER TABLE PART_USAGE
ADD CONSTRAINT FK_PART_USAGE_MECHANIC
FOREIGN KEY (DEPOT_ID, MECHANIC_ID)
REFERENCES MECHANIC (DEPOT_ID, MECHANIC_ID)
ON DELETE CASCADE;
GO

ALTER TABLE PART_USAGE
ADD CONSTRAINT FK_PART_USAGE_SPARE_PARTS
FOREIGN KEY (PART_ID)
REFERENCES SPARE_PARTS (PART_ID)
ON DELETE CASCADE;
GO




SELECT name
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('PART_USAGE');



DECLARE @sql NVARCHAR(MAX) = '';

SELECT @sql +=
'ALTER TABLE PART_USAGE DROP CONSTRAINT [' + name + '];'
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('PART_USAGE');

EXEC sp_executesql @sql;

ALTER TABLE PART_USAGE
ADD CONSTRAINT FK_PART_USAGE_MECHANIC
FOREIGN KEY (DEPOT_ID, MECHANIC_ID)
REFERENCES MECHANIC (DEPOT_ID, MECHANIC_ID)
ON DELETE CASCADE;
GO

ALTER TABLE PART_USAGE
ADD CONSTRAINT FK_PART_USAGE_SPARE_PARTS
FOREIGN KEY (PART_ID)
REFERENCES SPARE_PARTS (PART_ID)
ON DELETE CASCADE;
GO