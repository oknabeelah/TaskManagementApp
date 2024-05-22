namespace TaskManagementApp
{
    partial class CreateForm
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
            this.CreateLabel = new System.Windows.Forms.Label();
            this.CreateListButton = new System.Windows.Forms.Button();
            this.CreateGroupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateLabel
            // 
            this.CreateLabel.AutoSize = true;
            this.CreateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateLabel.Location = new System.Drawing.Point(169, 36);
            this.CreateLabel.Name = "CreateLabel";
            this.CreateLabel.Size = new System.Drawing.Size(94, 32);
            this.CreateLabel.TabIndex = 0;
            this.CreateLabel.Text = "Create?";
            // 
            // CreateListButton
            // 
            this.CreateListButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateListButton.Location = new System.Drawing.Point(79, 124);
            this.CreateListButton.Name = "CreateListButton";
            this.CreateListButton.Size = new System.Drawing.Size(133, 49);
            this.CreateListButton.TabIndex = 1;
            this.CreateListButton.Text = "List";
            this.CreateListButton.UseVisualStyleBackColor = true;
            this.CreateListButton.Click += new System.EventHandler(this.CreateListButton_Click);
            // 
            // CreateGroupButton
            // 
            this.CreateGroupButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGroupButton.Location = new System.Drawing.Point(250, 124);
            this.CreateGroupButton.Name = "CreateGroupButton";
            this.CreateGroupButton.Size = new System.Drawing.Size(133, 49);
            this.CreateGroupButton.TabIndex = 2;
            this.CreateGroupButton.Text = "Group";
            this.CreateGroupButton.UseVisualStyleBackColor = true;
            this.CreateGroupButton.Click += new System.EventHandler(this.CreateGroupButton_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 222);
            this.Controls.Add(this.CreateGroupButton);
            this.Controls.Add(this.CreateListButton);
            this.Controls.Add(this.CreateLabel);
            this.Name = "CreateForm";
            this.Text = "Create";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreateLabel;
        private System.Windows.Forms.Button CreateListButton;
        private System.Windows.Forms.Button CreateGroupButton;
    }
}