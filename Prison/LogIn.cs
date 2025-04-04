using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            // Authenticate the user against the database
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT role FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string role = reader["role"].ToString();
                    Session.Role = role; // Store the role in a global Session variable
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void OpenUserDashboard(string username)
        {
            string role = Session.Role; // Get the role from the Session

            // Open different dashboards based on the role
            if (role == "warden")
            {
                AdminDash mainForm = new AdminDash(); // For warden role, show AdminDash
                mainForm.ShowDialog();
            }
            else if (role == "desk_officer")
            {
              
            }
            else if (role == "records_officer")
            {
                DESKOFFICER RoForm = new DESKOFFICER(); // Create and show a specific form for IT officers
                RoForm.ShowDialog();

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
    }

    public static class Session
    {
        // Store the role of the logged-in user
        public static string Role { get; set; }
    }
}
