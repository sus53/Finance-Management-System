using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server.Dtos.Account;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService) : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsNullOrEmpty())
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Username
                };

                var CreatedUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (CreatedUser.Succeeded)
                {
                    var RoleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (RoleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            Email = registerDto.Email,
                            UserName = registerDto.Username,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return BadRequest(RoleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(CreatedUser.Errors);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}