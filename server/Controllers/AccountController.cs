using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Dtos.Account;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager) : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<AppUser> _signInManager = signInManager;

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
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
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(i => loginDto.UserName.ToLower() == i.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid Username or Password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid Username or Password");

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}