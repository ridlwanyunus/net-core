using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class UsersMapper : Profile
    {

        public UsersMapper()
        {
            CreateMap<UsersParamDTO, Users>();
            CreateMap<Users, UsersParamDTO>();
            CreateMap<Users, UsersDTO>();

            CreateMap<UserRoleParamDTO, UserRole>();
            CreateMap<UserRole, UserRoleDTO>();

        }
    }
}
