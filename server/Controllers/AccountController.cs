using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Account;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController() : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

        }
    }
}