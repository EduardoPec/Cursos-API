using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<CreateCursoDto, Curso>();
            CreateMap<UpdateCursoDto, Curso>();
            CreateMap<Curso, ReadCursoDto>(); 
        }
    }
}
