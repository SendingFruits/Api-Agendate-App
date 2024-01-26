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

namespace Api_Agendate_App.Services
{
    public class FavoritosService
    {
        private readonly IFavoritos _FavoRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _SNoticar;

        public FavoritosService(IFavoritos favoRepo, IMapper mapper, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _FavoRepo = favoRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
        }

        public async Task<APIRespuestas> GetFavoritos(int id)
        {
            try
            {
                var EmpresasZona = await _FavoRepo.ObtenerTodos(f => f.ClienteId);
                if (!EmpresasZona.Any())
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                }
                var Lista = _Mapper.Map<IEnumerable<EmpresaDTO>>(EmpresasZona).ToList();
                _respuestas.Resultado = Lista;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }

    }
}
