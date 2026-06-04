namespace database_app
{
    partial class Depot
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

            // ── Controls ─────────────────────────────────────────────
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlForm = new Panel();
            lblDepotID = new Label(); txtDepotID = new TextBox();
            lblName = new Label(); txtName = new TextBox();
            lblLocation = new Label(); txtLocation = new TextBox();
            lblCapacity = new Label(); txtCapacity = new TextBox();
            lblManager = new Label(); txtManager = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dataGridView1 = new DataGridView();

            SuspendLayout();

            // ── Top bar ───────────────────────────────────────────────
            pnlTop.BackColor = sidebar;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;

            lblTitle.Text = "🏭   Depot Management";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = textPrim;
            lblTitle.Location = new Point(20, 14);
            lblTitle.Size = new Size(340, 32);
            pnlTop.Controls.Add(lblTitle);

            // ── Form panel ────────────────────────────────────────────
            pnlForm.BackColor = cardBg;
            pnlForm.Location = new Point(10, 72);
            pnlForm.Size = new Size(440, 310);

            void Field(Label lbl, TextBox txt, string caption, int y)
            {
                lbl.Text = caption;
                lbl.Font = new Font("Segoe UI", 9F);
                lbl.ForeColor = textMuted;
                lbl.Location = new Point(16, y);
                lbl.Size = new Size(120, 22);

                txt.Font = new Font("Segoe UI", 10F);
                txt.BackColor = inputBg;
                txt.ForeColor = textPrim;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Location = new Point(16, y + 22);
                txt.Size = new Size(408, 28);
                pnlForm.Controls.Add(lbl);
                pnlForm.Controls.Add(txt);
            }

            Field(lblDepotID, txtDepotID, "Depot ID", 10);
            Field(lblName, txtName, "Depot Name", 60);
            Field(lblLocation, txtLocation, "Location", 110);
            Field(lblCapacity, txtCapacity, "Capacity", 170);
            Field(lblManager, txtManager, "Manager", 220);

            void Btn(Button b, string text, Color back, int x)
            {
                b.Text = text;
                b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.BackColor = back;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Location = new Point(x, 270);
                b.Size = new Size(98, 32);
                b.Cursor = Cursors.Hand;
                pnlForm.Controls.Add(b);
            }

            Btn(btnAdd, "➕ Add", Color.FromArgb(34, 139, 34), 6);
            Btn(btnUpdate, "✏ Update", accent, 110);
            Btn(btnDelete, "🗑 Delete", Color.FromArgb(180, 40, 40), 214);
            Btn(btnClear, "✕ Clear", Color.FromArgb(80, 90, 110), 318);

            // ── DataGridView ──────────────────────────────────────────
            dataGridView1.BackgroundColor = bg;
            dataGridView1.ForeColor = textPrim;
            dataGridView1.GridColor = Color.FromArgb(60, 70, 90);
            dataGridView1.DefaultCellStyle.BackColor = cardBg;
            dataGridView1.DefaultCellStyle.ForeColor = textPrim;
            dataGridView1.DefaultCellStyle.SelectionBackColor = accent;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = sidebar;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = textPrim;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Location = new Point(10, 392);
            dataGridView1.Size = new Size(760, 200);
            dataGridView1.CellClick += dataGridView1_CellClick;

            // ── Form ─────────────────────────────────────────────────
            BackColor = bg;
            ClientSize = new Size(780, 610);
            Text = "Depot Management – FleetHub";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(pnlTop);
            Controls.Add(pnlForm);
            Controls.Add(dataGridView1);

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            ResumeLayout(false);
        }

        private Panel pnlTop, pnlForm;
        private Label lblTitle;
        private Label lblDepotID, lblName, lblLocation, lblCapacity, lblManager;
        private TextBox txtDepotID, txtName, txtLocation, txtCapacity, txtManager;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dataGridView1;
    }
}