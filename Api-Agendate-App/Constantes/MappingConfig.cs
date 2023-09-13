using Api_Agendate_App.Models;
using Logic.Entities;
using AutoMapper;

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
