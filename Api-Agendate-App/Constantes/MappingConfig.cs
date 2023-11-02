using Api_Agendate_App.DTOs;
using Logic.Entities;
using AutoMapper;
using Api_Agendate_App.DTOs.Usuarios;

namespace Api_Agendate_App.Constantes
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Usuarios, UsuarioDTO>().ReverseMap();
            CreateMap<Clientes, ClienteDTO>().ReverseMap();
            CreateMap<Empresas, EmpresaDTO>().ReverseMap();
            CreateMap<Empresas, EmpresaMapaDTO>().ReverseMap();
            CreateMap<Servicios, ServicioDTO>().ReverseMap();
        }
    }
}
