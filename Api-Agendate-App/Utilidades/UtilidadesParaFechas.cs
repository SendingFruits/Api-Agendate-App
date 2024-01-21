namespace Api_Agendate_App.Utilidades
{
    public class UtilidadesParaFechas
    {
        /// <summary>
        /// Segun una fecha, devuelve el dia en espanol sin tilde para hacer la corroboracion de la bd
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string DevolverDiaDeSemanaEspanol(DateTime fecha)
        {
            DayOfWeek diaDeLaFecha = fecha.DayOfWeek;
            switch (diaDeLaFecha)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miercoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sabado";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string DevolverMesEspanol(DateTime fecha)
        {
            int numeroMes = fecha.Month;

            switch (numeroMes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
                default:
                    throw new ArgumentOutOfRangeException(nameof(numeroMes), "El número de mes está fuera del rango válido (1-12).");
            }
        }
    }
}
