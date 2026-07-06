using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Dtos
{
    public class CreateEstudanteDto
    {
        [Required(ErrorMessage = "O nome do estudante é obrigatório")]
        public string NomeCompleto { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "O email do estudante é obrigatório")]
        public string Email { get; set; } = string.Empty;
    }
}
