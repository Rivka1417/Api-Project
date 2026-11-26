using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Service
{
    public class PasswordService : IPasswordService
    {
        public int CheckPasswordStrength(string password)
        {
            var strength = Zxcvbn.Core.EvaluatePassword(password);

            return strength.Score;
        }
    }
}
