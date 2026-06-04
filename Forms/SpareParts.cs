using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class SpareParts : Form
    {
        public SpareParts()
        {
            InitializeComponent();
            LoadParts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                "INSERT INTO SPARE_PARTS VALUES (@id,@cost,@name,@category)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtPartID.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);
                cmd.Parameters.AddWithValue("@name", txtPartName.Text);
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Part Added Successfully");

                LoadParts();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                "UPDATE SPARE_PARTS SET COST=@cost WHERE PART_ID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtPartID.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Part Updated Successfully");

                LoadParts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                "DELETE FROM SPARE_PARTS WHERE PART_ID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtPartID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Part Deleted Successfully");

                LoadParts();
            }
        }

        private void LoadParts()
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlDataAdapter da =
                new SqlDataAdapter("SELECT * FROM SPARE_PARTS", conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}