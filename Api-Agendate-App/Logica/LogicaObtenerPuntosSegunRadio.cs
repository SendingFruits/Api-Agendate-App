using Api_Agendate_App.DTOs.Empresas;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Api_Agendate_App.Logica
{
    public class LogicaObtenerPuntosSegunRadio
    {

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
                double distancia = CalcularDistancia(latitudCli, longitudCli, empMap.Latitude, empMap.Longitude);

                if (distancia <= radioKm) //<= porque el calculo puede ser impreciso
                {
                    empresasDentroDelRadio.Add(empMap);
                }
            }

            return empresasDentroDelRadio;
        }

        private static double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Radio de la Tierra en kilómetros

            // Convertir latitudes y longitudes de grados a radianes
            double lat1Rad = ConvertirARadians(lat1);
            double lon1Rad = ConvertirARadians(lon1);
            double lat2Rad = ConvertirARadians(lat2);
            double lon2Rad = ConvertirARadians(lon2);

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

        private static double ConvertirARadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
