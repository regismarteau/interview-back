using System;
using System.Linq;

namespace Account.Domain
{
    public class Password
    {
        private readonly string value;

        public Password(string password)
        {
            if(string.IsNullOrEmpty(password) || !IsValid(password))
            {
                throw new UnsecuredPasswordException();
            }
            this.value = password;
        }

        private static bool IsValid(string password)
        {
            return !HasMoreThanTwoTimesTheSameChar(password)
                && !HasTwoSameCharInARow(password);
        }

        private static bool HasTwoSameCharInARow(string password)
        {
            CharEnumerator enumerator = password.ToLower().GetEnumerator();
            char? previous = default;
            while (enumerator.MoveNext())
            {
                if (previous == enumerator.Current)
                {
                    return true;
                }
                previous = enumerator.Current;
            }

            return false;
        }

        private static bool HasMoreThanTwoTimesTheSameChar(string password)
        {
            return password
                .ToLower()
                .GroupBy(c => c)
                .Any(c => c.Count() > 2);
        }

        public static implicit operator string(Password password)
        {
            return password.ToString();
        }

        public static implicit operator Password(string password)
        {
            return new Password(password);
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
