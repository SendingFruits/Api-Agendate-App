using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using System.Text;
using System.Security.Claims;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.DTOs.Usuarios;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly string secretKey;
        private readonly EmpresasService _empresasService;
        private readonly ClientesService _clienteService;

        public AuthenticationController(IConfiguration config, EmpresasService empresasService,ClientesService clientesService)
        {
            secretKey= config.GetSection("settings").GetSection("secretkey").ToString();
            _clienteService= clientesService;
            _empresasService= empresasService;

        }
        [HttpPost]
        [Route ("Login")]
        public async Task<ActionResult> Validar(string NomUsu , string Contrasenia)
        {
            if (string.IsNullOrWhiteSpace(NomUsu) && string.IsNullOrWhiteSpace(Contrasenia))
                return BadRequest("El usuario o la contraseña no pueden ser vacíos.");

            UsuarioDTO usuarioU = await _clienteService.Login(NomUsu, Encriptadores.Encriptar(Contrasenia));
            if (usuarioU == null)
            {
                usuarioU = await _empresasService.Login(NomUsu, Encriptadores.Encriptar(Contrasenia));
            }

            if (usuarioU != null)
            {
                var KeyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, NomUsu));
                //Crea Tokens
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);


                return StatusCode (StatusCodes.Status200OK,new { token = tokenCreado });
               // return Ok(usuarioU);
            }

            return BadRequest("Usuario no encontrado verifique identidades");

        }
    }
}
