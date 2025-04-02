using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prison
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string correctUsername = "admin";
            string correctPassword = "admin";

            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // Hide the login form
                AdminDash mainForm = new AdminDash(); // Open a new form after login
                mainForm.ShowDialog();
                this.Close(); // Close login form after main form is closed
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }



        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
