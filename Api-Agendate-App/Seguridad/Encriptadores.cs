using System.Security.Cryptography;
using System.Text;

namespace Api_Agendate_App.Seguridad
{
    public class Encriptadores
    {
        // Clave que se utiliza como secreto compartido para encriptar la clave
        private static readonly string _ClaveFija = "UnaClaveSecretaMuyDificil123!@#"; 

        // El Iv se combina con la clave para formar una clave unica para cada conjunto de datos cifradis
        // El valor de abajo genera un arreglo de bytes[] con el valor pasado por parametro
        // De esta forma, todas las claves tendran el mismo algoritmo de encriptacion y tendremos el mismo algoritmos.
        //
        private static readonly byte[] _Iv = Encoding.UTF8.GetBytes("Agendate-App-2023");

        public static string Encriptar(string contraseña)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_ClaveFija);
                aesAlg.IV = _Iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(contraseña);
                        }
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Desencriptar(string contraseñaCifrada)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_ClaveFija);
                aesAlg.IV = _Iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(contraseñaCifrada)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
