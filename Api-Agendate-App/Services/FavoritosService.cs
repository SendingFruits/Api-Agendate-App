using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using Repositorio.Interfases;
using System.Collections.Generic;
using Api_Agendate_App.Logica;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Favoritos;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class FavoritosService
    {
        private readonly IFavoritos _FavoRepo;
        private readonly IServicios _ServRepo;
        private readonly ICliente _CliRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _SNoticar;


        public FavoritosService(IFavoritos favoRepo, IServicios servRepo, ICliente clieRepo, IMapper mapper, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _FavoRepo = favoRepo;
            _ServRepo = servRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
            _CliRepo = clieRepo;
        }

        public async Task<APIRespuestas> GetFavoritos(int idCliente)
        {
            try
            {
                #region Corroboracion de existencia de las relaciones ->
                var cliente = await _CliRepo.Obtener(cli => cli.Id == idCliente);
                if (cliente == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                    return _respuestas;
                }
                #endregion

                var favoritosCliente = await _FavoRepo.ObtenerTodos(f => f.ClienteId == idCliente);
                if (!favoritosCliente.Any())
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                }
                var Lista = _Mapper.Map<IEnumerable<FavoritosDTO>>(favoritosCliente).ToList();
                _respuestas.Resultado = Lista;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }

        public async Task<APIRespuestas> AddFavoritos(FavoritosDTO favoritodto)
        {
            try
            {
                #region Corroboracion de existencia de las relaciones ->
                var cliente = await _CliRepo.Obtener(cli => cli.Id == favoritodto.IdCliente);
                if (cliente == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                    return _respuestas;
                }

                var servicio = await _ServRepo.Obtener(srv => srv.Id == favoritodto.IdServicio);
                if (servicio == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorServicioConIdNoEncontrado;
                    return _respuestas;
                }

                var favoritoBD = await _FavoRepo.Obtener(f => f.ClienteId == favoritodto.IdCliente && f.ServicioId == favoritodto.IdServicio);
                if (favoritoBD != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorFavoritoYaExistente;
                    return _respuestas;
                }
                #endregion

                Favoritos favorito = _Mapper.Map<Favoritos>(favoritodto);
                await _FavoRepo.Crear(favorito);

                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }

        public async Task<APIRespuestas> ModificarNotificacionFavorito(int idFavoritos, bool notificacion)
        {
            try
            {
                var favorito = await _FavoRepo.Obtener(r => r.Id == idFavoritos);
                if (favorito == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorFavoritoConIdInexistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                favorito.recibirNotificaciones = notificacion;
                await _FavoRepo.Actualizar(favorito);
            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoAlCancelarReserva;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            return _respuestas;
        }

    }
}
