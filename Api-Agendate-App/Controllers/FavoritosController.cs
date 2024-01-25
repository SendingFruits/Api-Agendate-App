using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
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

    }
}
