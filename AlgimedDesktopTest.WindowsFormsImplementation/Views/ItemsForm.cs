using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Models;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Parsers;
using AlgimedDesktopTest.WindowsFormsImplementation.Views.Base;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : BaseForm
{
    private const int IdIndex = 0;
    private const int StartIndex = 1;
    private const int ModeEndIndex = 3;
    private const int StepEndIndex = 6;
    private const string ModesTag = "Modes";
    private const string StepsTag = "Steps";

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

    private async Task UpdateRowAsync<TEntity>(DataGridViewRow row, ManagedIndexesModel indexes)
        where TEntity : class, IBaseEntity<int>
    {
        var id = row.Cells[indexes.Id].Value;
        var properties = new Dictionary<string, object>();
        for (var index = indexes.Start; index <= indexes.End; index++)
        {
            var propertyName = row.Cells[index].OwningColumn.HeaderText;
            var propertyValue = row.Cells[index].EditedFormattedValue;
            properties.Add(propertyName, propertyValue);
        }
        var updated = EntityHelper.UpdateInMemory(properties, _context?.Set<TEntity>().Find(id)!);
        _context?.Set<TEntity>().Update(updated!);
        await _context!.SaveChangesAsync();
        if (typeof(TEntity) == typeof(ModeEntity))
        {
            LoadModes();
        }
        else if (typeof(TEntity) == typeof(StepEntity))
        {
            LoadSteps();
        }
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

    private async void UpdateRow(object sender, DataGridViewCellMouseEventArgs e)
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
                    var indexes = new ManagedIndexesModel();
                    if (view.Tag.ToString() == ModesTag)
                    {
                        indexes.Set(IdIndex, StartIndex, ModeEndIndex);
                        await UpdateRowAsync<ModeEntity>(row, indexes);
                    }
                    else if (view.Tag.ToString() == StepsTag)
                    {
                        indexes.Set(IdIndex, StartIndex, StepEndIndex);
                        await UpdateRowAsync<StepEntity>(row, indexes);
                    }
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
