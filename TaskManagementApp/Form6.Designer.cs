namespace TaskManagementApp
{
    partial class AddTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TasknameLabel = new System.Windows.Forms.Label();
            this.DuedateLabel = new System.Windows.Forms.Label();
            this.CreateTaskButton = new System.Windows.Forms.Button();
            this.TasknameInput = new System.Windows.Forms.TextBox();
            this.DueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AddAttachmentButton = new System.Windows.Forms.Button();
            this.Attachment = new System.Windows.Forms.OpenFileDialog();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.ChangefileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TasknameLabel
            // 
            this.TasknameLabel.AutoSize = true;
            this.TasknameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TasknameLabel.Location = new System.Drawing.Point(12, 67);
            this.TasknameLabel.Name = "TasknameLabel";
            this.TasknameLabel.Size = new System.Drawing.Size(130, 32);
            this.TasknameLabel.TabIndex = 1;
            this.TasknameLabel.Text = "Task name:";
            // 
            // DuedateLabel
            // 
            this.DuedateLabel.AutoSize = true;
            this.DuedateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DuedateLabel.Location = new System.Drawing.Point(12, 213);
            this.DuedateLabel.Name = "DuedateLabel";
            this.DuedateLabel.Size = new System.Drawing.Size(120, 32);
            this.DuedateLabel.TabIndex = 2;
            this.DuedateLabel.Text = "Due Date:";
            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTaskButton.Location = new System.Drawing.Point(151, 582);
            this.CreateTaskButton.Name = "CreateTaskButton";
            this.CreateTaskButton.Size = new System.Drawing.Size(196, 38);
            this.CreateTaskButton.TabIndex = 4;
            this.CreateTaskButton.Text = "Create Task";
            this.CreateTaskButton.UseVisualStyleBackColor = true;
            this.CreateTaskButton.Click += new System.EventHandler(this.CreateTaskButton_Click);
            // 
            // TasknameInput
            // 
            this.TasknameInput.Location = new System.Drawing.Point(170, 73);
            this.TasknameInput.Name = "TasknameInput";
            this.TasknameInput.Size = new System.Drawing.Size(304, 26);
            this.TasknameInput.TabIndex = 5;
            // 
            // DueDatePicker
            // 
            this.DueDatePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DueDatePicker.Location = new System.Drawing.Point(170, 219);
            this.DueDatePicker.Name = "DueDatePicker";
            this.DueDatePicker.Size = new System.Drawing.Size(319, 26);
            this.DueDatePicker.TabIndex = 6;
            // 
            // AddAttachmentButton
            // 
            this.AddAttachmentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAttachmentButton.Location = new System.Drawing.Point(12, 364);
            this.AddAttachmentButton.Name = "AddAttachmentButton";
            this.AddAttachmentButton.Size = new System.Drawing.Size(220, 53);
            this.AddAttachmentButton.TabIndex = 7;
            this.AddAttachmentButton.Text = "Add Attachment:";
            this.AddAttachmentButton.UseCompatibleTextRendering = true;
            this.AddAttachmentButton.UseVisualStyleBackColor = true;
            this.AddAttachmentButton.Click += new System.EventHandler(this.AddAttachmentButton_Click);
            // 
            // Attachment
            // 
            this.Attachment.FileName = "SelectedFile";
            this.Attachment.Filter = "\"All Files|*.*|Text Files|*.txt|Image Files|*.jpg;*.png\"";
            this.Attachment.Title = "Select a file";
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoEllipsis = true;
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilenameLabel.Location = new System.Drawing.Point(12, 440);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(206, 32);
            this.FilenameLabel.TabIndex = 8;
            this.FilenameLabel.Text = "\"No File Selected\"";
            // 
            // ChangefileButton
            // 
            this.ChangefileButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangefileButton.Location = new System.Drawing.Point(18, 501);
            this.ChangefileButton.Name = "ChangefileButton";
            this.ChangefileButton.Size = new System.Drawing.Size(126, 32);
            this.ChangefileButton.TabIndex = 9;
            this.ChangefileButton.Text = "Change File";
            this.ChangefileButton.UseVisualStyleBackColor = true;
            this.ChangefileButton.Click += new System.EventHandler(this.ChangefileButton_Click);
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 680);
            this.Controls.Add(this.ChangefileButton);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.AddAttachmentButton);
            this.Controls.Add(this.DueDatePicker);
            this.Controls.Add(this.TasknameInput);
            this.Controls.Add(this.CreateTaskButton);
            this.Controls.Add(this.DuedateLabel);
            this.Controls.Add(this.TasknameLabel);
            this.Name = "AddTask";
            this.Text = "Add a Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TasknameLabel;
        private System.Windows.Forms.Label DuedateLabel;
        private System.Windows.Forms.Button CreateTaskButton;
        private System.Windows.Forms.TextBox TasknameInput;
        private System.Windows.Forms.DateTimePicker DueDatePicker;
        private System.Windows.Forms.Button AddAttachmentButton;
        private System.Windows.Forms.OpenFileDialog Attachment;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.Button ChangefileButton;
    }
}