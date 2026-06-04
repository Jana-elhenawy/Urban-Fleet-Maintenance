namespace database_app
{
    partial class Mechanic
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

            pnlTop          = new Panel();
            lblFormTitle    = new Label();
            pnlForm         = new Panel();
            lblFields       = new Label();
            lblDepotLbl     = new Label();
            cmbDepot        = new ComboBox();
            txtMechanicID   = new TextBox();
            txtName         = new TextBox();
            txtSpecialty    = new TextBox();
            txtSpecialization = new TextBox();
            txtPhone        = new TextBox();
            pnlActions      = new Panel();
            btnAdd          = new Button();
            btnUpdate       = new Button();
            btnDelete       = new Button();
            btnClear        = new Button();
            lblGrid         = new Label();
            dataGridView1   = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // ── Top bar ──────────────────────────────────────────────
            pnlTop.BackColor = panel2; pnlTop.Dock = DockStyle.Top; pnlTop.Height = 64;
            lblFormTitle.Text = "🔧  Mechanic Management";
            lblFormTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFormTitle.ForeColor = textPrim; lblFormTitle.Location = new Point(24, 16); lblFormTitle.AutoSize = true;
            pnlTop.Controls.Add(lblFormTitle);

            // ── Form panel ───────────────────────────────────────────
            pnlForm.BackColor = panel2; pnlForm.Location = new Point(0, 64); pnlForm.Size = new Size(290, 580);

            lblFields.Text = "MECHANIC DETAILS"; lblFields.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFields.ForeColor = textMuted; lblFields.Location = new Point(24, 14); lblFields.AutoSize = true;
            pnlForm.Controls.Add(lblFields);

            // Depot dropdown
            lblDepotLbl.Text = "Depot"; lblDepotLbl.Font = new Font("Segoe UI", 8F);
            lblDepotLbl.ForeColor = textMuted; lblDepotLbl.Location = new Point(24, 36); lblDepotLbl.AutoSize = true;
            pnlForm.Controls.Add(lblDepotLbl);

            cmbDepot.Font = new Font("Segoe UI", 10F); cmbDepot.BackColor = inputBg; cmbDepot.ForeColor = textPrim;
            cmbDepot.DropDownStyle = ComboBoxStyle.DropDownList; cmbDepot.FlatStyle = FlatStyle.Flat;
            cmbDepot.Location = new Point(24, 54); cmbDepot.Size = new Size(242, 30);
            pnlForm.Controls.Add(cmbDepot);

            void SI(TextBox tb, string ph, int y)
            {
                tb.PlaceholderText = ph; tb.BackColor = inputBg; tb.ForeColor = textPrim;
                tb.Font = new Font("Segoe UI", 10F); tb.BorderStyle = BorderStyle.FixedSingle;
                tb.Location = new Point(24, y); tb.Size = new Size(242, 30);
                pnlForm.Controls.Add(tb);
            }

            SI(txtMechanicID,     "Mechanic ID",        96);
            SI(txtName,           "Full Name",          136);
            SI(txtSpecialty,      "Speciality (e.g. Brakes)", 176);
            SI(txtSpecialization, "Specialization",    216);
            SI(txtPhone,          "Phone Number",       256);

            // ── Actions ──────────────────────────────────────────────
            pnlActions.BackColor = Color.Transparent;
            pnlActions.Location = new Point(24, 306); pnlActions.Size = new Size(242, 40);
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

            // ── Grid ─────────────────────────────────────────────────
            lblGrid.Text = "MECHANIC RECORDS"; lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted; lblGrid.Location = new Point(302, 74); lblGrid.AutoSize = true;

            dataGridView1.Location = new Point(300, 96); dataGridView1.Size = new Size(780, 528);
            dataGridView1.BackgroundColor = inputBg; dataGridView1.GridColor = Color.FromArgb(60,70,90);
            dataGridView1.DefaultCellStyle.BackColor = inputBg; dataGridView1.DefaultCellStyle.ForeColor = textPrim;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridView1.DefaultCellStyle.SelectionBackColor = accent;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = panel2;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = textMuted;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false; dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false; dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true; dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 42, 58);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click  += btnClear_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644); BackColor = bg;
            Controls.Add(pnlTop); Controls.Add(pnlForm); Controls.Add(lblGrid); Controls.Add(dataGridView1);
            Name = "Mechanic"; Text = "Mechanic Management – FleetHub";
            FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Panel pnlTop, pnlForm, pnlActions;
        private Label lblFormTitle, lblFields, lblGrid, lblDepotLbl;
        private ComboBox cmbDepot;
        private TextBox txtMechanicID, txtName, txtSpecialty, txtSpecialization, txtPhone;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dataGridView1;
    }
}
