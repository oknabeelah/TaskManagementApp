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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateListButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Indicates "List" was chosen
            this.Close();
        }

        private void CreateGroupButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; // Indicates "Group" was chosen
            this.Close();
        }
    }
}
