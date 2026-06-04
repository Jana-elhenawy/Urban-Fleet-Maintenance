namespace database_app
{
    partial class InspectionSchedule
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
            Color cardBg    = Color.FromArgb(38, 46, 64);
            Color inputBg   = Color.FromArgb(44, 54, 74);

            pnlTop          = new Panel();
            lblTitle        = new Label();
            pnlForm         = new Panel();
            lblVehicleLbl   = new Label();  cmbVehicle   = new ComboBox();
            lblTypeLbl      = new Label();  cmbInspType  = new ComboBox();
            lblTriggerLbl   = new Label();  cmbTrigger   = new ComboBox();
            lblMileTrigLbl  = new Label();  txtMilageTrigger = new TextBox();
            lblAgeTrigLbl   = new Label();  txtAgeTrigger    = new TextBox();
            lblSchedLbl     = new Label();  dtpScheduled = new DateTimePicker();
            lblNotesLbl     = new Label();  txtNotes     = new TextBox();
            btnSchedule     = new Button();
            pnlActions      = new Panel();
            lblInspIDLbl    = new Label();  txtInspectionID = new TextBox();
            btnComplete     = new Button();
            btnCancel_btn   = new Button();
            btnMarkOverdue  = new Button();
            pnlFilter       = new Panel();
            lblFilterLbl    = new Label();  cmbStatusFilter = new ComboBox();
            lblGrid         = new Label();
            dgvInspections  = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvInspections).BeginInit();
            SuspendLayout();

            // ── Top bar ──────────────────────────────────────────────
            pnlTop.BackColor = panel2; pnlTop.Dock = DockStyle.Top; pnlTop.Height = 64;
            lblTitle.Text = "📋  Inspection Scheduling";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = textPrim; lblTitle.Location = new Point(24, 16); lblTitle.AutoSize = true;
            pnlTop.Controls.Add(lblTitle);

            // ── Form panel ───────────────────────────────────────────
            pnlForm.BackColor = cardBg; pnlForm.Location = new Point(10, 72); pnlForm.Size = new Size(370, 520);

            void Lbl(Label l, string t, int y)
            {
                l.Text = t; l.Font = new Font("Segoe UI", 8.5F); l.ForeColor = textMuted;
                l.Location = new Point(14, y); l.Size = new Size(340, 18);
                pnlForm.Controls.Add(l);
            }
            void Cmb(ComboBox c, int y, string[] items)
            {
                c.Font = new Font("Segoe UI", 9.5F); c.BackColor = inputBg; c.ForeColor = textPrim;
                c.DropDownStyle = ComboBoxStyle.DropDownList; c.FlatStyle = FlatStyle.Flat;
                c.Location = new Point(14, y); c.Size = new Size(342, 26);
                c.Items.AddRange(items);
                if (c.Items.Count > 0) c.SelectedIndex = 0;
                pnlForm.Controls.Add(c);
            }
            void Txt(TextBox t, string ph, int y)
            {
                t.PlaceholderText = ph; t.Font = new Font("Segoe UI", 9.5F);
                t.BackColor = inputBg; t.ForeColor = textPrim; t.BorderStyle = BorderStyle.FixedSingle;
                t.Location = new Point(14, y); t.Size = new Size(342, 26);
                pnlForm.Controls.Add(t);
            }

            Lbl(lblVehicleLbl,  "Vehicle (ID | Depot | Model)", 12);
            cmbVehicle.Font = new Font("Segoe UI", 9.5F); cmbVehicle.BackColor = inputBg; cmbVehicle.ForeColor = textPrim;
            cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList; cmbVehicle.FlatStyle = FlatStyle.Flat;
            cmbVehicle.Location = new Point(14, 30); cmbVehicle.Size = new Size(342, 26);
            pnlForm.Controls.Add(cmbVehicle);

            Lbl(lblTypeLbl,     "Inspection Type", 66);
            Cmb(cmbInspType, 84, new[] { "Routine","Mileage-Based","Age-Based","Safety" });

            Lbl(lblTriggerLbl,  "Schedule Trigger", 120);
            Cmb(cmbTrigger, 138, new[] { "Manual","Mileage","Age" });

            Lbl(lblMileTrigLbl, "Mileage Trigger (km) — fires when vehicle reaches this km", 174);
            Txt(txtMilageTrigger, "e.g. 50000", 192);

            Lbl(lblAgeTrigLbl,  "Age Trigger (days from today) — fires after N days", 228);
            Txt(txtAgeTrigger, "e.g. 180", 246);

            Lbl(lblSchedLbl,    "Scheduled Date (override or auto-computed)", 282);
            dtpScheduled.Format = DateTimePickerFormat.Short; dtpScheduled.Value = DateTime.Today.AddDays(30);
            dtpScheduled.Location = new Point(14, 300); dtpScheduled.Size = new Size(180, 26);
            dtpScheduled.CalendarMonthBackground = inputBg;
            pnlForm.Controls.Add(dtpScheduled);

            Lbl(lblNotesLbl,    "Notes", 336);
            Txt(txtNotes, "Optional notes …", 354);

            btnSchedule.Text = "📅  Schedule Inspection"; btnSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSchedule.BackColor = accentG; btnSchedule.ForeColor = Color.White;
            btnSchedule.FlatStyle = FlatStyle.Flat; btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.Location = new Point(14, 394); btnSchedule.Size = new Size(200, 34); btnSchedule.Cursor = Cursors.Hand;
            pnlForm.Controls.Add(btnSchedule);

            // ── Actions panel (right of form) ─────────────────────────
            pnlActions.BackColor = cardBg; pnlActions.Location = new Point(390, 72); pnlActions.Size = new Size(310, 180);

            void ALbl(Label l, string t, int y)
            {
                l.Text = t; l.Font = new Font("Segoe UI", 8.5F); l.ForeColor = textMuted;
                l.Location = new Point(14, y); l.AutoSize = true;
                pnlActions.Controls.Add(l);
            }
            ALbl(lblInspIDLbl, "Selected Inspection ID", 12);
            txtInspectionID.Font = new Font("Segoe UI", 9.5F); txtInspectionID.BackColor = inputBg;
            txtInspectionID.ForeColor = textPrim; txtInspectionID.BorderStyle = BorderStyle.FixedSingle;
            txtInspectionID.ReadOnly = true; txtInspectionID.PlaceholderText = "click row in grid";
            txtInspectionID.Location = new Point(14, 30); txtInspectionID.Size = new Size(282, 26);
            pnlActions.Controls.Add(txtInspectionID);

            void ActBtn(Button b, string t, Color c, int y)
            {
                b.Text = t; b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                b.BackColor = c; b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
                b.Location = new Point(14, y); b.Size = new Size(282, 34); b.Cursor = Cursors.Hand;
                pnlActions.Controls.Add(b);
            }
            ActBtn(btnComplete,    "✔  Mark as Completed",   accentG, 72);
            ActBtn(btnCancel_btn,  "✕  Cancel Inspection",   accentR, 114);

            // Mark Overdue button (batch)
            btnMarkOverdue.Text = "⚠  Mark Past-Due as Overdue (Batch)";
            btnMarkOverdue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkOverdue.BackColor = Color.FromArgb(180, 100, 20); btnMarkOverdue.ForeColor = Color.White;
            btnMarkOverdue.FlatStyle = FlatStyle.Flat; btnMarkOverdue.FlatAppearance.BorderSize = 0;
            btnMarkOverdue.Location = new Point(390, 264); btnMarkOverdue.Size = new Size(310, 34); btnMarkOverdue.Cursor = Cursors.Hand;

            // ── Filter bar ───────────────────────────────────────────
            pnlFilter.BackColor = Color.FromArgb(28, 35, 50);
            pnlFilter.Location = new Point(10, 600); pnlFilter.Size = new Size(820, 44);

            lblFilterLbl.Text = "Filter by status:"; lblFilterLbl.Font = new Font("Segoe UI", 9F);
            lblFilterLbl.ForeColor = textMuted; lblFilterLbl.Location = new Point(12, 12); lblFilterLbl.AutoSize = true;
            pnlFilter.Controls.Add(lblFilterLbl);

            cmbStatusFilter.Items.AddRange(new object[] { "All","Pending","Completed","Overdue","Cancelled" });
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F); cmbStatusFilter.BackColor = inputBg;
            cmbStatusFilter.ForeColor = textPrim; cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbStatusFilter.Location = new Point(130, 9); cmbStatusFilter.Size = new Size(160, 26);
            pnlFilter.Controls.Add(cmbStatusFilter);

            // ── Grid ─────────────────────────────────────────────────
            lblGrid.Text = "SCHEDULED INSPECTIONS"; lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted; lblGrid.Location = new Point(10, 652); lblGrid.AutoSize = true;

            dgvInspections.Location = new Point(10, 672); dgvInspections.Size = new Size(1080, 280);
            dgvInspections.BackgroundColor = inputBg; dgvInspections.GridColor = Color.FromArgb(60,70,90);
            dgvInspections.DefaultCellStyle.BackColor = cardBg; dgvInspections.DefaultCellStyle.ForeColor = textPrim;
            dgvInspections.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvInspections.DefaultCellStyle.SelectionBackColor = accent;
            dgvInspections.ColumnHeadersDefaultCellStyle.BackColor = panel2;
            dgvInspections.ColumnHeadersDefaultCellStyle.ForeColor = textMuted;
            dgvInspections.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvInspections.EnableHeadersVisualStyles = false; dgvInspections.BorderStyle = BorderStyle.None;
            dgvInspections.RowHeadersVisible = false; dgvInspections.AllowUserToAddRows = false;
            dgvInspections.ReadOnly = true; dgvInspections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInspections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInspections.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 42, 58);
            dgvInspections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // ── Wire events ──────────────────────────────────────────
            btnSchedule.Click   += btnSchedule_Click;
            btnComplete.Click   += btnComplete_Click;
            btnCancel_btn.Click += btnCancel_Click;
            btnMarkOverdue.Click += btnMarkOverdue_Click;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            dgvInspections.CellClick += dgvInspections_CellClick;

            // ── Form ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 970); BackColor = bg;
            Controls.Add(pnlTop); Controls.Add(pnlForm); Controls.Add(pnlActions);
            Controls.Add(btnMarkOverdue); Controls.Add(pnlFilter);
            Controls.Add(lblGrid); Controls.Add(dgvInspections);
            Name = "InspectionSchedule"; Text = "Inspection Scheduling – FleetHub";
            FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dgvInspections).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Panel pnlTop, pnlForm, pnlActions, pnlFilter;
        private Label lblTitle, lblVehicleLbl, lblTypeLbl, lblTriggerLbl, lblMileTrigLbl;
        private Label lblAgeTrigLbl, lblSchedLbl, lblNotesLbl, lblInspIDLbl, lblFilterLbl, lblGrid;
        private ComboBox cmbVehicle, cmbInspType, cmbTrigger, cmbStatusFilter;
        private TextBox txtMilageTrigger, txtAgeTrigger, txtNotes, txtInspectionID;
        private DateTimePicker dtpScheduled;
        private Button btnSchedule, btnComplete, btnCancel_btn, btnMarkOverdue;
        private DataGridView dgvInspections;
    }
}
