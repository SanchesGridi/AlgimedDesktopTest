namespace AlgimedDesktopTest.WindowsFormsImplementation.Views.Base;

public class BaseForm : Form
{
    private const string ErrorTitle = "Error occured";

    protected static void ShowExceptionDialog(Exception ex)
    {
        MessageBox.Show(ex.Message, ErrorTitle, MessageBoxButtons.OK);
    }
}
