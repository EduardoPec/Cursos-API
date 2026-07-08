namespace CursosAPI.Dtos
{
    public record ReadCursoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<ReadInscricaoDto> Inscricoes { get; set; } = new List<ReadInscricaoDto>();
    }
}
