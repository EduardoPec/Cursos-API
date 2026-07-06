using CursosAPI.Models;

namespace CursosAPI.Repositories.Interface
{
    public interface IInscricaoRepository
    {
        Task<IEnumerable<Inscricao>> GetAllAsync();
        Task<IEnumerable<Inscricao>> GetByEstudanteIdAsync(int estudanteId);
        Task<Inscricao?> GetByIdAsync(int id);
        Task<bool> CursoExisteAsync(int cursoId);
        Task<bool> EstudanteExisteAsync(int  estudanteId);
        Task<bool> InscricaoExisteAsync(int cursoId, int estudanteId);
        Task CreateAsync(Inscricao inscricao);
        Task DeleteAsync(Inscricao inscricao);
        Task<bool> SaveChangesAsync();
    }
}
