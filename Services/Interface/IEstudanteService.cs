using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Services.Interface
{
    public interface IEstudanteService
    {
        Task<IEnumerable<ReadEstudanteDto>> GetAllAsync();
        Task<ReadEstudanteDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateEstudanteDto dto);
        Task UpdateAsync(int id, UpdateEstudanteDto dto);
        Task DeleteAsync(int id);
    }
}
