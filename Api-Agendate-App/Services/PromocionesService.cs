using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Promociones;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;


namespace Api_Agendate_App.Services
{
    public class PromocionesService
    {

        private readonly IPromocion _promo;
        private readonly MensajeriaService _mens;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        // private readonly List<> _client;

        public PromocionesService(MensajeriaService mens, IEmpresa empresaRepo, IMapper mapper, APIRespuestas respuestas, IPromocion promo)
        {
            _mens= mens;
            _Mapper = mapper;
            _respuestas = respuestas;
            _EmpresaRepo = empresaRepo;
            _promo = promo;
        }

        public async Task<APIRespuestas> Create([FromBody] PromocionDTO NuevaPromo)
        {
            var Existe = await _promo.Obtener(pro => pro.Titulo == NuevaPromo.titulo && pro.Empresa.Id == NuevaPromo.IdEmpresa);
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteElNombreDelaPromocion;
                return _respuestas;
            }


            var existeEmpresa = await _EmpresaRepo.Obtener(emp => emp.Id == NuevaPromo.IdEmpresa);

            if (existeEmpresa == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                return _respuestas;
            }

            Promociones P = _Mapper.Map<Promociones>(NuevaPromo);

            var empresa = await _EmpresaRepo.Obtener(emp => emp.Id == P.EmpresaId);

            if (empresa != null)
                P.Empresa = empresa;

            await _promo.Crear(P);

            return _respuestas;
        }


        public async Task<APIRespuestas> Eliminar(int PromoId)
        {
            try
            {
                var Existe = _promo.Obtener(pro => pro.Id == PromoId);
                if (Existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;


                }
                await _promo.Remover(PromoId);


            }
            catch (Exception ex)
            {
                _respuestas.codigo = 9999;
                _respuestas.mensaje = ex.Message;
            }

            return _respuestas;
        }

        public async Task<APIRespuestas> Modificar([FromBody] promoActualizarDTO entidad)
        {
            try
            {
                var PromoObtenido = await _promo.Obtener(c => c.Id == entidad.id && c.Activo == true);
                if (PromoObtenido == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }

                ActualizarAtributos(ref PromoObtenido, entidad);
                await _promo.Actualizar(PromoObtenido);

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }

            return _respuestas;

        }
        public async Task<IEnumerable<PromocionDTO>> GetPromociones()
        {
            try
            {
                IEnumerable<Promociones> LPromo = await _promo.ObtenerTodos(p => p.Activo == true);
                IEnumerable<PromocionDTO> Lista = _Mapper.Map<IEnumerable<PromocionDTO>>(LPromo);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<PromocionDTO>)_respuestas.Resultado;

        }
        public async Task<IEnumerable<PromocionDTO>> GetPromocionesporEmpresa(int Empresaid)
        {
            try
            {
                IEnumerable<Promociones> LPromo = await _promo.ObtenerTodos(p => p.Activo == true&& p.EmpresaId==Empresaid);
                IEnumerable<PromocionDTO> Lista = _Mapper.Map<IEnumerable<PromocionDTO>>(LPromo);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<PromocionDTO>)_respuestas.Resultado;

        }

        public async Task<APIRespuestas> EnviarPromocion([FromBody] PromocionDTO entidad)
        {
            try
            {

                var P = await _promo.Obtener(p => p.Id == entidad.id);
                if (P == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }

                List<Clientes> cl = P.lClientes;
                List<string> Mails = new List<string>();
                foreach (Clientes c in cl)
                {
                    string correo = c.Correo;
                    Mails.Add(correo);
                }


               await _mens.CreateMail(Mails.ToString(), P.Titulo, P.Descripcion);
                
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }
        private void ActualizarAtributos(ref Promociones PromoContext, promoActualizarDTO entidad)
        {
            if (PromoContext.Titulo != entidad.titulo)
                PromoContext.Titulo = entidad.titulo;
            if (PromoContext.Intervalo != entidad.intervalo)
                PromoContext.Intervalo = entidad.intervalo;
            if (PromoContext.FechaInicio != entidad.fechaInicio)
                PromoContext.FechaInicio = entidad.fechaInicio;
            if (PromoContext.FechaFin != entidad.fechaFin)
                PromoContext.FechaFin = entidad.fechaFin;
            if (PromoContext.Descripcion != entidad.descripcion)
                PromoContext.Descripcion = entidad.descripcion;
        }
    }
}
