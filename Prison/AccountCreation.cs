﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Prison
{
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void AccountCreation_Load(object sender, EventArgs e)
        {
            // Load accounts and disable typing in ComboBox
            LoadAccounts();
            Roles.DropDownStyle = ComboBoxStyle.DropDownList; // Disable typing in the ComboBox

            // Populate ComboBox with roles (example roles)
            Roles.Items.Add("Records Officer");
            Roles.Items.Add("Desk Officer");
            Roles.Items.Add("Warden");
            Roles.Items.Add("IT Officer");

            LogOut.Dock = DockStyle.None; // To remove docking

        }



        private void LogOut_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is within a row (not the header)
            if (e.RowIndex >= 0)
            {
                // Get the username and role from the selected row
                string username = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string role = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                // Display or use these values as needed
                MessageBox.Show($"Username: {username}\nRole: {role}");
            }
        }


        private void LoadAccounts()
        {
            // Connection string to your MySQL database
            string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";

            // Create a connection to the database
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Query to fetch only the username and role (excluding password)
                    string query = "SELECT username as 'Username', role as 'Role' FROM users";

                    // Execute the query
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); // Fill the DataTable with the fetched data

                    // Map the role values to their human-readable format
                    foreach (DataRow row in dt.Rows)
                    {
                        string role = row["Role"].ToString();
                        switch (role)
                        {
                            case "desk_officer":
                                row["Role"] = "Desk Officer";
                                break;
                            case "records_officer":
                                row["Role"] = "Records Officer";
                                break;
                            case "warden":
                                row["Role"] = "Warden";
                                break;
                            case "IT_officer":
                                row["Role"] = "IT Officer";
                                break;
                            default:
                                row["Role"] = role; // Leave as is if no match
                                break;
                        }
                    }

                    // Bind the modified data to the DataGridView
                    dataGridView1.DataSource = dt;

                    // Disable the extra row for new entries
                    dataGridView1.AllowUserToAddRows = false;  // This removes the blank row

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }





        private void Confirm_Click_1(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
            string role = Roles.SelectedItem?.ToString(); // Role selected from combobox

            // Check if any of the fields are empty or if no role is selected
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Map the selected role to the database value
            switch (role)
            {
                case "Records Officer":
                    role = "records_officer";
                    break;
                case "Desk Officer":
                    role = "desk_officer";
                    break;
                case "Warden":
                    role = "warden";
                    break;
                case "IT Officer":
                    role = "IT_officer";
                    break;
                default:
                    MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Hash the password before storing it
            string hashedPassword = HashPassword(password);

            // Database connection string
            string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";

            try
            {
                // Connect to the database
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    // Check if the username already exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);

                    int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        // Show confirmation dialogbox if username exists
                        DialogResult result = MessageBox.Show("Username is already taken. Do you want to try another?", "Username Taken", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            return; // Exit if user does not want to proceed
                        }
                        else
                        {
                            // Optionally, you can focus on the Username field for correction
                            Username.Focus();
                            return;
                        }
                    }

                    // SQL query to insert a new user if the username is unique
                    string query = "INSERT INTO users (username, password, role) VALUES (@username, @password, @role)";

                    // Create the command and add parameters
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // Store the hashed password
                    cmd.Parameters.AddWithValue("@role", role);

                    // Debugging: Check the values being passed to the query
                    Console.WriteLine($"Inserting: Username={username}, Password={hashedPassword}, Role={role}");

                    // Execute the query
                    int resultExecute = cmd.ExecuteNonQuery();

                    if (resultExecute > 0)
                    {
                        MessageBox.Show("Account created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload the DataGrid to reflect the new account
                        LoadAccounts();

                        // Optionally, clear the input fields
                        Username.Clear();
                        Password.Clear();
                        Roles.SelectedIndex = -1; // Reset combo box selection
                    }
                    else
                    {
                        MessageBox.Show("Account creation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert password to byte array and compute the hash
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array back to string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2")); // Convert to hexadecimal
                }

                return sb.ToString(); // Return the hashed password
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            Username.Text = Username.Text.Replace(" ", "");

            // Move the cursor to the end after removing spaces
            Username.SelectionStart = Username.Text.Length;
        }
    }
}
