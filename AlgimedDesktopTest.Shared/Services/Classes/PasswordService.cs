using AlgimedDesktopTest.Shared.Services.Interfaces;

namespace AlgimedDesktopTest.Shared.Services.Classes;

public class PasswordService : IPasswordService
{
    private const int Length = 6;

    public bool Validate(string password)
    {
        var hasDigit = false;
        var hasLetter = false;

        foreach (var c in password)
        {
            if (hasDigit && hasLetter)
            {
                break;
            }
            if (char.IsDigit(c))
            {
                hasDigit = true;
            }
            else if (char.IsLetter(c))
            {
                hasLetter = true;
            }
        }

        return password.Length >= Length && hasDigit && hasLetter;
    }
}
