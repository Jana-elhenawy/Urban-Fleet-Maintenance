namespace database_app
{
    partial class Dashboard
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
            Color sidebar   = Color.FromArgb(30, 37, 52);
            Color accent    = Color.FromArgb(56, 114, 196);
            Color textPrim  = Color.FromArgb(241, 245, 249);
            Color textMuted = Color.FromArgb(100, 116, 139);
            Color cardBg    = Color.FromArgb(38, 46, 64);
            Color divider   = Color.FromArgb(60, 70, 90);
            Color exitClr   = Color.FromArgb(239, 68, 68);

            pnlSidebar = new Panel();
            lblAppName = new Label();
            lblSubtitle = new Label();
            pnlDivider = new Panel();
            btnVehicles       = new Button();
            btnMechanics      = new Button();
            btnDepots         = new Button();
            btnSpareParts     = new Button();
            btnMaintenanceLogs = new Button();
            btnInspections    = new Button();
            btnReports        = new Button();
            btnExit           = new Button();
            pnlMain = new Panel();
            lblWelcome = new Label();
            lblWelcomeSub = new Label();
            pnlCard1 = new Panel(); lblCard1Icon = new Label(); lblCard1Title = new Label(); lblCard1Desc = new Label();
            pnlCard2 = new Panel(); lblCard2Icon = new Label(); lblCard2Title = new Label(); lblCard2Desc = new Label();
            pnlCard3 = new Panel(); lblCard3Icon = new Label(); lblCard3Title = new Label(); lblCard3Desc = new Label();
            pnlCard4 = new Panel(); lblCard4Icon = new Label(); lblCard4Title = new Label(); lblCard4Desc = new Label();
            pnlCard5 = new Panel(); lblCard5Icon = new Label(); lblCard5Title = new Label(); lblCard5Desc = new Label();
            pnlCard6 = new Panel(); lblCard6Icon = new Label(); lblCard6Title = new Label(); lblCard6Desc = new Label();
            pnlCard7 = new Panel(); lblCard7Icon = new Label(); lblCard7Title = new Label(); lblCard7Desc = new Label();
            pnlFooter = new Panel();
            lblFooter = new Label();

            SuspendLayout();

            // ── SIDEBAR ──────────────────────────────────────────────
            pnlSidebar.BackColor = sidebar;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 240;

            lblAppName.Text = "  FleetHub";
            lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppName.ForeColor = textPrim;
            lblAppName.Location = new Point(16, 28);
            lblAppName.Size = new Size(210, 38);

            lblSubtitle.Text = "  Urban Fleet & Maintenance";
            lblSubtitle.Font = new Font("Segoe UI", 8F);
            lblSubtitle.ForeColor = textMuted;
            lblSubtitle.Location = new Point(16, 66);
            lblSubtitle.Size = new Size(210, 20);

            pnlDivider.BackColor = divider;
            pnlDivider.Location = new Point(16, 96);
            pnlDivider.Size = new Size(208, 1);

            void NavBtn(Button btn, string emoji, string label, int y, bool active)
            {
                btn.Text = $"   {emoji}   {label}";
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("Segoe UI", 10F);
                btn.ForeColor = textPrim;
                btn.BackColor = active ? Color.FromArgb(42, 58, 88) : Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 55, 82);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 72, 108);
                btn.Location = new Point(8, y);
                btn.Size = new Size(224, 42);
                btn.Cursor = Cursors.Hand;
            }

            NavBtn(btnVehicles,        "🚗", "Vehicles",          108, false);
            NavBtn(btnMechanics,       "🔧", "Mechanics",         154, false);
            NavBtn(btnDepots,          "🏭", "Depots",            200, false);
            NavBtn(btnSpareParts,      "⚙",  "Spare Parts",       246, false);
            NavBtn(btnMaintenanceLogs, "🔩", "Maintenance Logs",  292, false);
            NavBtn(btnInspections,     "📋", "Inspections",       338, false);
            NavBtn(btnReports,         "📊", "Reports",           384, false);

            btnExit.Text = "   ✕   Exit Application";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.Font = new Font("Segoe UI", 10F);
            btnExit.ForeColor = exitClr;
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 20, 20);
            btnExit.Location = new Point(8, 470);
            btnExit.Size = new Size(224, 42);
            btnExit.Cursor = Cursors.Hand;

            pnlSidebar.Controls.AddRange(new Control[] {
                lblAppName, lblSubtitle, pnlDivider,
                btnVehicles, btnMechanics, btnDepots, btnSpareParts,
                btnMaintenanceLogs, btnInspections, btnReports, btnExit });

            // ── MAIN PANEL ───────────────────────────────────────────
            pnlMain.BackColor = bg;
            pnlMain.Dock = DockStyle.Fill;

            lblWelcome.Text = "Welcome back  👋";
            lblWelcome.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWelcome.ForeColor = textPrim;
            lblWelcome.Location = new Point(40, 34);
            lblWelcome.Size = new Size(620, 48);

            lblWelcomeSub.Text = "Manage your fleet, depots, mechanics, parts, maintenance and inspections from one place.";
            lblWelcomeSub.Font = new Font("Segoe UI", 10F);
            lblWelcomeSub.ForeColor = textMuted;
            lblWelcomeSub.Location = new Point(40, 84);
            lblWelcomeSub.Size = new Size(660, 24);

            void Card(Panel p, Label icon, Label title, Label desc,
                      string ic, string ti, string de, int x, int y)
            {
                p.BackColor = cardBg;
                p.Location = new Point(x, y);
                p.Size = new Size(200, 130);
                p.Cursor = Cursors.Hand;

                icon.Text = ic;
                icon.Font = new Font("Segoe UI Emoji", 26F);
                icon.ForeColor = accent;
                icon.Location = new Point(14, 12);
                icon.Size = new Size(50, 46);

                title.Text = ti;
                title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                title.ForeColor = textPrim;
                title.Location = new Point(14, 62);
                title.Size = new Size(174, 24);

                desc.Text = de;
                desc.Font = new Font("Segoe UI", 8F);
                desc.ForeColor = textMuted;
                desc.Location = new Point(14, 88);
                desc.Size = new Size(174, 20);

                p.Controls.AddRange(new Control[] { icon, title, desc });
            }

            // Row 1 — y=118
            Card(pnlCard1, lblCard1Icon, lblCard1Title, lblCard1Desc, "🚗", "Vehicles",          "Fleet catalog & status",    40,  118);
            Card(pnlCard2, lblCard2Icon, lblCard2Title, lblCard2Desc, "🔧", "Mechanics",          "Staff & assignments",       256, 118);
            Card(pnlCard3, lblCard3Icon, lblCard3Title, lblCard3Desc, "🏭", "Depots",             "Depot & manager info",      472, 118);
            
            // Row 2 — y=268
            Card(pnlCard5, lblCard5Icon, lblCard5Title, lblCard5Desc, "🔩", "Maintenance Logs",   "Open / close repair logs",  40,  268);
            Card(pnlCard6, lblCard6Icon, lblCard6Title, lblCard6Desc, "📋", "Inspections",        "Schedule & track checks",   256, 268);
            Card(pnlCard7, lblCard7Icon, lblCard7Title, lblCard7Desc, "📊", "Reports",            "Analytics & joined views",  472, 268);

            // Wire card clicks
            void WireCard(Panel p, EventHandler h)
            {
                p.Click += h;
                foreach (Control c in p.Controls) c.Click += h;
            }
            WireCard(pnlCard1, (s, e) => btnVehicles_Click(s, e));
            WireCard(pnlCard2, (s, e) => btnMechanics_Click(s, e));
            WireCard(pnlCard3, (s, e) => btnDepots_Click(s, e));
            WireCard(pnlCard4, (s, e) => btnSpareParts_Click(s, e));
            WireCard(pnlCard5, (s, e) => btnMaintenanceLogs_Click(s, e));
            WireCard(pnlCard6, (s, e) => btnInspections_Click(s, e));
            WireCard(pnlCard7, (s, e) => btnReports_Click(s, e));

            pnlMain.Controls.AddRange(new Control[] {
                lblWelcome, lblWelcomeSub,
                pnlCard1, pnlCard2, pnlCard3, pnlCard4,
                pnlCard5, pnlCard6, pnlCard7 });

            // ── FOOTER ───────────────────────────────────────────────
            pnlFooter.BackColor = Color.FromArgb(24, 30, 44);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 34;
            lblFooter.Text = "Urban Fleet and Maintenance Hub  •  v3.0  Full-Feature";
            lblFooter.Font = new Font("Segoe UI", 8F);
            lblFooter.ForeColor = textMuted;
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            lblFooter.Dock = DockStyle.Fill;
            pnlFooter.Controls.Add(lblFooter);

            // ── Wire nav events ──────────────────────────────────────
            btnVehicles.Click        += btnVehicles_Click;
            btnMechanics.Click       += btnMechanics_Click;
            btnDepots.Click          += btnDepots_Click;
            btnSpareParts.Click      += btnSpareParts_Click;
            btnMaintenanceLogs.Click += btnMaintenanceLogs_Click;
            btnInspections.Click     += btnInspections_Click;
            btnReports.Click         += btnReports_Click;
            btnExit.Click            += btnExit_Click;
            Load                     += Dashboard_Load;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 560);
            BackColor = bg;
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlFooter);
            Name = "Dashboard";
            Text = "Urban Fleet and Maintenance Hub";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            ResumeLayout(false);
        }

        // ── Control declarations ─────────────────────────────────────
        private Panel pnlSidebar, pnlMain, pnlDivider, pnlFooter;
        private Panel pnlCard1, pnlCard2, pnlCard3, pnlCard4, pnlCard5, pnlCard6, pnlCard7;
        private Label lblAppName, lblSubtitle, lblWelcome, lblWelcomeSub, lblFooter;
        private Label lblCard1Icon, lblCard1Title, lblCard1Desc;
        private Label lblCard2Icon, lblCard2Title, lblCard2Desc;
        private Label lblCard3Icon, lblCard3Title, lblCard3Desc;
        private Label lblCard4Icon, lblCard4Title, lblCard4Desc;
        private Label lblCard5Icon, lblCard5Title, lblCard5Desc;
        private Label lblCard6Icon, lblCard6Title, lblCard6Desc;
        private Label lblCard7Icon, lblCard7Title, lblCard7Desc;
        private Button btnVehicles, btnMechanics, btnDepots, btnSpareParts;
        private Button btnMaintenanceLogs, btnInspections, btnReports, btnExit;
    }
}
