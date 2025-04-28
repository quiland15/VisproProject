namespace VisproProject
{
    partial class History
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.userStatus = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dropdownPanel = new VisproProject.roundpanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLapangan = new System.Windows.Forms.Label();
            this.roundedPanel1 = new VisproProject.RoundedPanel();
            this.roundedPictureBox1 = new VisproProject.RoundedPictureBox();
            this.btnAbout = new VisproProject.CustomButton();
            this.btnHistory = new VisproProject.CustomButton();
            this.btnLapangan = new VisproProject.CustomButton();
            this.btnDashboard = new VisproProject.CustomButton();
            this.roundpanel1 = new VisproProject.roundpanel();
            this.roundedPictureBox2 = new VisproProject.RoundedPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundpanel2 = new VisproProject.roundpanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.dropdownPanel.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            this.roundpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox2)).BeginInit();
            this.roundpanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.AutoSize = true;
            this.panelHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHeader.BackColor = System.Drawing.Color.DimGray;
            this.panelHeader.Controls.Add(this.userStatus);
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.btnMaximize);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.MaximumSize = new System.Drawing.Size(2048, 32);
            this.panelHeader.MinimumSize = new System.Drawing.Size(800, 32);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1006, 32);
            this.panelHeader.TabIndex = 5;
            // 
            // userStatus
            // 
            this.userStatus.AutoSize = true;
            this.userStatus.BackColor = System.Drawing.Color.Transparent;
            this.userStatus.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatus.Location = new System.Drawing.Point(3, 4);
            this.userStatus.Name = "userStatus";
            this.userStatus.Size = new System.Drawing.Size(66, 26);
            this.userStatus.TabIndex = 31;
            this.userStatus.Text = "Cashier";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(811, -11);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(68, 44);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "–";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Location = new System.Drawing.Point(878, -2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(55, 34);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.Text = "☐";
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(931, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dropdownPanel
            // 
            this.dropdownPanel.BackColor = System.Drawing.Color.White;
            this.dropdownPanel.Controls.Add(this.button2);
            this.dropdownPanel.Controls.Add(this.button1);
            this.dropdownPanel.Location = new System.Drawing.Point(797, 136);
            this.dropdownPanel.Name = "dropdownPanel";
            this.dropdownPanel.Size = new System.Drawing.Size(152, 100);
            this.dropdownPanel.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(19, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Log Out";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Account";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLapangan
            // 
            this.lblLapangan.AutoSize = true;
            this.lblLapangan.BackColor = System.Drawing.Color.Transparent;
            this.lblLapangan.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapangan.ForeColor = System.Drawing.Color.White;
            this.lblLapangan.Location = new System.Drawing.Point(24, 145);
            this.lblLapangan.Name = "lblLapangan";
            this.lblLapangan.Size = new System.Drawing.Size(113, 38);
            this.lblLapangan.TabIndex = 30;
            this.lblLapangan.Text = "History";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.DimGray;
            this.roundedPanel1.BorderColor = System.Drawing.Color.Black;
            this.roundedPanel1.BorderRadius = 30;
            this.roundedPanel1.BorderSize = 2;
            this.roundedPanel1.Controls.Add(this.roundedPictureBox1);
            this.roundedPanel1.Location = new System.Drawing.Point(904, 59);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(55, 51);
            this.roundedPanel1.TabIndex = 27;
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("roundedPictureBox1.Image")));
            this.roundedPictureBox1.Location = new System.Drawing.Point(9, 8);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(36, 34);
            this.roundedPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundedPictureBox1.TabIndex = 9;
            this.roundedPictureBox1.TabStop = false;
            this.roundedPictureBox1.Click += new System.EventHandler(this.roundedPictureBox1_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BorderColor = System.Drawing.Color.White;
            this.btnAbout.BorderRadius = 20;
            this.btnAbout.BorderSize = 2;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(707, 70);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(107, 30);
            this.btnAbout.TabIndex = 26;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnHistory.BorderColor = System.Drawing.Color.White;
            this.btnHistory.BorderRadius = 20;
            this.btnHistory.BorderSize = 2;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(574, 70);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(107, 30);
            this.btnHistory.TabIndex = 25;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnLapangan
            // 
            this.btnLapangan.BackColor = System.Drawing.Color.Transparent;
            this.btnLapangan.BorderColor = System.Drawing.Color.White;
            this.btnLapangan.BorderRadius = 20;
            this.btnLapangan.BorderSize = 2;
            this.btnLapangan.FlatAppearance.BorderSize = 0;
            this.btnLapangan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapangan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapangan.ForeColor = System.Drawing.Color.White;
            this.btnLapangan.Location = new System.Drawing.Point(441, 70);
            this.btnLapangan.Name = "btnLapangan";
            this.btnLapangan.Size = new System.Drawing.Size(107, 30);
            this.btnLapangan.TabIndex = 24;
            this.btnLapangan.Text = "Lapangan";
            this.btnLapangan.UseVisualStyleBackColor = false;
            this.btnLapangan.Click += new System.EventHandler(this.btnLapangan_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderColor = System.Drawing.Color.White;
            this.btnDashboard.BorderRadius = 20;
            this.btnDashboard.BorderSize = 2;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(295, 70);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(121, 30);
            this.btnDashboard.TabIndex = 23;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // roundpanel1
            // 
            this.roundpanel1.BackColor = System.Drawing.Color.DimGray;
            this.roundpanel1.Controls.Add(this.roundedPictureBox2);
            this.roundpanel1.Controls.Add(this.label1);
            this.roundpanel1.Location = new System.Drawing.Point(0, 39);
            this.roundpanel1.Name = "roundpanel1";
            this.roundpanel1.Size = new System.Drawing.Size(1006, 91);
            this.roundpanel1.TabIndex = 29;
            // 
            // roundedPictureBox2
            // 
            this.roundedPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("roundedPictureBox2.Image")));
            this.roundedPictureBox2.Location = new System.Drawing.Point(31, 21);
            this.roundedPictureBox2.Name = "roundedPictureBox2";
            this.roundedPictureBox2.Size = new System.Drawing.Size(50, 50);
            this.roundedPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundedPictureBox2.TabIndex = 11;
            this.roundedPictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(87, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = "BearsApp";
            // 
            // roundpanel2
            // 
            this.roundpanel2.BackColor = System.Drawing.Color.DimGray;
            this.roundpanel2.Controls.Add(this.dataGridView1);
            this.roundpanel2.Location = new System.Drawing.Point(57, 203);
            this.roundpanel2.Name = "roundpanel2";
            this.roundpanel2.Size = new System.Drawing.Size(878, 490);
            this.roundpanel2.TabIndex = 31;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(838, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.dropdownPanel);
            this.Controls.Add(this.roundpanel2);
            this.Controls.Add(this.lblLapangan);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnLapangan);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.roundpanel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(2048, 1080);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.dropdownPanel.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            this.roundpanel1.ResumeLayout(false);
            this.roundpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox2)).EndInit();
            this.roundpanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnClose;
        private roundpanel dropdownPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLapangan;
        private RoundedPanel roundedPanel1;
        private RoundedPictureBox roundedPictureBox1;
        private CustomButton btnAbout;
        private CustomButton btnHistory;
        private CustomButton btnLapangan;
        private CustomButton btnDashboard;
        private roundpanel roundpanel1;
        private RoundedPictureBox roundedPictureBox2;
        private System.Windows.Forms.Label label1;
        private roundpanel roundpanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label userStatus;
    }
}