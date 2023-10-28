using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.WindowsFormsImplementation.Utils;
using Microsoft.EntityFrameworkCore;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class AuthorizationForm : Form
{
    private const string ExceptionMessage = "Invalid login data!";

    public AuthorizationForm() => InitializeComponent();

    #region event-methods
    private async void SignIn(object sender, EventArgs e)
    {
        try
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            using var context = ContextFactory.Create();
            var user = await context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password)
                ?? throw new InvalidOperationException(ExceptionMessage);

            var form = new ItemsForm(user);
            form.Show(this);
            Hide();
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }
    #endregion
}