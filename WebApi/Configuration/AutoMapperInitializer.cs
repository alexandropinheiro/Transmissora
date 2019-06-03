using AutoMapper;
using Dominio.Entidades;
using Dominio.Models;

namespace WebApi.Configuration
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ApiProfile>());
        }
    }

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<TransmissoraModel, Transmissora>();
        }
    }
}