namespace Prison
{
    partial class AddVisitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVisitor));
            this.label1 = new System.Windows.Forms.Label();
            this.FullName = new System.Windows.Forms.TextBox();
            this.ContactNumber = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.cmbRelationship = new System.Windows.Forms.ComboBox();
            this.VisitDate = new System.Windows.Forms.DateTimePicker();
            this.VisitTimeIn = new System.Windows.Forms.DateTimePicker();
            this.VisitPurpose = new System.Windows.Forms.TextBox();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.cmbPrisoner = new System.Windows.Forms.ComboBox();
            this.ValidationError = new System.Windows.Forms.Label();
            this.ValidationErrorTimer = new System.Windows.Forms.Timer(this.components);
            this.VisitTimeOut = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Visitor";
            // 
            // FullName
            // 
            this.FullName.Location = new System.Drawing.Point(178, 101);
            this.FullName.Multiline = true;
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(233, 56);
            this.FullName.TabIndex = 0;
            // 
            // ContactNumber
            // 
            this.ContactNumber.AcceptsReturn = true;
            this.ContactNumber.Location = new System.Drawing.Point(178, 185);
            this.ContactNumber.Multiline = true;
            this.ContactNumber.Name = "ContactNumber";
            this.ContactNumber.Size = new System.Drawing.Size(233, 56);
            this.ContactNumber.TabIndex = 2;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(178, 387);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(613, 56);
            this.Address.TabIndex = 4;
            // 
            // cmbRelationship
            // 
            this.cmbRelationship.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRelationship.FormattingEnabled = true;
            this.cmbRelationship.Items.AddRange(new object[] {
            "Family",
            "Friend",
            "Church"});
            this.cmbRelationship.Location = new System.Drawing.Point(600, 168);
            this.cmbRelationship.Name = "cmbRelationship";
            this.cmbRelationship.Size = new System.Drawing.Size(191, 24);
            this.cmbRelationship.TabIndex = 6;
            this.cmbRelationship.Text = "Relationship";
            // 
            // VisitDate
            // 
            this.VisitDate.Location = new System.Drawing.Point(600, 236);
            this.VisitDate.Name = "VisitDate";
            this.VisitDate.Size = new System.Drawing.Size(191, 22);
            this.VisitDate.TabIndex = 7;
            // 
            // VisitTimeIn
            // 
            this.VisitTimeIn.Location = new System.Drawing.Point(600, 289);
            this.VisitTimeIn.Name = "VisitTimeIn";
            this.VisitTimeIn.Size = new System.Drawing.Size(191, 22);
            this.VisitTimeIn.TabIndex = 8;
            // 
            // VisitPurpose
            // 
            this.VisitPurpose.Location = new System.Drawing.Point(178, 273);
            this.VisitPurpose.Multiline = true;
            this.VisitPurpose.Name = "VisitPurpose";
            this.VisitPurpose.Size = new System.Drawing.Size(233, 56);
            this.VisitPurpose.TabIndex = 9;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 58);
            this.label3.TabIndex = 11;
            this.label3.Text = "Contact \r\nNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 58);
            this.label4.TabIndex = 12;
            this.label4.Text = "Visit\r\nPurpose\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(438, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Prisoner";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(438, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 29);
            this.label7.TabIndex = 15;
            this.label7.Text = "Relationship";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(519, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 29);
            this.label8.TabIndex = 16;
            this.label8.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Book", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(519, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "Time";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(507, 460);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(284, 41);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cmbPrisoner
            // 
            this.cmbPrisoner.FormattingEnabled = true;
            this.cmbPrisoner.Location = new System.Drawing.Point(600, 106);
            this.cmbPrisoner.Name = "cmbPrisoner";
            this.cmbPrisoner.Size = new System.Drawing.Size(191, 24);
            this.cmbPrisoner.TabIndex = 20;
            this.cmbPrisoner.Text = "Select Prisoner";
            // 
            // ValidationError
            // 
            this.ValidationError.AutoSize = true;
            this.ValidationError.ForeColor = System.Drawing.Color.IndianRed;
            this.ValidationError.Location = new System.Drawing.Point(473, 55);
            this.ValidationError.Name = "ValidationError";
            this.ValidationError.Size = new System.Drawing.Size(67, 16);
            this.ValidationError.TabIndex = 21;
            this.ValidationError.Text = "Validation";
            // 
            // VisitTimeOut
            // 
            this.VisitTimeOut.Location = new System.Drawing.Point(600, 326);
            this.VisitTimeOut.Name = "VisitTimeOut";
            this.VisitTimeOut.Size = new System.Drawing.Size(191, 22);
            this.VisitTimeOut.TabIndex = 22;
            // 
            // AddVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 536);
            this.Controls.Add(this.VisitTimeOut);
            this.Controls.Add(this.ValidationError);
            this.Controls.Add(this.cmbPrisoner);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VisitPurpose);
            this.Controls.Add(this.VisitTimeIn);
            this.Controls.Add(this.VisitDate);
            this.Controls.Add(this.cmbRelationship);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.ContactNumber);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddVisitor";
            this.Text = "Add Visitor";
            this.Load += new System.EventHandler(this.AddVisitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FullName;
        private System.Windows.Forms.TextBox ContactNumber;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.ComboBox cmbRelationship;
        private System.Windows.Forms.DateTimePicker VisitDate;
        private System.Windows.Forms.DateTimePicker VisitTimeIn;
        private System.Windows.Forms.TextBox VisitPurpose;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox cmbPrisoner;
        private System.Windows.Forms.Label ValidationError;
        private System.Windows.Forms.Timer ValidationErrorTimer;
        private System.Windows.Forms.DateTimePicker VisitTimeOut;
    }
}