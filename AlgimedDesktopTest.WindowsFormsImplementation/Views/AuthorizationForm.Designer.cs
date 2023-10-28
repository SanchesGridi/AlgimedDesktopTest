namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

partial class AuthorizationForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        loginLabel = new Label();
        passwordLabel = new Label();
        loginTextBox = new TextBox();
        passwordTextBox = new TextBox();
        signInButton = new Button();
        questionLabel = new Label();
        signUpButton = new Button();
        authorizationMessageLabel = new Label();
        SuspendLayout();
        // 
        // loginLabel
        // 
        loginLabel.AutoSize = true;
        loginLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        loginLabel.Location = new Point(12, 81);
        loginLabel.Name = "loginLabel";
        loginLabel.Size = new Size(52, 21);
        loginLabel.TabIndex = 0;
        loginLabel.Text = "Login:";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        passwordLabel.Location = new Point(12, 123);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(79, 21);
        passwordLabel.TabIndex = 1;
        passwordLabel.Text = "Password:";
        // 
        // loginTextBox
        // 
        loginTextBox.Location = new Point(102, 79);
        loginTextBox.Name = "loginTextBox";
        loginTextBox.Size = new Size(270, 23);
        loginTextBox.TabIndex = 2;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(102, 121);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new Size(270, 23);
        passwordTextBox.TabIndex = 3;
        // 
        // signInButton
        // 
        signInButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        signInButton.Location = new Point(102, 169);
        signInButton.Name = "signInButton";
        signInButton.Size = new Size(270, 34);
        signInButton.TabIndex = 4;
        signInButton.Text = "Sign In";
        signInButton.UseVisualStyleBackColor = true;
        signInButton.Click += SignIn;
        // 
        // questionLabel
        // 
        questionLabel.AutoSize = true;
        questionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        questionLabel.Location = new Point(149, 218);
        questionLabel.Name = "questionLabel";
        questionLabel.Size = new Size(171, 21);
        questionLabel.TabIndex = 5;
        questionLabel.Text = "Don't have an account?";
        // 
        // signUpButton
        // 
        signUpButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        signUpButton.Location = new Point(102, 253);
        signUpButton.Name = "signUpButton";
        signUpButton.Size = new Size(270, 34);
        signUpButton.TabIndex = 6;
        signUpButton.Text = "Sign Up";
        signUpButton.UseVisualStyleBackColor = true;
        signUpButton.Click += SignUp;
        // 
        // authorizationMessageLabel
        // 
        authorizationMessageLabel.Dock = DockStyle.Top;
        authorizationMessageLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        authorizationMessageLabel.Location = new Point(0, 0);
        authorizationMessageLabel.Name = "authorizationMessageLabel";
        authorizationMessageLabel.Size = new Size(380, 28);
        authorizationMessageLabel.TabIndex = 7;
        authorizationMessageLabel.Text = "Authorization";
        authorizationMessageLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AuthorizationForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ControlLight;
        ClientSize = new Size(380, 307);
        Controls.Add(authorizationMessageLabel);
        Controls.Add(signUpButton);
        Controls.Add(questionLabel);
        Controls.Add(signInButton);
        Controls.Add(passwordTextBox);
        Controls.Add(loginTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(loginLabel);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Margin = new Padding(3, 2, 3, 2);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AuthorizationForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Welcome";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label loginLabel;
    private Label passwordLabel;
    private TextBox loginTextBox;
    private TextBox passwordTextBox;
    private Button signInButton;
    private Label questionLabel;
    private Button signUpButton;
    private Label authorizationMessageLabel;
}