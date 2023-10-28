namespace AlgimedDesktopTest.WindowsFormsImplementation.Models;

public class ManagedIndexesModel
{
    public int Id { get; private set; }
    public int Start { get; private set; }
    public int End { get; private set; }

    public void Set(int id, int start, int end)
    {
        Id = id; Start = start; End = end;
    }
}
