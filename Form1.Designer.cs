namespace database_app
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            button1      = new Button();
            txtVehicleID = new TextBox();
            txtModel     = new TextBox();
            txtStatus    = new TextBox();
            btnAdd       = new Button();
            btnUpdate    = new Button();
            btnDelete    = new Button();
            dataGridView1= new DataGridView();
            pnlTop       = new Panel();
            lblTitle2    = new Label();
            pnlForm      = new Panel();
            lblSection   = new Label();
            pnlActions   = new Panel();
            lblGrid      = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            Color bg        = Color.FromArgb(22, 27, 38);
            Color panel2    = Color.FromArgb(30, 37, 52);
            Color accent    = Color.FromArgb(56, 114, 196);
            Color accentG   = Color.FromArgb(34, 197, 94);
            Color accentY   = Color.FromArgb(234, 179, 8);
            Color accentR   = Color.FromArgb(239, 68, 68);
            Color textPrim  = Color.FromArgb(241, 245, 249);
            Color textMuted = Color.FromArgb(100, 116, 139);
            Color inputBg   = Color.FromArgb(38, 46, 64);

            // Header
            pnlTop.BackColor = panel2;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 64;
            lblTitle2.Text = "🚌  Urban Fleet and Maintenance Hub";
            lblTitle2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle2.ForeColor = textPrim;
            lblTitle2.Location = new Point(24, 16);
            lblTitle2.AutoSize = true;
            pnlTop.Controls.Add(lblTitle2);

            // Test connection button in header
            button1.Text = "⚡ Test Connection";
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = textPrim;
            button1.BackColor = accent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(640, 16);
            button1.Size = new Size(140, 32);
            button1.Cursor = Cursors.Hand;
            button1.Click += button1_Click;
            pnlTop.Controls.Add(button1);

            // Left form panel
            pnlForm.BackColor = panel2;
            pnlForm.Location = new Point(0, 64);
            pnlForm.Size = new Size(280, 460);

            lblSection.Text = "VEHICLE DETAILS";
            lblSection.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSection.ForeColor = textMuted;
            lblSection.Location = new Point(24, 18);
            lblSection.AutoSize = true;
            pnlForm.Controls.Add(lblSection);

            void SI(TextBox tb, string ph, int y)
            {
                tb.PlaceholderText = ph;
                tb.BackColor = inputBg;
                tb.ForeColor = textPrim;
                tb.Font = new Font("Segoe UI", 10F);
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.Location = new Point(24, y);
                tb.Size = new Size(232, 30);
                pnlForm.Controls.Add(tb);
            }

            SI(txtVehicleID, "Vehicle ID",          44);
            SI(txtModel,     "Model",               84);
            SI(txtStatus,    "Operational Status",  124);

            pnlActions.BackColor = Color.Transparent;
            pnlActions.Location = new Point(24, 180);
            pnlActions.Size = new Size(232, 54);
            pnlForm.Controls.Add(pnlActions);

            void AB(Button btn, string text, Color bg2, int x)
            {
                btn.Text = text;
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.BackColor = bg2;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(x, 0);
                btn.Size = new Size(72, 36);
                btn.Cursor = Cursors.Hand;
                pnlActions.Controls.Add(btn);
            }

            AB(btnAdd,    "＋ Add",  accentG, 0);
            AB(btnUpdate, "✎ Edit", accentY, 80);
            AB(btnDelete, "✕ Del",  accentR, 160);
            btnAdd.Click    += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            lblGrid.Text = "VEHICLE RECORDS";
            lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted;
            lblGrid.Location = new Point(296, 74);
            lblGrid.AutoSize = true;

            dataGridView1.Location = new Point(296, 96);
            dataGridView1.Size = new Size(680, 400);
            dataGridView1.BackgroundColor = inputBg;
            dataGridView1.GridColor = Color.FromArgb(60, 70, 90);
            dataGridView1.DefaultCellStyle.BackColor = inputBg;
            dataGridView1.DefaultCellStyle.ForeColor = textPrim;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridView1.DefaultCellStyle.SelectionBackColor = accent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = panel2;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = textMuted;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 42, 58);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 560);
            BackColor = bg;
            Controls.Add(pnlTop);
            Controls.Add(pnlForm);
            Controls.Add(lblGrid);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Urban Fleet and Maintenance Hub";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel    pnlTop, pnlForm, pnlActions;
        private Label    lblTitle2, lblSection, lblGrid;
        private Button   button1;
        private TextBox  txtVehicleID, txtModel, txtStatus;
        private Button   btnAdd, btnUpdate, btnDelete;
        private DataGridView dataGridView1;
    }
}
