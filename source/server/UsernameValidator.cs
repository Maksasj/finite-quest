using System.Text.RegularExpressions;

namespace FQ.Server
{
    public class UsernameValidator
    {
        public static bool ValidateUsername(string username)
        {
            if (username.Length < 3 || username.Length > 20)
                return false;

            if (!char.IsLetter(username[0]))
                return false;

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                return false;

            return true;
        }
    }
}
