using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Required for MySQL

namespace Prison
{
    public partial class AdminDash : Form
    {
        // Database connection string (Change prison_management to your actual database name)
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";

        public AdminDash()
        {
            InitializeComponent();
            dataGridViewRecords.CellEndEdit += DataGridViewRecords_CellEndEdit;
            LoadVisitorData();

            // Make DataGridView read-only when the form starts
            dataGridViewRecords.ReadOnly = true;

            dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Prevent individual cell selection
            dataGridViewRecords.AllowUserToAddRows = false; // Disable the extra row

            // Set up the sticky sidebar
            SidePanel.Dock = DockStyle.Left;
            SidePanel.BringToFront();
            VisitorData.ReadOnly = true;



            dataGridViewRecords.CellEndEdit += DataGridViewRecords_CellEndEdit;
            dataGridViewRecords.ReadOnly = true;

            dataGridViewRecords.EditingControlShowing += dataGridViewRecords_EditingControlShowing;
            dataGridViewRecords.CellClick += dataGridViewRecords_CellClick;
            dataGridViewRecords.CellEnter += dataGridViewRecords_CellEnter;


        }

        private void LoadVisitorData()
        {
            try
            {
                // SQL query to fetch all visitor records
                string query = "SELECT v.full_name AS 'Visitor Name', v.contact_number AS 'Contact Number', v.visit_purpose AS 'Visit Purpose', " +
                               "v.address AS 'Address', p.full_name AS 'Prisoner Name', v.relationship_to_prisoner AS 'Relationship', v.visit_date AS 'Visit Date', " +
                               "v.visit_time_in AS 'Time In', v.visit_time_out AS 'Time Out' FROM visitors v " +
                               "JOIN prisoners p ON v.prisoner_id = p.id";  // Join with prisoners table to get prisoner names

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);  // Fill the DataTable with the data from the query

                    // Bind the DataTable to the DataGridView
                    VisitorData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load visitor records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRecords_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox txtBox)
            {
                string columnName = dataGridViewRecords.Columns[dataGridViewRecords.CurrentCell.ColumnIndex].HeaderText;

                txtBox.KeyPress -= TxtBox_KeyPress; // Remove previous handler (if any)
                txtBox.KeyPress += TxtBox_KeyPress; // Add new event handler

                txtBox.TextChanged -= TxtBox_TextChanged;
                txtBox.TextChanged += TxtBox_TextChanged;

                // Prevent typing in date fields
                if (columnName == "Detained Date" || columnName == "Sentence Start" || columnName == "Sentence End")
                {
                    txtBox.ReadOnly = true; // Make text box read-only
                }
                else
                {
                    txtBox.ReadOnly = false; // Allow editing for other fields
                }
            }

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


        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewRecords.CurrentCell == null) return;

            string columnName = dataGridViewRecords.Columns[dataGridViewRecords.CurrentCell.ColumnIndex].HeaderText;
            TextBox txtBox = sender as TextBox;

            // Ensure "Age" is within the valid range (18-100)
            if (columnName == "Age" && int.TryParse(txtBox.Text, out int age))
            {
                if (age < 18 || age > 100)
                {

                }
                else
                {
                    txtBox.BackColor = Color.White; // Reset
                }
            }
            // Ensure "Contact Number" is exactly 11 digits
            else if (columnName == "Contact Number")
            {
                if (txtBox.Text.Length != 11)
                {

                }
                else
                {
                    txtBox.BackColor = Color.White;
                }
            }


        }



        // Validation based on column names
        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridViewRecords.CurrentCell == null) return;

            string columnName = dataGridViewRecords.Columns[dataGridViewRecords.CurrentCell.ColumnIndex].HeaderText;
            TextBox txtBox = sender as TextBox;

            // Prevent numbers in "Full Name"
            if (columnName == "Full Name" && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Allow only numbers in "Prisoner ID"
            else if (columnName == "Prisoner ID" && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            else if (columnName == "Cell Number" && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            // Allow only valid numbers in "Age"
            else if (columnName == "Age")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                {
                    int newAge;
                    string newText = txtBox.Text.Insert(txtBox.SelectionStart, e.KeyChar.ToString());
                    if (int.TryParse(newText, out newAge))
                    {
                        if (newAge < 1 || newAge > 122)
                        {
                            e.Handled = true;
                            MessageBox.Show("Age must be valid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            // Allow only 11 digits in "Contact Number"
            else if (columnName == "Contact Number")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else if (txtBox.Text.Length >= 11 && e.KeyChar != (char)Keys.Back) // Limit to 11 digits
                {
                    e.Handled = true;
                    MessageBox.Show("Contact number must be exactly 11 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else if (columnName == "Prisoner ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else if (txtBox.Text.Length >= 20 && e.KeyChar != (char)Keys.Back) // Limit to 11 digits
                {
                    e.Handled = true;
                    MessageBox.Show("Must only contain 20 character", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }



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
            }
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

        public void LoadPrisonerRecords()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT 
                    id, -- Still select the ID but we'll hide it
                    full_name AS 'Full Name', 
                    id_number AS 'Prisoner ID', 
                    age AS 'Age', 
                    contact_number AS 'Contact Number', 
                    prisoner_case AS 'Case', 
                    detained_date AS 'Detained Date', 
                    cell_number AS 'Cell Number', 
                    sentence_start AS 'Sentence Start', 
                    sentence_end AS 'Sentence End', 
                    gender AS 'Gender' 
                    FROM prisoners";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewRecords.DataSource = dt;
                    dataGridViewRecords.AutoGenerateColumns = false;
                    dataGridViewRecords.RowHeadersVisible = false;

                    // Hide the ID column after binding
                    if (dataGridViewRecords.Columns["id"] != null)
                    {
                        dataGridViewRecords.Columns["id"].Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading prisoner records: " + ex.Message);
            }
        }





        private void EditDetails_Click(object sender, EventArgs e)
        {
            if (EditDetails.Text == "Edit Details")
            {
                dataGridViewRecords.ReadOnly = false;
                dataGridViewRecords.DefaultCellStyle.BackColor = Color.White;
                dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.CellSelect;
                EditDetails.Text = "Save Changes";
                MessageBox.Show("Editing mode enabled. Press 'Enter' to save changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveChangesToDatabase();
                dataGridViewRecords.ReadOnly = true;


                EditDetails.Text = "Edit Details";
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

                            // Validate Age after editing
                            if (displayName == "Age")
                            {
                                if (int.TryParse(newValue.ToString(), out int age))
                                {
                                    if (age < 1 || age > 122)
                                    {
                                        MessageBox.Show("Age must be between 18 and 122.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        row.Cells[colIndex].Value = DBNull.Value; // Clear invalid input
                                        return;
                                    }
                                }
                            }
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
                            else
                                columnName = displayName.ToLower().Replace(" ", "_");

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
                                    gender = @gender 
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

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show($"No rows updated for ID: {prisonerId}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }

                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPrisonerRecords(); // Refresh DataGridView
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

        private void EditDetails_Click_1(object sender, EventArgs e)
        {
            if (EditDetails.Text == "Edit Details")
            {
                dataGridViewRecords.ReadOnly = false;
                dataGridViewRecords.DefaultCellStyle.BackColor = Color.White;
                dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.CellSelect;
                EditDetails.Text = "Save Changes";
                MessageBox.Show("Editing mode enabled. Press 'Enter' to save changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveChangesToDatabase();
                dataGridViewRecords.ReadOnly = true;
                EditDetails.Text = "Edit Details";
            }
        }

        private void EditDetails_Click_2(object sender, EventArgs e)
        {
            if (EditDetails.Text == "Edit Details")
            {
                dataGridViewRecords.ReadOnly = false;
                dataGridViewRecords.DefaultCellStyle.BackColor = Color.White;
                dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.CellSelect;
                EditDetails.Text = "Save Changes";

                // Allow editing of all columns except the specified ones
                foreach (DataGridViewColumn col in dataGridViewRecords.Columns)
                {
                    if (col.HeaderText == "Detained Date" || col.HeaderText == "Sentence Start" || col.HeaderText == "Sentence End" || col.HeaderText == "Gender")
                    {
                        col.ReadOnly = true; // Keep these columns non-editable even in edit mode
                    }
                    else
                    {
                        col.ReadOnly = false; // Allow editing of other columns
                    }
                }

                MessageBox.Show("Editing mode enabled. Press 'Enter' to save changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveChangesToDatabase();
                dataGridViewRecords.ReadOnly = true;
                EditDetails.Text = "Edit Details";

                // Reset all columns to fully read-only
                foreach (DataGridViewColumn col in dataGridViewRecords.Columns)
                {
                    col.ReadOnly = true;
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
            AddVisitor add = new AddVisitor();
            add.Show();
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

        private void VisitorData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditVisitorDetails_Click(object sender, EventArgs e)
        {
            VisitorData.ReadOnly = false;
        }
    }
}
