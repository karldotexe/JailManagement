using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Required for MySQL
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Prison
{
    public partial class AdminDash : Form
    {
        // Database connection string (Change prison_management to your actual database name)
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";
        private PictureBox previewPictureBox = new PictureBox();
        public AdminDash()
        {
            InitializeComponent();

            // Set up the preview PictureBox
            previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ensure proper image zooming
            previewPictureBox.Visible = false;  // Initially hidden
            previewPictureBox.BackColor = Color.Black;  // Black background for immersive preview
            previewPictureBox.Width = Screen.PrimaryScreen.Bounds.Width / 2;  // Set width to half the screen width
            previewPictureBox.Height = Screen.PrimaryScreen.Bounds.Height / 2;  // Set height to half the screen height
            previewPictureBox.Left = (Screen.PrimaryScreen.Bounds.Width - previewPictureBox.Width) / 2; // Center horizontally
            previewPictureBox.Top = (Screen.PrimaryScreen.Bounds.Height - previewPictureBox.Height) / 2; // Center vertically

            // Add close button on top of the image
            closeButton.Text = "X";
            closeButton.BackColor = Color.Red;
            closeButton.ForeColor = Color.White;
            closeButton.Size = new Size(40, 40);
            closeButton.Location = new Point(previewPictureBox.Width - 50, 10);  // Positioned at the top-right corner
            closeButton.Click += CloseButton_Click;  // Close the preview when clicked
            closeButton.Visible = false;  // Hide the close button initially
            this.Controls.Add(closeButton);  // Add close button on top of the picture box

            previewPictureBox.Click += previewPictureBox_Click;  // Close the preview when clicked
            this.Controls.Add(previewPictureBox);  // Add it to the form


            dataGridViewRecords.CellEndEdit += DataGridViewRecords_CellEndEdit;
            VisitorData.CellContentClick += VisitorData_CellContentClick;
            LoadVisitorData();
            LoadPendingVisitorRequests();

            // Make DataGridView read-only when the form starts

            dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Prevent individual cell selection
            dataGridViewRecords.AllowUserToAddRows = false; // Disable the extra row

            // Set up the sticky sidebar
            SidePanel.Dock = DockStyle.Left;
            SidePanel.BringToFront();
            VisitorData.ReadOnly = true;



            dataGridViewRecords.CellEndEdit += DataGridViewRecords_CellEndEdit;
           
            dataGridViewRecords.EditingControlShowing += dataGridViewRecords_EditingControlShowing;
            dataGridViewRecords.CellClick += dataGridViewRecords_CellClick;
            dataGridViewRecords.CellEnter += dataGridViewRecords_CellEnter;


        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            previewPictureBox.Visible = false;  // Hide the image
            closeButton.Visible = false;  // Hide the close button
        }

        public void LoadVisitorData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // ✅ Fetch prisoner full_name instead of prisoner_id
                string query = @"
                SELECT v.id, v.full_name as 'Full Name', v.contact_number as 'Contact', v.visit_purpose as 'Visit Purpose', v.address as 'Address',
                       p.full_name AS 'Prisoner Name', v.relationship_to_prisoner AS 'Relationship', v.visit_date as Date, 
                       v.visit_time_in as 'Time In' , v.visit_time_out as 'Time Out', v.visitor_id_image 
                FROM visitors v
                JOIN prisoners p ON v.prisoner_id = p.id ORDER BY v.id DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

 


                    // Remove the 'visitor_id_image' column if it exists before setting the DataSource
                    if (dt.Columns.Contains("visitor_id_image"))
                    {
                        dt.Columns.Remove("visitor_id_image");
                    }

                    // Clear previous columns to avoid duplication
                    VisitorData.Columns.Clear();

                    // Set the DataSource for the DataGridView
                    VisitorData.DataSource = dt;

                    // Hide the 'id' column
                    if (VisitorData.Columns.Contains("id"))
                    {
                        VisitorData.Columns["id"].Visible = false;
                    }

                    // Rename prisoner_name column header
                    if (VisitorData.Columns.Contains("prisoner_name"))
                    {
                        VisitorData.Columns["prisoner_name"].HeaderText = "Prisoner Name";
                    }

                    // Format the 'Date' column to display as 'March 20, 2025'
                    if (VisitorData.Columns.Contains("Date"))
                    {
                        VisitorData.Columns["Date"].DefaultCellStyle.Format = "MMMM dd, yyyy"; // Date format
                    }

                    // Remove row headers (extra first column)
                    VisitorData.RowHeadersVisible = false;

                    // Add a button column for image preview
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                    {
                        Name = "PreviewImageButton",
                        HeaderText = "Valid ID",
                        Text = "View", // Button text
                        UseColumnTextForButtonValue = true, // Use the button text
                        Width = 100
                    };

                    VisitorData.Columns.Add(buttonColumn);

                    // Prevent the addition of extra rows (blank row at the bottom)
                    VisitorData.AllowUserToAddRows = false;
                    VisitorData.Refresh();
                }
            }
        }




       


        // Handle the button click event for the "Preview" button
        private void VisitorData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            VisitorData.BeginEdit(true);
            // Check if the clicked cell is in the PreviewImageButton column
            if (e.ColumnIndex == VisitorData.Columns["PreviewImageButton"].Index && e.RowIndex >= 0)
            {
                // Fetch visitor_id_image for the selected visitor (e.g., from the database)
                int visitorId = (int)VisitorData.Rows[e.RowIndex].Cells["id"].Value;

                byte[] imageData = GetImageDataByVisitorId(visitorId);

                if (imageData != null)
                {
                    ShowImagePreview(imageData);  // Implement ShowImage to display the image in a new form or picture box
                }
                else
                {
                    MessageBox.Show("No image available for this visitor.");
                }
            }
        }

        private byte[] GetImageDataByVisitorId(int visitorId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT visitor_id_image FROM visitors WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", visitorId);
                    object result = cmd.ExecuteScalar();
                    return result as byte[];
                }
            }

        }

        private byte[] GetVisitorImageById(int requestId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT visitor_id_image FROM pending_visitor_requests WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", requestId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (byte[])result;
                    }
                }
            }

            return null; // No image found
        }

        private void previewPictureBox_Click(object sender, EventArgs e)
        {
            // Close the preview when clicked
            previewPictureBox.Visible = false;
            closeButton.Visible = false;
        }


        // Method to display the image preview in a custom PictureBox (half screen size)
        // Method to display the image preview in a custom PictureBox
        private void ShowImagePreview(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                MessageBox.Show("No valid image available.");
                return;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image img = Image.FromStream(ms);

                    // Set image and sizing
                    previewPictureBox.Image = img;
                    previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // Set size (optional: adjust based on your design)
                    previewPictureBox.Size = new Size(400, 300); // Or any size that fits well

                    // ✅ Center the PictureBox on the form
                    int x = (this.ClientSize.Width - previewPictureBox.Width) / 2;
                    int y = (this.ClientSize.Height - previewPictureBox.Height) / 2;
                    previewPictureBox.Location = new Point(x, y);

                    // Show and bring to front
                    previewPictureBox.Visible = true;
                    previewPictureBox.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void VisitorManagement_Load(object sender, EventArgs e)
        {
            Timer refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Refresh every 5 seconds
            refreshTimer.Tick += (s, args) => LoadVisitorData();
            refreshTimer.Start();
        }



        // When displaying images in a DataGridView, handle cell formatting
        private void VisitorData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (VisitorData.Columns[e.ColumnIndex].Name == "visitor_id_image" && e.Value != null && e.Value is byte[])
            {
                byte[] imageBytes = (byte[])e.Value;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    e.Value = Image.FromStream(ms);
                }
            }
        }

        




        private void dataGridViewRecords_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           

            if (dataGridViewRecords.CurrentCell.ColumnIndex == dataGridViewRecords.Columns["Gender"].Index)
            {
                // Prevent dropdown from appearing if Edit Mode is OFF
                if (EditDetails.Text != "Save Changes")
                {
                    e.Control.Visible = false; // Hide the dropdown
                    return;
                }

                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Prevent text input
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(new string[] { "Male", "Female", "Other" });
                }
            }
        }

        private void dataGridViewRecords_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Prevent editing unless Edit Mode is enabled
            if (EditDetails.Text != "Save Changes")
            {
                e.Cancel = true;
            }
        }


        //private void TxtBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewRecords.CurrentCell == null) return;

        //    string columnName = dataGridViewRecords.Columns[dataGridViewRecords.CurrentCell.ColumnIndex].HeaderText;
        //    TextBox txtBox = sender as TextBox;

        //    // Ensure "Age" is within the valid range (18-100)
        //    if (columnName == "Age" && int.TryParse(txtBox.Text, out int age))
        //    {
        //        if (age < 18 || age > 100)
        //        {
        //            txtBox.BackColor = Color.LightPink; // Invalid input feedback
        //        }
        //        else
        //        {
        //            txtBox.BackColor = Color.White; // Reset to normal
        //        }
        //    }
        //    // Ensure "Contact Number" is exactly 11 digits
        //    else if (columnName == "Contact Number")
        //    {
        //        if (txtBox.Text.Length != 11)
        //        {
        //            txtBox.BackColor = Color.LightPink; // Invalid input feedback
        //        }
        //        else
        //        {
        //            txtBox.BackColor = Color.White; // Reset to normal
        //        }
        //    }
        //}




        //private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (dataGridViewRecords.CurrentCell == null) return;

        //    string columnName = dataGridViewRecords.Columns[dataGridViewRecords.CurrentCell.ColumnIndex].HeaderText;
        //    TextBox txtBox = sender as TextBox;

        //    // Prevent numbers in "Full Name"
        //    if (columnName == "Full Name" && char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //    // Allow only numbers in "Prisoner ID"
        //    else if (columnName == "Prisoner ID" && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }
        //    // Limit the length of "Contact Number" to 11 digits
        //    else if (columnName == "Contact Number")
        //    {
        //        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //        {
        //            e.Handled = true;
        //        }
        //        else if (txtBox.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
        //        {
        //            e.Handled = true;
        //            // Optional: Visual cue here instead of a message box
        //            txtBox.BackColor = Color.LightPink; // Invalid input feedback
        //        }
        //    }
        //    // Ensure "Age" is a valid number between 1 and 122
        //}









        private void dataGridViewRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Ignore header clicks

            string columnName = dataGridViewRecords.Columns[e.ColumnIndex].HeaderText;

            // Prevent selection of restricted columns when not in edit mode
            if (EditDetails.Text != "Save Changes" &&
                (columnName == "Detained Date" || columnName == "Sentence Start" || columnName == "Sentence End" || columnName == "Gender"))
            {
                dataGridViewRecords.CurrentCell = null; // Deselect the cell
                return;
            }

            // If in edit mode, allow special controls
            if (EditDetails.Text == "Save Changes")
            {
                if (columnName == "Detained Date" || columnName == "Sentence Start" || columnName == "Sentence End")
                {
                    ShowDatePicker(e.RowIndex, e.ColumnIndex);
                }
                else if (columnName == "Gender")
                {
                    ShowGenderDropdown(e.RowIndex, e.ColumnIndex);
                }

                else if (columnName == "Status")  // Add condition for Status column
                {
                    ShowStatusDropdown(e.RowIndex, e.ColumnIndex); // Show dropdown for Status
                }
            }

        }

        private void ShowStatusDropdown(int rowIndex, int colIndex)
        {
            if (EditDetails.Text != "Save Changes") return; // Prevent showing dropdown if not in edit mode

            // Create a ComboBox for the Status dropdown with the provided status values
            ComboBox statusDropdown = new ComboBox();
            statusDropdown.Items.AddRange(new string[] {
                    "Standard Detention",
                    "Pending Trial",
                    "Awaiting Bail",
                    "Non-Violent",
                    "Remanded ",
                    "On Probation",
                    "Work-Release ",
                    "Low-Risk",
                    "Moderate-Risk"
                                                        });
            statusDropdown.DropDownStyle = ComboBoxStyle.DropDownList; // Prevents text input

            // Get the rectangle for the cell to position the ComboBox
            Rectangle cellRect = dataGridViewRecords.GetCellDisplayRectangle(colIndex, rowIndex, true);
            statusDropdown.Bounds = cellRect;
                
            // Set the current value of the cell as the selected item in the dropdown
            statusDropdown.SelectedItem = dataGridViewRecords.Rows[rowIndex].Cells[colIndex].Value;

            // When a value is selected, update the cell's value with the selected status
            statusDropdown.SelectedIndexChanged += (s, e) =>
            {
                dataGridViewRecords.Rows[rowIndex].Cells[colIndex].Value = statusDropdown.SelectedItem.ToString();
            };

            // Add the ComboBox to the DataGridView's control collection so it's displayed
            dataGridViewRecords.Controls.Add(statusDropdown);

            // Show the dropdown list automatically when the user clicks the cell
            statusDropdown.DroppedDown = true;
        }





        private void ShowDatePicker(int rowIndex, int columnIndex)
        {
            if (EditDetails.Text != "Save Changes") return; // Prevent selection if not in edit mode

            Rectangle cellRectangle = dataGridViewRecords.GetCellDisplayRectangle(columnIndex, rowIndex, true);

            DateTimePicker dtp = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Bounds = cellRectangle,
                Visible = true
            };

            if (dataGridViewRecords.Rows[rowIndex].Cells[columnIndex].Value != DBNull.Value)
            {
                dtp.Value = Convert.ToDateTime(dataGridViewRecords.Rows[rowIndex].Cells[columnIndex].Value);
            }

            dtp.CloseUp += (s, ev) => { dtp.Visible = false; };
            dtp.TextChanged += (s, ev) =>
            {
                dataGridViewRecords.Rows[rowIndex].Cells[columnIndex].Value = dtp.Value;
            };

            dataGridViewRecords.Controls.Add(dtp);
            dtp.BringToFront();
            dtp.Focus();
        }


        private void ShowGenderDropdown(int rowIndex, int colIndex)
        {
            if (EditDetails.Text != "Save Changes") return; // Prevent showing dropdown if not in edit mode

            ComboBox genderDropdown = new ComboBox();
            genderDropdown.Items.AddRange(new string[] { "Male", "Female", "Other" });
            genderDropdown.DropDownStyle = ComboBoxStyle.DropDownList; // Prevents text input

            Rectangle cellRect = dataGridViewRecords.GetCellDisplayRectangle(colIndex, rowIndex, true);
            genderDropdown.Bounds = cellRect;

            genderDropdown.SelectedIndexChanged += (s, e) =>
            {
                dataGridViewRecords.Rows[rowIndex].Cells[colIndex].Value = genderDropdown.SelectedItem.ToString();
            };

            dataGridViewRecords.Controls.Add(genderDropdown);
            genderDropdown.DroppedDown = true;
        }



        // Add Dropdown for Gender
        private void dataGridViewRecords_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewRecords.Columns[e.ColumnIndex].HeaderText == "Gender")
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Items.AddRange(new string[] { "Male", "Female", "Other" });
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.SelectedIndexChanged += (s, ev) =>
                {
                    dataGridViewRecords.CurrentCell.Value = comboBox.SelectedItem.ToString();
                };

                dataGridViewRecords.Controls.Add(comboBox);
                comboBox.Location = dataGridViewRecords.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                comboBox.Size = dataGridViewRecords.CurrentCell.Size;
                comboBox.BringToFront();

                // Set the selected value if already exists
                if (dataGridViewRecords.CurrentCell.Value != null)
                {
                    comboBox.SelectedItem = dataGridViewRecords.CurrentCell.Value.ToString();
                }
            }

           

        }






        private void MainForm_Load(object sender, EventArgs e)
        {
            SidePanel.Dock = DockStyle.Left;
            SidePanel.BringToFront();

            LoadPendingVisitorRequests();
            PendingRequestsGrid.CellClick += PendingRequestsGrid_CellClick;



            // Ensure SidePanel stays on top of other controls


            LoadPrisonerRecords();
        }


        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Dashboard_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }






        private void MainPanel_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Records_Click(object sender, EventArgs e)
        {


        }


        private void RecordsPanel_Click(object sender, EventArgs e) { }

        private void AddPrisoner_Click(object sender, EventArgs e)
        {
            AddPrisonerForm addForm = new AddPrisonerForm();
            addForm.ShowDialog(); // Opens as a modal dialog
        }





        public void LoadPrisonerRecords(bool allowEdit = false)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT 
                id, 
                full_name AS 'Full Name', 
                id_number AS 'Prisoner ID', 
                age AS 'Age', 
                contact_number AS 'Contact Number', 
                prisoner_case AS 'Case', 
                detained_date AS 'Detained Date', 
                cell_number AS 'Cell Number', 
                sentence_start AS 'Sentence Start', 
                sentence_end AS 'Sentence End', 
                gender AS 'Gender', 
                status AS 'Status'  -- Added the status column here
                FROM prisoners";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewRecords.DataSource = dt;

                    // Apply conditions based on allowEdit
                   
                    dataGridViewRecords.Enabled = allowEdit;
                    dataGridViewRecords.SelectionMode = allowEdit ? DataGridViewSelectionMode.CellSelect : DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewRecords.DefaultCellStyle.BackColor = allowEdit ? Color.White : SystemColors.Control;
                    dataGridViewRecords.MultiSelect = false;
                    dataGridViewRecords.ClearSelection();

                    dataGridViewRecords.RowHeadersVisible = false;
                    dataGridViewRecords.AutoGenerateColumns = false;

                    // Format the 'Date' columns
                    foreach (DataGridViewColumn column in dataGridViewRecords.Columns)
                    {
                        if (column.Name == "Detained Date" || column.Name == "Sentence Start" || column.Name == "Sentence End")
                        {
                            column.DefaultCellStyle.Format = "MMMM dd, yyyy"; // Format for "March 25, 2025"
                        }
                    }

                    // Hide the ID column
                    if (dataGridViewRecords.Columns["id"] != null)
                    {
                        dataGridViewRecords.Columns["id"].Visible = false;
                    }

                    // Make sure the "Status" column is visible in the DataGridView
                    if (dataGridViewRecords.Columns["Status"] != null)
                    {
                        dataGridViewRecords.Columns["Status"].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading prisoner records: " + ex.Message);
            }
        }








        private void DataGridViewRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    int rowIndex = e.RowIndex;
                    int colIndex = e.ColumnIndex;

                    if (rowIndex >= 0 && colIndex >= 0)
                    {
                        DataGridViewRow row = dataGridViewRecords.Rows[rowIndex];
                        if (row.Cells["id"].Value != null)
                        {
                            int prisonerId = Convert.ToInt32(row.Cells["id"].Value);
                            string displayName = dataGridViewRecords.Columns[colIndex].Name;
                            object newValue = row.Cells[colIndex].Value ?? DBNull.Value;

                            // Map display names to database column names (C# 7.3 compatible)
                            string columnName;
                            if (displayName == "Full Name")
                                columnName = "full_name";
                            else if (displayName == "Prisoner ID")
                                columnName = "id_number";
                            else if (displayName == "Case")
                                columnName = "prisoner_case";
                            else if (displayName == "Detained Date")
                                columnName = "detained_date";
                            else if (displayName == "Cell Number")
                                columnName = "cell_number";
                            else if (displayName == "Sentence Start")
                                columnName = "sentence_start";
                            else if (displayName == "Sentence End")
                                columnName = "sentence_end";
                            else if (displayName == "Age")
                                columnName = "age";
                            else if (displayName == "Contact Number")
                                columnName = "contact_number";
                            else if (displayName == "Gender")
                                columnName = "gender";
                            else if (displayName == "Status") // Handle the 'Status' column
                                columnName = "status";
                            else
                                columnName = displayName.ToLower().Replace(" ", "_");

                            // Update the database with the edited value
                            string query = $"UPDATE prisoners SET {columnName} = @value WHERE id = @id";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", prisonerId);
                                cmd.Parameters.AddWithValue("@value", newValue);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show($"Update failed for ID: {prisonerId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    // Visual feedback that update succeeded
                                    dataGridViewRecords.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.LightGreen;
                                    var timer = new Timer { Interval = 500 };
                                    timer.Tick += (s, ev) =>
                                    {
                                        dataGridViewRecords.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.White;
                                        timer.Stop();
                                        timer.Dispose();
                                    };
                                    timer.Start();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveChangesToDatabase()
        {
            try
            {
                // Remove any active controls inside the DataGridView (like DatePicker and ComboBox)
                foreach (Control control in dataGridViewRecords.Controls)
                {
                    if (control is DateTimePicker || control is ComboBox)
                    {
                        dataGridViewRecords.Controls.Remove(control);
                    }
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridViewRecords.Rows)
                    {
                        if (row.Cells["id"].Value != null) // Ensure there's an ID
                        {
                            int prisonerId = Convert.ToInt32(row.Cells["id"].Value);

                            // ✅ Use the column names as they appear in the DataGridView
                            string fullName = row.Cells["Full Name"].Value.ToString();
                            string idNumber = row.Cells["Prisoner ID"].Value.ToString();
                            int age = Convert.ToInt32(row.Cells["Age"].Value);
                            string contactNumber = row.Cells["Contact Number"].Value.ToString();
                            string prisonerCase = row.Cells["Case"].Value.ToString();
                            DateTime detainedDate = Convert.ToDateTime(row.Cells["Detained Date"].Value);
                            string cellNumber = row.Cells["Cell Number"].Value.ToString();
                            DateTime? sentenceStart = row.Cells["Sentence Start"].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row.Cells["Sentence Start"].Value);
                            DateTime? sentenceEnd = row.Cells["Sentence End"].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row.Cells["Sentence End"].Value);
                            string gender = row.Cells["Gender"].Value.ToString();
                            string status = row.Cells["Status"].Value.ToString();

                            // Update the SQL query to include the status column
                            string query = @"UPDATE prisoners SET 
                             full_name = @name, 
                             id_number = @idnum, 
                             age = @age, 
                             contact_number = @contact, 
                             prisoner_case = @case, 
                             detained_date = @detained, 
                             cell_number = @cell, 
                             sentence_start = @start, 
                             sentence_end = @end, 
                             gender = @gender,
                             status = @status 
                             WHERE id = @id";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", prisonerId);
                                cmd.Parameters.AddWithValue("@name", fullName);
                                cmd.Parameters.AddWithValue("@idnum", idNumber);
                                cmd.Parameters.AddWithValue("@age", age);
                                cmd.Parameters.AddWithValue("@contact", contactNumber);
                                cmd.Parameters.AddWithValue("@case", prisonerCase);
                                cmd.Parameters.AddWithValue("@detained", detainedDate);
                                cmd.Parameters.AddWithValue("@cell", cellNumber);
                                cmd.Parameters.AddWithValue("@start", sentenceStart);
                                cmd.Parameters.AddWithValue("@end", sentenceEnd);
                                cmd.Parameters.AddWithValue("@gender", gender);
                                cmd.Parameters.AddWithValue("@status", status);  // Add the status parameter here

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show($"No rows updated for ID: {prisonerId}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }

                    // Reload the records after updating
                    LoadPrisonerRecords(false); // ✅ explicit and matches EditDetails state
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }



        private void DataGridViewRecords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridViewRecords.CurrentCell != null)
            {
                e.SuppressKeyPress = true; // Prevents the default Enter key behavior
                SaveChangesToDatabase();
            }


        }

        private void AddPrisoner_Click_1(object sender, EventArgs e)
        {
            AddPrisonerForm addForm = new AddPrisonerForm(); // Create an instance of the form
            addForm.Show(); // Show the form (non-modal)
        }


        private void EditDetails_Click_2(object sender, EventArgs e)
        {
            if (EditDetails.Text == "Edit Details")
            {
                // Enable editing mode
                dataGridViewRecords.ReadOnly = false;
                dataGridViewRecords.Enabled = true;
                dataGridViewRecords.DefaultCellStyle.BackColor = Color.White;
                dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.CellSelect;
                EditDetails.Text = "Save Changes";

                // Allow editing for all columns except those related to gender, dates
                foreach (DataGridViewColumn col in dataGridViewRecords.Columns)
                {
                    if (col.Name == "detained_date" || col.Name == "sentence_start" || col.Name == "sentence_end" || col.Name == "gender")
                        col.ReadOnly = true;
                    else
                        col.ReadOnly = false;
                }

                MessageBox.Show("Editing mode enabled. Press 'Enter' to save changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Show a confirmation modal before saving changes
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to save the changes?",
                    "Confirm Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Save changes to the database
                    SaveChangesToDatabase();

                    // Disable editing mode after saving changes
                    dataGridViewRecords.ReadOnly = true;
                    dataGridViewRecords.Enabled = false;
                    EditDetails.Text = "Edit Details";

                    // Make all columns read-only after save
                    foreach (DataGridViewColumn col in dataGridViewRecords.Columns)
                    {
                        col.ReadOnly = true;
                    }

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // If user chooses 'No', exit without saving
                    MessageBox.Show("Changes were not saved.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        private void AddPrisoner_Click_2(object sender, EventArgs e)
        {
            AddPrisonerForm addForm = new AddPrisonerForm(); // Create an instance of the form
            addForm.Show(); // Show the form (non-modal)
        }

        private void SidePanel_Scroll(object sender, PaintEventArgs e)
        {
            label1.Top = panel1.VerticalScroll.Value; // Keeps label at the top
        }
        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Dashboard_Click_1(object sender, EventArgs e)
        {

        }

        private void AddVisitor_Click(object sender, EventArgs e)
        {
            AddVisitor addVisitorForm = new AddVisitor(this);
            addVisitorForm.Show();
          

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)


            {
                Application.Restart();

                // Show the login form
                LogInForm login = new LogInForm();
                login.Show();

                // Hide the Admin Dashboard instead of closing it
                this.Hide();
            }
        }

        private bool isEditMode = false;

        private void EditVisitorDetails_Click(object sender, EventArgs e)
        {
            VisitorData.ReadOnly = false;

            if (!isEditMode)
            {
                // Enable edit mode
                VisitorData.ReadOnly = false;

                // Exclude non-editable columns
                foreach (DataGridViewColumn col in VisitorData.Columns)
                {
                    if (col.Name == "PreviewImageButton" || col.Name == "id")
                        col.ReadOnly = true;
                }

                isEditMode = true;
                EditVisitorDetails.Text = "Save Changes";
            }
            else
            {
                // Save changes to the database
                SaveVisitorChanges();
                VisitorData.ReadOnly = true;
                isEditMode = false;
                EditVisitorDetails.Text = "Edit Visitor Details";
            }
        }

        private void SaveVisitorChanges()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                foreach (DataGridViewRow row in VisitorData.Rows)
                {
                    if (row.IsNewRow) continue;

                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    string fullName = row.Cells["Full Name"].Value.ToString();
                    string contact = row.Cells["Contact"].Value.ToString();
                    string purpose = row.Cells["Visit Purpose"].Value.ToString();
                    string address = row.Cells["Address"].Value.ToString();
                    string relationship = row.Cells["Relationship"].Value.ToString();
                    DateTime visitDate = Convert.ToDateTime(row.Cells["Date"].Value);
                    string timeIn = row.Cells["Time In"].Value.ToString();
                    string timeOut = row.Cells["Time Out"].Value.ToString();

                    string updateQuery = @"
                UPDATE visitors SET 
                    full_name = @full_name,
                    contact_number = @contact,
                    visit_purpose = @purpose,
                    address = @address,
                    relationship_to_prisoner = @relationship,
                    visit_date = @date,
                    visit_time_in = @time_in,
                    visit_time_out = @time_out
                WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@full_name", fullName);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@purpose", purpose);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@relationship", relationship);
                        cmd.Parameters.AddWithValue("@date", visitDate);
                        cmd.Parameters.AddWithValue("@time_in", timeIn);
                        cmd.Parameters.AddWithValue("@time_out", timeOut);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Visitor details updated successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVisitorData(); // Refresh after saving
            }
        }


        private void dataGridViewRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewRecords.ReadOnly = false;
        }

        private void PendingRequestsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PendingRequestsGrid.ReadOnly = true;
            // Make sure the click is not on header
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = PendingRequestsGrid;
            var clickedColumn = grid.Columns[e.ColumnIndex];

            // Get the visitor request ID from the hidden "id" column
            var row = grid.Rows[e.RowIndex];
            int requestId = Convert.ToInt32(row.Cells["id"].Value);

            if (clickedColumn.Name == "Approve")
            {
                // ✅ Approve logic here
                ApproveVisitorRequest(requestId);
                LoadPendingVisitorRequests(); // Refresh the grid
            }
            else if (clickedColumn.Name == "Decline")
            {
                // ✅ Decline logic here
                DeclineVisitorRequest(requestId);
                LoadPendingVisitorRequests(); // Refresh the grid
            }
            else if (clickedColumn.Name == "ViewID")
            {
                // ✅ Fetch the image bytes using the ID
                byte[] imageBytes = GetVisitorImageById((requestId));
                ShowImagePreview(imageBytes);
            }
        }


        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PendingRequestsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ApproveVisitorRequest(int requestId)
        {
            // Ask for confirmation before proceeding
            DialogResult result = MessageBox.Show(
                "Are you sure you want to approve this visitor request?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return; // If user clicks No, cancel the action
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // First get the request details
                string selectQuery = @"SELECT * FROM pending_visitor_requests WHERE id = @id";
                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@id", requestId);
                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Read values from the row
                            string fullName = reader["full_name"].ToString();
                            string contact = reader["contact_number"].ToString();
                            string purpose = reader["visit_purpose"].ToString();
                            string address = reader["address"].ToString();
                            int prisonerId = Convert.ToInt32(reader["prisoner_id"]);
                            string relationship = reader["relationship_to_prisoner"].ToString();
                            DateTime date = Convert.ToDateTime(reader["visit_date"]);
                            string timeIn = reader["visit_time_in"].ToString();
                            string timeOut = reader["visit_time_out"].ToString();
                            byte[] imageBytes = (byte[])reader["visitor_id_image"];

                            reader.Close(); // close before running the insert

                            // ✅ Insert into visitors
                            string insertQuery = @"INSERT INTO visitors 
                        (full_name, contact_number, visit_purpose, address, prisoner_id, 
                         relationship_to_prisoner, visit_date, visit_time_in, visit_time_out, visitor_id_image)
                         VALUES (@full_name, @contact, @purpose, @address, @prisoner_id, 
                                 @relationship, @visit_date, @time_in, @time_out, @image)";

                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@full_name", fullName);
                                insertCmd.Parameters.AddWithValue("@contact", contact);
                                insertCmd.Parameters.AddWithValue("@purpose", purpose);
                                insertCmd.Parameters.AddWithValue("@address", address);
                                insertCmd.Parameters.AddWithValue("@prisoner_id", prisonerId);
                                insertCmd.Parameters.AddWithValue("@relationship", relationship);
                                insertCmd.Parameters.AddWithValue("@visit_date", date);
                                insertCmd.Parameters.AddWithValue("@time_in", timeIn);
                                insertCmd.Parameters.AddWithValue("@time_out", timeOut);
                                insertCmd.Parameters.AddWithValue("@image", imageBytes);

                                insertCmd.ExecuteNonQuery();
                            }

                            // ✅ Remove from pending table
                            string deleteQuery = "DELETE FROM pending_visitor_requests WHERE id = @id";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@id", requestId);
                                deleteCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Visitor request approved and added to main visitor records.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    LoadVisitorData(); // Refresh after approving
                }
            }
        }


        private void DeclineVisitorRequest(int requestId)
        {
            // Ask for confirmation before declining the request
            DialogResult result = MessageBox.Show(
                "Are you sure you want to decline this visitor request?",
                "Confirm Decline",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return; // If user clicks No, cancel the action
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM pending_visitor_requests WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@id", requestId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Visitor request declined.");
            LoadPendingVisitorRequests(); // Refresh after declining
        }

        public void LoadPendingVisitorRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
            SELECT pvr.id, pvr.full_name AS 'Full Name', pvr.contact_number AS 'Contact',
                   pvr.visit_purpose AS 'Visit Purpose', pvr.address AS 'Address',
                   p.full_name AS 'Prisoner Name', pvr.relationship_to_prisoner AS 'Relationship',
                   pvr.visit_date AS 'Date', pvr.visit_time_in AS 'Time In',
                   pvr.visit_time_out AS 'Time Out', pvr.visitor_id_image
            FROM pending_visitor_requests pvr
            JOIN prisoners p ON pvr.prisoner_id = p.id
            ORDER BY pvr.id DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Remove image column before binding
                    if (dt.Columns.Contains("visitor_id_image"))
                    {
                        dt.Columns.Remove("visitor_id_image");
                    }

                    // Clear old columns
                    PendingRequestsGrid.Columns.Clear();

                    // Bind data
                    PendingRequestsGrid.DataSource = dt;

                    // Hide ID column
                    if (PendingRequestsGrid.Columns.Contains("id"))
                    {
                        PendingRequestsGrid.Columns["id"].Visible = false;
                    }

                    // Format date nicely
                    if (PendingRequestsGrid.Columns.Contains("Date"))
                    {
                        PendingRequestsGrid.Columns["Date"].DefaultCellStyle.Format = "MMMM dd, yyyy";
                    }

                   


                    // Hide row headers
                    PendingRequestsGrid.RowHeadersVisible = false;

                    // Add Approve button
                    DataGridViewButtonColumn approveBtn = new DataGridViewButtonColumn
                    {
                        Name = "Approve",
                        HeaderText = "Action",
                        Text = "Approve",
                        UseColumnTextForButtonValue = true,
                        Width = 80
                    };
                    PendingRequestsGrid.Columns.Add(approveBtn);

                    // Add Decline button
                    DataGridViewButtonColumn declineBtn = new DataGridViewButtonColumn
                    {
                        Name = "Decline",
                        HeaderText = "",
                        Text = "Decline",
                        UseColumnTextForButtonValue = true,
                        Width = 80
                    };
                    PendingRequestsGrid.Columns.Add(declineBtn);

                    // Add View ID button
                    DataGridViewButtonColumn viewIDBtn = new DataGridViewButtonColumn
                    {
                        Name = "ViewID",
                        HeaderText = "Valid ID",
                        Text = "View",
                        UseColumnTextForButtonValue = true,
                        Width = 100
                    };
                    PendingRequestsGrid.Columns.Add(viewIDBtn);

                    // Prevent extra row
                    PendingRequestsGrid.AllowUserToAddRows = false;
                    PendingRequestsGrid.Refresh();
                }
            }
        }




    }
}
