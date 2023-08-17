using System.Security.Cryptography;
using System.Text;

namespace Api_Agendate_App.Utilidades
{
    public class Utilidad
    {

        public static string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash= SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(clave));

                foreach (byte b in result)
                {
                    //guarda un exadecimal 
                    sb.Append(b.ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}
