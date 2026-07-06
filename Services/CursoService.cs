using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using CursosAPI.Services.Interface;

namespace CursosAPI.Services
{
    public class CursoService : ICursoService
    {

        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadCursoDto>> GetAllAsync()
        {
            var cursos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadCursoDto>>(cursos);
        }

        public async Task<ReadCursoDto?> GetByIdAsync(int id)
        {
            var curso = await _repository.GetByIdAsync(id);

            if (curso == null)
            {
                return null;
            }
            return _mapper.Map<ReadCursoDto>(curso);
        }

        public async Task CreateAsync(CreateCursoDto dto)
        {
            var curso = _mapper.Map<Curso>(dto);
            await _repository.CreateAsync(curso);
        }        

        public async Task UpdateAsync(int id, UpdateCursoDto dto)
        {
            var curso = await _repository.GetByIdAsync(id);

            if (curso == null) 
            {
                throw new NotFoundException($"Curso não encontrado! Id: {id}");
            }
            _mapper.Map(dto, curso);
            await _repository.UpdateAsync(curso);
        }
        public async Task DeleteAsync(int id)
        {
            var curso = await _repository.GetByIdAsync(id);

            if (curso == null)
            {
                throw new NotFoundException($"Curso não encontrado! Id: {id}");
            }
            await _repository.DeleteAsync(curso);
        }
    }
}
