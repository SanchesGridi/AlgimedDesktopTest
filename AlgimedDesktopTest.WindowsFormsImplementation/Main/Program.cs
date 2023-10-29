using AlgimedDesktopTest.WindowsFormsImplementation.Views;

namespace AlgimedDesktopTest.WindowsFormsImplementation.Main;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new ItemsForm(new() { FirstName = "Alexander", LastName = "Gridin", Login = "AlexGrid" }));
        // Application.Run(new AuthorizationForm());
    }
}