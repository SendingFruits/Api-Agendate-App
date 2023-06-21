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

        public APIRespuestas Create(Cliente p_nuevoCliente)
        {
            APIRespuestas respuestas = new APIRespuestas();
            var cliente = dataContext.Clientes.Where(cli => cli.Documento == p_nuevoCliente.Documento).FirstOrDefault();
            if (cliente != null)
            {
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
            }

            dataContext.Clientes.Add(p_nuevoCliente);
            dataContext.SaveChanges();

            return respuestas;
        }
    }
}
