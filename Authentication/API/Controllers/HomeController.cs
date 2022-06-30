using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using API.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";
    }
}