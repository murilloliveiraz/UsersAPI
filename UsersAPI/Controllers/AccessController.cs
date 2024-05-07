using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController: ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "Minimum Age")]
        public IActionResult Get()
        {
            return Ok("Acesso Permitido");
        }
    }
}
