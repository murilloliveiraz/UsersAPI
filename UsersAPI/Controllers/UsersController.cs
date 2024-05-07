using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Data.Models;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO) 
        {
            await _userService.Create(userDTO);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDTO userDTO)
        {
            var token = await _userService.Login(userDTO);
            return Ok(token);
        }
    }
}
