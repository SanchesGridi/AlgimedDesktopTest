namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

partial class ItemsForm : Form
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
        components = new System.ComponentModel.Container();
        itemsTabControl = new TabControl();
        tabPageModes = new TabPage();
        dataGrid_Modes = new DataGridView();
        idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        maxBottleNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        maxUsedTipsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        stepsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        modeEntityBindingSource = new BindingSource(components);
        tabPageSteps = new TabPage();
        dataGrid_Steps = new DataGridView();
        idDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        timerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        destinationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        speedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        volumeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        modeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        modeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        stepEntityBindingSource = new BindingSource(components);
        labelForTips = new Label();
        addItemButton = new Button();
        removeItemButton = new Button();
        profileLabel = new Label();
        userNameLabel = new Label();
        loadXlsxButton = new Button();
        itemsTabControl.SuspendLayout();
        tabPageModes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGrid_Modes).BeginInit();
        ((System.ComponentModel.ISupportInitialize)modeEntityBindingSource).BeginInit();
        tabPageSteps.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGrid_Steps).BeginInit();
        ((System.ComponentModel.ISupportInitialize)stepEntityBindingSource).BeginInit();
        SuspendLayout();
        // 
        // itemsTabControl
        // 
        itemsTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        itemsTabControl.Controls.Add(tabPageModes);
        itemsTabControl.Controls.Add(tabPageSteps);
        itemsTabControl.Location = new Point(3, 89);
        itemsTabControl.Margin = new Padding(3, 2, 3, 2);
        itemsTabControl.Name = "itemsTabControl";
        itemsTabControl.SelectedIndex = 0;
        itemsTabControl.Size = new Size(940, 318);
        itemsTabControl.TabIndex = 3;
        // 
        // tabPageModes
        // 
        tabPageModes.Controls.Add(dataGrid_Modes);
        tabPageModes.Location = new Point(4, 24);
        tabPageModes.Margin = new Padding(3, 2, 3, 2);
        tabPageModes.Name = "tabPageModes";
        tabPageModes.Padding = new Padding(3, 2, 3, 2);
        tabPageModes.Size = new Size(932, 290);
        tabPageModes.TabIndex = 0;
        tabPageModes.Text = "Modes";
        tabPageModes.UseVisualStyleBackColor = true;
        // 
        // dataGrid_Modes
        // 
        dataGrid_Modes.AllowUserToAddRows = false;
        dataGrid_Modes.AllowUserToDeleteRows = false;
        dataGrid_Modes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGrid_Modes.AutoGenerateColumns = false;
        dataGrid_Modes.BackgroundColor = SystemColors.Control;
        dataGrid_Modes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGrid_Modes.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, maxBottleNumberDataGridViewTextBoxColumn, maxUsedTipsDataGridViewTextBoxColumn, stepsDataGridViewTextBoxColumn });
        dataGrid_Modes.DataSource = modeEntityBindingSource;
        dataGrid_Modes.Location = new Point(3, 2);
        dataGrid_Modes.Margin = new Padding(3, 2, 3, 2);
        dataGrid_Modes.MultiSelect = false;
        dataGrid_Modes.Name = "dataGrid_Modes";
        dataGrid_Modes.RowHeadersWidth = 51;
        dataGrid_Modes.RowTemplate.Height = 29;
        dataGrid_Modes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGrid_Modes.Size = new Size(928, 289);
        dataGrid_Modes.TabIndex = 4;
        dataGrid_Modes.Tag = "Modes";
        dataGrid_Modes.RowHeaderMouseDoubleClick += UpdateRow;
        // 
        // idDataGridViewTextBoxColumn
        // 
        idDataGridViewTextBoxColumn.DataPropertyName = "Id";
        idDataGridViewTextBoxColumn.HeaderText = "Id";
        idDataGridViewTextBoxColumn.MinimumWidth = 6;
        idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
        idDataGridViewTextBoxColumn.ReadOnly = true;
        idDataGridViewTextBoxColumn.Width = 125;
        // 
        // nameDataGridViewTextBoxColumn
        // 
        nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
        nameDataGridViewTextBoxColumn.HeaderText = "Name";
        nameDataGridViewTextBoxColumn.MinimumWidth = 6;
        nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
        nameDataGridViewTextBoxColumn.Width = 125;
        // 
        // maxBottleNumberDataGridViewTextBoxColumn
        // 
        maxBottleNumberDataGridViewTextBoxColumn.DataPropertyName = "MaxBottleNumber";
        maxBottleNumberDataGridViewTextBoxColumn.HeaderText = "MaxBottleNumber";
        maxBottleNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
        maxBottleNumberDataGridViewTextBoxColumn.Name = "maxBottleNumberDataGridViewTextBoxColumn";
        maxBottleNumberDataGridViewTextBoxColumn.Width = 125;
        // 
        // maxUsedTipsDataGridViewTextBoxColumn
        // 
        maxUsedTipsDataGridViewTextBoxColumn.DataPropertyName = "MaxUsedTips";
        maxUsedTipsDataGridViewTextBoxColumn.HeaderText = "MaxUsedTips";
        maxUsedTipsDataGridViewTextBoxColumn.MinimumWidth = 6;
        maxUsedTipsDataGridViewTextBoxColumn.Name = "maxUsedTipsDataGridViewTextBoxColumn";
        maxUsedTipsDataGridViewTextBoxColumn.Width = 125;
        // 
        // stepsDataGridViewTextBoxColumn
        // 
        stepsDataGridViewTextBoxColumn.DataPropertyName = "Steps";
        stepsDataGridViewTextBoxColumn.HeaderText = "Steps";
        stepsDataGridViewTextBoxColumn.MinimumWidth = 6;
        stepsDataGridViewTextBoxColumn.Name = "stepsDataGridViewTextBoxColumn";
        stepsDataGridViewTextBoxColumn.ReadOnly = true;
        stepsDataGridViewTextBoxColumn.Visible = false;
        stepsDataGridViewTextBoxColumn.Width = 125;
        // 
        // modeEntityBindingSource
        // 
        modeEntityBindingSource.DataSource = typeof(Database.Entities.ModeEntity);
        // 
        // tabPageSteps
        // 
        tabPageSteps.Controls.Add(dataGrid_Steps);
        tabPageSteps.Location = new Point(4, 24);
        tabPageSteps.Margin = new Padding(3, 2, 3, 2);
        tabPageSteps.Name = "tabPageSteps";
        tabPageSteps.Padding = new Padding(3, 2, 3, 2);
        tabPageSteps.Size = new Size(932, 290);
        tabPageSteps.TabIndex = 1;
        tabPageSteps.Text = "Steps";
        tabPageSteps.UseVisualStyleBackColor = true;
        // 
        // dataGrid_Steps
        // 
        dataGrid_Steps.AllowUserToAddRows = false;
        dataGrid_Steps.AllowUserToDeleteRows = false;
        dataGrid_Steps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGrid_Steps.AutoGenerateColumns = false;
        dataGrid_Steps.BackgroundColor = SystemColors.Control;
        dataGrid_Steps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGrid_Steps.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn2, timerDataGridViewTextBoxColumn, destinationDataGridViewTextBoxColumn, speedDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, volumeDataGridViewTextBoxColumn, modeIdDataGridViewTextBoxColumn, modeDataGridViewTextBoxColumn });
        dataGrid_Steps.DataSource = stepEntityBindingSource;
        dataGrid_Steps.Location = new Point(3, 2);
        dataGrid_Steps.Margin = new Padding(3, 2, 3, 2);
        dataGrid_Steps.MultiSelect = false;
        dataGrid_Steps.Name = "dataGrid_Steps";
        dataGrid_Steps.RowHeadersWidth = 51;
        dataGrid_Steps.RowTemplate.Height = 29;
        dataGrid_Steps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGrid_Steps.Size = new Size(925, 289);
        dataGrid_Steps.TabIndex = 5;
        dataGrid_Steps.Tag = "Steps";
        dataGrid_Steps.RowHeaderMouseDoubleClick += UpdateRow;
        // 
        // idDataGridViewTextBoxColumn2
        // 
        idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
        idDataGridViewTextBoxColumn2.HeaderText = "Id";
        idDataGridViewTextBoxColumn2.MinimumWidth = 6;
        idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
        idDataGridViewTextBoxColumn2.ReadOnly = true;
        idDataGridViewTextBoxColumn2.Width = 125;
        // 
        // timerDataGridViewTextBoxColumn
        // 
        timerDataGridViewTextBoxColumn.DataPropertyName = "Timer";
        timerDataGridViewTextBoxColumn.HeaderText = "Timer";
        timerDataGridViewTextBoxColumn.MinimumWidth = 6;
        timerDataGridViewTextBoxColumn.Name = "timerDataGridViewTextBoxColumn";
        timerDataGridViewTextBoxColumn.Width = 125;
        // 
        // destinationDataGridViewTextBoxColumn
        // 
        destinationDataGridViewTextBoxColumn.DataPropertyName = "Destination";
        destinationDataGridViewTextBoxColumn.HeaderText = "Destination";
        destinationDataGridViewTextBoxColumn.MinimumWidth = 6;
        destinationDataGridViewTextBoxColumn.Name = "destinationDataGridViewTextBoxColumn";
        destinationDataGridViewTextBoxColumn.Width = 125;
        // 
        // speedDataGridViewTextBoxColumn
        // 
        speedDataGridViewTextBoxColumn.DataPropertyName = "Speed";
        speedDataGridViewTextBoxColumn.HeaderText = "Speed";
        speedDataGridViewTextBoxColumn.MinimumWidth = 6;
        speedDataGridViewTextBoxColumn.Name = "speedDataGridViewTextBoxColumn";
        speedDataGridViewTextBoxColumn.Width = 125;
        // 
        // typeDataGridViewTextBoxColumn
        // 
        typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
        typeDataGridViewTextBoxColumn.HeaderText = "Type";
        typeDataGridViewTextBoxColumn.MinimumWidth = 6;
        typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
        typeDataGridViewTextBoxColumn.Width = 125;
        // 
        // volumeDataGridViewTextBoxColumn
        // 
        volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
        volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
        volumeDataGridViewTextBoxColumn.MinimumWidth = 6;
        volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
        volumeDataGridViewTextBoxColumn.Width = 125;
        // 
        // modeIdDataGridViewTextBoxColumn
        // 
        modeIdDataGridViewTextBoxColumn.DataPropertyName = "ModeId";
        modeIdDataGridViewTextBoxColumn.HeaderText = "ModeId";
        modeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
        modeIdDataGridViewTextBoxColumn.Name = "modeIdDataGridViewTextBoxColumn";
        modeIdDataGridViewTextBoxColumn.Width = 125;
        // 
        // modeDataGridViewTextBoxColumn
        // 
        modeDataGridViewTextBoxColumn.DataPropertyName = "Mode";
        modeDataGridViewTextBoxColumn.HeaderText = "Mode";
        modeDataGridViewTextBoxColumn.MinimumWidth = 6;
        modeDataGridViewTextBoxColumn.Name = "modeDataGridViewTextBoxColumn";
        modeDataGridViewTextBoxColumn.ReadOnly = true;
        modeDataGridViewTextBoxColumn.Visible = false;
        modeDataGridViewTextBoxColumn.Width = 125;
        // 
        // stepEntityBindingSource
        // 
        stepEntityBindingSource.DataSource = typeof(Database.Entities.StepEntity);
        // 
        // labelForTips
        // 
        labelForTips.AutoSize = true;
        labelForTips.BorderStyle = BorderStyle.Fixed3D;
        labelForTips.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        labelForTips.ForeColor = Color.LimeGreen;
        labelForTips.Location = new Point(3, 62);
        labelForTips.Name = "labelForTips";
        labelForTips.Size = new Size(373, 21);
        labelForTips.TabIndex = 1;
        labelForTips.Text = "for update row u can double click on row start (arrow) icon ";
        // 
        // addItemButton
        // 
        addItemButton.Location = new Point(468, 59);
        addItemButton.Margin = new Padding(3, 2, 3, 2);
        addItemButton.Name = "addItemButton";
        addItemButton.Size = new Size(153, 22);
        addItemButton.TabIndex = 0;
        addItemButton.Text = "Add";
        addItemButton.UseVisualStyleBackColor = true;
        addItemButton.Click += AddRow;
        // 
        // removeItemButton
        // 
        removeItemButton.Location = new Point(627, 59);
        removeItemButton.Margin = new Padding(3, 2, 3, 2);
        removeItemButton.Name = "removeItemButton";
        removeItemButton.Size = new Size(153, 22);
        removeItemButton.TabIndex = 1;
        removeItemButton.Text = "Remove";
        removeItemButton.UseVisualStyleBackColor = true;
        removeItemButton.Click += RemoveRow;
        // 
        // profileLabel
        // 
        profileLabel.AutoSize = true;
        profileLabel.BorderStyle = BorderStyle.Fixed3D;
        profileLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        profileLabel.ForeColor = Color.LimeGreen;
        profileLabel.Location = new Point(3, 33);
        profileLabel.Name = "profileLabel";
        profileLabel.Size = new Size(60, 21);
        profileLabel.TabIndex = 4;
        profileLabel.Text = "Profile:";
        // 
        // userNameLabel
        // 
        userNameLabel.AutoSize = true;
        userNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        userNameLabel.ForeColor = Color.Black;
        userNameLabel.Location = new Point(61, 35);
        userNameLabel.Name = "userNameLabel";
        userNameLabel.Size = new Size(0, 19);
        userNameLabel.TabIndex = 5;
        // 
        // loadXlsxButton
        // 
        loadXlsxButton.Location = new Point(786, 59);
        loadXlsxButton.Margin = new Padding(3, 2, 3, 2);
        loadXlsxButton.Name = "loadXlsxButton";
        loadXlsxButton.Size = new Size(153, 22);
        loadXlsxButton.TabIndex = 2;
        loadXlsxButton.Text = "Load (.xlsx)";
        loadXlsxButton.UseVisualStyleBackColor = true;
        loadXlsxButton.Click += LoadFromXlsx;
        // 
        // ItemsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(947, 409);
        Controls.Add(loadXlsxButton);
        Controls.Add(userNameLabel);
        Controls.Add(profileLabel);
        Controls.Add(removeItemButton);
        Controls.Add(addItemButton);
        Controls.Add(labelForTips);
        Controls.Add(itemsTabControl);
        Margin = new Padding(3, 2, 3, 2);
        Name = "ItemsForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Items management";
        FormClosed += OnFormClosed;
        Load += LoadDataSource;
        itemsTabControl.ResumeLayout(false);
        tabPageModes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGrid_Modes).EndInit();
        ((System.ComponentModel.ISupportInitialize)modeEntityBindingSource).EndInit();
        tabPageSteps.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGrid_Steps).EndInit();
        ((System.ComponentModel.ISupportInitialize)stepEntityBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TabControl itemsTabControl;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPageModes;
    private DataGridView dataGrid_Modes;
    private TabPage tabPageSteps;
    private BindingSource modeEntityBindingSource;
    private DataGridView dataGrid_Steps;
    private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn maxBottleNumberDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn maxUsedTipsDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn stepsDataGridViewTextBoxColumn1;
    private BindingSource stepEntityBindingSource;
    private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn maxBottleNumberDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn maxUsedTipsDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn stepsDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn timerDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn modeIdDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn modeDataGridViewTextBoxColumn;
    private Label labelForTips;
    private Button addItemButton;
    private Button removeItemButton;
    private Label profileLabel;
    private Label userNameLabel;
    private Button loadXlsxButton;
}