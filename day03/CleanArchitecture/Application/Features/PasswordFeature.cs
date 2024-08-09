
using Domain.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class PasswordFeature(IPasswordHasher<Object> _passwordHasher)
    {
        public string HashPassword(UsersParamDTO usersParamDTO, string password)
        {
            return _passwordHasher.HashPassword(usersParamDTO, password);
        }

        public bool VerifyPassword(UsersParamDTO usersParamDTO, string hashPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(usersParamDTO, hashPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
