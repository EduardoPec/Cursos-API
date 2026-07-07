using CursosAPI.Models;

namespace CursosAPI.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Usuario usuario);
    }
}
