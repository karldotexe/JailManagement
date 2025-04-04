using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prison
{
    public partial class DESKOFFICER : Form
    {

        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";
        private PictureBox previewPictureBox = new PictureBox();

        public DESKOFFICER()
        {
            InitializeComponent();

            closeButton.Text = "X";
            closeButton.BackColor = Color.Red;
            closeButton.ForeColor = Color.White;
            closeButton.Size = new Size(40, 40);
            closeButton.Location = new Point(previewPictureBox.Width - 50, 10);  // Positioned at the top-right corner
            closeButton.Click += CloseButton_Click;  // Close the preview when clicked
            closeButton.Visible = false;  // Hide the close button initially
            this.Controls.Add(closeButton);  // Add close button on top of the picture box

            // Set up the preview PictureBox
            previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ensure proper image zooming
            previewPictureBox.Visible = false;  // Initially hidden
            previewPictureBox.BackColor = Color.Black;  // Black background for immersive preview
            previewPictureBox.Width = Screen.PrimaryScreen.Bounds.Width / 2;  // Set width to half the screen width
            previewPictureBox.Height = Screen.PrimaryScreen.Bounds.Height / 2;  // Set height to half the screen height
            previewPictureBox.Left = (Screen.PrimaryScreen.Bounds.Width - previewPictureBox.Width) / 2; // Center horizontally
            previewPictureBox.Top = (Screen.PrimaryScreen.Bounds.Height - previewPictureBox.Height) / 2; // Center vertically
            previewPictureBox.Click += previewPictureBox_Click;  // Close the preview when clicked
            this.Controls.Add(previewPictureBox); 


        }


        private void RecordsOfficer_Load(object sender, EventArgs e)
        {
            
            LoadVisitorDataRC();

            VisitorDataRC.CellContentClick += VisitorDataRC_CellContentClick;

        }


        public void LoadVisitorDataRC()
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
                    VisitorDataRC.Columns.Clear();

                    // Set the DataSource for the DataGridView
                    VisitorDataRC.DataSource = dt;

                    // Hide the 'id' column
                    if (VisitorDataRC.Columns.Contains("id"))
                    {
                        VisitorDataRC.Columns["id"].Visible = false;
                    }

                    // Rename prisoner_name column header
                    if (VisitorDataRC.Columns.Contains("prisoner_name"))
                    {
                        VisitorDataRC.Columns["prisoner_name"].HeaderText = "Prisoner Name";
                    }

                    // Format the 'Date' column to display as 'March 20, 2025'
                    if (VisitorDataRC.Columns.Contains("Date"))
                    {
                        VisitorDataRC.Columns["Date"].DefaultCellStyle.Format = "MMMM dd, yyyy"; // Date format
                    }

                    // Remove row headers (extra first column)
                    VisitorDataRC.RowHeadersVisible = false;

                    // Add a button column for image preview
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                    {
                        Name = "PreviewImageButton",
                        HeaderText = "Valid ID",
                        Text = "View", // Button text
                        UseColumnTextForButtonValue = true, // Use the button text
                        Width = 100
                    };


                    VisitorDataRC.Columns.Add(buttonColumn);

                    // Prevent the addition of extra rows (blank row at the bottom)
                    VisitorDataRC.AllowUserToAddRows = false;
                    VisitorDataRC.Refresh();
                    VisitorDataRC.ReadOnly = true;
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            previewPictureBox.Visible = false;  // Hide the image
            closeButton.Visible = false;  // Hide the close button
        }

        // Handle the button click event for the "Preview" button
        private void VisitorDataRC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the PreviewImageButton column
            if (e.ColumnIndex == VisitorDataRC.Columns["PreviewImageButton"].Index && e.RowIndex >= 0)
            {
                // Fetch visitor_id_image for the selected visitor (e.g., from the database)
                int visitorId = (int)VisitorDataRC.Rows[e.RowIndex].Cells["id"].Value;

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

                    // Use the existing previewPictureBox instead of creating a new one
                    previewPictureBox.Image = img;
                    previewPictureBox.Visible = true;
                    previewPictureBox.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // When displaying images in a DataGridView, handle cell formatting
        private void VisitorDataRC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (VisitorDataRC.Columns[e.ColumnIndex].Name == "visitor_id_image" && e.Value != null && e.Value is byte[])
            {
                byte[] imageBytes = (byte[])e.Value;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    e.Value = Image.FromStream(ms);
                }
            }
        }

        private void previewPictureBox_Click(object sender, EventArgs e)
        {
            // Close the preview when clicked
            previewPictureBox.Visible = false;
            closeButton.Visible = false;
        }

        private void VisitorData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
            
        private void closeButton_Click_1(object sender, EventArgs e)
        {

        }

        private void VisitorDataRC_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddVisitor_Click(object sender, EventArgs e)
        {
            DeskAddVisitor addForm = new DeskAddVisitor(); // Create an instance of the form
            addForm.Show(); // Show the form (non-modal)
        }

        private void EditVisitorDetails_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        

    }
}
