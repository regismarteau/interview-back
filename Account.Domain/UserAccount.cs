using System;

namespace Account.Domain
{
    public class UserAccount
    {
        public UserAccount(string email, string password)
        {
            this.Id = Guid.NewGuid();
            this.Email = email;
            this.Password = new Password(password);
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; private set; }

        public void ChangePassword(string newPassword)
        {
            this.Password = new Password(newPassword);
        }
    }
}
