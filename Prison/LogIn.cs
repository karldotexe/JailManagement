using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Prison
{
    public partial class LogInForm : Form
    {
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";

        public LogInForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Convert hash to a string
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                this.Hide(); // Hide the login form

                // Open the corresponding form based on the role
                OpenUserDashboard(username);
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Hash the entered password
            string hashedPassword = HashPassword(password);

            // Authenticate the user against the database
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT role, password FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string storedPasswordHash = reader["password"].ToString();
                    string role = reader["role"].ToString();

                    // Compare hashed password with stored hash
                    if (storedPasswordHash == hashedPassword)
                    {
                        Session.Role = role; // Store the role in a global Session variable
                        return true;
                    }
                }
            }

            return false; // Return false if credentials are invalid
        }


        private void OpenUserDashboard(string username)
        {
            string role = Session.Role; // Get the role from the Session

            // Open different dashboards based on the role
            if (role == "warden")
            {
                Warden WardenForm = new Warden(); // For warden role, show AdminDash
                WardenForm.ShowDialog();
            }
            else if (role == "desk_officer")
            {
                DESKOFFICER RoForm = new DESKOFFICER(); // Create and show a specific form for IT officers
                RoForm.ShowDialog();

            }
            else if (role == "records_officer")
            {
                AdminDash mainForm = new AdminDash(); // For warden role, show AdminDash
                mainForm.ShowDialog();
            }
            else if (role == "IT_officer")
            {
                AccountCreation itForm = new AccountCreation(); // Create and show a specific form for IT officers
                itForm.ShowDialog();

                // Allow IT Officer to access AccountCreation form
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }


    }





        public static class Session
        {
            // Store the role of the logged-in user
            public static string Role { get; set; }
        }
}
