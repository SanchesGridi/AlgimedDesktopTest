namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

partial class StepForm
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
        destinationLabel = new Label();
        destinationTextBox = new TextBox();
        typeLabel = new Label();
        typeTextBox = new TextBox();
        timerLabel = new Label();
        timerNumeric = new NumericUpDown();
        speedLabel = new Label();
        speedNumeric = new NumericUpDown();
        volumeLabel = new Label();
        volumeNumeric = new NumericUpDown();
        modeLabel = new Label();
        modeComboBox = new ComboBox();
        saveButton = new Button();
        ((System.ComponentModel.ISupportInitialize)timerNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)speedNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)volumeNumeric).BeginInit();
        SuspendLayout();
        // 
        // destinationLabel
        // 
        destinationLabel.AutoSize = true;
        destinationLabel.Location = new Point(14, 22);
        destinationLabel.Margin = new Padding(5);
        destinationLabel.Name = "destinationLabel";
        destinationLabel.Padding = new Padding(2);
        destinationLabel.Size = new Size(74, 19);
        destinationLabel.TabIndex = 1;
        destinationLabel.Text = "Destination:";
        // 
        // destinationTextBox
        // 
        destinationTextBox.Location = new Point(142, 18);
        destinationTextBox.Name = "destinationTextBox";
        destinationTextBox.Size = new Size(230, 23);
        destinationTextBox.TabIndex = 2;
        // 
        // typeLabel
        // 
        typeLabel.AutoSize = true;
        typeLabel.Location = new Point(14, 60);
        typeLabel.Margin = new Padding(5);
        typeLabel.Name = "typeLabel";
        typeLabel.Padding = new Padding(2);
        typeLabel.Size = new Size(38, 19);
        typeLabel.TabIndex = 4;
        typeLabel.Text = "Type:";
        // 
        // typeTextBox
        // 
        typeTextBox.Location = new Point(142, 56);
        typeTextBox.Name = "typeTextBox";
        typeTextBox.Size = new Size(230, 23);
        typeTextBox.TabIndex = 5;
        // 
        // timerLabel
        // 
        timerLabel.AutoSize = true;
        timerLabel.Location = new Point(14, 99);
        timerLabel.Margin = new Padding(5);
        timerLabel.Name = "timerLabel";
        timerLabel.Padding = new Padding(2);
        timerLabel.Size = new Size(44, 19);
        timerLabel.TabIndex = 6;
        timerLabel.Text = "Timer:";
        // 
        // timerNumeric
        // 
        timerNumeric.Location = new Point(142, 95);
        timerNumeric.Name = "timerNumeric";
        timerNumeric.Size = new Size(230, 23);
        timerNumeric.TabIndex = 7;
        // 
        // speedLabel
        // 
        speedLabel.AutoSize = true;
        speedLabel.Location = new Point(14, 128);
        speedLabel.Margin = new Padding(5);
        speedLabel.Name = "speedLabel";
        speedLabel.Padding = new Padding(2);
        speedLabel.Size = new Size(46, 19);
        speedLabel.TabIndex = 8;
        speedLabel.Text = "Speed:";
        // 
        // speedNumeric
        // 
        speedNumeric.Location = new Point(142, 124);
        speedNumeric.Name = "speedNumeric";
        speedNumeric.Size = new Size(230, 23);
        speedNumeric.TabIndex = 9;
        // 
        // volumeLabel
        // 
        volumeLabel.AutoSize = true;
        volumeLabel.Location = new Point(14, 157);
        volumeLabel.Margin = new Padding(5);
        volumeLabel.Name = "volumeLabel";
        volumeLabel.Padding = new Padding(2);
        volumeLabel.Size = new Size(54, 19);
        volumeLabel.TabIndex = 10;
        volumeLabel.Text = "Volume:";
        // 
        // volumeNumeric
        // 
        volumeNumeric.Location = new Point(142, 153);
        volumeNumeric.Name = "volumeNumeric";
        volumeNumeric.Size = new Size(230, 23);
        volumeNumeric.TabIndex = 11;
        // 
        // modeLabel
        // 
        modeLabel.AutoSize = true;
        modeLabel.Location = new Point(14, 186);
        modeLabel.Margin = new Padding(5);
        modeLabel.Name = "modeLabel";
        modeLabel.Padding = new Padding(2);
        modeLabel.Size = new Size(59, 19);
        modeLabel.TabIndex = 12;
        modeLabel.Text = "Mode ID:";
        // 
        // modeComboBox
        // 
        modeComboBox.FormattingEnabled = true;
        modeComboBox.Location = new Point(142, 182);
        modeComboBox.Name = "modeComboBox";
        modeComboBox.Size = new Size(230, 23);
        modeComboBox.TabIndex = 13;
        modeComboBox.SelectedValueChanged += SelectedModeIdChanged;
        // 
        // saveButton
        // 
        saveButton.DialogResult = DialogResult.OK;
        saveButton.Location = new Point(142, 226);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(230, 23);
        saveButton.TabIndex = 14;
        saveButton.Text = "Save Item";
        saveButton.UseVisualStyleBackColor = true;
        // 
        // StepForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 261);
        Controls.Add(saveButton);
        Controls.Add(modeComboBox);
        Controls.Add(modeLabel);
        Controls.Add(volumeNumeric);
        Controls.Add(volumeLabel);
        Controls.Add(speedNumeric);
        Controls.Add(speedLabel);
        Controls.Add(timerNumeric);
        Controls.Add(timerLabel);
        Controls.Add(typeTextBox);
        Controls.Add(typeLabel);
        Controls.Add(destinationTextBox);
        Controls.Add(destinationLabel);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "StepForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Step-Item Creation";
        Load += LoadStepForm;
        ((System.ComponentModel.ISupportInitialize)timerNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)speedNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)volumeNumeric).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label destinationLabel;
    private TextBox destinationTextBox;
    private Label typeLabel;
    private TextBox typeTextBox;
    private Label timerLabel;
    private NumericUpDown timerNumeric;
    private Label speedLabel;
    private NumericUpDown speedNumeric;
    private Label volumeLabel;
    private NumericUpDown volumeNumeric;
    private Label modeLabel;
    private ComboBox modeComboBox;
    private Button saveButton;
}