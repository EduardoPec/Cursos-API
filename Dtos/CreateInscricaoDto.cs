using System.ComponentModel.DataAnnotations;

namespace CursosAPI.Dtos
{
    public class CreateInscricaoDto
    {
        public int EstudanteId { get; set; }

        public int CursoId { get; set; }

        [Required(ErrorMessage = "O status da inscrição é obrigatório")]
        public Status Status { get; set; }
    }
}
