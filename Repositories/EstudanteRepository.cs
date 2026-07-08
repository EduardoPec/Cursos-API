using CursosAPI.Data;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CursosAPI.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {

        private readonly CursoContext _context;

        public EstudanteRepository(CursoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudante>> GetAllAsync()
        {
            var estudante = await _context.Estudantes.ToListAsync();
            return estudante;
        }

        public async Task<Estudante?> GetByIdAsync(int id)
        {
            var estudante = await _context.Estudantes.FirstOrDefaultAsync(e => e.Id == id);
            return estudante;
        }

        public async Task<Estudante?> GetByEmailAsync(string email)
        {
            var estudanteEmail = await _context.Estudantes.FirstOrDefaultAsync(e => e.Email == email);
            return estudanteEmail;
        }

        public async Task CreateAsync(Estudante estudante)
        {
            await _context.Estudantes.AddAsync(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudante estudante)
        {
            _context.Estudantes.Update(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Estudante estudante)
        {
            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
