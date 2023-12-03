using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

      

    }
 }