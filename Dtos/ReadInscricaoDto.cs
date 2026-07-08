namespace CursosAPI.Dtos
{
    public record ReadInscricaoDto
    {
        public int Id { get; set; }
        public int EstudanteId { get; set; }
        public int CursoId { get; set; }
        public Status Status { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
