using AlgimedDesktopTest.Database.Contexts;
using AlgimedDesktopTest.WpfImplementation.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Regions;

namespace AlgimedDesktopTest.WpfImplementation.ViewModels;

public class ListViewModel : ViewModelBase
{
    private readonly AppContext _context;

    public ListViewModel(
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        AppContext context) : base(regionManager, eventAggregator)
    {
        _context = context;

        Load();
    }

    // todo: scope for context (extension->GetContainer)
    private async void Load()
    {
        try
        {
            var modesCount = await _context.Modes.CountAsync();
            var stepsCount = await _context.Steps.CountAsync();
        }
        catch (System.Exception ex)
        {
            await System.Console.Out.WriteLineAsync(ex.Message);
            throw;
        }
    }
}
