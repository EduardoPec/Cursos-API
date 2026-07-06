using CursosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosAPI.Data
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Curso>()
                .HasIndex(curso => curso.Categoria);

            builder.Entity<Estudante>()
                .HasIndex(estudante => estudante.Email)
                .IsUnique();

            builder.Entity<Inscricao>()
                .HasIndex(inscricao => new { inscricao.CursoId, inscricao.EstudanteId })
                .IsUnique();

            builder.Entity<Inscricao>()
                .HasOne(inscricao => inscricao.Curso)
                .WithMany(curso => curso.Inscricoes)
                .HasForeignKey(inscricao => inscricao.CursoId);

            builder.Entity<Inscricao>()
                .HasOne(inscricao => inscricao.Estudante)
                .WithMany(estudante => estudante.Inscricoes)
                .HasForeignKey(inscricao => inscricao.EstudanteId);
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
