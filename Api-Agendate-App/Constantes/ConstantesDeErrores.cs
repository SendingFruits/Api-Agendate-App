namespace Api_Agendate_App.Constantes
{
    public class ConstantesDeErrores
    {   
        // Del 1001 al 2000
        #region Errores por entidad (Singular)

        public const int ErrorEntidadExistente = 1001;
        public const int ErrorInsertandoEntidad = 1002;
        public const int ErrorEntidadInexistente = 1003;

        #endregion
        // Del 2001 al 3000
        #region Errores por entidades (Plural)
        public const int ErrorEntidadesExistentes = 2001;
        public const int ErrorInsertandoEntidades = 2002;
        public const int ErrorEntidadesInexistentes = 2003;
        #endregion

        // Del 3001 al 4000 
        #region Errores Generales 
        public const int ErrorCredencialesIncorrectas = 3001;

        #endregion

        public static string DevolverMensaje(int codigoError)
        {
            string mensaje = "";

            if (codigoError >= 1001 && codigoError <= 2000)
            {
                switch (codigoError)
                {
                    case 0:
                        mensaje = "Exito";
                        break;
                    case ErrorEntidadExistente:
                        mensaje = "La entidad a crear ya existe en el sistema";
                        break;
                    case ErrorInsertandoEntidad:
                        mensaje = "Error insertando la entidad en el sistema";
                        break;
                    case ErrorEntidadInexistente:
                        mensaje = "La entidad no existe";
                        break;
                }
            }
            else if  (codigoError >= 2001 && codigoError <= 3000)
            {
                switch (codigoError)
                {
                    case 0:
                        mensaje = "Exito";
                        break;
                    case ErrorEntidadExistente:
                        mensaje = "Las entidades a crear ya existen en el sistema";
                        break;
                    case ErrorInsertandoEntidad:
                        mensaje = "Error insertando las entidades en el sistema";
                        break;
                    case ErrorEntidadInexistente:
                        mensaje = "Las entidades no existen";
                        break;
                }
            }
            
            return mensaje;
        }
    }

}
