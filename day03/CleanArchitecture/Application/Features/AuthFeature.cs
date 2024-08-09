using Application.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTO.UserRoleDTO;

namespace Application.Features
{
    public class AuthFeature
    (
        TokenFeature _tokenFeature,
        IRepositoriy<Users> _userRepository,
        IRepositoriy<UserRole> _roleRepository,
        PasswordFeature _passwordFeature,
        IMapper _mapper,
        IConfiguration configuration
    )
    {
        public async Task<Object> CreateToken(LoginModel loginModel)
        {
            var user = await _userRepository.Get(x => x.Username == loginModel.username);

            if (user.FirstOrDefault() == null)
            {
                throw new Exception("Username tidak ditemukan");
            }

            var userParam = _mapper.Map<UsersParamDTO>(user.FirstOrDefault());

            if (_passwordFeature.VerifyPassword(userParam, user.FirstOrDefault().Password, loginModel.password))
            {
                var token = _tokenFeature.GenerateToken(loginModel.username);

                var finalToken = new
                {
                    Token = token,
                };

                return finalToken.ToString();
            }
            throw new Exception("Unknown Error");
        }

        public async Task<object?> ChangeRole(string username, int roleid)
        {
            var user = await _userRepository.Get(x => x.Username == username);

            var roleExist = await _roleRepository.Get(x => x.IDUser == user.FirstOrDefault().ID);

            if (!roleExist.Select(x => x.IDRole).ToList().Contains(roleid))
            {
                throw new Exception("Tidak memiliki Role ini");
            }

            var userRoleDto = new UserRoleDTO()
            {
                IDRole = (RoleNameEnum)roleid,
            };
            var token = _tokenFeature.GenerateToken(username, userRoleDto);

            var finalToken = new
            {
                Token = token
            };
            return finalToken;
        }

        public async Task<object?> ValidatePublic(HttpRequest request)
        {
            var clientId = request.Headers.FirstOrDefault(x => x.Key.ToLower() == "clientid").Value;
            var clientSecret = request.Headers.FirstOrDefault(x => x.Key.ToLower() == "clientsecret").Value;

            if (clientId == configuration["PublicToken:ClientId"] && clientSecret == configuration["PublicToken:ClientSecret"])
            {
                var token = _tokenFeature.GeneratePublicToken();

                var finalToken = new
                {
                    Token = token
                };
                return finalToken;
            }

            throw new Exception("Tidak valid");
        }
    }
}
