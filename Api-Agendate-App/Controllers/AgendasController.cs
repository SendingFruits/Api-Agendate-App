using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Agendas")]
    public class AgendasController : ControllerBase
    {
    }
}
