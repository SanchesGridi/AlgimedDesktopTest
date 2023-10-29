using AlgimedDesktopTest.Shared.Services.Interfaces;

namespace AlgimedDesktopTest.Shared.Services.Classes;

public class FileService : IFileService
{
    public string Browse()
    {
        using var dialog = new OpenFileDialog();
        var result = dialog.ShowDialog();
        return result == DialogResult.OK ? dialog.FileName : string.Empty;
    }
}
