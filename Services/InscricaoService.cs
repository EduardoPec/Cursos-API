using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using CursosAPI.Services.Interface;

namespace CursosAPI.Services
{
    public class InscricaoService : IInscricaoService
    {

        private readonly IInscricaoRepository _repository;
        private readonly IMapper _mapper;

        public InscricaoService(IInscricaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadInscricaoDto>> GetAllAsync()
        {
            var inscricoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadInscricaoDto>>(inscricoes);
        }

        public async Task<IEnumerable<ReadInscricaoDto>> GetByEstudanteIdAsync(int estudanteId)
        {
            var inscricoes = await _repository.GetByEstudanteIdAsync(estudanteId);
            return _mapper.Map<IEnumerable<ReadInscricaoDto>>(inscricoes);
        }

        public async Task<ReadInscricaoDto?> GetByIdAsync(int id)
        {
            var inscricao = await _repository.GetByIdAsync(id);

            if (inscricao == null)
            {
                return null;
            }
            return _mapper.Map<ReadInscricaoDto>(inscricao);
        }

        public async Task CreateAsync(CreateInscricaoDto dto)
        {
            if (!await _repository.CursoExisteAsync(dto.CursoId)) 
            {
                throw new NotFoundException($"Curso não encontrado! Id: {dto.CursoId}");
            }

            if (!await _repository.EstudanteExisteAsync(dto.EstudanteId))
            {
                throw new NotFoundException($"Estudante não encontrado! Id: {dto.EstudanteId}");
            }

            if (await _repository.InscricaoExisteAsync(dto.CursoId, dto.EstudanteId))
            {
                throw new DuplicatedException($"Estudante já matriculado neste curso! CursoId: {dto.CursoId}, EstudanteId: {dto.EstudanteId}");
            }

            var inscricao = _mapper.Map<Inscricao>(dto);
            await _repository.CreateAsync(inscricao);
        }

        public async Task DeleteAsync(int id)
        {
            var inscricao = await _repository.GetByIdAsync(id);

            if (inscricao == null)
            {
                throw new NotFoundException($"Inscrição não encontrada! Id: {id}");
            }
            await _repository.DeleteAsync(inscricao);
        }
    }
}
