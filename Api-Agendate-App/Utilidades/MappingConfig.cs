using Api_Agendate_App.DTOs;
using Logic.Entities;
using AutoMapper;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.DTOs.Reservas;

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
            .ForMember(dest => dest.IdEmpresa, opt => opt.MapFrom(src => src.Empresa.Id))
            .ReverseMap();
            CreateMap<Reservas, ReservaDTO>().
                ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.ClienteId)).
                ForMember(dest => dest.IdServicio, opt => opt.MapFrom(src => src.ServicioId)).ReverseMap();
        }
    }
}
