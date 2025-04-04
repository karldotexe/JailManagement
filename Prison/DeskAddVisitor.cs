using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace Prison
{
    public partial class DeskAddVisitor : Form
    {
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";


        public DeskAddVisitor()
        {
            InitializeComponent();
            SetupValidations();
        }

        private DESKOFFICER parentForm;  // Declare a reference to AdminDash

        public DeskAddVisitor(DESKOFFICER parent)  // Constructor with AdminDash parameter
        {
            InitializeComponent();
            this.parentForm = parent;  // Assign the parent form to the reference
        }


        public void SetCapturedImage(Bitmap image)
        {
            if (image != null)
            {
                SelectedPictureBox1.Image = image;
                SelectedPictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ensure the image is displayed correctly
            }
            else
            {
                MessageBox.Show("No image received!");
            }
        }

        private void ShowImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                SelectedPictureBox1.Image = Image.FromStream(ms);
            }
        }


        private VisitorID VisitorID; // Declare parent form reference

        public DeskAddVisitor(VisitorID parent)
        {
            InitializeComponent();
            this.VisitorID = parent; // Assign parent form reference
            SetupValidations();
        }


      
       


        // When the form loads, populate the ComboBox with prisoner names.
        private void DeskAddVisitor_Load(object sender, EventArgs e)
        {
            LoadPrisonerNames();  // Populate the ComboBox when the form loads.

            // ✅ Set VisitTimeIn to Time Only
            VisitTimeIn.Format = DateTimePickerFormat.Custom;
            VisitTimeIn.CustomFormat = "HH:mm";  // Only show time (24-hour format)
            VisitTimeIn.ShowUpDown = true;  // No calendar view, only up-down time picker

            // ✅ Set VisitTimeOut to Time Only
            VisitTimeOut.Format = DateTimePickerFormat.Custom;
            VisitTimeOut.CustomFormat = "HH:mm";  // Only show time (24-hour format)
            VisitTimeOut.ShowUpDown = true;  // No calendar view, only up-down time picker
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
            // Full Name validation - Prevent numbers, allow spaces and letters
            FullName.KeyPress += (s, e) =>
            {
                // Only letters, spaces, and backspace are allowed
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // Prevent invalid input
                    ShowValidationError("Only letters and spaces are allowed in Full Name");
                }
            };

            // Contact number validation - Only numbers allowed, must be exactly 11 digits
            ContactNumber.KeyPress += (s, e) =>
            {
                // Allow digits and backspace, but not anything else
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Prevent invalid input
                    ShowValidationError("Only numbers are allowed in Contact Number");
                }
            };

            ContactNumber.TextChanged += (s, e) =>
            {
                // Limit the input to 11 digits
                if (ContactNumber.Text.Length > 11)
                {
                    ShowValidationError("Contact Number must be exactly 11 digits");
                    ContactNumber.Text = ContactNumber.Text.Substring(0, 11);  // Limit to 11 digits
                    ContactNumber.SelectionStart = ContactNumber.Text.Length; // Keep cursor at the end
                }
            };

            // Optional: PreviewKeyDown (alternative) for catching all key events
            FullName.PreviewKeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Back || (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || e.KeyCode == Keys.Space)
                {
                    // Allow backspace, letters, and space
                }
                else
                {
                    e.IsInputKey = false;  // Stop the invalid keys
                    ShowValidationError("Only letters and spaces are allowed in Full Name");
                }
            };

            ContactNumber.PreviewKeyDown += (s, e) =>
            {
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || e.KeyCode == Keys.Back)
                {
                    // Allow digits and backspace
                }
                else
                {
                    e.IsInputKey = false;  // Stop the invalid keys
                    ShowValidationError("Only numbers are allowed in Contact Number");
                }
            };
        }


        // Display the validation error message
        private void ShowValidationError(string message)
        {
            // Debugging the validation issue
            Console.WriteLine(message);  // Check if validation messages are being called correctly

            ValidationError.Text = message;  // Show error message
            ValidationError.Visible = true;   // Make the error label visible
            ValidationErrorDesk.Start();     // Start the timer to hide the error
        }

        // Timer to hide validation error message after a delay
        private void ValidationErrorTimer_Tick(object sender, EventArgs e)
        {
            ValidationError.Visible = false;  // Hide error after the timer ticks
            ValidationErrorDesk.Stop();      // Stop the timer
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
        }




        private string selectedFilePath = ""; // Store the selected file path




        private void VisitTimeIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void File_Click(object sender, EventArgs e)
        {
           
        }




        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
            {
                MessageBox.Show("Image is null, cannot save.");
                return null;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  // Make sure the format is supported
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting image to byte array: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName.Text) ||
                  string.IsNullOrWhiteSpace(ContactNumber.Text) ||
                  string.IsNullOrWhiteSpace(VisitPurpose.Text) ||
                  string.IsNullOrWhiteSpace(Address.Text) ||
                  cmbPrisoner.SelectedValue == null || cmbPrisoner.SelectedValue.ToString() == "0" ||
                  string.IsNullOrWhiteSpace(cmbRelationship.Text) ||
                  SelectedPictureBox1.Image == null)
            {
                ShowValidationError("Please fill in all fields and select an image.");
                return;
            }

            try
            {
                byte[] imageBytes = ConvertImageToByteArray(SelectedPictureBox1.Image);
                if (imageBytes == null)
                {
                    MessageBox.Show("The image could not be converted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO pending_visitor_requests 
                                    (full_name, contact_number, visit_purpose, address, prisoner_id, 
                                     relationship_to_prisoner, visit_date, visit_time_in, visit_time_out, visitor_id_image)
                                    VALUES 
                                    (@name, @contact, @purpose, @address, @prisonerId, 
                                     @relationship, @visitDate, @visitTimeIn, @visitTimeOut, @image)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", FullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", ContactNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@purpose", VisitPurpose.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", Address.Text.Trim());
                        cmd.Parameters.AddWithValue("@prisonerId", cmbPrisoner.SelectedValue);
                        cmd.Parameters.AddWithValue("@relationship", cmbRelationship.Text.Trim());
                        cmd.Parameters.AddWithValue("@visitDate", VisitDate.Value.Date);
                        cmd.Parameters.AddWithValue("@visitTimeIn", VisitTimeIn.Value.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@visitTimeOut", VisitTimeOut.Value.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@image", imageBytes);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Visitor request submitted successfully and is pending approval.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Just close the form for now — no admin update necessary
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit visitor request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeskAddVisitor_Load_1(object sender, EventArgs e)
        {
            LoadPrisonerNames();  // Populate the ComboBox when the form loads.

            // ✅ Set VisitTimeIn to Time Only
            VisitTimeIn.Format = DateTimePickerFormat.Custom;
            VisitTimeIn.CustomFormat = "HH:mm";  // Only show time (24-hour format)
            VisitTimeIn.ShowUpDown = true;  // No calendar view, only up-down time picker

            // ✅ Set VisitTimeOut to Time Only
            VisitTimeOut.Format = DateTimePickerFormat.Custom;
            VisitTimeOut.CustomFormat = "HH:mm";  // Only show time (24-hour format)
            VisitTimeOut.ShowUpDown = true;  // No calendar view, only up-down time picker
        }

      

        private void File_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath)) // If no file is selected, open file dialog
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select an Image";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFilePath = openFileDialog.FileName;
                        try
                        {
                            SelectedPictureBox1.Image = new Bitmap(selectedFilePath); // Try loading the image
                            SelectedPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            File.Text = "Preview Image"; // Change button text after selection
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else // If file is already selected, preview it
            {
                try
                {
                    System.Diagnostics.Process.Start(selectedFilePath); // Open the image with default viewer
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidID_Click(object sender, EventArgs e)
        {
            if (cmbPrisoner.SelectedValue == null || cmbPrisoner.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select a prisoner first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedPrisonerId = Convert.ToInt32(cmbPrisoner.SelectedValue);
            VisitorID visitorForm = new VisitorID(this, selectedPrisonerId); // Pass prisoner ID
            visitorForm.Show();
        }
    }
}

