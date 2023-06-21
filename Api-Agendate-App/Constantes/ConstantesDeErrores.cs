namespace Api_Agendate_App.Constantes
{
    public class ConstantesDeErrores
    {
        public const int Exito = 0;
        public const int ErrorEntidadExistente = 1;
        public const int ErrorInsertandoEntidad = 2;

        public static string DevolverMensaje(int codigoError)
        {
            string mensaje = "";
            switch (codigoError)
            {
                case Exito:
                    mensaje = "Exito";
                    break;
                case ErrorEntidadExistente:
                    mensaje = "La entidad a crear ya existe en el sistema";
                    break;
                case ErrorInsertandoEntidad:
                    mensaje = "Error insertando la entidad en el sistema";
                    break;
            }
            return mensaje;
        }
    }

}
