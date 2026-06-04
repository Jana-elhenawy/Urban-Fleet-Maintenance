using System;
using System.Windows.Forms;

namespace database_app
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            new Vehicle().Show();
        }

        private void btnMechanics_Click(object sender, EventArgs e)
        {
            new Mechanic().Show();
        }

        private void btnDepots_Click(object sender, EventArgs e)
        {
            new Depot().Show();
        }

        private void btnSpareParts_Click(object sender, EventArgs e)
        {
            new SpareParts().Show();
        }

        private void btnMaintenanceLogs_Click(object sender, EventArgs e)
        {
            new MaintenanceLog().Show();
        }

        private void btnInspections_Click(object sender, EventArgs e)
        {
            new InspectionSchedule().Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new Reports().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e) { }
    }
}
