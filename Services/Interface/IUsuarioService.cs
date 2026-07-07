using CursosAPI.Dtos;

namespace CursosAPI.Services.Interface
{
    public interface IUsuarioService
    {
        Task Cadastra(CreateUsuarioDto dto);
        Task<string> Login(LoginUsuarioDto dto);
    }
}
