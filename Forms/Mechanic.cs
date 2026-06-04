using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class Mechanic : Form
    {
        public Mechanic()
        {
            InitializeComponent();
            LoadDepots();
            LoadMechanics();
        }

        // ── Load helpers ────────────────────────────────────────────

        private void LoadDepots()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DEPOT_ID, ISNULL(NAME,'') AS NAME FROM DEPOT ORDER BY DEPOT_ID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDepot.DataSource = dt;
                cmbDepot.DisplayMember = "DEPOT_ID";
                cmbDepot.ValueMember = "DEPOT_ID";
            }
        }

        private void LoadMechanics()
        {
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT DEPOT_ID, MECHANIC_ID, ISNULL(NAME,'') AS NAME,
                             ISNULL(PART_NAME,'') AS SPECIALITY,
                             ISNULL(SPECIALIZATION,'') AS SPECIALIZATION,
                             ISNULL(PHONE,'') AS PHONE
                      FROM MECHANIC
                      ORDER BY DEPOT_ID, MECHANIC_ID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
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
                    INSERT INTO MECHANIC (DEPOT_ID, MECHANIC_ID, PART_NAME, NAME, SPECIALIZATION, PHONE)
                    VALUES (@depot, @id, @specialty, @name, @spec, @phone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Mechanic Added Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMechanics();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMechanicID.Text))
            { MessageBox.Show("Enter Mechanic ID to update."); return; }
            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE MECHANIC
                    SET    PART_NAME=@specialty, NAME=@name, SPECIALIZATION=@spec, PHONE=@phone
                    WHERE  DEPOT_ID=@depot AND MECHANIC_ID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Mechanic Updated Successfully"
                                         : "No mechanic found.",
                    "Update", MessageBoxButtons.OK,
                    rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadMechanics();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMechanicID.Text))
            { MessageBox.Show("Enter Mechanic ID to delete."); return; }
            if (MessageBox.Show("Delete this mechanic?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            DBconnection db = new DBconnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MECHANIC WHERE DEPOT_ID=@depot AND MECHANIC_ID=@id", conn);
                cmd.Parameters.AddWithValue("@depot", cmbDepot.SelectedValue?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@id", txtMechanicID.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Mechanic Deleted Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMechanics();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        // ── Grid row click ───────────────────────────────────────────

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            // Set depot combo
            string depotId = row.Cells["DEPOT_ID"].Value?.ToString() ?? "";
            foreach (DataRowView dr in cmbDepot.Items)
                if (dr["DEPOT_ID"].ToString() == depotId)
                { cmbDepot.SelectedItem = dr; break; }

            txtMechanicID.Text   = row.Cells["MECHANIC_ID"].Value?.ToString() ?? "";
            txtName.Text         = row.Cells["NAME"].Value?.ToString() ?? "";
            txtSpecialty.Text    = row.Cells["SPECIALITY"].Value?.ToString() ?? "";
            txtSpecialization.Text = row.Cells["SPECIALIZATION"].Value?.ToString() ?? "";
            txtPhone.Text        = row.Cells["PHONE"].Value?.ToString() ?? "";
        }

        // ── Helpers ─────────────────────────────────────────────────

        private void BindParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@depot",     cmbDepot.SelectedValue?.ToString() ?? "");
            cmd.Parameters.AddWithValue("@id",        txtMechanicID.Text.Trim());
            cmd.Parameters.AddWithValue("@name",      txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@specialty", txtSpecialty.Text.Trim());
            cmd.Parameters.AddWithValue("@spec",      txtSpecialization.Text.Trim());
            cmd.Parameters.AddWithValue("@phone",     string.IsNullOrWhiteSpace(txtPhone.Text)
                                                        ? DBNull.Value : (object)txtPhone.Text.Trim());
        }

        private bool ValidateInputs()
        {
            if (cmbDepot.SelectedValue == null)   { MessageBox.Show("Select a Depot."); return false; }
            if (string.IsNullOrWhiteSpace(txtMechanicID.Text)) { MessageBox.Show("Mechanic ID is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtName.Text))       { MessageBox.Show("Name is required."); return false; }
            return true;
        }

        private void ClearFields()
        {
            txtMechanicID.Text = txtName.Text = txtSpecialty.Text = "";
            txtSpecialization.Text = txtPhone.Text = "";
            if (cmbDepot.Items.Count > 0) cmbDepot.SelectedIndex = 0;
        }
    }
}
