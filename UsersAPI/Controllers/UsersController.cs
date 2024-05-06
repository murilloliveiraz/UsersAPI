using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        public IActionResult CreateUser(CreateUserDTO user) 
        {
            throw new NotImplementedException();
        }
    }
}
