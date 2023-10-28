namespace AlgimedDesktopTest.WindowsFormsImplementation.Views
{
    partial class RegistrationForm
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
            fnLabel = new Label();
            fnTextBox = new TextBox();
            lnLabel = new Label();
            lnTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            confirmLabel = new Label();
            confirmTextBox = new TextBox();
            loginLabel = new Label();
            loginTextBox = new TextBox();
            signUpButton = new Button();
            SuspendLayout();
            // 
            // fnLabel
            // 
            fnLabel.AutoSize = true;
            fnLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fnLabel.Location = new Point(12, 9);
            fnLabel.Name = "fnLabel";
            fnLabel.Size = new Size(89, 21);
            fnLabel.TabIndex = 0;
            fnLabel.Text = "First Name:";
            // 
            // fnTextBox
            // 
            fnTextBox.Location = new Point(107, 7);
            fnTextBox.Name = "fnTextBox";
            fnTextBox.Size = new Size(265, 23);
            fnTextBox.TabIndex = 0;
            // 
            // lnLabel
            // 
            lnLabel.AutoSize = true;
            lnLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lnLabel.Location = new Point(12, 45);
            lnLabel.Name = "lnLabel";
            lnLabel.Size = new Size(87, 21);
            lnLabel.TabIndex = 2;
            lnLabel.Text = "Last Name:";
            // 
            // lnTextBox
            // 
            lnTextBox.Location = new Point(107, 43);
            lnTextBox.Name = "lnTextBox";
            lnTextBox.Size = new Size(265, 23);
            lnTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.Location = new Point(12, 114);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(79, 21);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(107, 112);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(265, 23);
            passwordTextBox.TabIndex = 3;
            // 
            // confirmLabel
            // 
            confirmLabel.AutoSize = true;
            confirmLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            confirmLabel.Location = new Point(12, 149);
            confirmLabel.Name = "confirmLabel";
            confirmLabel.Size = new Size(70, 21);
            confirmLabel.TabIndex = 6;
            confirmLabel.Text = "Confirm:";
            // 
            // confirmTextBox
            // 
            confirmTextBox.Location = new Point(107, 147);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.PasswordChar = '*';
            confirmTextBox.Size = new Size(265, 23);
            confirmTextBox.TabIndex = 4;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.Location = new Point(12, 80);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(52, 21);
            loginLabel.TabIndex = 8;
            loginLabel.Text = "Login:";
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(107, 78);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(265, 23);
            loginTextBox.TabIndex = 2;
            // 
            // signUpButton
            // 
            signUpButton.Location = new Point(107, 276);
            signUpButton.Name = "signUpButton";
            signUpButton.Size = new Size(265, 23);
            signUpButton.TabIndex = 5;
            signUpButton.Text = "Sign Up";
            signUpButton.UseVisualStyleBackColor = true;
            signUpButton.Click += SignUp;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 311);
            Controls.Add(signUpButton);
            Controls.Add(loginTextBox);
            Controls.Add(loginLabel);
            Controls.Add(confirmTextBox);
            Controls.Add(confirmLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(lnTextBox);
            Controls.Add(lnLabel);
            Controls.Add(fnTextBox);
            Controls.Add(fnLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fnLabel;
        private TextBox fnTextBox;
        private Label lnLabel;
        private TextBox lnTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label confirmLabel;
        private TextBox confirmTextBox;
        private Label loginLabel;
        private TextBox loginTextBox;
        private Button signUpButton;
    }
}