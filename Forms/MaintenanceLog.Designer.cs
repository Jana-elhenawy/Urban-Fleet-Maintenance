namespace database_app
{
    partial class MaintenanceLog
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Color bg = Color.FromArgb(22, 27, 38);
            Color sidebar = Color.FromArgb(30, 37, 52);
            Color accent = Color.FromArgb(56, 114, 196);
            Color textPrim = Color.FromArgb(241, 245, 249);
            Color textMuted = Color.FromArgb(100, 116, 139);
            Color cardBg = Color.FromArgb(38, 46, 64);
            Color inputBg = Color.FromArgb(44, 54, 74);
            Color green = Color.FromArgb(34, 139, 34);
            Color red = Color.FromArgb(180, 40, 40);

            // Declare
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlForm = new Panel();
            lblVehicle = new Label(); cmbVehicle = new ComboBox();
            lblMechanic = new Label(); cmbMechanic = new ComboBox();
            lblOpenDate = new Label(); dtpOpenDate = new DateTimePicker();
            lblDescription = new Label(); txtDescription = new TextBox();
            btnOpenLog = new Button();
            pnlClose = new Panel();
            lblLogID = new Label(); txtLogID = new TextBox();
            btnCloseLog = new Button();
            pnlParts = new Panel();
            lblPartsTitle = new Label();
            lblPart = new Label(); cmbPart = new ComboBox();
            lblQty = new Label(); txtQty = new TextBox();
            btnAddPart = new Button();
            dgvParts = new DataGridView();
            lblLogsTitle = new Label();
            dgvLogs = new DataGridView();

            SuspendLayout();

            // Top bar
            pnlTop.BackColor = sidebar; pnlTop.Dock = DockStyle.Top; pnlTop.Height = 60;
            lblTitle.Text = "🔩   Maintenance Logs"; lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = textPrim; lblTitle.Location = new Point(20, 14); lblTitle.Size = new Size(400, 32);
            pnlTop.Controls.Add(lblTitle);

            // ── Open-Log form ────────────────────────────────────────
            pnlForm.BackColor = cardBg; pnlForm.Location = new Point(10, 72); pnlForm.Size = new Size(490, 260);

            void Lbl(Label l, string t, int x, int y, Panel p)
            {
                l.Text = t; l.Font = new Font("Segoe UI", 9F); l.ForeColor = textMuted;
                l.Location = new Point(x, y); l.Size = new Size(200, 20); p.Controls.Add(l);
            }
            void Cmb(ComboBox c, int x, int y, int w, Panel p)
            {
                c.Font = new Font("Segoe UI", 9.5F); c.BackColor = inputBg; c.ForeColor = textPrim;
                c.DropDownStyle = ComboBoxStyle.DropDownList; c.FlatStyle = FlatStyle.Flat;
                c.Location = new Point(x, y); c.Size = new Size(w, 26); p.Controls.Add(c);
            }

            Lbl(lblVehicle, "Vehicle (ID | Depot | Model)", 12, 10, pnlForm);
            Cmb(cmbVehicle, 12, 30, 460, pnlForm);
            Lbl(lblMechanic, "Mechanic (ID | Depot)", 12, 66, pnlForm);
            Cmb(cmbMechanic, 12, 86, 460, pnlForm);

            Lbl(lblOpenDate, "Open Date", 12, 120, pnlForm);
            dtpOpenDate.Format = DateTimePickerFormat.Short; dtpOpenDate.Value = DateTime.Today;
            dtpOpenDate.Location = new Point(12, 140); dtpOpenDate.Size = new Size(160, 26);
            dtpOpenDate.CalendarMonthBackground = inputBg;
            pnlForm.Controls.Add(dtpOpenDate);

            Lbl(lblDescription, "Description / Fault Notes", 12, 176, pnlForm);
            txtDescription.Font = new Font("Segoe UI", 9.5F); txtDescription.BackColor = inputBg;
            txtDescription.ForeColor = textPrim; txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(12, 196); txtDescription.Size = new Size(460, 26);
            pnlForm.Controls.Add(txtDescription);

            btnOpenLog.Text = "▶  Open Log"; btnOpenLog.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenLog.BackColor = green; btnOpenLog.ForeColor = Color.White;
            btnOpenLog.FlatStyle = FlatStyle.Flat; btnOpenLog.FlatAppearance.BorderSize = 0;
            btnOpenLog.Location = new Point(12, 228); btnOpenLog.Size = new Size(130, 32);
            btnOpenLog.Cursor = Cursors.Hand; pnlForm.Controls.Add(btnOpenLog);

            // ── Close-log strip ──────────────────────────────────────
            pnlClose.BackColor = cardBg; pnlClose.Location = new Point(510, 72); pnlClose.Size = new Size(260, 76);
            Label lblClose = new Label
            {
                Text = "Close a Log (enter Log ID)",
                Font = new Font("Segoe UI", 9F),
                ForeColor = textMuted,
                Location = new Point(12, 8),
                Size = new Size(240, 20)
            };
            lblLogID.Text = "Log ID"; lblLogID.Font = new Font("Segoe UI", 9F); lblLogID.ForeColor = textMuted;
            lblLogID.Location = new Point(12, 30); lblLogID.Size = new Size(60, 20);
            txtLogID.Font = new Font("Segoe UI", 9.5F); txtLogID.BackColor = inputBg; txtLogID.ForeColor = textPrim;
            txtLogID.BorderStyle = BorderStyle.FixedSingle; txtLogID.Location = new Point(80, 28); txtLogID.Size = new Size(80, 24);
            btnCloseLog.Text = "■  Close"; btnCloseLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCloseLog.BackColor = red; btnCloseLog.ForeColor = Color.White;
            btnCloseLog.FlatStyle = FlatStyle.Flat; btnCloseLog.FlatAppearance.BorderSize = 0;
            btnCloseLog.Location = new Point(168, 26); btnCloseLog.Size = new Size(84, 28); btnCloseLog.Cursor = Cursors.Hand;
            pnlClose.Controls.AddRange(new Control[] { lblClose, lblLogID, txtLogID, btnCloseLog });

            // ── Parts-usage panel ────────────────────────────────────
            pnlParts.BackColor = cardBg; pnlParts.Location = new Point(510, 158); pnlParts.Size = new Size(260, 174);
            lblPartsTitle.Text = "⚙  Add Spare Part to Log"; lblPartsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPartsTitle.ForeColor = textPrim; lblPartsTitle.Location = new Point(10, 8); lblPartsTitle.Size = new Size(240, 20);
            lblPart.Text = "Part"; lblPart.Font = new Font("Segoe UI", 9F); lblPart.ForeColor = textMuted;
            lblPart.Location = new Point(10, 34); lblPart.Size = new Size(240, 18);
            cmbPart.Font = new Font("Segoe UI", 9F); cmbPart.BackColor = inputBg; cmbPart.ForeColor = textPrim;
            cmbPart.DropDownStyle = ComboBoxStyle.DropDownList; cmbPart.FlatStyle = FlatStyle.Flat;
            cmbPart.Location = new Point(10, 52); cmbPart.Size = new Size(240, 24);
            lblQty.Text = "Quantity"; lblQty.Font = new Font("Segoe UI", 9F); lblQty.ForeColor = textMuted;
            lblQty.Location = new Point(10, 84); lblQty.Size = new Size(80, 18);
            txtQty.Font = new Font("Segoe UI", 9.5F); txtQty.BackColor = inputBg; txtQty.ForeColor = textPrim;
            txtQty.BorderStyle = BorderStyle.FixedSingle; txtQty.Text = "1";
            txtQty.Location = new Point(10, 102); txtQty.Size = new Size(80, 24);
            btnAddPart.Text = "+ Add Part"; btnAddPart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddPart.BackColor = accent; btnAddPart.ForeColor = Color.White;
            btnAddPart.FlatStyle = FlatStyle.Flat; btnAddPart.FlatAppearance.BorderSize = 0;
            btnAddPart.Location = new Point(10, 136); btnAddPart.Size = new Size(110, 28); btnAddPart.Cursor = Cursors.Hand;
            pnlParts.Controls.AddRange(new Control[] { lblPartsTitle, lblPart, cmbPart, lblQty, txtQty, btnAddPart });

            // ── Parts grid (per selected log) ────────────────────────
            void StyleGrid(DataGridView g, int x, int y, int w, int h)
            {
                g.BackgroundColor = bg; g.ForeColor = textPrim; g.GridColor = Color.FromArgb(60, 70, 90);
                g.DefaultCellStyle.BackColor = cardBg; g.DefaultCellStyle.ForeColor = textPrim;
                g.DefaultCellStyle.SelectionBackColor = accent;
                g.ColumnHeadersDefaultCellStyle.BackColor = sidebar;
                g.ColumnHeadersDefaultCellStyle.ForeColor = textPrim;
                g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                g.EnableHeadersVisualStyles = false;
                g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                g.RowHeadersVisible = false; g.AllowUserToAddRows = false; g.ReadOnly = true;
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                g.Location = new Point(x, y); g.Size = new Size(w, h);
            }

            StyleGrid(dgvParts, 510, 340, 260, 160);
            Label lblPartsGrid = new Label
            {
                Text = "Parts Used in Selected Log",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = textMuted,
                Location = new Point(510, 322),
                Size = new Size(260, 20)
            };

            // ── All logs grid ────────────────────────────────────────
            lblLogsTitle.Text = "All Maintenance Logs"; lblLogsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLogsTitle.ForeColor = textPrim; lblLogsTitle.Location = new Point(10, 340); lblLogsTitle.Size = new Size(490, 22);
            StyleGrid(dgvLogs, 10, 364, 490, 136);

            // Form
            BackColor = bg; ClientSize = new Size(780, 510); Text = "Maintenance Logs – FleetHub";
            StartPosition = FormStartPosition.CenterScreen; FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false;

            Controls.AddRange(new Control[] { pnlTop, pnlForm, pnlClose, pnlParts,
                lblPartsGrid, lblLogsTitle, dgvParts, dgvLogs });

            btnOpenLog.Click += btnOpenLog_Click;
            btnCloseLog.Click += btnCloseLog_Click;
            btnAddPart.Click += btnAddPart_Click;
            dgvLogs.CellClick += dgvLogs_CellClick;

            ResumeLayout(false);
        }

        private Panel pnlTop, pnlForm, pnlClose, pnlParts;
        private Label lblTitle, lblVehicle, lblMechanic, lblOpenDate, lblDescription;
        private Label lblLogID, lblPartsTitle, lblPart, lblQty, lblLogsTitle;
        private ComboBox cmbVehicle, cmbMechanic, cmbPart;
        private DateTimePicker dtpOpenDate;
        private TextBox txtDescription, txtLogID, txtQty;
        private Button btnOpenLog, btnCloseLog, btnAddPart;
        private DataGridView dgvLogs, dgvParts;
    }
}