using AlgimedDesktopTest.Database.Entities;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class WarningForm : Form
{
    private readonly List<StepEntity> _steps;

    public WarningForm(List<StepEntity> steps)
    {
        _steps = steps;

        InitializeComponent();
    }

    #region event-methods
    private void LoadWarningForm(object sender, EventArgs e)
    {
        foreach (var step in _steps)
        {
            itemsListBox.Items.Add($"Id: {step.Id};\t\t\t ModeId: {step.ModeId}");
        }
    }
    #endregion
}
