using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WindowsFormsImplementation.Models;
using AlgimedDesktopTest.WindowsFormsImplementation.Utils;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class StepForm : Form
{
    private readonly List<int> _modes;
    private readonly StepModel _model;

    public StepForm(List<int> modes)
    {
        modes.Insert(0, 0);
        _modes = new(modes);
        _model = new();

        InitializeComponent();
    }

    #region form-methods
    public StepEntity GetItem() => new()
    {
        Destination = _model.Destination,
        Type = _model.Type,
        Timer = _model.Timer,
        Speed = _model.Speed,
        Volume = _model.Volume,
        ModeId = _model.ModeId
    };
    #endregion

    #region event-methods
    private void LoadStepForm(object sender, EventArgs e)
    {
        try
        {
            destinationTextBox.DataBindings.Add(
                nameof(destinationTextBox.Text), _model, nameof(_model.Destination), true, DataSourceUpdateMode.OnPropertyChanged
            );
            typeTextBox.DataBindings.Add(
                nameof(typeTextBox.Text), _model, nameof(_model.Type), true, DataSourceUpdateMode.OnPropertyChanged
            );
            timerNumeric.Maximum = decimal.MaxValue;
            timerNumeric.DataBindings.Add(
                nameof(timerNumeric.Value), _model, nameof(_model.Timer), true, DataSourceUpdateMode.OnPropertyChanged
            );
            volumeNumeric.Maximum = decimal.MaxValue;
            volumeNumeric.DataBindings.Add(
                nameof(volumeNumeric.Value), _model, nameof(_model.Volume), true, DataSourceUpdateMode.OnPropertyChanged
            );
            speedNumeric.Maximum = decimal.MaxValue;
            speedNumeric.DataBindings.Add(
                nameof(speedNumeric.Value), _model, nameof(_model.Speed), true, DataSourceUpdateMode.OnPropertyChanged
            );
            modeComboBox.DataSource = _modes;
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }

    private void SelectedModeIdChanged(object sender, EventArgs e)
    {
        if (sender is ComboBox view)
        {
            _model.ModeId = (int)view.SelectedItem;
        }
    }
    #endregion
}
