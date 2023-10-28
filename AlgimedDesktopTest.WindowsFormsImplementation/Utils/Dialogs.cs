namespace AlgimedDesktopTest.WindowsFormsImplementation.Utils;

public static class Dialogs
{
    private const string ErrorTitle = "Error occured";

    public static void ShowExceptionDialog(Exception ex)
    {
        MessageBox.Show(ex.Message, ErrorTitle, MessageBoxButtons.OK);
    }
}
