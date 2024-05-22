using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagementApp
{
    
    public partial class OpeningPage : Form
    {
        public OpeningPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();

        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            Signupform signupform = new Signupform();
            signupform.Show();
            this.Hide();

        }

        private void OpeningPage_Load(object sender, EventArgs e)
        {

        }
    }
}
