namespace Api_Agendate_App.Constantes
{
    public class ConstantesDeErrores
    {   
        // Del 1001 al 2000
        #region Errores por entidad (Singular)

        public const int ErrorEntidadExistente = 1001;
        public const int ErrorInsertandoEntidad = 1002;
        public const int ErrorEntidadInexistente = 1003;


        #region Clientes 1101 al 1200 -> ...
        public const int ErrorClienteConDocumentoExistente = 1101;
        #endregion

        #region Empresas 1201 al 1300 -> ...
        public const int ErrorEmpresaConDocumentoExistente = 1201;
        #endregion
        #region Errores Generales 1901 al 2000 -> ...
        public const int ErrorClaveViejaIngresadaConfirmarVacia = 1901;
        public const int ErrorClaveNuevaIngresadaConfirmarVacia = 1902;
        #endregion

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
        public const int ErrorContraseniaViejaNoCoincide = 3002;
        #endregion

        public static string DevolverMensaje(int codigoError)
        {
            string mensaje = "";

            if (codigoError == 0) return "Exito";

            #region Errores por entidad (Singular) --> ...
            if (codigoError >= 1001 && codigoError <= 2000)
            {
                switch (codigoError)
                {
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
            #endregion

            #region Errores de Clientes --> ...
            else if (codigoError >= 1101 && codigoError <= 1200)
            {
                switch (codigoError)
                {
                    case ErrorClienteConDocumentoExistente:
                        mensaje = "Ya existe un usuario con el documento de identidad ingresado";
                        break;
                }
            }
            #endregion

            #region Errores de Empresas --> ...
            else if (codigoError >= 1201 && codigoError <= 1300)
            {
                switch (codigoError)
                {
                    case ErrorEmpresaConDocumentoExistente:
                        mensaje = "Ya existe una Empresa con el RUT ingresado";
                        break;
                }
            }
            #endregion
            #region Errores generales en singular --> ...
            else if ( codigoError >= 1901 && codigoError <= 2000)
            {
                switch (codigoError)
                {
                    case ErrorClaveViejaIngresadaConfirmarVacia:
                        mensaje = "La clave vieja ingresada no puede ser vacía";
                        break;
                    case ErrorClaveNuevaIngresadaConfirmarVacia:
                        mensaje = "La clave nueva ingresada no puede ser vacía";
                        break;
                }

            }
            #endregion
            #region Errores por entidades(Plural) --> ...
            else if  (codigoError >= 2001 && codigoError <= 3000)
            {
                switch (codigoError)
                {
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
            #endregion
            #region Errores Generales --> ...
            else if (codigoError >= 3001 && codigoError <= 4000)
            {
                switch (codigoError)
                {
                    case ErrorCredencialesIncorrectas:
                        mensaje = "Las credenciales ingresadas no son correctas";
                        break;
                    case ErrorContraseniaViejaNoCoincide:
                        mensaje = "La contraseña vieja ingresada no coincide con la del usuario";
                        break;
                }
            }
            #endregion

            return mensaje;
        }
    }

}
