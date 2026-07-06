using CursosAPI.Models;

namespace CursosAPI.Repositories.Interface
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> GetByIdAsync(int id);
        Task CreateAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(Curso curso);
        Task<bool> SaveChangesAsync();
    }
}
