using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class Depot : Form
    {
        public Depot()
        {
            InitializeComponent();
            LoadDepots();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO DEPOT (DEPOT_ID, NAME, LOCATION, CAPACITY, MANAGER)
                                 VALUES (@id, @name, @location, @capacity, @manager)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtDepotID.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", int.TryParse(txtCapacity.Text, out int cap) ? cap : 10);
                cmd.Parameters.AddWithValue("@manager", string.IsNullOrWhiteSpace(txtManager.Text)
                                                         ? DBNull.Value : (object)txtManager.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Depot Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepots();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepotID.Text)) { MessageBox.Show("Enter Depot ID to update."); return; }
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE DEPOT SET NAME=@name, LOCATION=@location,
                                 CAPACITY=@capacity, MANAGER=@manager WHERE DEPOT_ID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtDepotID.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@capacity", int.TryParse(txtCapacity.Text, out int cap) ? cap : 10);
                cmd.Parameters.AddWithValue("@manager", string.IsNullOrWhiteSpace(txtManager.Text)
                                                         ? DBNull.Value : (object)txtManager.Text.Trim());
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Depot Updated Successfully" : "No depot found with that ID.",
                                "Update", MessageBoxButtons.OK, rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadDepots();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepotID.Text)) { MessageBox.Show("Enter Depot ID to delete."); return; }
            if (MessageBox.Show("Delete this depot? This cannot be undone.", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DEPOT WHERE DEPOT_ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtDepotID.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Depot Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepots();
                ClearFields();
            }
        }

        private void LoadDepots()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DEPOT_ID, NAME, LOCATION, CAPACITY, MANAGER FROM DEPOT ORDER BY DEPOT_ID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtDepotID.Text = row.Cells["DEPOT_ID"].Value?.ToString() ?? "";
            txtName.Text = row.Cells["NAME"].Value?.ToString() ?? "";
            txtLocation.Text = row.Cells["LOCATION"].Value?.ToString() ?? "";
            txtCapacity.Text = row.Cells["CAPACITY"].Value?.ToString() ?? "";
            txtManager.Text = row.Cells["MANAGER"].Value?.ToString() ?? "";
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtDepotID.Text = "";
            txtName.Text = "";
            txtLocation.Text = "";
            txtCapacity.Text = "";
            txtManager.Text = "";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDepotID.Text)) { MessageBox.Show("Depot ID is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Depot Name is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtLocation.Text)) { MessageBox.Show("Location is required."); return false; }
            if (!int.TryParse(txtCapacity.Text, out int c) || c <= 0)
            { MessageBox.Show("Capacity must be a positive number."); return false; }
            return true;
        }
    }
}