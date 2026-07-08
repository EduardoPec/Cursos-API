using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Repositories.Interface
{
    public interface IEstudanteRepository
    {
        Task<IEnumerable<Estudante>> GetAllAsync();
        Task<Estudante?> GetByIdAsync(int id);
        Task<Estudante?> GetByEmailAsync(string email);
        Task CreateAsync(Estudante estudante);
        Task UpdateAsync(Estudante estudante);
        Task DeleteAsync(Estudante estudante);
        Task<bool> SaveChangesAsync();
    }
}
