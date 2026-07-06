using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles
{
    public class InscricaoProfile : Profile
    {
        public InscricaoProfile()
        {
            CreateMap<CreateInscricaoDto, Inscricao>();
            CreateMap<Inscricao, ReadInscricaoDto>();
        }
    }
}
