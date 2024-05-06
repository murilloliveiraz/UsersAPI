using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Data.Models;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UsersController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO) 
        {
            User user = _mapper.Map<User>(userDTO);

            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                return Ok("Usuário cadastrado com sucesso");
            }

            throw new ApplicationException("Falha ao cadastrar usuário");
        }
    }
}
