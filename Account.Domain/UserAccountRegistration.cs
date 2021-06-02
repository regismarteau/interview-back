﻿using System;
using System.Threading.Tasks;

namespace Account.Domain
{
    public class UserAccountRegistration
    {
        private readonly IUserAccountRepository userAccountRepository;

        public UserAccountRegistration(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }


        public async Task Register(string email, string password)
        {
            UserAccount userAccount = new UserAccount(email, password);
            await this.userAccountRepository.Save(userAccount);
        }
    }
}
