using System.Text.RegularExpressions;

namespace Account.Domain
{
    public class Password
    {
        private static readonly Regex UpperCaseValidator = new Regex("[A-Z]", RegexOptions.Compiled);
        private static readonly Regex LowerCaseValidator = new Regex("[a-z]", RegexOptions.Compiled);
        private static readonly Regex DigitValidator = new Regex("[0-9]", RegexOptions.Compiled);
        private static readonly Regex SpecialCharacterValidator = new Regex(@"(#|\$|@)", RegexOptions.Compiled);
        private readonly string value;

        public Password(string password)
        {
            if(!IsValid(password))
            {
                throw new UnsecuredPasswordException();
            }
            this.value = password;
        }

        private static bool IsValid(string password)
        {
            return IsPasswordLongEnough(password)
                && HasAtLeastOneUppercaseLetter(password)
                && HasAtLeastOneLowercaseLetter(password)
                && HasAtLeastOneSpecialCharacter(password)
                && HasAtLeastOneNumber(password);
        }

        private static bool IsPasswordLongEnough(string password)
        {
            return password.Length >= 8;
        }

        private static bool HasAtLeastOneUppercaseLetter(string password)
        {
            return UpperCaseValidator.IsMatch(password);
        }

        private static bool HasAtLeastOneLowercaseLetter(string password)
        {
            return LowerCaseValidator.IsMatch(password);
        }

        private static bool HasAtLeastOneSpecialCharacter(string password)
        {
            return SpecialCharacterValidator.IsMatch(password);
        }

        private static bool HasAtLeastOneNumber(string password)
        {
            return DigitValidator.IsMatch(password);
        }

        public static implicit operator string(Password password)
        {
            return password.value;
        }

        public static implicit operator Password(string password)
        {
            return new Password(password);
        }
    }
}
