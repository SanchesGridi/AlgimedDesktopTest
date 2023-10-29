using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Entities.Base;
using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.Shared.Excel.Classes;
using AlgimedDesktopTest.Shared.Services.Classes;
using AlgimedDesktopTest.WindowsFormsImplementation.Models;
using AlgimedDesktopTest.WindowsFormsImplementation.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : Form
{
    private const int IdIndex = 0;
    private const int StartIndex = 1;
    private const int ModeEndIndex = 3;
    private const int StepEndIndex = 6;
    private const string Modes = "Modes";
    private const string Steps = "Steps";
    private const string ExcludedStepsMessage = "All modes was saved successfully, but steps are skipped!";
    private const string ExcludedStepsTitle = "Steps are skipped!";

    private readonly UserEntity _user;
    private readonly AppDbContext? _context;
    private readonly ExcelService _excelService;
    private readonly FileService _folderService;
    private readonly string[] _mode_XlsxHeaders;
    private readonly string[] _step_XlsxHeaders;

    public ItemsForm(UserEntity user)
    {
        _user = user;
        _context = ContextFactory.Create();
        _excelService = new();
        _folderService = new();
        _mode_XlsxHeaders = new[] { "ID", "Name", "MaxBottleNumber", "MaxUsedTips" };
        _step_XlsxHeaders = new[] { "ID", "ModeId", "Timer", "Destination", "Speed", "Type", "Volume" };

        InitializeComponent();
    }

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

    private async Task LoadStepsFromXlsxAsync(List<StepEntity> steps)
    {
        var stepIds = await _context!.Steps.Select(x => x.Id).ToListAsync();
        foreach (var step in steps)
        {
            if (stepIds.Contains(step.Id))
            {
                var existingStep = await _context!.Steps.FirstOrDefaultAsync(x => x.Id == step.Id);
                existingStep!.ModeId = step.ModeId;
                existingStep!.Type = step.Type;
                existingStep!.Destination = step.Destination;
                existingStep!.Speed = step.Speed;
                existingStep!.Timer = step.Timer;
                existingStep!.Volume = step.Volume;

                _context!.Steps.Update(existingStep);
            }
            else
            {
                _context!.Steps.Add(step);
            }
        }
        await _context!.SaveChangesAsync();
    }

    private static ModeEntity ModeMapper(DataRow row) =>
        new()
        {
            Id = int.Parse(row["ID"].ToString()!),
            Name = row["Name"].ToString(),
            MaxBottleNumber = int.Parse(row["MaxBottleNumber"].ToString()!),
            MaxUsedTips = int.Parse(row["MaxUsedTips"].ToString()!)
        };

    private static StepEntity StepMapper(DataRow row) =>
        new()
        {
            Id = int.Parse(row["ID"].ToString()!),
            ModeId = int.Parse(row["ModeId"].ToString()!),
            Type = row["Type"].ToString(),
            Destination = row["Destination"].ToString(),
            Speed = row.Field<double>("Speed"),
            Timer = row.Field<double>("Timer"),
            Volume = row.Field<double>("Volume")
        };

    private static bool RowValidator(DataRow row) =>
        !string.IsNullOrWhiteSpace(row["Id"].ToString());
    #endregion

    #region event-methods
    private void LoadDataSource(object sender, EventArgs e)
    {
        try
        {
            userNameLabel.Text = $"{_user.FirstName} {_user.LastName} (@{_user.Login})";
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

    private async void LoadFromXlsx(object sender, EventArgs e)
    {
        try
        {
            this.Enabled = false;
            var path = _folderService.Browse();
            if (!string.IsNullOrWhiteSpace(path))
            {
                // modes:
                var loadedModes = _excelService.LoadFromXlsx<ModeEntity>(
                    new(ModeMapper, RowValidator) { Path = path, SheetName = Modes, HeaderNames = _mode_XlsxHeaders }
                );
                var modeIds = await _context!.Modes.Select(x => x.Id).ToListAsync();
                foreach (var mode in loadedModes)
                {
                    if (modeIds.Contains(mode.Id))
                    {
                        var existingMode = await _context!.Modes.FirstOrDefaultAsync(x => x.Id == mode.Id);
                        existingMode!.Name = mode.Name;
                        existingMode!.MaxBottleNumber = mode.MaxBottleNumber;
                        existingMode!.MaxUsedTips = mode.MaxUsedTips;

                        _context!.Modes.Update(existingMode);
                    }
                    else
                    {
                        _context.Modes.Add(mode);
                    }
                }
                await _context!.SaveChangesAsync();

                // steps:
                var loadedSteps = _excelService.LoadFromXlsx<StepEntity>(
                    new(StepMapper, RowValidator) { Path = path, SheetName = Steps, HeaderNames = _step_XlsxHeaders }
                );

                modeIds = await _context!.Modes.Select(x => x.Id).ToListAsync();
                var excludedSteps = loadedSteps.Where(x => !modeIds.Contains((int)x.ModeId!)).ToList();
                var includedSteps = loadedSteps.Where(x => modeIds.Contains((int)x.ModeId!)).ToList();

                if (excludedSteps.Count > 0)
                {
                    var form = new WarningForm(excludedSteps);
                    var dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        await LoadStepsFromXlsxAsync(includedSteps);
                    }
                    else
                    {
                        Dialogs.ShowDialog(ExcludedStepsMessage, ExcludedStepsTitle);
                    }
                }
                else
                {
                    await LoadStepsFromXlsxAsync(loadedSteps);
                }
            }
            this.Enabled = true;
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }

    private void OnFormClosed(object sender, FormClosedEventArgs e) =>
        Owner?.Dispose();
    #endregion
}
