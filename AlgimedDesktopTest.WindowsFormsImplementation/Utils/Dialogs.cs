namespace AlgimedDesktopTest.WindowsFormsImplementation.Utils;

public static class Dialogs
{
    private const string ErrorTitle = "Error occured";

    public static void ShowExceptionDialog(Exception ex)
    {
        MessageBox.Show(ex.Message, ErrorTitle, MessageBoxButtons.OK);
    }

    public static void ShowDialog(string message, string title)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK);
    }
}
