using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Services.Interface
{
    public interface IInscricaoService
    {
        Task<IEnumerable<ReadInscricaoDto>> GetAllAsync();
        Task<IEnumerable<ReadInscricaoDto>> GetByEstudanteIdAsync(int estudanteId);
        Task<ReadInscricaoDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateInscricaoDto dto);
        Task DeleteAsync(int id);
    }
}
