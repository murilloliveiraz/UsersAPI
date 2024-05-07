using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTOs;
using UsersAPI.Data.Models;

namespace UsersAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

        public async Task<string> Login(LoginUserDTO userDTO)
        {
            var resultado = await _signInManager.PasswordSignInAsync(userDTO.Username, userDTO.Password, false, false);
            if(!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado");
            }

            var user = _signInManager.
                        UserManager.
                        Users.
                        FirstOrDefault(user =>
                            user.NormalizedUserName == userDTO.Username.ToUpper()
                        );

            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}
