using System;

namespace Account.Domain
{
    public class UnsecuredPasswordException : Exception
    {
        private const string InnerMessage = "Unsecured password submitted.";
        public UnsecuredPasswordException() : base(InnerMessage)
        {
        }
    }
}
