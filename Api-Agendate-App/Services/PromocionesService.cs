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
        private readonly IReserva _reservaRepo;
        private readonly IPromocion _promo;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _mens;

        public PromocionesService(MensajeriaService mens, IEmpresa empresaRepo, IMapper mapper, APIRespuestas respuestas, IPromocion promo, IReserva reservaRepo)
        {
            _mens = mens;
            _Mapper = mapper;
            _respuestas = respuestas;
            _EmpresaRepo = empresaRepo;
            _promo = promo;
            _reservaRepo = reservaRepo;
        }

        public async Task<APIRespuestas> Create([FromBody] PromocionDTO NuevaPromo)
        {
            var Existe = await _promo.Obtener(pro => pro.Empresa.Id == NuevaPromo.EmpresaId);
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteElNombreDelaPromocion;
                return _respuestas;
            }


            var existeEmpresa = await _EmpresaRepo.Obtener(emp => emp.Id == NuevaPromo.EmpresaId);

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
        public async Task<APIRespuestas> Modificar([FromBody] PromocionDTO entidad)
        {
            try
            {
                var PromoObtenido = await _promo.Obtener(c => c.Id == entidad.Id);
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
        public async Task<IEnumerable<PromocionDTO>> GetPromocionesporEmpresa(int Empresaid)
        {
            try
            {
                IEnumerable<Promociones> LPromo = await _promo.ObtenerTodos(p => p.EmpresaId==Empresaid);
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

        //public async Task<APIRespuestas> EnviarPromocion([FromBody] PromocionDTO entidad)
        //{
        //    try
        //    {
        //        var P = await _promo.Obtener(p => p.Id == entidad.Id);
        //        if (P == null)
        //        {
        //            _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
        //            return _respuestas;
        //        }
        //        List<string> Mails = new List<string>();
        //        foreach (Clientes c in cl)
        //        {
        //            string correo = c.Correo;
        //            Mails.Add(correo);
        //        }

        //       await _mens.CreateMail(Mails.ToString(), P.Titulo, P.Descripcion);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        _respuestas.mensaje = ex.Message;

        //    }
        //    return _respuestas;
        //}

        //private async string ObtenerContactosParaPromocion(int idServicio)
        //{
        //    string contactos = "";
        //    try
        //    {
        //        var reservas = await _reservaRepo.ObtenerTodos(r => r.ServicioId == idServicio);
        //        if (reservas.Count() != 0 || !reservas.Any() || reservas == null)
        //            return string.Empty;

        //        foreach (var r in  reservas)
        //        {
        //            contactos = string.Concat(contactos, ',', r.Cliente.Correo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return string.Empty;
        //    }
        //    return contactos;
        //}
        private void ActualizarAtributos(ref Promociones PromoContext, PromocionDTO entidad)
        {
                if (PromoContext.CuerpoMensaje != entidad.CuerpoMensaje)
                    PromoContext.CuerpoMensaje = entidad.CuerpoMensaje;
                if (PromoContext.AsuntoMensaje != entidad.AsuntoMensaje)
                    PromoContext.AsuntoMensaje = entidad.AsuntoMensaje;
                if (PromoContext.Destinatarios != entidad.Destinatarios)
                    PromoContext.Destinatarios = entidad.Destinatarios;
        }
    }
}
