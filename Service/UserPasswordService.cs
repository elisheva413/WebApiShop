using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Zxcvbn;

namespace Service
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IUserPasswordRepository _userPasswordRepository;

        public UserPasswordService(IUserPasswordRepository userPassword)
        {
            _userPasswordRepository = userPassword;
        }

        public int CheckPassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
