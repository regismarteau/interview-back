using System;

namespace Account.Domain
{
    public class Password
    {
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
                && !HasTwoSameCharInARow(password);
        }

        private static bool IsPasswordLongEnough(string password)
        {
            return password.Length >= 8;
        }

        private static bool HasTwoSameCharInARow(string password)
        {
            CharEnumerator enumerator = password.GetEnumerator();
            char? previous = default;
            while(enumerator.MoveNext())
            {
                if(previous == enumerator.Current)
                {
                    return true;
                }
                previous = enumerator.Current;
            }

            return false;
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
