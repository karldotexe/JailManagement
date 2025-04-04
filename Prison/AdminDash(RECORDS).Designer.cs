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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.EditDetails = new System.Windows.Forms.Button();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.AddPrisoner = new System.Windows.Forms.Button();
            this.RecordsPanel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.EditVisitorDetails = new System.Windows.Forms.Button();
            this.AddVisitor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitorData = new System.Windows.Forms.DataGridView();
            this.PendingRequestsGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.SidePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PendingRequestsGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Firebrick;
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1998, 114);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Records Officer";
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.Tomato;
            this.SidePanel.Controls.Add(this.LogOutButton);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 114);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(232, 1872);
            this.SidePanel.TabIndex = 1;
            this.SidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SidePanel_Paint);
            // 
            // LogOutButton
            // 
            this.LogOutButton.AutoSize = true;
            this.LogOutButton.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LogOutButton.Location = new System.Drawing.Point(42, 623);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(120, 34);
            this.LogOutButton.TabIndex = 3;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackColor = System.Drawing.Color.Silver;
            this.MainPanel.Controls.Add(this.EditDetails);
            this.MainPanel.Controls.Add(this.dataGridViewRecords);
            this.MainPanel.Controls.Add(this.AddPrisoner);
            this.MainPanel.Controls.Add(this.RecordsPanel);
            this.MainPanel.Location = new System.Drawing.Point(232, 1388);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1761, 598);
            this.MainPanel.TabIndex = 2;
            // 
            // EditDetails
            // 
            this.EditDetails.Location = new System.Drawing.Point(1471, 43);
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
            this.dataGridViewRecords.Location = new System.Drawing.Point(148, 140);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.RowHeadersWidth = 51;
            this.dataGridViewRecords.RowTemplate.Height = 24;
            this.dataGridViewRecords.Size = new System.Drawing.Size(1466, 399);
            this.dataGridViewRecords.TabIndex = 2;
            this.dataGridViewRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecords_CellContentClick);
            // 
            // AddPrisoner
            // 
            this.AddPrisoner.Location = new System.Drawing.Point(1311, 43);
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
            this.RecordsPanel.Location = new System.Drawing.Point(141, 44);
            this.RecordsPanel.Name = "RecordsPanel";
            this.RecordsPanel.Size = new System.Drawing.Size(269, 38);
            this.RecordsPanel.TabIndex = 0;
            this.RecordsPanel.Text = "Prisoner Records";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.EditVisitorDetails);
            this.panel1.Controls.Add(this.AddVisitor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.VisitorData);
            this.panel1.Location = new System.Drawing.Point(232, 764);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1761, 625);
            this.panel1.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1204, 157);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // EditVisitorDetails
            // 
            this.EditVisitorDetails.Location = new System.Drawing.Point(1403, 56);
            this.EditVisitorDetails.Name = "EditVisitorDetails";
            this.EditVisitorDetails.Size = new System.Drawing.Size(131, 55);
            this.EditVisitorDetails.TabIndex = 6;
            this.EditVisitorDetails.Text = "Edit Details";
            this.EditVisitorDetails.UseVisualStyleBackColor = true;
            this.EditVisitorDetails.Click += new System.EventHandler(this.EditVisitorDetails_Click);
            // 
            // AddVisitor
            // 
            this.AddVisitor.Location = new System.Drawing.Point(1243, 56);
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
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Visitor Log";
            // 
            // VisitorData
            // 
            this.VisitorData.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.VisitorData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VisitorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitorData.Location = new System.Drawing.Point(196, 132);
            this.VisitorData.Name = "VisitorData";
            this.VisitorData.RowHeadersWidth = 51;
            this.VisitorData.RowTemplate.Height = 24;
            this.VisitorData.Size = new System.Drawing.Size(1340, 461);
            this.VisitorData.TabIndex = 0;
            this.VisitorData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VisitorData_CellContentClick);
            // 
            // PendingRequestsGrid
            // 
            this.PendingRequestsGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.PendingRequestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingRequestsGrid.Location = new System.Drawing.Point(148, 125);
            this.PendingRequestsGrid.Name = "PendingRequestsGrid";
            this.PendingRequestsGrid.RowHeadersWidth = 51;
            this.PendingRequestsGrid.RowTemplate.Height = 24;
            this.PendingRequestsGrid.Size = new System.Drawing.Size(1466, 446);
            this.PendingRequestsGrid.TabIndex = 4;
            this.PendingRequestsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PendingRequestsGrid_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.PendingRequestsGrid);
            this.panel2.Location = new System.Drawing.Point(232, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1766, 657);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pending Visitor";
            // 
            // AdminDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TopPanel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminDash";
            this.Text = "Records Officer Dashboard";
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
            ((System.ComponentModel.ISupportInitialize)(this.PendingRequestsGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label RecordsPanel;
        private System.Windows.Forms.Button AddPrisoner;
        private System.Windows.Forms.Label LogOutButton;
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.Button EditDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView VisitorData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EditVisitorDetails;
        private System.Windows.Forms.Button AddVisitor;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView PendingRequestsGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}