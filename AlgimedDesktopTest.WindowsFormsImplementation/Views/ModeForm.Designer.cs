namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

partial class ModeForm
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
        nameLabel = new Label();
        bottlesNumeric = new NumericUpDown();
        nameTextBox = new TextBox();
        bottlesLabel = new Label();
        tipsLabel = new Label();
        tipsNumeric = new NumericUpDown();
        saveButton = new Button();
        ((System.ComponentModel.ISupportInitialize)bottlesNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tipsNumeric).BeginInit();
        SuspendLayout();
        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(14, 22);
        nameLabel.Margin = new Padding(5);
        nameLabel.Name = "nameLabel";
        nameLabel.Padding = new Padding(2);
        nameLabel.Size = new Size(46, 19);
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Name:";
        // 
        // bottlesNumeric
        // 
        bottlesNumeric.Location = new Point(142, 56);
        bottlesNumeric.Name = "bottlesNumeric";
        bottlesNumeric.Size = new Size(230, 23);
        bottlesNumeric.TabIndex = 1;
        // 
        // nameTextBox
        // 
        nameTextBox.Location = new Point(142, 18);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(230, 23);
        nameTextBox.TabIndex = 0;
        // 
        // bottlesLabel
        // 
        bottlesLabel.AutoSize = true;
        bottlesLabel.Location = new Point(14, 60);
        bottlesLabel.Margin = new Padding(5);
        bottlesLabel.Name = "bottlesLabel";
        bottlesLabel.Padding = new Padding(2);
        bottlesLabel.Size = new Size(50, 19);
        bottlesLabel.TabIndex = 3;
        bottlesLabel.Text = "Bottles:";
        // 
        // tipsLabel
        // 
        tipsLabel.AutoSize = true;
        tipsLabel.Location = new Point(14, 99);
        tipsLabel.Margin = new Padding(5);
        tipsLabel.Name = "tipsLabel";
        tipsLabel.Padding = new Padding(2);
        tipsLabel.Size = new Size(35, 19);
        tipsLabel.TabIndex = 4;
        tipsLabel.Text = "Tips:";
        // 
        // tipsNumeric
        // 
        tipsNumeric.Location = new Point(142, 95);
        tipsNumeric.Name = "tipsNumeric";
        tipsNumeric.Size = new Size(230, 23);
        tipsNumeric.TabIndex = 2;
        // 
        // saveButton
        // 
        saveButton.DialogResult = DialogResult.OK;
        saveButton.Location = new Point(142, 144);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(230, 23);
        saveButton.TabIndex = 3;
        saveButton.Text = "Save Item";
        saveButton.UseVisualStyleBackColor = true;
        // 
        // ModeForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 191);
        Controls.Add(saveButton);
        Controls.Add(tipsNumeric);
        Controls.Add(tipsLabel);
        Controls.Add(bottlesLabel);
        Controls.Add(nameTextBox);
        Controls.Add(bottlesNumeric);
        Controls.Add(nameLabel);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ModeForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Mode-Item Creation";
        Load += LoadModeForm;
        ((System.ComponentModel.ISupportInitialize)bottlesNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)tipsNumeric).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label nameLabel;
    private NumericUpDown bottlesNumeric;
    private TextBox nameTextBox;
    private Label bottlesLabel;
    private Label tipsLabel;
    private NumericUpDown tipsNumeric;
    private Button saveButton;
}