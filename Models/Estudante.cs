using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Models
{
    public class Estudante
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do estudante é obrigatório")]
        public string NomeCompleto { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "O email do estudante é obrigatório")]
        public string Email { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
