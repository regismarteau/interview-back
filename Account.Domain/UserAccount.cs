using System;

namespace Account.Domain
{
    public class UserAccount
    {
        public UserAccount(string email, Password password)
        {
            this.Id = Guid.NewGuid();
            this.Email = email;
            this.Password = password;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; private set; }

        public void ChangePassword(Password newPassword)
        {
            this.Password = newPassword;
        }
    }
}
