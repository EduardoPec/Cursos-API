using CursosAPI.Data;
using CursosAPI.Dtos;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CursosAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        private readonly CursoContext _context;

        public CursoRepository(CursoContext context)
        {
            _context = context;
        } 

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            var cursos = await _context.Cursos.ToListAsync();
            return cursos;
        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id);
            return curso;
        }

        public async Task CreateAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        internal async Task CreateAsync(CreateCursoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
