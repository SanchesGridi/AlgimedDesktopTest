using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WindowsFormsImplementation.Internal.Factories;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class ItemsForm : Form
{
    private AppDbContext? _context;

    public ItemsForm()
    {
        InitializeComponent();
    }

    private void LoadDataSource(object sender, EventArgs e)
    {
        _context = ContextFactory.Create();

        _context.Modes.Load();
        dataGrid_Modes.DataSource = _context.Modes.Local.ToBindingList();

        _context.Steps.Load();
        dataGrid_Steps.DataSource = _context.Steps.Local.ToBindingList();
    }
}
