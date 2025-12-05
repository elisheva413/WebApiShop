using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositeries;
using Zxcvbn;

namespace Service
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IUserPasswordRipository _userPasswordRipo;

        public UserPasswordService(IUserPasswordRipository userPassword)
        {
            _userPasswordRipo = userPassword;
        }

        public int CheckPassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
