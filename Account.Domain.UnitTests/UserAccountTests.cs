using FluentAssertions;
using NUnit.Framework;
using System;

namespace Account.Domain.UnitTests
{
    [TestFixture]
    public class UserAccountTests
    {
        [Test]

        [TestCase("@Azerty123")]
        [TestCase("$JohnDoe0")]
        public void The_password_of_an_user_account_could_be_changed(string password)
        {
            UserAccount userAccount = AnAlreadyRegisteredUserAccount();

            userAccount.ChangePassword(password);
            
            userAccount.Password
                .Should()
                .BeEquivalentTo(password);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("AAzerty123")]
        [TestCase("abc")]
        [TestCase("Azertyy123")]
        [TestCase("Azerty1233")]
        [Test]
        public void Registration_should_throw_an_error_when_an_invalid_password_is_submitted(string password)
        {
            new Action(() => new UserAccount("my_custom_mail@email.com", password))
                 .Should()
                 .Throw<UnsecuredPasswordException>()
                 .WithMessage("Unsecured password submitted.");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("AAzerty123")]
        [TestCase("abc")]
        [TestCase("Azertyy123")]
        [TestCase("Azerty1233")]
        [Test]
        public void Change_user_account_s_password_should_throw_an_error_when_an_invalid_password_is_submitted(string password)
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
