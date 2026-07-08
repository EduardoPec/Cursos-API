using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Exceptions;
using CursosAPI.Models;
using CursosAPI.Repositories.Interface;
using CursosAPI.Services.Interface;

namespace CursosAPI.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly IEstudanteRepository _repository;
        private readonly IMapper _mapper;

        public EstudanteService(IEstudanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;         
        }

        public async Task<IEnumerable<ReadEstudanteDto>> GetAllAsync()
        {
            var estudantes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadEstudanteDto>>(estudantes);
        }

        public async Task<ReadEstudanteDto?> GetByIdAsync(int id)
        {
            var estudante = await _repository.GetByIdAsync(id);

            if (estudante == null)
            {
                return null;
            }
            return _mapper.Map<ReadEstudanteDto>(estudante);
        }

        public async Task CreateAsync(CreateEstudanteDto dto)
        {
            var estudante = _mapper.Map<Estudante>(dto);
            await _repository.CreateAsync(estudante);
        }  

        public async Task UpdateAsync(int id, UpdateEstudanteDto dto)
        {
            var estudante = await _repository.GetByIdAsync(id);

            if (estudante == null) 
            { 
                throw new NotFoundException($"Estudante não encontrado! Id: {id}");
            }
                       
            _mapper.Map(dto, estudante);
            await _repository.UpdateAsync(estudante);
        }
        public async Task DeleteAsync(int id)
        {
            var estudante = await _repository.GetByIdAsync(id);

            if (estudante == null)
            {
                throw new NotFoundException($"Estudante não encontrado! Id: {id}");
            }
            await _repository.DeleteAsync(estudante);
        }
    }
}
