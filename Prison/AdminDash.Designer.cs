namespace Prison
{
    partial class AdminDash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDash));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.LogOutButton = new System.Windows.Forms.Label();
            this.Visitors = new System.Windows.Forms.Label();
            this.Records = new System.Windows.Forms.Label();
            this.Dashboard = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Archive = new System.Windows.Forms.Button();
            this.EditDetails = new System.Windows.Forms.Button();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.AddPrisoner = new System.Windows.Forms.Button();
            this.RecordsPanel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditVisitorDetails = new System.Windows.Forms.Button();
            this.AddVisitor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitorData = new System.Windows.Forms.DataGridView();
            this.TopPanel.SuspendLayout();
            this.SidePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorData)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.DarkSalmon;
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1903, 72);
            this.TopPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Warden Pogi";
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SidePanel.Controls.Add(this.LogOutButton);
            this.SidePanel.Controls.Add(this.Visitors);
            this.SidePanel.Controls.Add(this.Records);
            this.SidePanel.Controls.Add(this.Dashboard);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 72);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(232, 1264);
            this.SidePanel.TabIndex = 1;
            this.SidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SidePanel_Paint);
            // 
            // LogOutButton
            // 
            this.LogOutButton.AutoSize = true;
            this.LogOutButton.Font = new System.Drawing.Font("Franklin Gothic Book", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.Location = new System.Drawing.Point(42, 623);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(114, 36);
            this.LogOutButton.TabIndex = 3;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // Visitors
            // 
            this.Visitors.AutoSize = true;
            this.Visitors.Font = new System.Drawing.Font("Franklin Gothic Book", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Visitors.Location = new System.Drawing.Point(42, 202);
            this.Visitors.Name = "Visitors";
            this.Visitors.Size = new System.Drawing.Size(109, 36);
            this.Visitors.TabIndex = 2;
            this.Visitors.Text = "Visitors";
            // 
            // Records
            // 
            this.Records.AutoSize = true;
            this.Records.Font = new System.Drawing.Font("Franklin Gothic Book", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Records.Location = new System.Drawing.Point(42, 136);
            this.Records.Name = "Records";
            this.Records.Size = new System.Drawing.Size(119, 36);
            this.Records.TabIndex = 1;
            this.Records.Text = "Records";
            // 
            // Dashboard
            // 
            this.Dashboard.AutoSize = true;
            this.Dashboard.Font = new System.Drawing.Font("Franklin Gothic Book", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard.Location = new System.Drawing.Point(42, 62);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(156, 36);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "DashBoard";
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click_1);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.MainPanel.Controls.Add(this.Archive);
            this.MainPanel.Controls.Add(this.EditDetails);
            this.MainPanel.Controls.Add(this.dataGridViewRecords);
            this.MainPanel.Controls.Add(this.AddPrisoner);
            this.MainPanel.Controls.Add(this.RecordsPanel);
            this.MainPanel.Location = new System.Drawing.Point(238, 745);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1414, 591);
            this.MainPanel.TabIndex = 2;
            // 
            // Archive
            // 
            this.Archive.BackColor = System.Drawing.Color.OrangeRed;
            this.Archive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Archive.Location = new System.Drawing.Point(1212, 41);
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(159, 55);
            this.Archive.TabIndex = 4;
            this.Archive.Text = "Archive a Prisoner";
            this.Archive.UseVisualStyleBackColor = false;
            // 
            // EditDetails
            // 
            this.EditDetails.Location = new System.Drawing.Point(1063, 41);
            this.EditDetails.Name = "EditDetails";
            this.EditDetails.Size = new System.Drawing.Size(131, 55);
            this.EditDetails.TabIndex = 3;
            this.EditDetails.Text = "Edit Details";
            this.EditDetails.UseVisualStyleBackColor = true;
            this.EditDetails.Click += new System.EventHandler(this.EditDetails_Click_2);
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.Location = new System.Drawing.Point(36, 138);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.RowHeadersWidth = 51;
            this.dataGridViewRecords.RowTemplate.Height = 24;
            this.dataGridViewRecords.Size = new System.Drawing.Size(1335, 399);
            this.dataGridViewRecords.TabIndex = 2;
            // 
            // AddPrisoner
            // 
            this.AddPrisoner.Location = new System.Drawing.Point(903, 41);
            this.AddPrisoner.Name = "AddPrisoner";
            this.AddPrisoner.Size = new System.Drawing.Size(131, 55);
            this.AddPrisoner.TabIndex = 1;
            this.AddPrisoner.Text = "Add Prisoner";
            this.AddPrisoner.UseVisualStyleBackColor = true;
            this.AddPrisoner.Click += new System.EventHandler(this.AddPrisoner_Click_2);
            // 
            // RecordsPanel
            // 
            this.RecordsPanel.AutoSize = true;
            this.RecordsPanel.Font = new System.Drawing.Font("Franklin Gothic Book", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsPanel.Location = new System.Drawing.Point(48, 58);
            this.RecordsPanel.Name = "RecordsPanel";
            this.RecordsPanel.Size = new System.Drawing.Size(269, 38);
            this.RecordsPanel.TabIndex = 0;
            this.RecordsPanel.Text = "Prisoner Records";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.EditVisitorDetails);
            this.panel1.Controls.Add(this.AddVisitor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.VisitorData);
            this.panel1.Location = new System.Drawing.Point(238, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1414, 661);
            this.panel1.TabIndex = 3;
            // 
            // EditVisitorDetails
            // 
            this.EditVisitorDetails.Location = new System.Drawing.Point(1240, 40);
            this.EditVisitorDetails.Name = "EditVisitorDetails";
            this.EditVisitorDetails.Size = new System.Drawing.Size(131, 55);
            this.EditVisitorDetails.TabIndex = 6;
            this.EditVisitorDetails.Text = "Edit Details";
            this.EditVisitorDetails.UseVisualStyleBackColor = true;
            this.EditVisitorDetails.Click += new System.EventHandler(this.EditVisitorDetails_Click);
            // 
            // AddVisitor
            // 
            this.AddVisitor.Location = new System.Drawing.Point(1080, 40);
            this.AddVisitor.Name = "AddVisitor";
            this.AddVisitor.Size = new System.Drawing.Size(131, 55);
            this.AddVisitor.TabIndex = 5;
            this.AddVisitor.Text = "Add Visitor";
            this.AddVisitor.UseVisualStyleBackColor = true;
            this.AddVisitor.Click += new System.EventHandler(this.AddVisitor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "Visitor Log";
            // 
            // VisitorData
            // 
            this.VisitorData.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.VisitorData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VisitorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitorData.Location = new System.Drawing.Point(36, 130);
            this.VisitorData.Name = "VisitorData";
            this.VisitorData.RowHeadersWidth = 51;
            this.VisitorData.RowTemplate.Height = 24;
            this.VisitorData.Size = new System.Drawing.Size(1335, 492);
            this.VisitorData.TabIndex = 0;
            this.VisitorData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VisitorData_CellContentClick);
            // 
            // AdminDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TopPanel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminDash";
            this.Text = "Admin Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label Visitors;
        private System.Windows.Forms.Label Records;
        private System.Windows.Forms.Label Dashboard;
        private System.Windows.Forms.Label RecordsPanel;
        private System.Windows.Forms.Button AddPrisoner;
        private System.Windows.Forms.Label LogOutButton;
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.Button EditDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView VisitorData;
        private System.Windows.Forms.Button Archive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EditVisitorDetails;
        private System.Windows.Forms.Button AddVisitor;
    }
}