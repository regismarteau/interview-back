using FluentAssertions;
using NUnit.Framework;

namespace Account.Domain.UnitTests
{
    [TestFixture]
    public class UserAccountTests
    {
        [Test]
        public void The_password_of_an_user_account_could_be_changed()
        {
            UserAccount userAccount = new UserAccount("my_custom_mail@email.com", "@Azerty123");
            
            userAccount.ChangePassword("@Azerty456");
            
            userAccount.Password
                .Should()
                .Be("@Azerty456");
        }

        [DataRow("@Azerty123")]
        [DataRow("$JohnDoe0")]
        [TestMethod]
        public void Valid_Passwords(string password)
        {
            new Action(() => new Password(password))
                 .Should()
                 .NotThrow();
        }

        [DataRow("Azerty123")]
        [DataRow("#123456789")]
        [DataRow("ARandomPasswordQuiteLongEnough")]
        [TestMethod]
        public void Invalid_Passwords(string password)
        {
            new Action(() => new Password(password))
                 .Should()
                 .Throw<UnsecuredPasswordException>()
                 .WithMessage("Unsecured password submitted.");
        }
    }
}
