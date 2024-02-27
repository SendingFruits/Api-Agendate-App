using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Favoritos;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Favoritos")]
    public class FavoritosController : ControllerBase
    {
        private readonly APIRespuestas _respuestas;
        private readonly FavoritosService _favoritosService;
        private readonly MensajeriaService _SNoticar;

        public FavoritosController(FavoritosService favoritosService, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _favoritosService = favoritosService;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
        }

        [HttpGet("ObtenerFavorito")]
        public async Task<ActionResult<APIRespuestas>> ObtenerFavorito(int idCliente) 
        {
            var respuesta = await _favoritosService.GetFavoritos(idCliente);
            if (respuesta.Resultado == null)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
            }
            _respuestas.Resultado = respuesta.Resultado;
            _respuestas.codigo = 0;

            return Ok(_respuestas.Resultado);

        }

        [HttpGet("ObtenerIdFavorito")]
        public async Task<ActionResult<APIRespuestas>> ObtenerIdFavorito(int idCliente,int idServicio)
        {
            var respuesta = await _favoritosService.GetFavoritosClienteServicio(idCliente, idServicio);
            if (respuesta.Resultado == null)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
            }
            _respuestas.Resultado = respuesta.Resultado;
            _respuestas.codigo = 0;

            return Ok(_respuestas.Resultado);
        }

        [HttpPost("AgregarFavorito")]
        public async Task<ActionResult<APIRespuestas>> AgregarFavorito(FavoritoCrearDTO nuevoFavorito)
        {
            var respuesta = await _favoritosService.AddFavoritos(nuevoFavorito);
            if (respuesta.codigo != 0)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidades;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorInsertandoEntidades);
                return BadRequest(_respuestas.mensaje);
            }
            _respuestas.Resultado = respuesta.Resultado;
            _respuestas.codigo = 0;

            return Ok(_respuestas.mensaje);
        }

        [HttpDelete("EliminarFavorito")]
        public async Task<ActionResult<APIRespuestas>> EliminarFavorito(int id)
        {
            var respuesta = await _favoritosService.EliminarFavorito(id);
            if (respuesta.codigo != 0)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidades;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorInsertandoEntidades);
                return BadRequest(_respuestas.mensaje);
            }
            _respuestas.Resultado = respuesta.Resultado;
            _respuestas.codigo = 0;

            return Ok();
        }
    }
}
