using System.Text.RegularExpressions;

namespace Gender.Application.Validators
{
    public class NameValidator
    {
        private static readonly Regex NameRegex = new Regex(
            @"^[a-zA-Z]+([-' ][a-zA-Z]+)*$",
            RegexOptions.Compiled
        );
        public static bool IsInvalid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return true;

            if (bool.TryParse(name, out _))
                return true;

            if (double.TryParse(name, out _))
                return true;

            if (!NameRegex.IsMatch(name))
                return true;

            return false;
        }
    }
}

