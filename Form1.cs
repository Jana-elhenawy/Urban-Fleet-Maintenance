using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadVehicles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                MessageBox.Show("Connected Successfully!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                    "INSERT INTO vehicle(vehicle_id, model, operational_status) VALUES(@id, @model, @status)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtVehicleID.Text);
                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Vehicle Added Successfully!");

                LoadVehicles();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                    "DELETE FROM vehicle WHERE vehicle_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtVehicleID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Vehicle Deleted Successfully!");

                LoadVehicles();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                    "UPDATE vehicle SET model=@model, operational_status=@status WHERE vehicle_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtVehicleID.Text);
                cmd.Parameters.AddWithValue("@model", txtModel.Text);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Vehicle Updated Successfully!");

                LoadVehicles();
            }
        }

        private void LoadVehicles()
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM vehicle", conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}