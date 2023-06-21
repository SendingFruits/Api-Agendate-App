using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using Logic.Entities;

namespace Api_Agendate_App.Services
{
    public class EmpresasService
    {
        private readonly Logic.Data.DataContext dataContext;

        public EmpresasService(Logic.Data.DataContext p_dataContext)
        {
            dataContext = p_dataContext;
        }

        public Empresa Login(string username, string password)
        {
            var empresas= dataContext.Empresas.Where(empe=> empe.NombreUsuario== username && empe.Contrasenia==password).FirstOrDefault();

            if (empresas==null)
            {
                return null;
            }
            return empresas;

        }

        public Empresa Create(Empresa nuevaEmpresa)
        public APIRespuestas Create(Empresa nuevaEmpresa)
        {
            APIRespuestas respuestas = new APIRespuestas();
            var empresas = dataContext.Empresas.Where(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento).FirstOrDefault();
            if (empresas != null)
            {
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
            }

            dataContext.Empresas.Add(nuevaEmpresa);
            dataContext.SaveChanges();

            return respuestas;
        }
    }
}
