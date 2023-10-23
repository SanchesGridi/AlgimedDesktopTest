using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Factories;
using AlgimedDesktopTest.WindowsFormsImplementation.Views.Base;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : BaseForm
{
    private const int ModeIdIndex = 0;
    private const int StartModeIndex = 1;
    private const int EndModeIndex = 3;

    public ItemsForm() => InitializeComponent();

    #region form-methods
    private void LoadModes(AppDbContext context)
    {
        context.Modes.Load();
        dataGrid_Modes.DataSource = context.Modes.Local.ToBindingList();
    }

    private void LoadSteps(AppDbContext context)
    {
        context.Steps.Load();
        dataGrid_Steps.DataSource = context.Steps.Local.ToBindingList();
    }
    #endregion

    #region event-methods
    private void LoadDataSource(object sender, EventArgs e)
    {
        try
        {
            using var context = ContextFactory.Create();
            LoadModes(context);
            LoadSteps(context);
        }
        catch (Exception ex)
        {
            ShowExceptionDialog(ex);
        }
    }

    private void UpdateModeRow(object sender, DataGridViewCellMouseEventArgs e)
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
                    // TODO:
                    var id = row.Cells[ModeIdIndex].Value;
                    for (var index = StartModeIndex; index <= EndModeIndex; index++)
                    {
                        // 1) add to collection (Dictionary) and map to entity
                        var propertyName = view.Columns[index].HeaderText;
                        var propertyValue = row.Cells[index].Value;
                    }
                    // 2) here is ready entity (id, and properties(Dictionary)
                    // 3) update context row
                    // 4) LoadModes(context)
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
