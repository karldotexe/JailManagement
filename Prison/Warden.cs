using MySql.Data.MySqlClient;
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
    public partial class Warden : Form
    {

        private string connString = "Server=localhost;Database=prison_management;Uid=root;Pwd=;";
        public Warden()
        {
            InitializeComponent();
        }

        private void Warden_Load(object sender, EventArgs e)
        {
            
            PendingPrisoners.CellClick += PendingPrisoners_CellClick;
            LoadPendingPrisoners();
            LoadPrisonerRecords();
        }

        private void LoadPendingPrisoners()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM pending_prisoners";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                PendingPrisoners.DataSource = table;

                // Hide 'id' column if it exists
                if (PendingPrisoners.Columns.Contains("id"))
                {
                    PendingPrisoners.Columns["id"].Visible = false;
                }

                if (PendingPrisoners.Columns.Contains("submitted_at"))
                {
                    PendingPrisoners.Columns["submitted_at"].Visible = false;
                }

                // Rename column headers
                var columnMappings = new Dictionary<string, string>()
                    {
                        { "full_name", "Full Name" },
                        { "id_number", "Prisoner ID" },
                        { "age", "Age" },
                        { "contact_number", "Contact Number" },
                        { "prisoner_case", "Case" },
                        { "detained_date", "Detained Date" },
                        { "cell_number", "Cell Number" },
                        { "sentence_start", "Sentence Start" },
                        { "sentence_end", "Sentence End" },
                        { "gender", "Gender" },
                        { "status", "Status" }
                    };

                foreach (DataGridViewColumn col in PendingPrisoners.Columns)
                {
                    if (columnMappings.ContainsKey(col.Name))
                    {
                        col.HeaderText = columnMappings[col.Name];
                    }
                }

                // Remove existing buttons to avoid duplicates
                if (PendingPrisoners.Columns.Contains("Approve"))
                    PendingPrisoners.Columns.Remove("Approve");
                if (PendingPrisoners.Columns.Contains("Decline"))
                    PendingPrisoners.Columns.Remove("Decline");

                // Add Approve button
                DataGridViewButtonColumn approveBtn = new DataGridViewButtonColumn();
                approveBtn.Name = "Approve";
                approveBtn.HeaderText = "Approve";
                approveBtn.Text = "Approve";
                approveBtn.UseColumnTextForButtonValue = true;
                PendingPrisoners.Columns.Add(approveBtn);

                // Add Decline button
                DataGridViewButtonColumn declineBtn = new DataGridViewButtonColumn();
                declineBtn.Name = "Decline";
                declineBtn.HeaderText = "Decline";
                declineBtn.Text = "Decline";
                declineBtn.UseColumnTextForButtonValue = true;
                PendingPrisoners.Columns.Add(declineBtn);

                PendingPrisoners.ReadOnly = true;
                PendingPrisoners.AllowUserToAddRows = false;
            }
        }




        private void ApproveSelected_Click(object sender, EventArgs e)
        {
            if (PendingPrisoners.SelectedRows.Count > 0)
            {
                DataGridViewRow row = PendingPrisoners.SelectedRows[0];
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    // Insert to prisoners
                    string insert = @"INSERT INTO prisoners 
                (full_name, id_number, age, contact_number, prisoner_case, 
                 detained_date, cell_number, sentence_start, sentence_end, gender, status) 
                VALUES 
                (@name, @id, @age, @contact, @case, @detained, @cell, @start, @end, @gender, @status)";

                    MySqlCommand insertCmd = new MySqlCommand(insert, conn);
                    insertCmd.Parameters.AddWithValue("@name", row.Cells["full_name"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@id", row.Cells["id_number"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@age", Convert.ToInt32(row.Cells["age"].Value));
                    insertCmd.Parameters.AddWithValue("@contact", row.Cells["contact_number"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@case", row.Cells["prisoner_case"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@detained", Convert.ToDateTime(row.Cells["detained_date"].Value));
                    insertCmd.Parameters.AddWithValue("@cell", row.Cells["cell_number"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@start", Convert.ToDateTime(row.Cells["sentence_start"].Value));
                    insertCmd.Parameters.AddWithValue("@end", Convert.ToDateTime(row.Cells["sentence_end"].Value));
                    insertCmd.Parameters.AddWithValue("@gender", row.Cells["gender"].Value.ToString());
                    insertCmd.Parameters.AddWithValue("@status", row.Cells["status"].Value.ToString());

                    insertCmd.ExecuteNonQuery();

                    // Remove from pending
                    int pendingId = Convert.ToInt32(row.Cells["id"].Value);
                    string delete = "DELETE FROM pending_prisoners WHERE id = @id";
                    MySqlCommand deleteCmd = new MySqlCommand(delete, conn);
                    deleteCmd.Parameters.AddWithValue("@id", pendingId);
                    deleteCmd.ExecuteNonQuery();
                }

                LoadPendingPrisoners(); // Refresh
                MessageBox.Show("Approved and moved to main prisoner records.");
                LoadPrisonerRecords();
            }
        }


        private void PendingPrisoners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && PendingPrisoners.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string columnName = PendingPrisoners.Columns[e.ColumnIndex].Name;
                DataGridViewRow row = PendingPrisoners.Rows[e.RowIndex];
                int pendingId = Convert.ToInt32(row.Cells["id"].Value);

                if (columnName == "Approve")
                {
                    ApprovePrisoner(row, pendingId);
                }
                else if (columnName == "Decline")
                {
                    DeclinePrisoner(pendingId);
                }
            }
        }

        private void ApprovePrisoner(DataGridViewRow row, int pendingId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string insert = @"INSERT INTO prisoners 
            (full_name, id_number, age, contact_number, prisoner_case, 
             detained_date, cell_number, sentence_start, sentence_end, gender, status) 
            VALUES 
            (@name, @id, @age, @contact, @case, @detained, @cell, @start, @end, @gender, @status)";

                MySqlCommand cmd = new MySqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@name", row.Cells["full_name"].Value.ToString());
                cmd.Parameters.AddWithValue("@id", row.Cells["id_number"].Value.ToString());
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(row.Cells["age"].Value));
                cmd.Parameters.AddWithValue("@contact", row.Cells["contact_number"].Value.ToString());
                cmd.Parameters.AddWithValue("@case", row.Cells["prisoner_case"].Value.ToString());
                cmd.Parameters.AddWithValue("@detained", Convert.ToDateTime(row.Cells["detained_date"].Value));
                cmd.Parameters.AddWithValue("@cell", row.Cells["cell_number"].Value.ToString());
                cmd.Parameters.AddWithValue("@start", Convert.ToDateTime(row.Cells["sentence_start"].Value));
                cmd.Parameters.AddWithValue("@end", Convert.ToDateTime(row.Cells["sentence_end"].Value));
                cmd.Parameters.AddWithValue("@gender", row.Cells["gender"].Value.ToString());
                cmd.Parameters.AddWithValue("@status", row.Cells["status"].Value.ToString());
                cmd.ExecuteNonQuery();

                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM pending_prisoners WHERE id = @id", conn);
                deleteCmd.Parameters.AddWithValue("@id", pendingId);
                deleteCmd.ExecuteNonQuery();
            }

            LoadPendingPrisoners();
            MessageBox.Show("Prisoner approved and added.", "Approved");
            LoadPrisonerRecords();
        }

        private void DeclinePrisoner(int pendingId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM pending_prisoners WHERE id = @id", conn);
                deleteCmd.Parameters.AddWithValue("@id", pendingId);
                deleteCmd.ExecuteNonQuery();
            }

            LoadPendingPrisoners();
            MessageBox.Show("Prisoner request declined.", "Declined");
        }

        private void PendingPrisoners_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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


        private void LoadPrisonerRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM prisoners";  // Change to the correct table if needed
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Set the data source for the DataGridView
                PrisonerRecords.DataSource = table;

                // Optionally, hide columns you don’t want to show
                if (PrisonerRecords.Columns.Contains("id"))
                {
                    PrisonerRecords.Columns["id"].Visible = false;
                }

                if (PrisonerRecords.Columns.Contains("submitted_at")) // If this column exists in your table
                {
                    PrisonerRecords.Columns["submitted_at"].Visible = false;
                }

                // Rename column headers for better readability
                var columnMappings = new Dictionary<string, string>()
        {
            { "full_name", "Full Name" },
            { "id_number", "Prisoner ID" },
            { "age", "Age" },
            { "contact_number", "Contact Number" },
            { "prisoner_case", "Case" },
            { "detained_date", "Detained Date" },
            { "cell_number", "Cell Number" },
            { "sentence_start", "Sentence Start" },
            { "sentence_end", "Sentence End" },
            { "gender", "Gender" },
            { "status", "Status" }
        };

                foreach (DataGridViewColumn col in PrisonerRecords.Columns)
                {
                    if (columnMappings.ContainsKey(col.Name))
                    {
                        col.HeaderText = columnMappings[col.Name];
                    }
                }

                // Optional: Disable editing and allow users to only view the records
                PrisonerRecords.ReadOnly = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
