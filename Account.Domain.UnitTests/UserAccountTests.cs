using FluentAssertions;
using NUnit.Framework;
using System;

namespace Account.Domain.UnitTests
{
    [TestFixture]
    public class UserAccountTests
    {
        [Test]
        public void The_password_of_an_user_account_could_be_changed()
        {
            UserAccount userAccount = AnAlreadyRegisteredUserAccount();
            
            userAccount.ChangePassword("@Azerty456");
            
            userAccount.Password
                .Should()
                .BeEquivalentTo("@Azerty456");
        }

        [DataRow("@Azerty123")]
        [DataRow("$JohnDoe0")]
        [TestMethod]
        public void Valid_Passwords(string password)
        {
            new Action(() => new UserAccount("my_custom_mail@email.com", password))
                 .Should()
                 .NotThrow();
        }

        [DataRow("AAzerty123")]
        [DataRow("abc")]
        [DataRow("Azertyy123")]
        [DataRow("Azerty1233")]
        [TestMethod]
        public void Invalid_Passwords(string password)
        {
            UserAccount userAccount = AnAlreadyRegisteredUserAccount();
            new Action(() => userAccount.ChangePassword(password))
                 .Should()
                 .Throw<UnsecuredPasswordException>()
                 .WithMessage("Unsecured password submitted.");
        }

        private static UserAccount AnAlreadyRegisteredUserAccount()
        {
            return new UserAccount("my_custom_mail@email.com", "@Azerty123");
        }
    }
}
