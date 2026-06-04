using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class Vehicle : Form
    {
        public Vehicle()
        {
            InitializeComponent();
            LoadVehicles();
        }

        // ── CRUD ────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO VEHICLE
                        (DEPOT_ID, VEHICLE_ID, MODEL, OPERATIONAL_STATUS,
                         VEHICLE_TYPE, FUEL_TYPE, MILEAGE, MANUFACTURE_YEAR)
                    VALUES
                        (@depot,@id,@model,@status,@type,@fuel,@mileage,@year)";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vehicle Added Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVehicles();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleID.Text) ||
                string.IsNullOrWhiteSpace(txtDepotID.Text))
            { MessageBox.Show("Enter Depot ID and Vehicle ID to update."); return; }

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE VEHICLE
                    SET    MODEL=@model, OPERATIONAL_STATUS=@status,
                           VEHICLE_TYPE=@type, FUEL_TYPE=@fuel,
                           MILEAGE=@mileage, MANUFACTURE_YEAR=@year
                    WHERE  DEPOT_ID=@depot AND VEHICLE_ID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Vehicle Updated Successfully"
                                         : "No vehicle found with that ID.",
                    "Update", MessageBoxButtons.OK,
                    rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadVehicles();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleID.Text))
            { MessageBox.Show("Enter Vehicle ID to delete."); return; }
            if (MessageBox.Show("Delete this vehicle? This cannot be undone.", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM VEHICLE WHERE DEPOT_ID=@depot AND VEHICLE_ID=@id", conn);
                cmd.Parameters.AddWithValue("@depot", txtDepotID.Text.Trim());
                cmd.Parameters.AddWithValue("@id", txtVehicleID.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vehicle Deleted Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVehicles();
                ClearFields();
            }
        }

        // ── Load / Search ────────────────────────────────────────────

        private void LoadVehicles(string statusFilter = "All", string search = "")
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string where = "WHERE 1=1";
                if (statusFilter != "All")
                    where += " AND OPERATIONAL_STATUS = @status";
                if (!string.IsNullOrWhiteSpace(search))
                    where += " AND (VEHICLE_ID LIKE @search OR MODEL LIKE @search OR DEPOT_ID LIKE @search)";

                string query = $@"
                    SELECT DEPOT_ID, VEHICLE_ID, MODEL, OPERATIONAL_STATUS,
                           VEHICLE_TYPE, FUEL_TYPE, MILEAGE, MANUFACTURE_YEAR
                    FROM   VEHICLE {where}
                    ORDER  BY DEPOT_ID, VEHICLE_ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (statusFilter != "All")
                    cmd.Parameters.AddWithValue("@status", statusFilter);
                if (!string.IsNullOrWhiteSpace(search))
                    cmd.Parameters.AddWithValue("@search", $"%{search}%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                // Colour-code status column
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string s = row.Cells["OPERATIONAL_STATUS"].Value?.ToString() ?? "";
                    row.DefaultCellStyle.ForeColor = s switch
                    {
                        "Active"      => Color.FromArgb(34, 197, 94),
                        "In Repair"   => Color.FromArgb(234, 179, 8),
                        "Out of Service" => Color.FromArgb(239, 68, 68),
                        _             => Color.FromArgb(241, 245, 249)
                    };
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
            => LoadVehicles(cmbStatusFilter.SelectedItem?.ToString() ?? "All", txtSearch.Text);

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
            => LoadVehicles(cmbStatusFilter.SelectedItem?.ToString() ?? "All", txtSearch.Text);

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtDepotID.Text   = row.Cells["DEPOT_ID"].Value?.ToString() ?? "";
            txtVehicleID.Text = row.Cells["VEHICLE_ID"].Value?.ToString() ?? "";
            txtModel.Text     = row.Cells["MODEL"].Value?.ToString() ?? "";
            txtStatus.Text    = row.Cells["OPERATIONAL_STATUS"].Value?.ToString() ?? "";
            txtType.Text      = row.Cells["VEHICLE_TYPE"].Value?.ToString() ?? "";
            txtFuel.Text      = row.Cells["FUEL_TYPE"].Value?.ToString() ?? "";
            txtMileage.Text   = row.Cells["MILEAGE"].Value?.ToString() ?? "";
            txtYear.Text      = row.Cells["MANUFACTURE_YEAR"].Value?.ToString() ?? "";
        }

        // ── Helpers ─────────────────────────────────────────────────

        private void BindParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@depot",  txtDepotID.Text.Trim());
            cmd.Parameters.AddWithValue("@id",     txtVehicleID.Text.Trim());
            cmd.Parameters.AddWithValue("@model",  txtModel.Text.Trim());
            cmd.Parameters.AddWithValue("@status", txtStatus.Text.Trim());
            cmd.Parameters.AddWithValue("@type",   txtType.Text.Trim());
            cmd.Parameters.AddWithValue("@fuel",   txtFuel.Text.Trim());
            cmd.Parameters.AddWithValue("@mileage",
                int.TryParse(txtMileage.Text, out int mi) ? mi : 0);
            cmd.Parameters.AddWithValue("@year",
                int.TryParse(txtYear.Text, out int yr)
                    ? (object)yr : DBNull.Value);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDepotID.Text))
            { MessageBox.Show("Depot ID is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtVehicleID.Text))
            { MessageBox.Show("Vehicle ID is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            { MessageBox.Show("Model is required."); return false; }
            return true;
        }

        private void ClearFields()
        {
            txtDepotID.Text = txtVehicleID.Text = txtModel.Text = "";
            txtStatus.Text  = txtType.Text = txtFuel.Text = "";
            txtMileage.Text = txtYear.Text = txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
        }
    }
}
