using CursosAPI.Models;
using CursosAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CursosAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;

        public TokenService(IConfiguration configuration, UserManager<Usuario> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(Usuario usuario)
        {
            var roles = await _userManager.GetRolesAsync(usuario);

            if (!roles.Any())
            {
                Console.WriteLine("Usuário sem roles!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName!),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim("loginTimeStamp", DateTime.UtcNow.ToString())
            };

            foreach (var role in roles)
            { 
                claims.Add(new Claim(ClaimTypes.Role, role));
            }  

                var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
