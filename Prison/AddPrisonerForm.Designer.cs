namespace Prison
{
    partial class AddPrisonerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPrisonerForm));
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrisonerID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtCase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDetainedDate = new System.Windows.Forms.DateTimePicker();
            this.txtCellNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpSentenceStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpSentenceEnd = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ValidationError = new System.Windows.Forms.Label();
            this.ValidationErrorTimer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.Status = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(249, 180);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(307, 44);
            this.txtFullName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add a New Prisoner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prisoner ID";
            // 
            // txtPrisonerID
            // 
            this.txtPrisonerID.Location = new System.Drawing.Point(249, 288);
            this.txtPrisonerID.Multiline = true;
            this.txtPrisonerID.Name = "txtPrisonerID";
            this.txtPrisonerID.Size = new System.Drawing.Size(307, 41);
            this.txtPrisonerID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(249, 401);
            this.txtAge.Multiline = true;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(307, 38);
            this.txtAge.TabIndex = 6;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(722, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 76);
            this.label5.TabIndex = 7;
            this.label5.Text = "Contact \r\nNumber";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(882, 152);
            this.txtContactNumber.Multiline = true;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(307, 44);
            this.txtContactNumber.TabIndex = 8;
            // 
            // txtCase
            // 
            this.txtCase.Location = new System.Drawing.Point(886, 335);
            this.txtCase.Multiline = true;
            this.txtCase.Name = "txtCase";
            this.txtCase.Size = new System.Drawing.Size(307, 44);
            this.txtCase.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(653, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 38);
            this.label6.TabIndex = 9;
            this.label6.Text = "Prisoner Case";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(647, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 38);
            this.label7.TabIndex = 11;
            this.label7.Text = "Detained Date";
            // 
            // dtpDetainedDate
            // 
            this.dtpDetainedDate.Location = new System.Drawing.Point(886, 434);
            this.dtpDetainedDate.Name = "dtpDetainedDate";
            this.dtpDetainedDate.Size = new System.Drawing.Size(307, 22);
            this.dtpDetainedDate.TabIndex = 13;
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.Location = new System.Drawing.Point(886, 249);
            this.txtCellNumber.Multiline = true;
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(307, 48);
            this.txtCellNumber.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(675, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 38);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cell Number";
            // 
            // dtpSentenceStart
            // 
            this.dtpSentenceStart.Location = new System.Drawing.Point(886, 539);
            this.dtpSentenceStart.Name = "dtpSentenceStart";
            this.dtpSentenceStart.Size = new System.Drawing.Size(307, 22);
            this.dtpSentenceStart.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(704, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 76);
            this.label9.TabIndex = 16;
            this.label9.Text = "Sentence\r\nStart Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpSentenceEnd
            // 
            this.dtpSentenceEnd.Location = new System.Drawing.Point(886, 658);
            this.dtpSentenceEnd.Name = "dtpSentenceEnd";
            this.dtpSentenceEnd.Size = new System.Drawing.Size(307, 22);
            this.dtpSentenceEnd.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(704, 618);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 76);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sentence\r\n End Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(103, 498);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 38);
            this.label11.TabIndex = 20;
            this.label11.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(249, 512);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(307, 24);
            this.cmbGender.TabIndex = 21;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(531, 733);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(189, 60);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ValidationError
            // 
            this.ValidationError.AutoSize = true;
            this.ValidationError.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationError.ForeColor = System.Drawing.Color.IndianRed;
            this.ValidationError.Location = new System.Drawing.Point(75, 106);
            this.ValidationError.Name = "ValidationError";
            this.ValidationError.Size = new System.Drawing.Size(108, 25);
            this.ValidationError.TabIndex = 23;
            this.ValidationError.Text = "Validation";
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Location = new System.Drawing.Point(249, 590);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(307, 24);
            this.Status.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(115, 577);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 38);
            this.label12.TabIndex = 25;
            this.label12.Text = "Status";
            // 
            // AddPrisonerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1307, 885);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.ValidationError);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpSentenceEnd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpSentenceStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCellNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDetainedDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrisonerID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFullName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPrisonerForm";
            this.Text = "AddPrisonerForm";
            this.Load += new System.EventHandler(this.AddPrisonerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrisonerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtCase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDetainedDate;
        private System.Windows.Forms.TextBox txtCellNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpSentenceStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpSentenceEnd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label ValidationError;
        private System.Windows.Forms.Timer ValidationErrorTimer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Label label12;
    }
}