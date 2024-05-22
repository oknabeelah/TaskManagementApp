namespace TaskManagementApp
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.SidebarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.MenuButton = new System.Windows.Forms.PictureBox();
            this.HomeContainer = new System.Windows.Forms.Panel();
            this.HomeButton = new System.Windows.Forms.Button();
            this.SubMenuButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.CompleteprofileButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.SidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.DropMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.TaskbarPanel = new System.Windows.Forms.Panel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.PictureBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.Bell = new System.Windows.Forms.PictureBox();
            this.ProfilePicBox = new Whole_Saler.forms.CircularPictureBox();
            this.DashboardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SidebarPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuButton)).BeginInit();
            this.HomeContainer.SuspendLayout();
            this.TaskbarPanel.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.BackColor = System.Drawing.Color.Gray;
            this.SidebarPanel.Controls.Add(this.MenuPanel);
            this.SidebarPanel.Controls.Add(this.HomeContainer);
            this.SidebarPanel.Controls.Add(this.SettingsButton);
            this.SidebarPanel.Controls.Add(this.CompleteprofileButton);
            this.SidebarPanel.Controls.Add(this.LogoutButton);
            this.SidebarPanel.Controls.Add(this.WelcomeLabel);
            this.SidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.SidebarPanel.MaximumSize = new System.Drawing.Size(396, 1024);
            this.SidebarPanel.MinimumSize = new System.Drawing.Size(90, 1024);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Size = new System.Drawing.Size(396, 1024);
            this.SidebarPanel.TabIndex = 0;
            this.SidebarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.MenuLabel);
            this.MenuPanel.Controls.Add(this.MenuButton);
            this.MenuPanel.Location = new System.Drawing.Point(3, 3);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(534, 236);
            this.MenuPanel.TabIndex = 0;
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLabel.ForeColor = System.Drawing.Color.White;
            this.MenuLabel.Location = new System.Drawing.Point(113, 49);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(77, 32);
            this.MenuLabel.TabIndex = 1;
            this.MenuLabel.Text = "Menu";
            // 
            // MenuButton
            // 
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuButton.Image")));
            this.MenuButton.Location = new System.Drawing.Point(25, 49);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(52, 51);
            this.MenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MenuButton.TabIndex = 0;
            this.MenuButton.TabStop = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // HomeContainer
            // 
            this.HomeContainer.Controls.Add(this.HomeButton);
            this.HomeContainer.Controls.Add(this.SubMenuButton);
            this.HomeContainer.Location = new System.Drawing.Point(3, 245);
            this.HomeContainer.MaximumSize = new System.Drawing.Size(527, 190);
            this.HomeContainer.MinimumSize = new System.Drawing.Size(527, 91);
            this.HomeContainer.Name = "HomeContainer";
            this.HomeContainer.Size = new System.Drawing.Size(527, 101);
            this.HomeContainer.TabIndex = 3;
            // 
            // HomeButton
            // 
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(-3, 3);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.HomeButton.Size = new System.Drawing.Size(528, 99);
            this.HomeButton.TabIndex = 3;
            this.HomeButton.Text = "          Home";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // SubMenuButton
            // 
            this.SubMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubMenuButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubMenuButton.ForeColor = System.Drawing.Color.White;
            this.SubMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("SubMenuButton.Image")));
            this.SubMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubMenuButton.Location = new System.Drawing.Point(0, 99);
            this.SubMenuButton.Name = "SubMenuButton";
            this.SubMenuButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.SubMenuButton.Size = new System.Drawing.Size(528, 91);
            this.SubMenuButton.TabIndex = 4;
            this.SubMenuButton.Text = "          Groups";
            this.SubMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubMenuButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.Location = new System.Drawing.Point(3, 352);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.SettingsButton.Size = new System.Drawing.Size(528, 91);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "          Settings";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.UseVisualStyleBackColor = true;
            // 
            // CompleteprofileButton
            // 
            this.CompleteprofileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteprofileButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteprofileButton.ForeColor = System.Drawing.Color.White;
            this.CompleteprofileButton.Image = ((System.Drawing.Image)(resources.GetObject("CompleteprofileButton.Image")));
            this.CompleteprofileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CompleteprofileButton.Location = new System.Drawing.Point(3, 449);
            this.CompleteprofileButton.Name = "CompleteprofileButton";
            this.CompleteprofileButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.CompleteprofileButton.Size = new System.Drawing.Size(528, 91);
            this.CompleteprofileButton.TabIndex = 5;
            this.CompleteprofileButton.Text = "          Complete your profile";
            this.CompleteprofileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CompleteprofileButton.UseVisualStyleBackColor = true;
            this.CompleteprofileButton.Click += new System.EventHandler(this.CompleteprofileButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.ForeColor = System.Drawing.Color.White;
            this.LogoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogoutButton.Image")));
            this.LogoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogoutButton.Location = new System.Drawing.Point(3, 546);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.LogoutButton.Size = new System.Drawing.Size(528, 91);
            this.LogoutButton.TabIndex = 6;
            this.LogoutButton.Text = "          Logout";
            this.LogoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(3, 640);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(156, 32);
            this.WelcomeLabel.TabIndex = 1;
            this.WelcomeLabel.Text = "WelcomeText";
            // 
            // SidebarTimer
            // 
            this.SidebarTimer.Interval = 10;
            this.SidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);
            // 
            // DropMenuTimer
            // 
            this.DropMenuTimer.Interval = 10;
            this.DropMenuTimer.Tick += new System.EventHandler(this.DropMenuTimer_Tick);
            // 
            // TaskbarPanel
            // 
            this.TaskbarPanel.BackColor = System.Drawing.Color.Gray;
            this.TaskbarPanel.Controls.Add(this.CreateButton);
            this.TaskbarPanel.Controls.Add(this.SearchPanel);
            this.TaskbarPanel.Controls.Add(this.Bell);
            this.TaskbarPanel.Controls.Add(this.ProfilePicBox);
            this.TaskbarPanel.Location = new System.Drawing.Point(399, 3);
            this.TaskbarPanel.Name = "TaskbarPanel";
            this.TaskbarPanel.Size = new System.Drawing.Size(1547, 67);
            this.TaskbarPanel.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(836, 17);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(105, 33);
            this.CreateButton.TabIndex = 7;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.Search);
            this.SearchPanel.Controls.Add(this.SearchBox);
            this.SearchPanel.Location = new System.Drawing.Point(965, 17);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(392, 33);
            this.SearchPanel.TabIndex = 6;
            // 
            // Search
            // 
            this.Search.Image = ((System.Drawing.Image)(resources.GetObject("Search.Image")));
            this.Search.Location = new System.Drawing.Point(3, 3);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(26, 26);
            this.Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Search.TabIndex = 5;
            this.Search.TabStop = false;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(33, 4);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(354, 26);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.Text = "Search";
            // 
            // Bell
            // 
            this.Bell.Image = ((System.Drawing.Image)(resources.GetObject("Bell.Image")));
            this.Bell.Location = new System.Drawing.Point(1422, 21);
            this.Bell.Name = "Bell";
            this.Bell.Size = new System.Drawing.Size(26, 26);
            this.Bell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Bell.TabIndex = 3;
            this.Bell.TabStop = false;
            // 
            // ProfilePicBox
            // 
            this.ProfilePicBox.BackColor = System.Drawing.Color.White;
            this.ProfilePicBox.Location = new System.Drawing.Point(1496, 9);
            this.ProfilePicBox.Name = "ProfilePicBox";
            this.ProfilePicBox.Size = new System.Drawing.Size(48, 47);
            this.ProfilePicBox.TabIndex = 2;
            this.ProfilePicBox.TabStop = false;
            // 
            // DashboardPanel
            // 
            this.DashboardPanel.AllowDrop = true;
            this.DashboardPanel.AutoScroll = true;
            this.DashboardPanel.BackColor = System.Drawing.Color.LightGray;
            this.DashboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DashboardPanel.Location = new System.Drawing.Point(402, 76);
            this.DashboardPanel.Name = "DashboardPanel";
            this.DashboardPanel.Size = new System.Drawing.Size(1541, 948);
            this.DashboardPanel.TabIndex = 2;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1951, 1051);
            this.Controls.Add(this.DashboardPanel);
            this.Controls.Add(this.TaskbarPanel);
            this.Controls.Add(this.SidebarPanel);
            this.Name = "Form5";
            this.Text = "Dashboard";
            this.SidebarPanel.ResumeLayout(false);
            this.SidebarPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuButton)).EndInit();
            this.HomeContainer.ResumeLayout(false);
            this.TaskbarPanel.ResumeLayout(false);
            this.TaskbarPanel.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SidebarPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button SettingsButton;
        private new System.Windows.Forms.Button CompleteprofileButton; //error CS0108, solved by adding 'new' not sure why
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.PictureBox MenuButton;
        private System.Windows.Forms.Timer SidebarTimer;
        private System.Windows.Forms.Panel HomeContainer;
        private System.Windows.Forms.Button SubMenuButton;
        private System.Windows.Forms.Timer DropMenuTimer;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Panel TaskbarPanel;
        private Whole_Saler.forms.CircularPictureBox ProfilePicBox;
        private System.Windows.Forms.PictureBox Bell;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.PictureBox Search;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.FlowLayoutPanel DashboardPanel;
    }
}