using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class InspectionSchedule : Form
    {
        public InspectionSchedule()
        {
            InitializeComponent();
            LoadVehicles();
            LoadInspections();
        }

        // ── Load helpers ────────────────────────────────────────────

        private void LoadVehicles()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT VEHICLE_ID + ' | ' + DEPOT_ID + ' | ' + ISNULL(MODEL,'') AS DISPLAY,
                           VEHICLE_ID, DEPOT_ID, ISNULL(MILEAGE,0) AS MILEAGE,
                           ISNULL(MANUFACTURE_YEAR, YEAR(GETDATE())) AS MANUFACTURE_YEAR
                    FROM VEHICLE ORDER BY DEPOT_ID, VEHICLE_ID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbVehicle.DataSource = dt;
                cmbVehicle.DisplayMember = "DISPLAY";
                cmbVehicle.ValueMember = "VEHICLE_ID";
            }
        }

        private void LoadInspections(string statusFilter = "All")
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string where = statusFilter == "All" ? "" : "AND I.STATUS = @status";
                string query = $@"
                    SELECT I.INSPECTION_ID, I.VEHICLE_ID, I.DEPOT_ID,
                           V.MODEL, V.MILEAGE,
                           I.SCHEDULED_DATE, I.INSPECTION_TYPE, I.TRIGGER_TYPE,
                           I.MILEAGE_TRIGGER, I.AGE_TRIGGER_DAYS,
                           I.STATUS, I.NOTES, I.COMPLETED_DATE
                    FROM   INSPECTION_SCHEDULE I
                    JOIN   VEHICLE V ON V.DEPOT_ID = I.DEPOT_ID AND V.VEHICLE_ID = I.VEHICLE_ID
                    WHERE  1=1 {where}
                    ORDER  BY I.SCHEDULED_DATE ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (statusFilter != "All")
                    cmd.Parameters.AddWithValue("@status", statusFilter);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInspections.DataSource = dt;

                // Colour rows by status
                foreach (DataGridViewRow row in dgvInspections.Rows)
                {
                    string s = row.Cells["STATUS"].Value?.ToString() ?? "";
                    row.DefaultCellStyle.ForeColor = s switch
                    {
                        "Pending"   => Color.FromArgb(234, 179, 8),
                        "Completed" => Color.FromArgb(34, 197, 94),
                        "Overdue"   => Color.FromArgb(239, 68, 68),
                        "Cancelled" => Color.FromArgb(100, 116, 139),
                        _           => Color.FromArgb(241, 245, 249)
                    };
                }
            }
        }

        // ── Schedule inspection ──────────────────────────────────────

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedItem == null)
            { MessageBox.Show("Select a vehicle."); return; }

            DataRowView rv = (DataRowView)cmbVehicle.SelectedItem;
            string vehicleId = rv["VEHICLE_ID"].ToString()!;
            string depotId   = rv["DEPOT_ID"].ToString()!;

            // Auto-compute scheduled date from trigger
            DateTime scheduledDate = dtpScheduled.Value.Date;
            string triggerType = cmbTrigger.SelectedItem?.ToString() ?? "Manual";

            if (triggerType == "Mileage" && int.TryParse(txtMilageTrigger.Text, out int km))
            {
                int currentMileage = Convert.ToInt32(rv["MILEAGE"]);
                if (km <= currentMileage)
                {
                    MessageBox.Show($"Mileage trigger ({km} km) is already exceeded by current mileage ({currentMileage} km).\n" +
                                    "Scheduling as overdue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    scheduledDate = DateTime.Today.AddDays(-1); // mark overdue immediately
                }
            }
            else if (triggerType == "Age" && int.TryParse(txtAgeTrigger.Text, out int days))
            {
                scheduledDate = DateTime.Today.AddDays(days);
            }

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO INSPECTION_SCHEDULE
                        (VEHICLE_ID, DEPOT_ID, SCHEDULED_DATE, INSPECTION_TYPE,
                         TRIGGER_TYPE, MILEAGE_TRIGGER, AGE_TRIGGER_DAYS, STATUS, NOTES)
                    VALUES
                        (@vid, @did, @sched, @type, @trigger, @mileTrig, @ageTrig, 'Pending', @notes)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vid",     vehicleId);
                cmd.Parameters.AddWithValue("@did",     depotId);
                cmd.Parameters.AddWithValue("@sched",   scheduledDate);
                cmd.Parameters.AddWithValue("@type",    cmbInspType.SelectedItem?.ToString() ?? "Routine");
                cmd.Parameters.AddWithValue("@trigger", triggerType);
                cmd.Parameters.AddWithValue("@mileTrig",
                    int.TryParse(txtMilageTrigger.Text, out int mt) ? mt : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ageTrig",
                    int.TryParse(txtAgeTrigger.Text, out int at) ? at : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@notes",
                    string.IsNullOrWhiteSpace(txtNotes.Text) ? DBNull.Value : (object)txtNotes.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inspection Scheduled Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInspections(cmbStatusFilter.SelectedItem?.ToString() ?? "All");
                ClearFields();
            }
        }

        // ── Mark complete ────────────────────────────────────────────

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInspectionID.Text, out int id))
            { MessageBox.Show("Select an inspection from the grid first."); return; }

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE INSPECTION_SCHEDULE
                    SET STATUS='Completed', COMPLETED_DATE=@today
                    WHERE INSPECTION_ID=@id AND STATUS='Pending'", conn);
                cmd.Parameters.AddWithValue("@today", DateTime.Today);
                cmd.Parameters.AddWithValue("@id", id);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Inspection marked as Completed."
                                         : "Inspection already completed or not found.",
                    "Complete", MessageBoxButtons.OK,
                    rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadInspections(cmbStatusFilter.SelectedItem?.ToString() ?? "All");
            }
        }

        // ── Cancel ──────────────────────────────────────────────────

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInspectionID.Text, out int id))
            { MessageBox.Show("Select an inspection from the grid first."); return; }
            if (MessageBox.Show("Cancel this inspection?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE INSPECTION_SCHEDULE
                    SET STATUS='Cancelled'
                    WHERE INSPECTION_ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inspection Cancelled.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInspections(cmbStatusFilter.SelectedItem?.ToString() ?? "All");
            }
        }

        // ── Mark overdue (batch job simulation) ─────────────────────

        private void btnMarkOverdue_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE INSPECTION_SCHEDULE
                    SET STATUS='Overdue'
                    WHERE STATUS='Pending' AND SCHEDULED_DATE < CAST(GETDATE() AS DATE)", conn);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} inspection(s) marked as Overdue.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInspections(cmbStatusFilter.SelectedItem?.ToString() ?? "All");
            }
        }

        // ── Grid click ───────────────────────────────────────────────

        private void dgvInspections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvInspections.Rows[e.RowIndex];
            txtInspectionID.Text = row.Cells["INSPECTION_ID"].Value?.ToString() ?? "";
            txtNotes.Text        = row.Cells["NOTES"].Value?.ToString() ?? "";
        }

        // ── Filter ───────────────────────────────────────────────────

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
            => LoadInspections(cmbStatusFilter.SelectedItem?.ToString() ?? "All");

        // ── Helpers ─────────────────────────────────────────────────

        private void ClearFields()
        {
            txtInspectionID.Text = txtMilageTrigger.Text = txtAgeTrigger.Text = txtNotes.Text = "";
            dtpScheduled.Value = DateTime.Today.AddDays(30);
            if (cmbVehicle.Items.Count > 0) cmbVehicle.SelectedIndex = 0;
            cmbInspType.SelectedIndex = 0;
            cmbTrigger.SelectedIndex = 0;
        }
    }
}
