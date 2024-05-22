using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql; //for postgresql connectivity
using Whole_Saler.forms; //custom namespace

namespace TaskManagementApp
{
    public partial class LoginPage : Form
    {
        Datalayer dl; // datalayer?
        public LoginPage()
        {
            dl = new Datalayer(); //whaa
            InitializeComponent();
        }

        private void Signupredirect_Click(object sender, EventArgs e) //when sign up button is clicked
        {
            Signupform signupform = new Signupform();
            signupform.Show();
            this.Hide();
        }

        private async void Submitbutton_Click(object sender, EventArgs e) //when submit button is clicked
        {
            // Check if email or password input is null or empty
            if (string.IsNullOrEmpty(EmailInput.Text) || string.IsNullOrEmpty(PasswordInput.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return; // Exit the method to prevent further execution
            }

            var connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
            await using var conn = new NpgsqlConnection(connString);              //proble is a connection string syntax error here and d
            await conn.OpenAsync();                                               //note how here is username and dl.cs is user/userid //incl port

                //check input with database, if correct move to next page, if not show error message, allow to enter detaisl again for 3 more tries (lol if i can)
                //instance of strings here, select from table
                //error handle null entires
                //error handle mismatched entries
                string query = "SELECT user_id from userinfo WHERE email = @Email AND password = @Password";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", EmailInput.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordInput.Text);

                    object result = await cmd.ExecuteScalarAsync();

                    if (result != null)
                    {
                        MessageBox.Show("Congrats! Login successful"); // Shows a message box if login is successful
                                                                       //go to dashboard , display welxome message with username
                        Form5 Form5 = new Form5(EmailInput.Text); //form5 is the dashboard, accidentally clicked too early and cant change it
                        Form5.Show();
                        this.Hide();
                }
                    else
                    {
                        MessageBox.Show("Email or Password is Incorrect! Try again."); // Shows a message box if login fails
                    }

                }
                /* dl.getsingleColumnValueByIndex(query, out user_id, 0);
                if (user_id != null)
                {
                    //enter code to move to dashboard
                    //incl welcome message with firstname and lastname
                    MessageBox.Show("Congrats! Login successful");
                }
                else
                {
                    MessageBox.Show("Email or Password is Incorrect! Try again.");
                }
                */
         }  

        private void ShowPwdBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPwdBox.Checked == true)
            {
                PasswordInput.UseSystemPasswordChar = false; //allow password characters to show
            }
            else 
            {
                PasswordInput.UseSystemPasswordChar = true; //dont :/
            }

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
