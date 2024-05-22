using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml;
using Npgsql;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace TaskManagementApp
<<<<<<< Updated upstream
{ //on the github site
=======
{
    //making sure it works
>>>>>>> Stashed changes
    public partial class Form5 : Form
    {
        bool sidebarExpand; //declaring 
        bool homebuttonCollapsed;
        private string email;
        private string connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
        private int UserId;
        private Dictionary<int?, Panel> Listpanels = new Dictionary<int?, Panel>();

        public Form5(string email)
        {
            InitializeComponent();
            //save email
            this.email = email;
            //display email in welcome message
            WelcomeLabel.Text = $"Welcome, {email}!";
            
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT user_id FROM userinfo WHERE email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                UserId = (int)command.ExecuteScalar(); //return int value user id
            }
            ViewUserLists(UserId);
            DashboardPanel.Refresh();
            // display all tasks in all lists
            Displaytasks(GetAllTasks(UserId));  
        }
        private void Displaytasks(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                if (Listpanels.TryGetValue(task.ListId, out var Listpanel)) //gettingt he corresponding listpanel
                {
                    var taskControl = CreateTaskControl(task);
                    Listpanel.Controls.Add(taskControl); // Add to the correct list panel 
                }
            }
            DashboardPanel.Refresh();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                SidebarPanel.Width -= 10;
                if (SidebarPanel.Width == SidebarPanel.MinimumSize.Width) //90,1024
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                SidebarPanel.Width += 10;
                if (SidebarPanel.Width == SidebarPanel.MaximumSize.Width) //396,1024
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            //lower timer interval to make smooth transition
            SidebarTimer.Start();
        }

        private void DropMenuTimer_Tick(object sender, EventArgs e)
        {
            if (homebuttonCollapsed)
            {
                HomeContainer.Height += 10;
                if (HomeContainer.Height == HomeContainer.MaximumSize.Height) //527, 190
                {
                    homebuttonCollapsed = false;
                    DropMenuTimer.Stop();
                }
            }
            else
            {
                HomeContainer.Height -= 10;
                if (HomeContainer.Height == HomeContainer.MinimumSize.Height) //527, 91
                {
                    homebuttonCollapsed = true;
                    DropMenuTimer.Stop();
                }


            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            DropMenuTimer.Start();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var dialog = new CreateForm();

            DialogResult choice = dialog.ShowDialog(); //display options to choose

            switch (choice)
            {
                case DialogResult.OK:
                    //create a list                    
                    if (CreateList(email).HasValue) //if the list id is returned
                    {                     
                        ViewUserLists(UserId);
                        DashboardPanel.Refresh();

                    }
                    //email as in what is stored from the login page duhh
                    //display on the dashboard with possibility to add tasks to list
                    // remember to display already created lists in db 
                    break;
                case DialogResult.No:
                    //create a group

                    break;
                default:
                    //do nothing
                    break;
            }
        }
        private int? listId; //list id that should be used everywhere else

        private int? CreateList(string email)
        {
            //retrieve  user id
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT user_id FROM userinfo WHERE email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                UserId = (int)command.ExecuteScalar(); //return int value user id
            }
            //get list name from user 
            string listName = InputDialog.ShowDialog("Enter List Name:", "Create New List"); //returns entered list name
            //insert ist record in db
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO userlistinfo (list_name, user_id) VALUES (@ListName, @UserId) RETURNING user_list_id", connection);
                command.Parameters.AddWithValue("@ListName", listName);
                command.Parameters.AddWithValue("@UserId", UserId);
                //  int rowsAffected = await cmd.ExecuteNonQueryAsync(); //execute sql satement // this doesnt work for an insert statemnt me thinks 
                listId = (int?)command.ExecuteScalar(); //here is list id
                //check if list is properly added 
                if (listId.HasValue)
                {
                    // List added successfully
                    MessageBox.Show("List created successfully!");           
                    return listId;
                    
                }
                else
                {
                    // Failed to add list
                    MessageBox.Show("Failed to create list. Please try again.");
                    return listId; //nothing here tho
                }
            }
        }
        //Panel Listpanel = new Panel();
        private Panel Listpanel = new Panel();
        private void ViewUserLists(int UserId)
        {
            Listpanels.Clear(); // Clear existing panels to avoid duplicates
            DashboardPanel.Controls.Clear();
            //check for all lists in db created by user (ensure only individual page
            Dictionary<int?, string> Userlists = GetUserlistsFromDB(UserId);
            //clear the current dashboard 
            //DashboardPanel.Controls.Clear();
            // If no lists found, show a message or simply return
            if (Userlists == null || Userlists.Count == 0)
            {
                MessageBox.Show("No lists found for this user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Exit early to avoid errors
            }
            // Initialize listPanels
            
            //create panels for each found list and add to dashboard
            foreach (var List in Userlists)
            {
                listId = List.Key; // ID of the list
                string listname = List.Value; // Name of the list
                                              //create a panel for the list 
                                              // Create a new list panel if it doesn't exist in the dictionary
                if (listId.HasValue && !Listpanels.ContainsKey(listId))
                {
                    var listPanel = new Panel
                    {
                        Size = new Size(250, 400),
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoScroll = true,
                        Dock = DockStyle.Top,
                        Padding = new Padding(10),
                        BackColor = Color.White
                    };

                    // Add label with the list name
                    var listLabel = new Label
                    {
                        Text = listname,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    //add addtaskbutton to the panels
                    var AddTaskbutton = new Button
                    {
                        Text = "Add Task",
                        Dock = DockStyle.Bottom,                  
                    };
                    
                    AddTaskbutton.Click += (sender, e) => AddTaskButton_Click(sender, e); // Add event handler to add tasks button click event, basically call addtasktolist method when utton is clicked
                    listPanel.Controls.Add(listLabel);
                    listPanel.Controls.Add(AddTaskbutton);
                    Listpanels[listId] = listPanel; // Add to the dictionary
                    DashboardPanel.Controls.Add(listPanel); // Add to the dashboard
                }

                // Enable auto-scrolling for the DashboardPanel
                DashboardPanel.AutoScroll = true;

                DashboardPanel.Visible = true; // Ensure visibility
                                                   //DashboardPanel.Refresh();
                
            }
            DashboardPanel.Refresh();
        }
        private void AddTaskButton_Click(object sender, EventArgs e) 
        {
            //show form as modal dialog (cant work on dashboard unless new form closes
            var AddTaskForm = new AddTask(listId.Value);  //send listid to form, ensure its not null?
            AddTaskForm.ShowDialog();

            if (AddTaskForm.TaskCreated)
            {
                // Clear the dashboard to avoid duplicates
                DashboardPanel.Controls.Clear();
                // Reload all lists and tasks
                ViewUserLists(UserId);
                List<Task> allTasks = GetAllTasks(UserId);
                foreach (var task in allTasks)
                {
                    if (Listpanels.TryGetValue(task.ListId, out var listPanel))
                    {
                        var taskControl = CreateTaskControl(task);
                        listPanel.Controls.Add(taskControl);
                    }
                }
                DashboardPanel.Refresh();
            }
            else
            {
                MessageBox.Show("Please create a list first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Task> GetAllTasks(int userId)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using (var connection = new NpgsqlConnection(connString))
                {
                    connection.Open();
                    var command = new NpgsqlCommand(
                        "SELECT usertaskmembershipinfo.user_list_id, usertaskinfo.task_name, usertaskinfo.progress_percentage, usertaskinfo.due_date, attachmentinfo.file_name\r\n FROM usertaskmembershipinfo\r\n LEFT JOIN userlistinfo\r\n ON usertaskmembershipinfo.user_list_id = userlistinfo.user_list_id\r\n LEFT JOIN usertaskinfo\r\n ON usertaskmembershipinfo.member_task_id = usertaskinfo.member_task_id\r\n LEFT JOIN attachmentinfo\r\n ON usertaskinfo.attachment_id = attachmentinfo.attachment_id\r\n WHERE userlistinfo.user_id = @UserId",
                        connection
                    );

                    command.Parameters.AddWithValue("@UserId", userId);    //useerriddd              

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Task
                            {
                                ListId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ProgressPercentage = reader.GetInt32(2),
                                DueDate = reader.GetDateTime(3),
                                //Filename = reader.IsDBNull(4) ? null : reader.GetString(4),
                                //ListId = reader.GetInt32(4)
                            };

                            tasks.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching tasks: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tasks;
        }



        private Control CreateTaskControl(Task task)
        {
            var taskPanel = new Panel()
            {
                Dock = DockStyle.Top, //ensures a vertical list
                Padding = new Padding (15),
                Height = 50,
                BackColor = Color.White, //to add hover functionality            
                Width = 400,
                BorderStyle = BorderStyle.FixedSingle
            };
            var taskLabel = new Label()
            {
                Text = task.Name,
                //Top = taskPanel.Top,
                BackColor = Color.White,
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,                
                Location = new Point (25, 15)          
            }; //from form 6 
            var checkBox = new CheckBox()
            {
                Checked = task.ProgressPercentage == 100,
                Location = new Point (5, 15) //to align with label
            };
            var progressBar = new ProgressBar()
            { 
                Maximum = 100,
                Value = task.ProgressPercentage,
                Dock = DockStyle.Bottom, //should be right but im trying sumn here 
                Width = 400,
                ForeColor = Color.Pink,
                //Location = new Point (0, 25)
            
            }; //same

            // add controls to the panel
            taskPanel.Controls.Add(taskLabel); //add task label , include as a to do that can be marked as completed 
            taskPanel.Controls.Add(checkBox);
            //taskPanel.Controls.Add(progressBar); //define where

            //add hover functionality 
            //taskPanel.MouseHover += (sender, e) => ShowTaskDetails(task); //hopefully when i unhover it goes away 
            //use priviously recommended mouse on and off lines
            return taskPanel; //return the created panel
        }
        private void ShowTaskDetails(Task task)
        {
            // Create a panel or tooltip to show detailed info about the task
            var detailPanel = new Panel()
            {
                Dock = DockStyle.Right,
                BackColor = Color.White,
                Padding = new Padding(10),
                Size = new Size(300, 300)
            };
            var taskNameLabel = new Label()
            {
                Text = $"Task Name: {task.Name}",
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };

            var progressLabel = new Label()
            {
                Text = $"Progress: {task.ProgressPercentage}%",
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };

            var dueDateLabel = new Label()
            {
                Text = $"Due Date: {task.DueDate}",
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };

            var attachmentLabel = new Label()
            {
                Text = $"Attachment: {task.Filename}",
                Dock = DockStyle.Top,
                Padding = new Padding(10)
                //clickable file? //viewing the attachment
            };

            //edit and delete button in the details panel
            var editButton = new Button()
            {
                Text = "Edit",
                Dock = DockStyle.Bottom
            };

            var deleteButton = new Button()
            {
                Text = "Delete",
                Dock = DockStyle.Bottom
            };
                      
            detailPanel.Controls.Add(taskNameLabel);
            detailPanel.Controls.Add(progressLabel);
            detailPanel.Controls.Add(dueDateLabel);
            detailPanel.Controls.Add(attachmentLabel);
            detailPanel.Controls.Add(editButton);
            detailPanel.Controls.Add(deleteButton);

            editButton.Click += (sender, e) => EditTask(task);
            deleteButton.Click += (sender, e) => DeleteTask(task);

            // Add the detail panel to the dashboard
            DashboardPanel.Controls.Add(detailPanel);
            //add style/layout to make sure it pops next to the list panel
        }
        private void EditTask(Task task)
        {
            // Open a dialog or form to edit the task
            // Modify the task in the database
        }
        private void DeleteTask(Task task)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                /*
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM tasks WHERE user_task_id = @TaskId", connection);
                command.Parameters.AddWithValue("@TaskId", task.Id);
                command.ExecuteNonQuery();
                */
                //message if done correctly or no
            }
        }
        private Dictionary<int?, string> GetUserlistsFromDB(int UserId) //error resolved by changing Listinfo to string 
        {
            // Implement database query to retrieve lists created by the user
            Dictionary<int?, string> Listnames = new Dictionary<int?, string>();
            try
            {

                using (var connection = new NpgsqlConnection(connString))
                {
                    connection.Open();
                    //define the SQL query to retrieve list names and id for the specified user
                    string query = "SELECT user_list_id, list_name FROM userlistinfo WHERE user_id = @UserId";
                    //create command with sql query and parameters
                    var command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", UserId);
                
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listId = reader.GetInt32(0);
                            string listName = reader.GetString(1);
                            Listnames.Add(listId, listName);  //correct list id is stored and the variable is passed correctly
                        }
                    }
                }
                // If the dictionary is empty, return a message or do nothing
                if (Listnames.Count == 0)
                {
                    // Optionally, show a message box indicating no lists found
                    MessageBox.Show("No lists found for this user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Listnames;
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show($"Database Error: {ex.Message}");
                return Listnames; //placeholed because it shouldnt work here 
            }
        }

        private void CompleteprofileButton_Click(object sender, EventArgs e)
        {
            CompleteProfileForm profileForm = new CompleteProfileForm(GetUsername(email));
            profileForm.ShowDialog(); 
        }
        private string user_name = string.Empty;
        private string GetUsername(string email)
        {
            //string user_name = string.Empty;
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT user_name FROM userinfo WHERE email = @email";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        user_name = result.ToString();
                    }
                }
            }
            return user_name;
        }

    }




    public static class InputDialog
    {
        public static string ShowDialog(string text, string caption) //text is the message and caption is the box title 
        {
            Form prompt = new Form(); //new instance idk 
            prompt.Width = 500; //setting size
            prompt.Height = 150;
            prompt.Text = caption; //sets the title of the box to caption

            Label textLabel = new Label() { Left = 50, Top = 20, Text = text }; //creates a lable with the question 
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70 };

            confirmation.Click += (sender, e) => { prompt.Close(); }; //textbox closes and sends input, so if there is like a db input errro fix by restarting process?

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();

            return textBox.Text; //whatever the user inputs 
        }
    }
}
public class Task
{
    public string Name { get; set; }
    public int ProgressPercentage { get; set; }
    public DateTime DueDate { get; set; }
    public string Filename { get; set; }
    public string Id { get; set; }
    public int? ListId { get; set; }

}
