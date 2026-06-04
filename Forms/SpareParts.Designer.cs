namespace database_app
{
    partial class SpareParts
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPartID     = new TextBox();
            txtCost       = new TextBox();
            txtPartName   = new TextBox();
            txtCategory   = new TextBox();
            btnAdd        = new Button();
            btnUpdate     = new Button();
            btnDelete     = new Button();
            dataGridView1 = new DataGridView();
            pnlTop        = new Panel();
            lblFormTitle  = new Label();
            pnlForm       = new Panel();
            lblFields     = new Label();
            pnlActions    = new Panel();
            lblGrid       = new Label();
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

            pnlTop.BackColor = panel2;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 64;
            lblFormTitle.Text = "⚙  Spare Parts Management";
            lblFormTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblFormTitle.ForeColor = textPrim;
            lblFormTitle.Location = new Point(24, 16);
            lblFormTitle.AutoSize = true;
            pnlTop.Controls.Add(lblFormTitle);

            pnlForm.BackColor = panel2;
            pnlForm.Location = new Point(0, 64);
            pnlForm.Size = new Size(280, 480);

            lblFields.Text = "PART DETAILS";
            lblFields.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFields.ForeColor = textMuted;
            lblFields.Location = new Point(24, 18);
            lblFields.AutoSize = true;
            pnlForm.Controls.Add(lblFields);

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

            SI(txtPartID,   "Part ID",   44);
            SI(txtPartName, "Part Name", 84);
            SI(txtCategory, "Category",  124);
            SI(txtCost,     "Cost (EGP)", 164);

            pnlActions.BackColor = Color.Transparent;
            pnlActions.Location = new Point(24, 220);
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

            lblGrid.Text = "PARTS INVENTORY";
            lblGrid.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblGrid.ForeColor = textMuted;
            lblGrid.Location = new Point(296, 74);
            lblGrid.AutoSize = true;

            dataGridView1.Location = new Point(296, 96);
            dataGridView1.Size = new Size(680, 430);
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
            ClientSize = new Size(1000, 580);
            BackColor = bg;
            Controls.Add(pnlTop);
            Controls.Add(pnlForm);
            Controls.Add(lblGrid);
            Controls.Add(dataGridView1);
            Name = "SpareParts";
            Text = "Spare Parts Management";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel    pnlTop, pnlForm, pnlActions;
        private Label    lblFormTitle, lblFields, lblGrid;
        private TextBox  txtPartID, txtCost, txtPartName, txtCategory;
        private Button   btnAdd, btnUpdate, btnDelete;
        private DataGridView dataGridView1;
    }
}
