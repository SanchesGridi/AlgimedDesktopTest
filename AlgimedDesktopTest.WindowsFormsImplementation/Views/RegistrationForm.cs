using AlgimedDesktopTest.Database.Entities;
using AlgimedDesktopTest.Database.Factories;
using AlgimedDesktopTest.Shared.Services.Classes;
using AlgimedDesktopTest.WindowsFormsImplementation.Utils;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Views;

public partial class RegistrationForm : Form
{
    private const string PasswordExceptionMessage = "Check passwords please!";
    private const string LoginExceptionMessage = "This login is already taken!";

    private readonly PasswordService _passwordService = new();

    public RegistrationForm() => InitializeComponent();

    #region event-method
    private async void SignUp(object sender, EventArgs e)
    {
        try
        {
            var firstName = fnTextBox.Text;
            var lastName = lnTextBox.Text;
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var confirm = confirmTextBox.Text;

            using var context = ContextFactory.Create();

            var uShallNotPass = string.IsNullOrWhiteSpace(password) && string.IsNullOrWhiteSpace(confirm);
            if (password != confirm || uShallNotPass || !_passwordService.Validate(password!))
            {
                throw new InvalidOperationException(PasswordExceptionMessage);
            }
            else if (context.Users.Select(x => x.Login).Contains(login))
            {
                throw new InvalidOperationException(LoginExceptionMessage);
            }
            else
            {
                var user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Login = login,
                    Password = password,
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                Close();
                Dispose();
            }
        }
        catch (Exception ex)
        {
            Dialogs.ShowExceptionDialog(ex);
        }
    }
    #endregion
}
