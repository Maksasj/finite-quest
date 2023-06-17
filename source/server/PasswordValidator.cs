using System.Text.RegularExpressions;

namespace FQ.Server
{
    public class PasswordValidator
    {
        public static bool ValidatePassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                return false;

            return true;
        }
    }
}
