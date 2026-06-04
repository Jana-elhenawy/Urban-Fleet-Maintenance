namespace database_app
{
    partial class Reports
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle      = new Label();
            dataGridView1 = new DataGridView();
            pnlTop        = new Panel();
            lblFormTitle  = new Label();
            lblSubInfo    = new Label();
            pnlGrid       = new Panel();
            lblGrid       = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();

            Color bg        = Color.FromArgb(22, 27, 38);
            Color panel2    = Color.FromArgb(30, 37, 52);
            Color accent    = Color.FromArgb(56, 114, 196);
            Color textPrim  = Color.FromArgb(241, 245, 249);
            Color textMuted = Color.FromArgb(100, 116, 139);
            Color inputBg   = Color.FromArgb(38, 46, 64);

            pnlTop.BackColor = panel2;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 80;

            lblFormTitle.Text = "📊  Reports & Analytics";
            lblFormTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFormTitle.ForeColor = textPrim;
            lblFormTitle.Location = new Point(24, 14);
            lblFormTitle.AutoSize = true;

            lblSubInfo.Text = "Joined views, aggregates and fleet statistics";
            lblSubInfo.Font = new Font("Segoe UI", 9.5F);
            lblSubInfo.ForeColor = textMuted;
            lblSubInfo.Location = new Point(26, 48);
            lblSubInfo.AutoSize = true;

            pnlTop.Controls.Add(lblFormTitle);
            pnlTop.Controls.Add(lblSubInfo);

            lblGrid.Text = "QUERY RESULTS";
            lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted;
            lblGrid.Location = new Point(24, 98);
            lblGrid.AutoSize = true;

            dataGridView1.Location = new Point(24, 122);
            dataGridView1.Size = new Size(952, 380);
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

            lblTitle.Text = "";  // kept for compatibility - hidden
            lblTitle.Visible = false;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 540);
            BackColor = bg;
            Controls.Add(pnlTop);
            Controls.Add(lblGrid);
            Controls.Add(dataGridView1);
            Controls.Add(lblTitle);
            Name = "Reports";
            Text = "Reports & Analytics";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlTop.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel    pnlTop, pnlGrid;
        private Label    lblTitle, lblFormTitle, lblSubInfo, lblGrid;
        private DataGridView dataGridView1;
    }
}
