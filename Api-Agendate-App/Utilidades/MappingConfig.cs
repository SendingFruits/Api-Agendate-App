using Api_Agendate_App.DTOs;
using Logic.Entities;
using AutoMapper;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.Utilidades
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Usuarios, UsuarioDTO>().ReverseMap();
            CreateMap<Clientes, ClienteDTO>().ReverseMap();
            CreateMap<Empresas, EmpresaDTO>().ReverseMap();
            CreateMap<Empresas, EmpresaMapaDTO>().ReverseMap();
            CreateMap<Servicios, ServicioDTO>()
            .ForMember(dest => dest.IdEmpresa, opt => opt.MapFrom(src => src.empresa.Id))
            .ReverseMap();
        }
    }
}
