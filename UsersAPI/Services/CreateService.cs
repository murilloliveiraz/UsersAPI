using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Data.Models;

namespace UsersAPI.Services
{
    public class CreateService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public CreateService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Create(CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

            if(!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }
    }
}
