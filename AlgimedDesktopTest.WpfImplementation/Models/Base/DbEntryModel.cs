using Prism.Mvvm;

namespace AlgimedDesktopTest.WpfImplementation.Models.Base;

public abstract class DbEntryModel : BindableBase
{
    private readonly int _id;

    public DbEntryModel(int id) => _id = id;

    public int GetId() => _id;
}
