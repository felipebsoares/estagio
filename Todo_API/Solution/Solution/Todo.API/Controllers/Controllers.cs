using Microsoft.AspNetCore.Mvc;
using Todo.Domain;

namespace Todo.API.Controllers;
[ApiController]
[Route("Controlers")]
public class Controllers : ControllerBase
{
    public static List<User> usuarios = new List<User>();
    [HttpGet]
    public async Task<ActionResult<List<User>>> oi()
    {

        return Ok(usuarios);
    }
}