using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class MaintenanceLog : Form
    {
        public MaintenanceLog()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadLogs();
        }

        // ── Load helpers ────────────────────────────────────────────

        private void LoadComboBoxes()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Vehicles
                SqlDataAdapter daV = new SqlDataAdapter(
                    "SELECT VEHICLE_ID + ' | ' + DEPOT_ID + ' | ' + MODEL AS DISPLAY, VEHICLE_ID, DEPOT_ID FROM VEHICLE", conn);
                DataTable dtV = new DataTable();
                daV.Fill(dtV);
                cmbVehicle.DataSource = dtV;
                cmbVehicle.DisplayMember = "DISPLAY";
                cmbVehicle.ValueMember = "VEHICLE_ID";

                // Mechanics
                SqlDataAdapter daM = new SqlDataAdapter(
                    "SELECT MECHANIC_ID + ' | ' + DEPOT_ID AS DISPLAY, MECHANIC_ID, DEPOT_ID FROM MECHANIC", conn);
                DataTable dtM = new DataTable();
                daM.Fill(dtM);
                cmbMechanic.DataSource = dtM;
                cmbMechanic.DisplayMember = "DISPLAY";
                cmbMechanic.ValueMember = "MECHANIC_ID";

                // Spare Parts (for the parts sub-section)
                SqlDataAdapter daP = new SqlDataAdapter(
                    "SELECT PART_ID, PART_NAME + ' ($' + CAST(COST AS VARCHAR) + ')' AS DISPLAY, COST FROM SPARE_PARTS", conn);
                DataTable dtP = new DataTable();
                daP.Fill(dtP);
                cmbPart.DataSource = dtP;
                cmbPart.DisplayMember = "DISPLAY";
                cmbPart.ValueMember = "PART_ID";
            }
        }

        private void LoadLogs()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT L.LOG_ID, L.VEHICLE_ID, L.DEPOT_ID, L.MECHANIC_ID,
                           L.OPEN_DATE, L.CLOSE_DATE, L.STATUS, L.DESCRIPTION, L.TOTAL_COST
                    FROM   MAINTENANCE_LOG L
                    ORDER  BY L.LOG_ID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLogs.DataSource = dt;
            }
        }

        private void LoadLogParts(int logId)
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT LP.PART_ID, SP.PART_NAME, LP.QUANTITY, LP.UNIT_COST,
                           (LP.QUANTITY * LP.UNIT_COST) AS LINE_TOTAL
                    FROM   LOG_PARTS LP
                    JOIN   SPARE_PARTS SP ON SP.PART_ID = LP.PART_ID
                    WHERE  LP.LOG_ID = @logId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@logId", logId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvParts.DataSource = dt;
            }
        }

        // ── Open / Close log ────────────────────────────────────────

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedItem == null || cmbMechanic.SelectedItem == null)
            { MessageBox.Show("Select a vehicle and mechanic."); return; }

            DataRowView rv = (DataRowView)cmbVehicle.SelectedItem;
            DataRowView rm = (DataRowView)cmbMechanic.SelectedItem;

            string vehicleId = rv["VEHICLE_ID"].ToString()!;
            string depotIdV = rv["DEPOT_ID"].ToString()!;
            string mechanicId = rm["MECHANIC_ID"].ToString()!;
            string depotIdM = rm["DEPOT_ID"].ToString()!;

            if (depotIdV != depotIdM)
            {
                MessageBox.Show("Vehicle and Mechanic must belong to the same depot.", "Depot Mismatch",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO MAINTENANCE_LOG
                        (VEHICLE_ID, DEPOT_ID, MECHANIC_ID, OPEN_DATE, STATUS, DESCRIPTION)
                    VALUES (@vid, @did, @mid, @date, 'Open', @desc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vid", vehicleId);
                cmd.Parameters.AddWithValue("@did", depotIdV);
                cmd.Parameters.AddWithValue("@mid", mechanicId);
                cmd.Parameters.AddWithValue("@date", dtpOpenDate.Value.Date);
                cmd.Parameters.AddWithValue("@desc", string.IsNullOrWhiteSpace(txtDescription.Text)
                                                     ? DBNull.Value : (object)txtDescription.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Maintenance Log Opened Successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLogs();
            }
        }

        private void btnCloseLog_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLogID.Text, out int logId))
            { MessageBox.Show("Enter a valid Log ID to close."); return; }

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE MAINTENANCE_LOG
                    SET STATUS='Closed', CLOSE_DATE=@closeDate
                    WHERE LOG_ID=@logId AND STATUS='Open'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@closeDate", DateTime.Today);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0
                    ? "Log Closed Successfully."
                    : "Log not found or already closed.",
                    "Close Log", MessageBoxButtons.OK,
                    rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadLogs();
            }
        }

        // ── Spare-parts usage ────────────────────────────────────────

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLogID.Text, out int logId))
            { MessageBox.Show("Enter a valid Log ID first."); return; }
            if (cmbPart.SelectedItem == null)
            { MessageBox.Show("Select a spare part."); return; }
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            { MessageBox.Show("Enter a valid quantity (> 0)."); return; }

            DataRowView rp = (DataRowView)cmbPart.SelectedItem;
            string partId = rp["PART_ID"].ToString()!;
            decimal unitCost = Convert.ToDecimal(rp["COST"]);

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                // Upsert: if part already in log, add quantity
                string upsert = @"
                    IF EXISTS (SELECT 1 FROM LOG_PARTS WHERE LOG_ID=@logId AND PART_ID=@partId)
                        UPDATE LOG_PARTS SET QUANTITY = QUANTITY + @qty
                        WHERE LOG_ID=@logId AND PART_ID=@partId
                    ELSE
                        INSERT INTO LOG_PARTS (LOG_ID, PART_ID, QUANTITY, UNIT_COST)
                        VALUES (@logId, @partId, @qty, @cost)";
                SqlCommand cmd = new SqlCommand(upsert, conn);
                cmd.Parameters.AddWithValue("@logId", logId);
                cmd.Parameters.AddWithValue("@partId", partId);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@cost", unitCost);
                cmd.ExecuteNonQuery();

                // Refresh total cost
                SqlCommand refresh = new SqlCommand("EXEC SP_REFRESH_LOG_COST @LogId", conn);
                refresh.Parameters.AddWithValue("@LogId", logId);
                refresh.ExecuteNonQuery();

                MessageBox.Show("Part added to log.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLogParts(logId);
                LoadLogs();
            }
        }

        private void dgvLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLogs.Rows[e.RowIndex];
            txtLogID.Text = row.Cells["LOG_ID"].Value?.ToString() ?? "";
            if (int.TryParse(txtLogID.Text, out int id)) LoadLogParts(id);
        }
    }
}