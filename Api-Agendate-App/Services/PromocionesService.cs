using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Promociones;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Interfases;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class PromocionesService
    {
        private readonly IReserva _reservaRepo;
        private readonly ICliente _clienteRepo;
        private readonly IPromocion _promo;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _mens;

        public PromocionesService(MensajeriaService mens, IEmpresa empresaRepo, IMapper mapper, APIRespuestas respuestas,ICliente cliente, IPromocion promo, IReserva reservaRepo)
        {
            _mens = mens;
            _Mapper = mapper;
            _respuestas = respuestas;
            _EmpresaRepo = empresaRepo;
            _promo = promo;
            _reservaRepo = reservaRepo;
            _clienteRepo = cliente;
        }

        public async Task<APIRespuestas> Create([FromBody] PromocionDTO NuevaPromo)
        {
            try
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
            }
            catch (Exception ex)
            {

            }
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

        public async Task<APIRespuestas> EnviarPromocion([FromBody] PromocionDTO entidad)
        {
            try
            {
                var P = await _promo.Obtener(p => p.Id == entidad.Id);
                if (P == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }
                if (P.Destinatarios.IsNullOrEmpty())
                {

                }


                await _mens.EnviarEmailPromocion(, P.AsuntoMensaje, P.CuerpoMensaje);

            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }

        public async Task<APIRespuestas> ObtenerContactosParaPromocion(int idServicio, int idPromocion)
        {
            try
            {
                var promocion = await _promo.Obtener(p => p.Id == idPromocion);
                if (promocion == null)
                {

                }   
                
                string contactos = await ObtenerContactosParaPromocion(idServicio);
                if (contactos.IsNullOrEmpty())
                {

                }

                promocion.Destinatarios = contactos;
                _promo.Actualizar(promocion);

            }
            catch (Exception ex)
            {

            }
            return _respuestas;
        }

        private async Task<string> ObtenerContactosParaPromocion(int idServicio)
        {
            string contactos = "";
            try
            {
                var reservas = await _reservaRepo.ObtenerTodos(r => r.ServicioId == idServicio);
                if (reservas.Count() == 0 || !reservas.Any() || reservas == null)
                    return string.Empty;

                var idsClientes =  reservas.Select(r => r.ClienteId).ToList();
                var clientes = await _clienteRepo.ObtenerTodos(c => idsClientes.Contains(c.Id));
                foreach (var c in clientes)
                {
                    if (contactos.IsNullOrEmpty())
                    {
                        contactos = c.Correo;
                        continue;
                    }
                    else if (contactos.Contains(c.Correo))
                        continue;

                    contactos = string.Concat(contactos, ',', c.Correo);
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            return contactos;
        }
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
