using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using API.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model) {
            var user = UserRepository.Get(model.Username, model.Password);
            if(user == null) return BadRequest("não encontrado");
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new 
            {
                user = user,
                token = token
            };
        }
    }
}