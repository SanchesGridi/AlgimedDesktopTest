using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.WindowsFormsImplementation.Models;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ModeForm : Form
{
    private readonly ModeModel _model = new();

    public ModeForm() => InitializeComponent();

    #region form-methods
    public ModeEntity GetItem() => new()
    {
        Name = _model.Name,
        MaxBottleNumber = _model.MaxBottleNumber,
        MaxUsedTips = _model.MaxUsedTips
    };
    #endregion

    #region event-methods
    private void LoadModeForm(object sender, EventArgs e)
    {
        nameTextBox.DataBindings.Add(nameof(nameTextBox.Text), _model, nameof(_model.Name), true, DataSourceUpdateMode.OnPropertyChanged);
        bottlesNumeric.Maximum = int.MaxValue;
        bottlesNumeric.DataBindings.Add(nameof(bottlesNumeric.Value), _model, nameof(_model.MaxBottleNumber), true, DataSourceUpdateMode.OnPropertyChanged);
        tipsNumeric.Maximum = int.MaxValue;
        tipsNumeric.DataBindings.Add(nameof(tipsNumeric.Value), _model, nameof(_model.MaxUsedTips), true, DataSourceUpdateMode.OnPropertyChanged);
    }
    #endregion
}
