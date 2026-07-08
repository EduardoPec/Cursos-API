using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Dtos
{
    public record UpdateCursoDto
    {
        [Required(ErrorMessage = "O título do curso é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do curso é obrigatória")]
        public string Descricao { get; set; } =  string.Empty;

        [Required(ErrorMessage = "A categoria do curso é obrigatória")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "A duração do curso é obrigatória")]
        public int CargaHoraria { get; set; }
    }
}
