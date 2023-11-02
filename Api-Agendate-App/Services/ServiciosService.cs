using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;

namespace Api_Agendate_App.Services
{
    public class ServiciosService
    {

        private readonly IServicios _ServRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        public ServiciosService(IServicios servRepo, IMapper mapper, APIRespuestas respuestas)
        {
            _ServRepo = servRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
        }

        public APIRespuestas Create([FromBody] ServicioDTO NuevoServicio)
        {
            var Existe = _ServRepo.Obtener(ser => ser.Id == NuevoServicio.Id);
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return _respuestas;
            }
            Servicios S = _Mapper.Map<Servicios>(NuevoServicio);
            _ServRepo.Crear(S);

            _respuestas.codigo = 0;



            return _respuestas;
        }


        public APIRespuestas Delete(int id)
        {
            var existe = _ServRepo.Obtener(ser => ser.Id == id);
            if (existe != null)
            {
                Servicios S = _Mapper.Map<Servicios>(existe);
                //_ServRepo.Remover(S);
                _respuestas.codigo = 0;
                return _respuestas;
            }




            _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;

            return _respuestas;
        }
        public APIRespuestas Update([FromBody] ServicioDTO entidad)
        {
            try
            {
                var Actualizo = _ServRepo.Obtener(e => e.Id == entidad.Id);
                if (Actualizo != null)
                {
                    /* var Servicio = new Servicio
                     {
                         Id = entidad.Id,
                         Nombre = entidad.Nombre,
                         Logo = entidad.Logo,
                         Calle = entidad.Calle,
                         Celular = entidad.Celular,
                         Contrasenia = entidad.Contrasenia,
                         NombreUsuario = entidad.NombreUsuario,
                         RutDocumento = entidad.RutDocumento,
                         RazonSocial = entidad.RazonSocial,
                         Descripcion = entidad.Descripcion,
                         Apellido = entidad.Apellido,
                         Ciudad = entidad.Ciudad,
                         Correo = entidad.Correo,
                         Latitud = entidad.Latitud,
                         NumeroPuerta = entidad.NumeroPuerta,
                         Longitud = entidad.Longitud,
                         NombrePropietario = entidad.NombrePropietario,
                         Rubro = entidad.Rubro
                     };*/


                    Servicios S = _Mapper.Map<Servicios>(entidad);
                    _ServRepo.Actualizar(S);


                    _respuestas.codigo = 0;



                }
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;


            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;

            }


            return _respuestas;

        }




        public async Task<IEnumerable<ServicioDTO>> GetSErvicios()
        {
            try
            {
                IEnumerable<Servicios> LServis = await _ServRepo.ObtenerTodos();
                IEnumerable<ServicioDTO> Lista = _Mapper.Map<IEnumerable<ServicioDTO>>(LServis);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<ServicioDTO>)_respuestas.Resultado;

        }

        internal async Task<ActionResult<ServicioDTO>> ObtenerServEmp(string Nomb)
        {
            try
            {
                
                var Servis =await  _ServRepo.ObtenerTodos(i => i.empresa.Nombre == Nomb);
                
                ServicioDTO EServ = _Mapper.Map<ServicioDTO>(Servis);
                _respuestas.Resultado = EServ;
                return EServ;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;
                return null;
            }
           
        }
    }
}
