using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles
{
    public class EstudanteProfile : Profile
    {
        public EstudanteProfile()
        {
            CreateMap<CreateEstudanteDto, Estudante>();
            CreateMap<UpdateEstudanteDto, Estudante>();
            CreateMap<Estudante, ReadEstudanteDto>();
        }
    }
}
