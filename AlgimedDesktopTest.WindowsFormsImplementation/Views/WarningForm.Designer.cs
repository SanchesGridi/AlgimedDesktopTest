namespace AlgimedDesktopTest.WindowsFormsImplementation.Views
{
    partial class WarningForm
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
            messageLabel = new Label();
            itemsListBox = new ListBox();
            okButton = new Button();
            SuspendLayout();
            // 
            // messageLabel
            // 
            messageLabel.Dock = DockStyle.Top;
            messageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            messageLabel.ForeColor = Color.Firebrick;
            messageLabel.Location = new Point(0, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(800, 44);
            messageLabel.TabIndex = 0;
            messageLabel.Text = "These steps will be excluded from being added to the database because their [ModeId] property points to a non-existent Mode in the database!";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // itemsListBox
            // 
            itemsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemsListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            itemsListBox.FormattingEnabled = true;
            itemsListBox.ItemHeight = 21;
            itemsListBox.Location = new Point(0, 59);
            itemsListBox.Margin = new Padding(10);
            itemsListBox.Name = "itemsListBox";
            itemsListBox.Size = new Size(800, 340);
            itemsListBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(0, 415);
            okButton.Name = "okButton";
            okButton.Size = new Size(800, 34);
            okButton.TabIndex = 2;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            // 
            // WarningForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(okButton);
            Controls.Add(itemsListBox);
            Controls.Add(messageLabel);
            Name = "WarningForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Warning";
            Load += LoadWarningForm;
            ResumeLayout(false);
        }

        #endregion

        private Label messageLabel;
        private ListBox itemsListBox;
        private Button okButton;
    }
}