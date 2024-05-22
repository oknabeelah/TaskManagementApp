using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Npgsql;
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
using Whole_Saler.forms;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Microsoft.Identity.Client;
using NLog;

namespace TaskManagementApp
{
    public partial class Signupform : Form
    {
        Datalayer dl; // datalayer?
        // Declare connString as a class-level variable
        private string connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";

        public Signupform()
        {
            dl = new Datalayer();
            InitializeComponent();
        }

        private void ShowPwdBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPwdBox.Checked == true)
            {
                Pwordinput.UseSystemPasswordChar = false; //allow password characters to show
            }
            else
            {
                Pwordinput.UseSystemPasswordChar = true; //dont :/
            }
        }

        private void CShowPwdBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CShowPwdBox.Checked == true)
            {
                RePwordinput.UseSystemPasswordChar = false; //allow password characters to show
            }
            else
            {
                RePwordinput.UseSystemPasswordChar = true; //dont :/
            }
        }

        private async void Signupbutton_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable the signup button to prevent multiple clicks
                Signupbutton.Enabled = false;
                // Display a loading spinner or message to indicate signup process is ongoing
                LoadingSpinner.Visible = true;

                // Check if any of the input fields are null or empty
                if (string.IsNullOrEmpty(Fnameinput.Text) || string.IsNullOrEmpty(Lnameinput.Text) ||
                    string.IsNullOrEmpty(Unameinput.Text) || string.IsNullOrEmpty(Emailinput.Text) ||
                    string.IsNullOrEmpty(Pwordinput.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return; // Exit the method to prevent further execution
                }

                //check if username already exists 
                if (await UsernameExistsAsync(Unameinput.Text))
                {
                    MessageBox.Show("Username is already taken. Please choose a different username.");
                    return; // Exit the method if username already exists
                }

                // Proceed with inserting the new user
                // Your code for inserting the user into the database goes here

                // Validate password complexity
                string password = Pwordinput.Text;
                if (!IsPasswordSecure(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
                    return;
                }

                // Check if passwords match
                if (password != RePwordinput.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }
                /* changing the minimum user id to 20 to allow for non duplicate values
                string ConnString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
                string sqlCommand = "ALTER SEQUENCE userinfo_user_id_seq RESTART WITH 20;";
                using (NpgsqlConnection sequenceConn = new NpgsqlConnection(ConnString))
                {                       //CS0136
                    sequenceConn.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlCommand, sequenceConn))
                    {
                        command.ExecuteNonQuery();
                    }

                    sequenceConn.Close();
                }
                */
                var connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();

                string query = "INSERT INTO userinfo (first_name, last_name, user_name, email, password) VALUES (@Fname, @Lname, @Uname, @Email, @Pwd)";
                // int count = DataAccess.execute(InsertData);
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fname", Fnameinput.Text);
                    cmd.Parameters.AddWithValue("@Lname", Lnameinput.Text);
                    cmd.Parameters.AddWithValue("@Uname", Unameinput.Text);
                    cmd.Parameters.AddWithValue("@Email", Emailinput.Text);
                    cmd.Parameters.AddWithValue("@Pwd", Pwordinput.Text);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync(); //execute sql satement

                    // Check that the number of rows changes to determine if the account was successfully created
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account created successfully!");
                        // Open complete profile 

                        CompleteProfileForm completeProfileForm = new CompleteProfileForm(Unameinput.Text);

                        completeProfileForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create account. Please try again."); // Show error message if account creation fails
                    }

                }
                // Hide the loading spinner and enable the signup button after successful signup
                LoadingSpinner.Visible = false;
            }
            catch (Exception ex)
            {
                // Log the exception to a log file
                //NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
                //logger.Error(ex, "An error occured:");

                // Display user-friendly error message
                MessageBox.Show($"An error occurred while creating the account. Please try again later. {ex.Message}");
            }
            finally
            {
                // Hide the loading spinner after the operation completes
                LoadingSpinner.Visible = false;
                // Enable the signup button after signup process is complete or failed
                Signupbutton.Enabled = true;
            }
        }


        private bool IsPasswordSecure(string password)
        {
            // Define password complexity rules
            const int MIN_LENGTH = 8;
            const string SPECIAL_CHARACTERS = "!@#$%^&*()-_+=<>?";

            // Check password length
            if (password.Length < MIN_LENGTH)
            {
                return false;
            }

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Check for at least one lowercase letter
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // Check for at least one digit
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Check for at least one special character
            if (!password.Any(c => SPECIAL_CHARACTERS.Contains(c)))
            {
                return false;
            }

            // Password meets all criteria
            return true;
        }

        private async Task<bool> UsernameExistsAsync(string username)
        {
            // Check if the username exists in the database
            string query = "SELECT COUNT(*) FROM userinfo WHERE LOWER (user_name) = LOWER (@username)";
            using (var conn = new NpgsqlConnection(connString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    return count > 0; // Return true if count > 0 (username exists), false otherwise
                }
            }
        }
    }

}
