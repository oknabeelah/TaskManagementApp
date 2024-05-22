namespace TaskManagementApp
{
    partial class CreateGroupform
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
            this.coverimage = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupnameLabel = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.CreategroupButton = new System.Windows.Forms.Button();
            this.groupnameInput = new System.Windows.Forms.TextBox();
            this.descInput = new System.Windows.Forms.TextBox();
            this.AddmembersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coverimage
            // 
            this.coverimage.Location = new System.Drawing.Point(0, 0);
            this.coverimage.Name = "coverimage";
            this.coverimage.Size = new System.Drawing.Size(837, 132);
            this.coverimage.TabIndex = 0;
            // 
            // GroupnameLabel
            // 
            this.GroupnameLabel.AutoSize = true;
            this.GroupnameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupnameLabel.Location = new System.Drawing.Point(30, 173);
            this.GroupnameLabel.Name = "GroupnameLabel";
            this.GroupnameLabel.Size = new System.Drawing.Size(156, 32);
            this.GroupnameLabel.TabIndex = 1;
            this.GroupnameLabel.Text = "Group Name:";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescLabel.Location = new System.Drawing.Point(30, 261);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(140, 32);
            this.DescLabel.TabIndex = 2;
            this.DescLabel.Text = "Description:";
            // 
            // CreategroupButton
            // 
            this.CreategroupButton.Location = new System.Drawing.Point(318, 579);
            this.CreategroupButton.Name = "CreategroupButton";
            this.CreategroupButton.Size = new System.Drawing.Size(122, 58);
            this.CreategroupButton.TabIndex = 3;
            this.CreategroupButton.Text = "Create";
            this.CreategroupButton.UseVisualStyleBackColor = true;
            // 
            // groupnameInput
            // 
            this.groupnameInput.Location = new System.Drawing.Point(229, 173);
            this.groupnameInput.Name = "groupnameInput";
            this.groupnameInput.Size = new System.Drawing.Size(378, 26);
            this.groupnameInput.TabIndex = 4;
            // 
            // descInput
            // 
            this.descInput.Location = new System.Drawing.Point(229, 261);
            this.descInput.Name = "descInput";
            this.descInput.Size = new System.Drawing.Size(378, 26);
            this.descInput.TabIndex = 5;
            // 
            // AddmembersLabel
            // 
            this.AddmembersLabel.AutoSize = true;
            this.AddmembersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddmembersLabel.Location = new System.Drawing.Point(30, 341);
            this.AddmembersLabel.Name = "AddmembersLabel";
            this.AddmembersLabel.Size = new System.Drawing.Size(254, 48);
            this.AddmembersLabel.TabIndex = 6;
            this.AddmembersLabel.Text = "Add members:";
            // 
            // CreateGroupform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 649);
            this.Controls.Add(this.AddmembersLabel);
            this.Controls.Add(this.descInput);
            this.Controls.Add(this.groupnameInput);
            this.Controls.Add(this.CreategroupButton);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.GroupnameLabel);
            this.Controls.Add(this.coverimage);
            this.Name = "CreateGroupform";
            this.Text = "Create group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel coverimage;
        private System.Windows.Forms.Label GroupnameLabel;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.Button CreategroupButton;
        private System.Windows.Forms.TextBox groupnameInput;
        private System.Windows.Forms.TextBox descInput;
        private System.Windows.Forms.Label AddmembersLabel;
    }
}