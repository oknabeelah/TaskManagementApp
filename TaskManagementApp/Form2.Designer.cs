namespace TaskManagementApp
{
    partial class LoginPage
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
            this.LogIn = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.EmailInput = new System.Windows.Forms.TextBox();
            this.Emaillabel = new System.Windows.Forms.Label();
            this.Passwordlabel = new System.Windows.Forms.Label();
            this.Submitbutton = new System.Windows.Forms.Button();
            this.Signupredirect = new System.Windows.Forms.Button();
            this.Forgotpasswordlabel = new System.Windows.Forms.Label();
            this.Forgotpwdllabel = new System.Windows.Forms.LinkLabel();
            this.ShowPwdBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LogIn
            // 
            this.LogIn.AutoSize = true;
            this.LogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogIn.Location = new System.Drawing.Point(221, 178);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(105, 37);
            this.LogIn.TabIndex = 0;
            this.LogIn.Text = "Log in";
            // 
            // PasswordInput
            // 
            this.PasswordInput.AcceptsTab = true;
            this.PasswordInput.Location = new System.Drawing.Point(152, 429);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(298, 26);
            this.PasswordInput.TabIndex = 3;
            this.PasswordInput.UseSystemPasswordChar = true;
            // 
            // EmailInput
            // 
            this.EmailInput.AcceptsTab = true;
            this.EmailInput.Location = new System.Drawing.Point(152, 303);
            this.EmailInput.Name = "EmailInput";
            this.EmailInput.Size = new System.Drawing.Size(298, 26);
            this.EmailInput.TabIndex = 4;
            // 
            // Emaillabel
            // 
            this.Emaillabel.AutoSize = true;
            this.Emaillabel.Location = new System.Drawing.Point(152, 245);
            this.Emaillabel.Name = "Emaillabel";
            this.Emaillabel.Size = new System.Drawing.Size(52, 20);
            this.Emaillabel.TabIndex = 5;
            this.Emaillabel.Text = "Email:";
            // 
            // Passwordlabel
            // 
            this.Passwordlabel.AutoSize = true;
            this.Passwordlabel.Location = new System.Drawing.Point(152, 373);
            this.Passwordlabel.Name = "Passwordlabel";
            this.Passwordlabel.Size = new System.Drawing.Size(82, 20);
            this.Passwordlabel.TabIndex = 6;
            this.Passwordlabel.Text = "Password:";
            // 
            // Submitbutton
            // 
            this.Submitbutton.Location = new System.Drawing.Point(228, 551);
            this.Submitbutton.Name = "Submitbutton";
            this.Submitbutton.Size = new System.Drawing.Size(108, 50);
            this.Submitbutton.TabIndex = 7;
            this.Submitbutton.Text = "Submit";
            this.Submitbutton.UseVisualStyleBackColor = true;
            this.Submitbutton.Click += new System.EventHandler(this.Submitbutton_Click);
            // 
            // Signupredirect
            // 
            this.Signupredirect.Location = new System.Drawing.Point(472, 612);
            this.Signupredirect.Name = "Signupredirect";
            this.Signupredirect.Size = new System.Drawing.Size(108, 50);
            this.Signupredirect.TabIndex = 8;
            this.Signupredirect.Text = "Sign up";
            this.Signupredirect.UseVisualStyleBackColor = true;
            this.Signupredirect.Click += new System.EventHandler(this.Signupredirect_Click);
            // 
            // Forgotpasswordlabel
            // 
            this.Forgotpasswordlabel.AutoSize = true;
            this.Forgotpasswordlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgotpasswordlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Forgotpasswordlabel.Location = new System.Drawing.Point(152, 495);
            this.Forgotpasswordlabel.Name = "Forgotpasswordlabel";
            this.Forgotpasswordlabel.Size = new System.Drawing.Size(0, 20);
            this.Forgotpasswordlabel.TabIndex = 9;
            // 
            // Forgotpwdllabel
            // 
            this.Forgotpwdllabel.AutoSize = true;
            this.Forgotpwdllabel.Location = new System.Drawing.Point(152, 511);
            this.Forgotpwdllabel.Name = "Forgotpwdllabel";
            this.Forgotpwdllabel.Size = new System.Drawing.Size(132, 20);
            this.Forgotpwdllabel.TabIndex = 10;
            this.Forgotpwdllabel.TabStop = true;
            this.Forgotpwdllabel.Text = "forgot password?";
            // 
            // ShowPwdBox
            // 
            this.ShowPwdBox.AutoSize = true;
            this.ShowPwdBox.Location = new System.Drawing.Point(152, 468);
            this.ShowPwdBox.Name = "ShowPwdBox";
            this.ShowPwdBox.Size = new System.Drawing.Size(144, 24);
            this.ShowPwdBox.TabIndex = 11;
            this.ShowPwdBox.Text = "show password";
            this.ShowPwdBox.UseVisualStyleBackColor = true;
            this.ShowPwdBox.CheckedChanged += new System.EventHandler(this.ShowPwdBox_CheckedChanged);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 703);
            this.Controls.Add(this.ShowPwdBox);
            this.Controls.Add(this.Forgotpwdllabel);
            this.Controls.Add(this.Forgotpasswordlabel);
            this.Controls.Add(this.Signupredirect);
            this.Controls.Add(this.Submitbutton);
            this.Controls.Add(this.Passwordlabel);
            this.Controls.Add(this.Emaillabel);
            this.Controls.Add(this.EmailInput);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.LogIn);
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogIn;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.TextBox EmailInput;
        private System.Windows.Forms.Label Emaillabel;
        private System.Windows.Forms.Label Passwordlabel;
        private System.Windows.Forms.Button Submitbutton;
        private System.Windows.Forms.Button Signupredirect;
        private System.Windows.Forms.Label Forgotpasswordlabel;
        private System.Windows.Forms.LinkLabel Forgotpwdllabel;
        private System.Windows.Forms.CheckBox ShowPwdBox;
    }
}