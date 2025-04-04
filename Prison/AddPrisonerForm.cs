using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;

namespace Prison
{
    public partial class AddPrisonerForm : Form //THIS IS THE ADD VISITOR FORM FOR RECORDS OFFICER
    {
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";

        public AddPrisonerForm()
        {
            InitializeComponent();


            SetupValidations();

            this.FormBorderStyle = FormBorderStyle.None;


            // Prevent typing in gender dropdown
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

            // Prevent typing in DatePickers
            dtpDetainedDate.Format = DateTimePickerFormat.Custom;
            dtpDetainedDate.CustomFormat = "yyyy-MM-dd"; // Ensures proper format
            dtpDetainedDate.ShowUpDown = false; // No manual typing

            dtpSentenceStart.Format = DateTimePickerFormat.Custom;
            dtpSentenceStart.CustomFormat = "yyyy-MM-dd";
            dtpSentenceStart.ShowUpDown = false;

            dtpSentenceEnd.Format = DateTimePickerFormat.Custom;
            dtpSentenceEnd.CustomFormat = "yyyy-MM-dd";
            dtpSentenceEnd.ShowUpDown = false;

            dtpDetainedDate.KeyPress += PreventDateTyping;
            dtpSentenceStart.KeyPress += PreventDateTyping;
            dtpSentenceEnd.KeyPress += PreventDateTyping;

        }

        private void SetupValidations()
        {
            // Full Name validation - Prevent numbers
            txtFullName.KeyPress += (s, e) => {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Numbers are not allowed in names");
                }
            };

            // Prisoner ID validation - Only numbers allowed
            txtPrisonerID.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed in Prisoner ID");
                }
            };

            // Age validation - Only numbers allowed, must be between 18-70
            txtAge.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed for age");
                }
            };

            txtAge.TextChanged += (s, e) => {
                // Allow age to be typed freely, but check when input is finished
                if (int.TryParse(txtAge.Text, out int age))
                {
                    if (age < 18)
                    {
                        ShowValidationError("Age cannot be less than 18");
                        txtAge.SelectionStart = txtAge.Text.Length; // Keep the cursor at the end
                    }
                    else if (age > 70)
                    {
                        ShowValidationError("Age cannot be greater than 70");
                        txtAge.SelectionStart = txtAge.Text.Length; // Keep the cursor at the end
                    }
                }
            };

            // Contact number validation - Only 11 digits allowed
            txtContactNumber.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed in Contact Number");
                }
            };

            // Cell number validation - Only numbers allowed
            txtCellNumber.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed in Cell Number");
                }
            };

            txtContactNumber.TextChanged += (s, e) => {
                if (txtContactNumber.Text.Length > 11)
                {
                    ShowValidationError("Contact Number must be exactly 11 digits");
                    txtContactNumber.Text = txtContactNumber.Text.Substring(0, 11);
                    txtContactNumber.SelectionStart = txtContactNumber.Text.Length;
                }
            };

            // Prisoner ID validation - Only numbers allowed, max 20 digits
            txtPrisonerID.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed in Prisoner ID");
                }
            };

            txtPrisonerID.TextChanged += (s, e) => {
                if (txtPrisonerID.Text.Length > 20)
                {
                    ShowValidationError("Prisoner ID must be exactly 20 digits");
                    txtPrisonerID.Text = txtPrisonerID.Text.Substring(0, 20); // Trim excess characters
                    txtPrisonerID.SelectionStart = txtPrisonerID.Text.Length; // Keep cursor at the end
                }
            };
        }






        private void PreventDateTyping(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Prevents user from typing inside the DateTimePicker
        }


        private void ShowValidationError(string message)
        {
            ValidationError.Text = message;
            ValidationError.Visible = true;
            ValidationErrorTimer.Start();
        }

        private void ValidationErrorTimer_Tick(object sender, EventArgs e)
        {
            ValidationError.Visible = false;
            ValidationErrorTimer.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

   

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO prisoners 
                            (full_name, id_number, age, contact_number, prisoner_case, 
                             detained_date, cell_number, sentence_start, sentence_end, gender, status) 
                            VALUES 
                            (@name, @id, @age, @contact, @case, @detained, @cell, @start, @end, @gender, @status)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", txtPrisonerID.Text.Trim());
                    cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                    cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@case", txtCase.Text.Trim());
                    cmd.Parameters.AddWithValue("@detained", dtpDetainedDate.Value);
                    cmd.Parameters.AddWithValue("@cell", txtCellNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@start", dtpSentenceStart.Value);
                    cmd.Parameters.AddWithValue("@end", dtpSentenceEnd.Value);
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@status", Status.SelectedItem.ToString()); // Add the status value

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prisoner record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh records in AdminDash
                    AdminDash adminDash = Application.OpenForms.OfType<AdminDash>().FirstOrDefault();
                    adminDash?.LoadPrisonerRecords();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Information incomplete.");
            }

            this.Close();
        }

        private void AddPrisonerForm_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with the status options
            Status.Items.Clear();
            Status.Items.Add("Standard Detention");
            Status.Items.Add("Pending Trial");
            Status.Items.Add("Awaiting Bail");
            Status.Items.Add("Non-Violent");
            Status.Items.Add("Remanded");
            Status.Items.Add("On Probation");
            Status.Items.Add("Work-Release");
            Status.Items.Add("Low-Risk ");
            Status.Items.Add("Moderate-Risk ");
            Status.Items.Add("High-Risk ");

            // Set a default status
            Status.SelectedIndex = 0;  // Default to "Standard Detention"
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

    }
}