using CursosAPI.Data;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CursosAPI.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {

        private readonly CursoContext _context;

        public InscricaoRepository(CursoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inscricao>> GetAllAsync()
        {
            var inscricao = await _context.Inscricoes.ToListAsync();
            return inscricao;
        }

        public async Task<IEnumerable<Inscricao>> GetByEstudanteIdAsync(int estudanteId)
        {
            var inscricoes = await _context.Inscricoes
                .Where(i => i.EstudanteId == estudanteId)
                .ToListAsync();

            return inscricoes;
        }

        public async Task<Inscricao?> GetByIdAsync(int id)
        {
            var inscricao = await _context.Inscricoes.FirstOrDefaultAsync(i => i.Id == id);
            return inscricao;
        }

        public async Task<bool> CursoExisteAsync(int cursoId)
        {
            var curso = await _context.Cursos.AnyAsync(c => c.Id == cursoId);
            return curso;
        }

        public async Task<bool> EstudanteExisteAsync(int estudanteId)
        {
            var estudante = await _context.Estudantes.AnyAsync(e => e.Id == estudanteId);
            return estudante;
        }

        public async Task<bool> InscricaoExisteAsync(int cursoId, int estudanteId)
        {
            var inscricao = await _context.Inscricoes.AnyAsync(i => i.CursoId == cursoId && i.EstudanteId == estudanteId);
            return inscricao;
        }

        public async Task CreateAsync(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(Inscricao inscricao)
        {
            _context.Inscricoes.Remove(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
