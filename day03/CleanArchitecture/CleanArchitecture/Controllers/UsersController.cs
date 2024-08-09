using Application.Features;
using Application.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(
        IMapper _mapper, 
        IRepositoriy<Users> _userRepository, 
        IRepositoriy<UserRole> _roleRepository,
        IUnitOfWork _unitOfWork, 
        PasswordFeature _passwrodFeature
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(UsersParamDTO usersParamDTO)
        {
            var user = _mapper.Map<Users>(usersParamDTO);
            var userExist = await _userRepository.Get(x => x.Username.ToLower() == usersParamDTO.Username.ToLower());
            if(userExist.FirstOrDefault() != null)
            {

                return BadRequest(new
                {
                    Message = "Username sudah ada"
                });
                
            }
            user.Password = _passwrodFeature.HashPassword(usersParamDTO, usersParamDTO.Password);

            await _userRepository.Add(user);
            await _unitOfWork.SaveChanges();
            return Ok(_mapper.Map<UsersDTO>(user));
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddRole(UserRoleParamDTO userRoleParamDTO)
        {
            var userExist = await _userRepository.Get(x => x.Username.Equals(userRoleParamDTO.username));

            if (userExist.FirstOrDefault() == null)
            {
                return BadRequest( new
                {
                    Message = "User tidak ada."
                });
            }
            var roleExist = await _roleRepository.Get(x => x.IDUser == userExist.FirstOrDefault().ID
                && x.IDRole == userRoleParamDTO.IdRole);

            if (roleExist.FirstOrDefault() != null) return BadRequest(new
            {
                Message = "Role sudah pernah ditambahkan"
            });

            var userRole = _mapper.Map<UserRole>(userRoleParamDTO);
            userRole.IDUser = userExist.FirstOrDefault().ID;

            await _roleRepository.Add(userRole);
            await _unitOfWork.SaveChanges();

            return Ok(_mapper.Map<UserRoleDTO>(userRole));

        }
    }
}
