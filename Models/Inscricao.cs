using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Models
{
    public class Inscricao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int EstudanteId { get; set; }
        public virtual Estudante Estudante { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [Required(ErrorMessage = "O status da inscrição é obrigatório")]
        public Status Status { get; set; }

        public DateTime DataMatricula { get; set; } = DateTime.UtcNow;

    }
}
