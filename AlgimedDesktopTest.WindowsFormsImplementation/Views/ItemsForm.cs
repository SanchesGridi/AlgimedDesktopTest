using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Factories;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Parsers;
using AlgimedDesktopTest.WindowsFormsImplementation.Views.Base;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : BaseForm
{
    private const int ModeIdIndex = 0;
    private const int StartModeIndex = 1;
    private const int EndModeIndex = 4;

    private readonly AppDbContext? _context = ContextFactory.Create();

    public ItemsForm() => InitializeComponent();

    #region form-methods
    private void LoadModes()
    {
        _context?.Modes.Load();
        dataGrid_Modes.DataSource = _context?.Modes.Local.ToBindingList();
    }

    private void LoadSteps()
    {
        _context?.Steps.Load();
        dataGrid_Steps.DataSource = _context?.Steps.Local.ToBindingList();
    }
    #endregion

    #region event-methods
    private void LoadDataSource(object sender, EventArgs e)
    {
        try
        {
            LoadModes();
            LoadSteps();
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private async void UpdateModeRow(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (sender is DataGridView view)
            {
                var emptyRowIndex = view.RowCount - 1;
                if (e.RowIndex == emptyRowIndex)
                {
                    return;
                }
                var row = view.Rows[e.RowIndex];
                if (row != null)
                {
                    var id = row.Cells[ModeIdIndex].Value;
                    var properties = new Dictionary<string, object>();
                    for (var index = StartModeIndex; index <= EndModeIndex; index++)
                    {
                        var propertyName = view.Columns[index].HeaderText;
                        var propertyValue = row.Cells[index].Value;
                        properties.Add(propertyName, propertyValue);
                    }
                    var updated = ModeParser.Parse(properties, (int)id);
                    _context?.Modes.Update(updated);
                    await _context!.SaveChangesAsync();
                    LoadModes();
                }
            }
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }
    #endregion
}
