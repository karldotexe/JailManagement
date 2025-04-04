namespace Prison
{
    partial class Warden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warden));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.PendingPrisoners = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.PrisonerRecords = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PendingPrisoners)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrisonerRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Tomato;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 1623);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(444, 56);
            this.label4.TabIndex = 11;
            this.label4.Text = "Welcome, Warden";
            // 
            // PendingPrisoners
            // 
            this.PendingPrisoners.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PendingPrisoners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingPrisoners.Location = new System.Drawing.Point(74, 94);
            this.PendingPrisoners.Name = "PendingPrisoners";
            this.PendingPrisoners.RowHeadersWidth = 51;
            this.PendingPrisoners.RowTemplate.Height = 24;
            this.PendingPrisoners.Size = new System.Drawing.Size(1377, 461);
            this.PendingPrisoners.TabIndex = 12;
            this.PendingPrisoners.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PendingPrisoners_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PendingPrisoners);
            this.panel1.Location = new System.Drawing.Point(371, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1531, 620);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1704, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 34);
            this.label1.TabIndex = 14;
            this.label1.Text = "Log Out";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(67, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 40);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pending Prisoners";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.PrisonerRecords);
            this.panel2.Location = new System.Drawing.Point(371, 880);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1531, 670);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(67, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 40);
            this.label3.TabIndex = 15;
            this.label3.Text = "Prisoner List";
            // 
            // PrisonerRecords
            // 
            this.PrisonerRecords.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PrisonerRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrisonerRecords.Location = new System.Drawing.Point(74, 94);
            this.PrisonerRecords.Name = "PrisonerRecords";
            this.PrisonerRecords.RowHeadersWidth = 51;
            this.PrisonerRecords.RowTemplate.Height = 24;
            this.PrisonerRecords.Size = new System.Drawing.Size(1377, 461);
            this.PrisonerRecords.TabIndex = 12;
            // 
            // Warden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Warden";
            this.Text = "Warden";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Warden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PendingPrisoners)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrisonerRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView PendingPrisoners;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView PrisonerRecords;
    }
}