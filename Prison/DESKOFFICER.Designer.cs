namespace Prison
{
    partial class DESKOFFICER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESKOFFICER));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.AddVisitor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitorData = new System.Windows.Forms.DataGridView();
            this.VisitorDataRC = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorDataRC)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Tomato;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 897);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Desk Officer";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1515, 388);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
            // 
            // AddVisitor
            // 
            this.AddVisitor.Location = new System.Drawing.Point(1537, 256);
            this.AddVisitor.Name = "AddVisitor";
            this.AddVisitor.Size = new System.Drawing.Size(131, 55);
            this.AddVisitor.TabIndex = 10;
            this.AddVisitor.Text = "Add Visitor";
            this.AddVisitor.UseVisualStyleBackColor = true;
            this.AddVisitor.Click += new System.EventHandler(this.AddVisitor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(590, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Visitor Log";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // VisitorData
            // 
            this.VisitorData.BackgroundColor = System.Drawing.Color.Tomato;
            this.VisitorData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VisitorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitorData.Location = new System.Drawing.Point(597, 345);
            this.VisitorData.Name = "VisitorData";
            this.VisitorData.RowHeadersWidth = 51;
            this.VisitorData.RowTemplate.Height = 24;
            this.VisitorData.Size = new System.Drawing.Size(1072, 494);
            this.VisitorData.TabIndex = 8;
            this.VisitorData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VisitorData_CellContentClick);
            // 
            // VisitorDataRC
            // 
            this.VisitorDataRC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VisitorDataRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitorDataRC.Location = new System.Drawing.Point(674, 441);
            this.VisitorDataRC.Name = "VisitorDataRC";
            this.VisitorDataRC.RowHeadersWidth = 51;
            this.VisitorDataRC.RowTemplate.Height = 24;
            this.VisitorDataRC.Size = new System.Drawing.Size(916, 302);
            this.VisitorDataRC.TabIndex = 13;
            this.VisitorDataRC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VisitorDataRC_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1526, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 61);
            this.button1.TabIndex = 15;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DESKOFFICER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 897);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VisitorDataRC);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.AddVisitor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VisitorData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DESKOFFICER";
            this.Text = "Desk Officer Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RecordsOfficer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VisitorData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorDataRC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button AddVisitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView VisitorData;
        private System.Windows.Forms.DataGridView VisitorDataRC;
        private System.Windows.Forms.Button button1;
    }
}