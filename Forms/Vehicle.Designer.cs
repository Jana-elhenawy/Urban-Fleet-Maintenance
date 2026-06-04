namespace database_app
{
    partial class Vehicle
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Color bg        = Color.FromArgb(22, 27, 38);
            Color panel2    = Color.FromArgb(30, 37, 52);
            Color accent    = Color.FromArgb(56, 114, 196);
            Color accentG   = Color.FromArgb(34, 197, 94);
            Color accentY   = Color.FromArgb(234, 179, 8);
            Color accentR   = Color.FromArgb(239, 68, 68);
            Color textPrim  = Color.FromArgb(241, 245, 249);
            Color textMuted = Color.FromArgb(100, 116, 139);
            Color inputBg   = Color.FromArgb(38, 46, 64);

            pnlTop       = new Panel();
            lblFormTitle = new Label();
            pnlForm      = new Panel();
            lblFields    = new Label();
            txtDepotID   = new TextBox();
            txtVehicleID = new TextBox();
            txtModel     = new TextBox();
            txtStatus    = new TextBox();
            txtType      = new TextBox();
            txtFuel      = new TextBox();
            txtMileage   = new TextBox();
            txtYear      = new TextBox();
            pnlActions   = new Panel();
            btnAdd       = new Button();
            btnUpdate    = new Button();
            btnDelete    = new Button();
            btnClear     = new Button();
            pnlFilter    = new Panel();
            lblFilter    = new Label();
            cmbStatusFilter = new ComboBox();
            txtSearch    = new TextBox();
            btnSearch    = new Button();
            lblGrid      = new Label();
            dataGridView1 = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // ── Top bar ─────────────────────────────────────────────
            pnlTop.BackColor = panel2; pnlTop.Dock = DockStyle.Top; pnlTop.Height = 64;
            lblFormTitle.Text = "🚗  Vehicle Fleet Management";
            lblFormTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFormTitle.ForeColor = textPrim;
            lblFormTitle.Location = new Point(24, 16); lblFormTitle.AutoSize = true;
            pnlTop.Controls.Add(lblFormTitle);

            // ── Form panel (left) ────────────────────────────────────
            pnlForm.BackColor = panel2; pnlForm.Location = new Point(0, 64); pnlForm.Size = new Size(290, 580);

            lblFields.Text = "VEHICLE DETAILS"; lblFields.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFields.ForeColor = textMuted; lblFields.Location = new Point(24, 14); lblFields.AutoSize = true;
            pnlForm.Controls.Add(lblFields);

            void SI(TextBox tb, string ph, int y)
            {
                tb.PlaceholderText = ph; tb.BackColor = inputBg; tb.ForeColor = textPrim;
                tb.Font = new Font("Segoe UI", 10F); tb.BorderStyle = BorderStyle.FixedSingle;
                tb.Location = new Point(24, y); tb.Size = new Size(242, 30);
                pnlForm.Controls.Add(tb);
            }

            SI(txtDepotID,   "Depot ID",             36);
            SI(txtVehicleID, "Vehicle ID",            76);
            SI(txtModel,     "Model",                116);
            SI(txtStatus,    "Status (Active / In Repair / Out of Service)", 156);
            SI(txtType,      "Vehicle Type (Bus / Rail / Truck …)",          196);
            SI(txtFuel,      "Fuel Type (Diesel / Electric / CNG …)",        236);
            SI(txtMileage,   "Mileage (km)",          276);
            SI(txtYear,      "Manufacture Year",      316);

            // ── Action buttons ───────────────────────────────────────
            pnlActions.BackColor = Color.Transparent;
            pnlActions.Location = new Point(24, 360); pnlActions.Size = new Size(242, 40);
            pnlForm.Controls.Add(pnlActions);

            void AB(Button b, string t, Color c, int x)
            {
                b.Text = t; b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.ForeColor = Color.White; b.BackColor = c;
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
                b.Location = new Point(x, 0); b.Size = new Size(56, 34); b.Cursor = Cursors.Hand;
                pnlActions.Controls.Add(b);
            }
            AB(btnAdd,    "＋ Add",    accentG, 0);
            AB(btnUpdate, "✎ Edit",   accentY, 62);
            AB(btnDelete, "✕ Del",    accentR, 124);
            AB(btnClear,  "↺ Clear",  Color.FromArgb(70,80,110), 186);

            // ── Filter bar ───────────────────────────────────────────
            pnlFilter.BackColor = Color.FromArgb(28, 35, 50);
            pnlFilter.Location = new Point(300, 72); pnlFilter.Size = new Size(780, 48);

            lblFilter.Text = "Filter:"; lblFilter.Font = new Font("Segoe UI", 9F);
            lblFilter.ForeColor = textMuted; lblFilter.Location = new Point(12, 14); lblFilter.AutoSize = true;
            pnlFilter.Controls.Add(lblFilter);

            cmbStatusFilter.Items.AddRange(new object[] { "All","Active","In Repair","Out of Service" });
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F); cmbStatusFilter.BackColor = inputBg;
            cmbStatusFilter.ForeColor = textPrim; cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbStatusFilter.Location = new Point(56, 11); cmbStatusFilter.Size = new Size(160, 26);
            pnlFilter.Controls.Add(cmbStatusFilter);

            txtSearch.PlaceholderText = "Search ID / Model / Depot …";
            txtSearch.Font = new Font("Segoe UI", 9.5F); txtSearch.BackColor = inputBg;
            txtSearch.ForeColor = textPrim; txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(232, 12); txtSearch.Size = new Size(260, 26);
            pnlFilter.Controls.Add(txtSearch);

            btnSearch.Text = "🔍 Search"; btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.BackColor = accent; btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat; btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Location = new Point(500, 11); btnSearch.Size = new Size(100, 26); btnSearch.Cursor = Cursors.Hand;
            pnlFilter.Controls.Add(btnSearch);

            // ── Grid ─────────────────────────────────────────────────
            lblGrid.Text = "VEHICLE RECORDS"; lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted; lblGrid.Location = new Point(302, 126); lblGrid.AutoSize = true;

            dataGridView1.Location = new Point(300, 148); dataGridView1.Size = new Size(780, 476);
            dataGridView1.BackgroundColor = inputBg; dataGridView1.GridColor = Color.FromArgb(60,70,90);
            dataGridView1.DefaultCellStyle.BackColor = inputBg; dataGridView1.DefaultCellStyle.ForeColor = textPrim;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridView1.DefaultCellStyle.SelectionBackColor = accent; dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = panel2;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = textMuted;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false; dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false; dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true; dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 42, 58);

            // ── Wire events ──────────────────────────────────────────
            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;

            // ── Form ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644); BackColor = bg;
            Controls.Add(pnlTop); Controls.Add(pnlForm);
            Controls.Add(pnlFilter); Controls.Add(lblGrid); Controls.Add(dataGridView1);
            Name = "Vehicle"; Text = "Vehicle Fleet – FleetHub";
            FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Panel pnlTop, pnlForm, pnlActions, pnlFilter;
        private Label lblFormTitle, lblFields, lblGrid, lblFilter;
        private TextBox txtDepotID, txtVehicleID, txtModel, txtStatus, txtType, txtFuel, txtMileage, txtYear, txtSearch;
        private ComboBox cmbStatusFilter;
        private Button btnAdd, btnUpdate, btnDelete, btnClear, btnSearch;
        private DataGridView dataGridView1;
    }
}
