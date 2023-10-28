using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.WindowsFormsImplementation.Models;
using AlgimedDesktopTest.WindowsFormsImplementation.Utils;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : Form
{
    private const int IdIndex = 0;
    private const int StartIndex = 1;
    private const int ModeEndIndex = 3;
    private const int StepEndIndex = 6;
    private const string Modes = "Modes";
    private const string Steps = "Steps";

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

    private async Task RemoveRowAsync<TEntity>(DataGridView view)
        where TEntity : class, IBaseEntity<int>
    {
        if (view.SelectedRows.Count > 0)
        {
            var row = view.SelectedRows[0];
            var id = row.Cells[IdIndex].Value;
            var entity = await _context?.Set<TEntity>().FirstAsync(x => x.Id == (int)id)!;
            _context?.Set<TEntity>().Remove(entity);
            await _context!.SaveChangesAsync();
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
            Dialogs.ShowExceptionDialog(ex);
        }
    }

    private async void UpdateRow(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (sender is DataGridView view)
            {
                var row = view.Rows[e.RowIndex];
                if (row != null)
                {
                    var indexes = new ManagedIndexesModel();
                    if (view.Tag.ToString() == Modes)
                    {
                        indexes.Set(IdIndex, StartIndex, ModeEndIndex);
                        await UpdateRowAsync<ModeEntity>(row, indexes);
                    }
                    else if (view.Tag.ToString() == Steps)
                    {
                        indexes.Set(IdIndex, StartIndex, StepEndIndex);
                        await UpdateRowAsync<StepEntity>(row, indexes);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }

    private async void RemoveRow(object sender, EventArgs e)
    {
        try
        {
            if (itemsTabControl.SelectedTab.Text == Modes)
            {
                await RemoveRowAsync<ModeEntity>(dataGrid_Modes);
            }
            else if (itemsTabControl.SelectedTab.Text == Steps)
            {
                await RemoveRowAsync<StepEntity>(dataGrid_Steps);
            }
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }

    private async void AddRow(object sender, EventArgs e)
    {
        try
        {
            if (itemsTabControl.SelectedTab.Text == Modes)
            {
                var form = new ModeForm();
                var dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    var item = form.GetItem();
                    await _context!.Modes.AddAsync(item);
                    await _context!.SaveChangesAsync();
                }
                form.Dispose();
            }
            else if (itemsTabControl.SelectedTab.Text == Steps)
            {
                var form = new StepForm(await _context!.Modes.Select(x => x.Id).ToListAsync());
                var dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    var item = form.GetItem();
                    await _context!.Steps.AddAsync(item);
                    await _context!.SaveChangesAsync();
                }
                form.Dispose();
            }
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }
    #endregion
}
