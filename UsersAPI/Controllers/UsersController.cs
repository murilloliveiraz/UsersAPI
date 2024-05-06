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
        private CreateService _createService;

        public UsersController(CreateService createService)
        {
            _createService = createService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO) 
        {
            await _createService.Create(userDTO);
            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
