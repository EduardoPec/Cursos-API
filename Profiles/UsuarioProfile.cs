using AutoMapper;
using CursosAPI.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
