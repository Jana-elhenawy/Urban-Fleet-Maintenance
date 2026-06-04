using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using database_app.Database;

namespace database_app
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            DBconnection db = new DBconnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT
                    M.MECHANIC_ID,
                    V.VEHICLE_ID,
                    V.MODEL
                FROM MECHANIC M
                JOIN WORKS_ON W
                ON M.DEPOT_ID = W.MEC_DEPOT_ID
                AND M.MECHANIC_ID = W.MECHANIC_ID
                JOIN VEHICLE V
                ON V.DEPOT_ID = W.DEPOT_ID
                AND V.VEHICLE_ID = W.VEHICLE_ID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}