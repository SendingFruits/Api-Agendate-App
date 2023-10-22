using Api_Agendate_App.Constantes;

namespace Api_Agendate_App.Utilidades
{
    public class APIRespuestas
    {
        public int codigo {  get; set; }
        public string mensaje { get; set; }

        public object Resultado { get; set; }

        public APIRespuestas()
        {
           this.codigo = 0;
           this.mensaje = string.Empty;
        }

        public void ObtenerMensaje(int p_codigo)
        {
            this.mensaje = ConstantesDeErrores.DevolverMensaje(p_codigo);
        }
    }
}
