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
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaMapaDTO>().ReverseMap();
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
        }
    }
}
