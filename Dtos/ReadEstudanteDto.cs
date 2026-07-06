namespace CursosAPI.Dtos
{
    public class ReadEstudanteDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<ReadInscricaoDto> Inscricoes { get; set; } = new List<ReadInscricaoDto>();
    }
}
