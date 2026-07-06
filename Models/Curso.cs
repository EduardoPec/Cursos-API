using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Models
{
    public class Curso
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do curso é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do curso é obrigatória")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria do curso é obrigatória")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "A duração do curso é obrigatória")]
        public int CargaHoraria { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
