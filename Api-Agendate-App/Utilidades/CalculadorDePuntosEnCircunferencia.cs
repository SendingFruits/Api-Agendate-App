using Api_Agendate_App.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Api_Agendate_App.Utilidades
{
    public class CalculadorDePuntosEnCircunferencia 
    {
        ////////////////////INFO\\\\\\\\\\\\\\\\\\\\
        //Formula: √( (x - a)^2 + (y - b)^2 ) = r
        //
        //Definiciones
        // El radio sera una constante que definiremos, ej: 20km
        // a y b son la latidud y la longitud que vendran del usuario
        // x e y son la latidud y la longitud que perteneceran a las empresas
        //
        //Razonamiento
        //Nos enviaran la ubicacion del cliente que definermos en las variables (a y b)
        //Luego obtendremos un diccionario con los ids de las empresas y sus latitudes y longitudes (x e y)
        //Sustituimos las variables y realizamos la formula
        // Si el resultado de la formula es el radio
        // ---> La empresa se encuentra dentro de la circunferencia del cliente

        /// <summary>
        /// Segun la longitud, la latitud del usuario y el radio de la circunferencia de la ubicacion, se filtran las empresas
        /// que estan ubicadas dentro de dicha circunferencia.
        /// </summary>
        /// <param name="listaEmpresas"></param>
        /// <param name="longitudCli"></param>
        /// <param name="latitudCli"></param>
        /// <param name="radioCircunferencia"></param>
        /// <returns>Lista de EmpresasMapaDTO filtradas por dicha circunferencia</returns>

        public static List<EmpresaMapaDTO> EmpresasDentroDelRadio(IEnumerable<EmpresaMapaDTO> listaEmpresas, float longitudCli, float latitudCli, float radioKm)
        {
            List<EmpresaMapaDTO> empresasDentroDelRadio = new List<EmpresaMapaDTO>();

            foreach (EmpresaMapaDTO empMap in listaEmpresas)
            {
                double distancia = CalculadorDePuntosEnCircunferencia.CalculateDistance(latitudCli, longitudCli, empMap.Latitude, empMap.Longitude);

                if (distancia <= radioKm)
                {
                    empresasDentroDelRadio.Add(empMap);
                }
            }

            return empresasDentroDelRadio;
        }

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Radio de la Tierra en kilómetros

            // Convertir latitudes y longitudes de grados a radianes
            double lat1Rad = DegreesToRadians(lat1);
            double lon1Rad = DegreesToRadians(lon1);
            double lat2Rad = DegreesToRadians(lat2);
            double lon2Rad = DegreesToRadians(lon2);

            // Diferencia de latitudes y longitudes
            double dLat = lat2Rad - lat1Rad;
            double dLon = lon2Rad - lon1Rad;

            // Fórmula del haversine
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calcular la distancia en kilómetros
            double distance = EarthRadius * c;

            return distance;
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
