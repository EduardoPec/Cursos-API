using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Dtos
{
    public record LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
