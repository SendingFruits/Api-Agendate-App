using Logic.Data;
using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using Logic.Entities;

namespace Api_Agendate_App.Services
{
    public class ClientesService
    {
        private readonly Logic.Data.DataContext dataContext;

        public ClientesService(Logic.Data.DataContext p_dataContext)
        {
            dataContext = p_dataContext;
        }


        public Cliente Login (string username, string password) 
        public APIRespuestas Create(Cliente p_nuevoCliente)
        {
            var clientes = dataContext.Clientes.Where(cli=> cli.NombreUsuario== username&& cli.Contrasenia== password).FirstOrDefault();
            if (clientes == null)
            APIRespuestas respuestas = new APIRespuestas();
            var cliente = dataContext.Clientes.Where(cli => cli.Documento == p_nuevoCliente.Documento).FirstOrDefault();
            if (cliente != null)
            {
                return null;
            }
            return clientes;
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
        }

    }
}
