using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Prison
{
    public partial class AddVisitor : Form
    {
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";  // Update with your connection string

        public AddVisitor()
        {
            InitializeComponent();

            SetupValidations();
        }

        // When the form loads, populate the ComboBox with prisoner names.
        private void AddVisitor_Load(object sender, EventArgs e)
        {
            LoadPrisonerNames();  // Populate the ComboBox when the form loads.

            // Ensure VisitTime DateTimePicker shows only the time
            VisitTimeIn.Format = DateTimePickerFormat.Custom;
            VisitTimeIn.CustomFormat = "HH:mm";  // Only show time (24-hour format)
            VisitTimeIn.ShowUpDown = true;  // No calendar view, only up-down time picker
        }

        // Populate the ComboBox with prisoner names from the database, sorted alphabetically
        private void LoadPrisonerNames()
        {
            string query = "SELECT id, full_name FROM prisoners ORDER BY full_name ASC";  // Query to fetch prisoner names sorted alphabetically

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<int, string> prisonerList = new Dictionary<int, string>();
                prisonerList.Add(0, "Select Prisoner");  // Default option

                while (reader.Read())
                {
                    prisonerList.Add(Convert.ToInt32(reader["id"]), reader["full_name"].ToString());  // Add prisoner ID and name
                }

                cmbPrisoner.DataSource = new BindingSource(prisonerList, null);
                cmbPrisoner.DisplayMember = "Value";  // Show name in ComboBox
                cmbPrisoner.ValueMember = "Key";  // Store ID as Value
                cmbPrisoner.DropDownStyle = ComboBoxStyle.DropDownList;  // Disable text typing, only selection
            }
        }

        // Setup validations for the form
        private void SetupValidations()
        {
            // Full Name validation - Prevent numbers
            FullName.KeyPress += (s, e) => {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Numbers are not allowed in Full Name");
                }
            };

            // Contact number validation - Only numbers allowed, must be exactly 11 digits
            ContactNumber.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    ShowValidationError("Only numbers are allowed in Contact Number");
                }
            };

            ContactNumber.TextChanged += (s, e) => {
                if (ContactNumber.Text.Length > 11)
                {
                    ShowValidationError("Contact Number must be exactly 11 digits");
                    ContactNumber.Text = ContactNumber.Text.Substring(0, 11);
                    ContactNumber.SelectionStart = ContactNumber.Text.Length; // Keep cursor at the end
                }
            };
        }

        // Display the validation error message
        private void ShowValidationError(string message)
        {
            ValidationError.Text = message;
            ValidationError.Visible = true;
            ValidationErrorTimer.Start();
        }

        // Timer to hide validation error message after a delay
        private void ValidationErrorTimer_Tick(object sender, EventArgs e)
        {
            ValidationError.Visible = false;
            ValidationErrorTimer.Stop();
        }

        // Optional: Handle the event when the user selects a prisoner from the ComboBox.
        private void cmbPrisoner_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPrisonerId = Convert.ToInt32(cmbPrisoner.SelectedValue);
            // You can use this ID to handle further logic if needed.
        }

        // Save the visitor information to the database
        private void btnSave_Click(object sender, EventArgs e)
        {
         
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate that required fields are not empty
            if (string.IsNullOrWhiteSpace(FullName.Text) ||
                string.IsNullOrWhiteSpace(ContactNumber.Text) ||
                string.IsNullOrWhiteSpace(VisitPurpose.Text) ||
                string.IsNullOrWhiteSpace(Address.Text) ||
                cmbPrisoner.SelectedValue == null || cmbPrisoner.SelectedValue.ToString() == "0" ||
                string.IsNullOrWhiteSpace(cmbRelationship.Text))
            {
                // Show error if any required field is missing
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Exit the method if validation fails
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO visitors 
                                (full_name, contact_number, visit_purpose, address, prisoner_id, 
                                 relationship_to_prisoner, visit_date, visit_time_in, visit_time_out)
                             VALUES 
                                (@name, @contact, @purpose, @address, @prisonerId, 
                                 @relationship, @visitDate, @visitTimeIn, @visitTimeOut)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", FullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", ContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@purpose", VisitPurpose.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", Address.Text.Trim());
                    cmd.Parameters.AddWithValue("@prisonerId", cmbPrisoner.SelectedValue);
                    cmd.Parameters.AddWithValue("@relationship", cmbRelationship.Text.Trim());
                    cmd.Parameters.AddWithValue("@visitDate", VisitDate.Value.Date);
                    cmd.Parameters.AddWithValue("@visitTimeIn", VisitTimeIn.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@visitTimeOut", VisitTimeOut.Value.TimeOfDay);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Visitor record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close(); // Close the form after successful addition
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save visitor information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

