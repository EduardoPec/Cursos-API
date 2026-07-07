using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Models;
using CursosAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace CursosAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(IMapper mapper, ITokenService tokenService, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new FalhaCadastroException("Falha ao cadastrar usuário!");
            }
            await _userManager.AddToRoleAsync(usuario, dto.Role.ToString());
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new NaoAutenticadoException("Usuário não autenticado!");
            }

            var usuario = await _userManager.FindByNameAsync(dto.Username);

            var token = await _tokenService.GenerateToken(usuario);
            return token;
        }
    }
}
