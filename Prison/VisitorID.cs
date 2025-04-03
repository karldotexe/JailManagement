using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;

namespace Prison
{
    public partial class VisitorID : Form
    {
        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap capturedImage;
        private AddVisitor parentForm;  // Reference to AddVisitor

        private int visitorId; // Store the correct visitor ID

        public VisitorID(AddVisitor parent, int visitorId)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.visitorId = visitorId; // Assign the correct visitor ID
        }

        private void VisitorID_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            StartCamera();
        }

        private void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No camera found!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            videoSource.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate { pictureBox1.Image = frame; }));
            }
            else
            {
                pictureBox1.Image = frame;

            }
        }

        private void button1_Click(object sender, EventArgs e) // Capture Button
        {
            if (pictureBox1.Image != null)
            {
                capturedImage = new Bitmap(pictureBox1.Image);
                MessageBox.Show("Image Captured!");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Save & Send Button
        {


            if (capturedImage == null)
            {
                MessageBox.Show("No image to save!");
                return;
            }

            // Save Locally
            string folderPath = @"C:\Users\Lenovo\source\repos\Prison\VisitorValidIDs";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = Path.Combine(folderPath, $"Captured_{DateTime.Now:yyyyMMdd_HHmmss}.jpg");
            capturedImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Save to Database
            using (MemoryStream ms = new MemoryStream())
            {
                capturedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "UPDATE visitors SET visitor_id_image = @Image WHERE id = @VisitorId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Image", imageBytes);
                      
                        cmd.Parameters.AddWithValue("@VisitorId", this.visitorId); // Use the stored visitor ID
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // ✅ Send Captured Image to AddVisitor
            if (parentForm != null)
            {
                parentForm.SetCapturedImage(capturedImage);
            }

            MessageBox.Show("Image saved");
            this.Close();
        }

      


        private void VisitorID_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
    }
}
