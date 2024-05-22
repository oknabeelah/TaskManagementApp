using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Whole_Saler.forms;

namespace TaskManagementApp
{
    public partial class CompleteProfileForm : Form
    {
        private string connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
        private CircularPictureBox CircularProfilePictureBox; //declared , not initialisied
        private string userName;
        public CompleteProfileForm(string userName)
        {
            InitializeComponent();

            // Initialize the control
            CircularProfilePictureBox = new CircularPictureBox();
            //CircularProfilePictureBox.Location = new Point(10, 10); // Set the location
            //CircularProfilePictureBox.Size = new Size(233, 239); // Set the size
            // Optionally, set other properties such as BackColor, BorderStyle, etc.
            // Add the control to the form's Controls collection
            //Controls.Add(CircularProfilePictureBox);

            // Save the user's name
            this.userName = userName;

            // Display the user's name in a label or other control
            NameLabel.Text = $"Welcome, {userName}!";
        }

        private void UpdateProfilePicButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Photo";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // Clear the existing image (dummy image)
                    CircularProfilePictureBox.Image = null;
                    // Assign the new image
                    CircularProfilePictureBox.Image = Image.FromFile(filePath);
                }
                CircularProfilePictureBox.Invalidate(); // Refresh to remove any choices
            }
        }

        private bool isDragging = false; // Flag to track if the image is being dragged
        private Point offset; // Store the offset between the mouse position and the image position
        private void CircularPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the mouse is within the bounds of the image
            if (IsMouseOverImage(e.Location))
            {
                isDragging = true; // Start dragging the image
                offset = e.Location; // Store the offset between the mouse position and the image position
            }
        }
        private bool IsMouseOverImage(Point mouseLocation)
        {
            // Check if the mouse position is within the bounds of the image
            // You may need to adjust the conditions based on the size and position of your image
            // For example, you can use geometric calculations to check if the point is inside the circular area
            return CircularProfilePictureBox.ClientRectangle.Contains(mouseLocation);
        }
        private void CircularPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the new position of the image based on the mouse movement
                int newX = CircularProfilePictureBox.Left + e.X - offset.X;
                int newY = CircularProfilePictureBox.Top + e.Y - offset.Y;

                // Ensure that the new position keeps the image within the circular boundaries
                LimitImagePosition(ref newX, ref newY);

                // Update the location of the image control
                CircularProfilePictureBox.Location = new Point(newX, newY);
            }
        }
        private void LimitImagePosition(ref int x, ref int y)
        {
            // Perform calculations to limit the movement of the image within the circular boundaries of the picture box
            // Ensure that the new position does not exceed the circular boundaries
            // Calculate the distance from the center of the circular picture box to the new position
            double distance = Math.Sqrt(Math.Pow(x - CircularProfilePictureBox.Width / 2, 2) + Math.Pow(y - CircularProfilePictureBox.Height / 2, 2));
            double radius = CircularProfilePictureBox.Width / 2; // Assuming the picture box is circular
            if (distance > radius)
            {
                // Adjust the new position to stay within the circular boundaries
                double angle = Math.Atan2(y - CircularProfilePictureBox.Height / 2, x - CircularProfilePictureBox.Width / 2);
                x = (int)(CircularProfilePictureBox.Width / 2 + radius * Math.Cos(angle));
                y = (int)(CircularProfilePictureBox.Height / 2 + radius * Math.Sin(angle));
            }
        }
        private void CircularPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Stop dragging the image
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //get data from controls
                byte[] profile_pic = null; //placeholder for image data
                string user_phone = PhoneInput.Text;
                DateTime Dobpicker = DoBPicker.Value; //make the value from DoBPicker a datetime datatype
                //string date_of_birth = Dobpicker.ToString("yyyy-MM-dd"); //convert to string of yyyy/mm/dd format
                string edu_level = EduInput.Text;
                string country = CountryInput.Text;
                string interest_1 = checkBox1.Checked ? checkBox1.Text : DBNull.Value.ToString(); // Retrieve checkbox value if checked, and null if unchecked
                string interest_2 = checkBox2.Checked ? checkBox2.Text : DBNull.Value.ToString();
                string interest_3 = checkBox3.Checked ? checkBox3.Text : DBNull.Value.ToString();
                string interest_4 = checkBox4.Checked ? checkBox4.Text : DBNull.Value.ToString();
                string interest_5 = checkBox5.Checked ? checkBox5.Text : DBNull.Value.ToString();
                string interest_6 = checkBox6.Checked ? checkBox6.Text : DBNull.Value.ToString();

                if (CircularPictureBox.Image != null) // Convert profile picture to byte array
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        CircularPictureBox.Image.Save(ms, CircularPictureBox.Image.RawFormat);
                        profile_pic = ms.ToArray();
                    }
                }
                //prepare sql query with parameters
                using (var conn = new NpgsqlConnection(connString))
                {
                    await conn.OpenAsync();

                    string query = @"UPDATE userinfo 
                                SET
                                    profile_pic = @profilepic,
                                    user_phone = @userphone,
                                    date_of_birth = @dob,
                                    edu_level = @edulevel,
                                    country = @country,
                                    interest_1 = @interest1,
                                    interest_2 = @interest2,
                                    interest_3 = @interest3,
                                    interest_4 = @interest4,
                                    interest_5 = @interest5,
                                    interest_6 = @interest6
                                WHERE 
                                    user_name = @userName";

                    //execute sql query
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Add parameters to the command
                        //cmd.Parameters.AddWithValue(@blah, blah);
                        cmd.Parameters.AddWithValue("@profilepic", profile_pic ?? (object)DBNull.Value); // Add profile_pic as a parameter with value null if no profile picture is selected
                        cmd.Parameters.AddWithValue("@userphone", user_phone);
                        cmd.Parameters.AddWithValue("@dob", Dobpicker);
                        cmd.Parameters.AddWithValue("@edulevel", edu_level);
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@interest1", interest_1); // Use retrieved value or null
                        cmd.Parameters.AddWithValue("@interest2", interest_2);
                        cmd.Parameters.AddWithValue("@interest3", interest_3);
                        cmd.Parameters.AddWithValue("@interest4", interest_4);
                        cmd.Parameters.AddWithValue("@interest5", interest_5);
                        cmd.Parameters.AddWithValue("@interest6", interest_6);
                        cmd.Parameters.AddWithValue("@userName", userName); // Use the userName variable for the WHERE clause

                        await cmd.ExecuteNonQueryAsync(); //execute sql query
                    }
                    MessageBox.Show("Data saved successfully!"); //show if sql query was successful
                                                                 //here is code for dashboard
                    string email = GetEmail(userName);
                    Form5 Form = new Form5(email);
                    Form.Show();
                    // Close this form
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                // Log the full error details to a log file
                File.AppendAllText("error.log", $"{DateTime.Now}: An error occurred: {ex.ToString()}\n");
            }

        }

        private string GetEmail(string userName)
        {
            string email = string.Empty;
            using (var connection = new NpgsqlConnection(connString)) 
            { 
                connection.Open();
                string query = "SELECT email FROM userinfo WHERE user_name = @userName";
                using (var command = new NpgsqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@userName", userName);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }
            return email;
        }
        private void NameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

