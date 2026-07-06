using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Services.Interface
{
    public interface ICursoService
    {
        Task<IEnumerable<ReadCursoDto>> GetAllAsync();
        Task<ReadCursoDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateCursoDto dto);
        Task UpdateAsync(int id, UpdateCursoDto dto);
        Task DeleteAsync(int id);
    }
}
