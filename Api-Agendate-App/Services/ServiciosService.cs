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
        private readonly IHorarios _HorariosRepo;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        public ServiciosService(IServicios servRepo, IHorarios horarioRepo, IEmpresa empresaRepo, IMapper mapper, APIRespuestas respuestas)
        {
            _ServRepo = servRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _HorariosRepo = horarioRepo;
            _EmpresaRepo = empresaRepo;
        }

        public async Task<APIRespuestas> Create([FromBody] ServicioDTO NuevoServicio)
        {
            var Existe = await _ServRepo.Obtener(ser => ser.Nombre == NuevoServicio.Nombre && ser.empresa.Id == NuevoServicio.IdEmpresa);
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteElNombreDelServicio;
                return _respuestas;
            }


            var existeEmpresa = await _EmpresaRepo.Obtener(emp => emp.Id == NuevoServicio.IdEmpresa);

            if (existeEmpresa == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                return _respuestas;
            }

            Servicios S = _Mapper.Map<Servicios>(NuevoServicio);

            var empresa = await _EmpresaRepo.Obtener(emp => emp.Id == S.empresa.Id);

            if (empresa != null)
                S.empresa = empresa;

            await _ServRepo.Crear(S);

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
            //try
            //{
            //    //var Actualizo = _ServRepo.Obtener(e => e.Id == entidad.Id);
            //    if (Actualizo != null)
            //    {
            //        /* var Servicio = new Servicio
            //         {
            //             Id = entidad.Id,
            //             Nombre = entidad.Nombre,
            //             Logo = entidad.Logo,
            //             Calle = entidad.Calle,
            //             Celular = entidad.Celular,
            //             Contrasenia = entidad.Contrasenia,
            //             NombreUsuario = entidad.NombreUsuario,
            //             RutDocumento = entidad.RutDocumento,
            //             RazonSocial = entidad.RazonSocial,
            //             Descripcion = entidad.Descripcion,
            //             Apellido = entidad.Apellido,
            //             Ciudad = entidad.Ciudad,
            //             Correo = entidad.Correo,
            //             Latitud = entidad.Latitud,
            //             NumeroPuerta = entidad.NumeroPuerta,
            //             Longitud = entidad.Longitud,
            //             NombrePropietario = entidad.NombrePropietario,
            //             Rubro = entidad.Rubro
            //         };*/


            //        Servicios S = _Mapper.Map<Servicios>(entidad);
            //        //_ServRepo.Actualizar(S);


            //        _respuestas.codigo = 0;



            //    }
            //    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;


            //}
            //catch (Exception)
            //{
            //    _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;

            //}


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

        internal async Task<ActionResult<ServicioDTO>> ObtenerServicioPorNombreEmpresa(string nombreEmp)
        {
            try
            {
                var Servis =await  _ServRepo.ObtenerTodos(i => i.empresa.Nombre == nombreEmp);
                
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

        internal async Task<ActionResult<ServicioDTO>> ObtenerServicioPorIdEmpresa(int id)
        {
            try
            {
                var Servis = await _ServRepo.ObtenerTodos(i => i.empresa.Id == id);

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
