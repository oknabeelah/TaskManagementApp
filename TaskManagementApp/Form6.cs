using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class AddTask : Form
    {
        private string connString = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;Username=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
        private string Filepath;
        private int? listId; //use sent list id in from form 5
        public bool TaskCreated { get; private set; }
        public AddTask(int? listId)
        {
            InitializeComponent();
            this.listId = listId;
        }
        
        private void AddAttachmentButton_Click(object sender, EventArgs e)
        {
            var result = Attachment.ShowDialog();
            if (result == DialogResult.OK)
            {
                 Filepath = Attachment.FileName; // Store the selected folder path
                FilenameLabel.Text = $"Selected file: {Path.GetFileName(Filepath)}"; //display file name
            }
        }
         
        private void CreateTaskButton_Click(object sender, EventArgs e)
        {
            //collect info from page
            string Taskname = TasknameInput.Text.Trim();
            DateTime Duedate = DueDatePicker.Value;
            int? Attachmentid = null;
            int Progress = 0;

            if (string.IsNullOrEmpty(Taskname))
            {
                MessageBox.Show("Task name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //insert attachment record if available
            if (Attachment.FileName != "")
            {
                Attachmentid = UploadAttachment(Filepath); //method to upload and return attachment id
            }
            //write out sql query and insert into db
            try
            {
                using (var connection = new NpgsqlConnection(connString))
                {
                    connection.Open();
                    string InsertTask = "INSERT INTO usertaskinfo (task_name, due_date, attachment_id, progress_percentage, member_task_id) VALUES (@Taskname, @Duedate, @Attachmentid, @Progress, 0) RETURNING user_task_id";
                    var command = new NpgsqlCommand(InsertTask, connection);
                    command.Parameters.AddWithValue("@Taskname", Taskname);
                    command.Parameters.AddWithValue("@Duedate", Duedate);
                    command.Parameters.AddWithValue("@Attachmentid", (object)Attachmentid ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Progress", Progress);

                    int usertaskID = (int)command.ExecuteScalar(); //// Get the primary key of the new task

                    // Update the member_task_id to be the same as the user_task_id
                    string updateTask = "UPDATE usertaskinfo SET member_task_id = @UsertaskID WHERE user_task_id = @UsertaskID";

                    var updateCommand = new NpgsqlCommand(updateTask, connection);

                    updateCommand.Parameters.AddWithValue("@UserTaskId", usertaskID);
                    
                    updateCommand.ExecuteNonQuery();

                    // Insert into usertaskmembershipinfo to link the task to the specified list
                    string InsertMemberLink = "INSERT INTO usertaskmembershipinfo (member_task_id, user_list_id, user_task_id) VALUES (@MemberTaskId, @UserListId, @UserTaskId)";

                    var insertmembershipCommand = new NpgsqlCommand(InsertMemberLink, connection);
                    insertmembershipCommand.Parameters.AddWithValue("@MemberTaskId", usertaskID);
                    insertmembershipCommand.Parameters.AddWithValue("@UserListId", listId); //pass the list id from the add task form
                    insertmembershipCommand.Parameters.AddWithValue("@UserTaskId", usertaskID); //make sure theyre equal

                    int rowsAffected = insertmembershipCommand.ExecuteNonQuery();

                    //message box
                    if (rowsAffected > 0) 
                    {
                        MessageBox.Show("Task successfully created ad linked to the list!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaskCreated = true; // Set to true when a task is created successfully                       
                        this.Close(); //closes this form

                        // Add logic to update the dashboard or reload data
                        //refresh list on dashboard
                    }
                    else
                    {
                        MessageBox.Show("Failed to create a link to list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? UploadAttachment(string Filepath)
        {
            if (string.IsNullOrEmpty(Filepath))
            {
                //throw new ArgumentException("Filepath cannot be null or empty", nameof(Filepath));
                // continue t create task and return null for attachment id
                return null;
            }

            byte[] FileData; //declaring

            // Read the file data into a byte array
            using (var fileStream = new FileStream(Filepath, FileMode.Open, FileAccess.Read))
            {
                FileData = new byte[fileStream.Length];
                fileStream.Read(FileData, 0, FileData.Length);
            }

            int attachmentID = 0; //declaring and initialising

            // Insert the attachment into the database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                string insertAttachment = "INSERT INTO attachmentinfo (file_name, file_type, uploaded_file) " +
                                          "VALUES (@FileName, @FileType, @FileData) " +
                                          "RETURNING attachment_id";

                using (var command = new NpgsqlCommand(insertAttachment, connection))
                {
                    var fileName = Path.GetFileName(Filepath); //extract name
                    var fileType = Path.GetExtension(Filepath); //extract type 

                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@FileType", fileType);
                    command.Parameters.AddWithValue("@FileData", FileData);

                    // Get the attachment_id after the record is inserted
                    attachmentID = (int)command.ExecuteScalar();
                }
            }
            return attachmentID; // Return the ID of the inserted attachment
        }

        private void ChangefileButton_Click(object sender, EventArgs e)
        {
            AddAttachmentButton_Click(sender, e);
        }
    }
}
