using Application.Features;
using Application.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        AuthFeature _authFeature,
        TokenFeature _tokenFeature, 
        IRepositoriy<Users> _userRepository,
        IRepositoriy<UserRole> _roleRepository,
        PasswordFeature _passwordFeature,
        IMapper _mapper
    ) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginModel loginModel)
        {
            try
            {
                var token = await _authFeature.CreateToken(loginModel);
                if(token != null)
                {
                    return Ok(token);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

                
        }

        [HttpPost("publicLogin")]
        public async Task<IActionResult> PublicLogin([FromHeader] string ClientId, [FromHeader] string ClientSecret)
        {
            try
            {
                var token = await _authFeature.ValidatePublic(Request);
                if (token != null)
                {
                    return Ok(token);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("changeRole")]
        public async Task<IActionResult> ChangeRole([FromBody] UserRoleParamDTO roleParam)
        {
            try
            {
                var claim = User.Claims;
                var username = claim.FirstOrDefault(x => x.Type == "username").Value;

                var roleid = roleParam.IdRole;

                var token = await _authFeature.ChangeRole(username, roleid);
                if (token != null)
                {
                    return Ok(token);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
