using System.Security.Cryptography;
using System.Text;

namespace Api_Agendate_App.Seguridad
{
    public class Encriptadores
    {
        // Clave que se utiliza como secreto compartido para encriptar la clave
        private static readonly byte[] _ClaveFija = new byte[16]; 

        // El Iv se combina con la clave para formar una clave unica para cada conjunto de datos cifradis
        // El valor de abajo genera un arreglo de bytes[] con el valor pasado por parametro
        // De esta forma, todas las claves tendran el mismo algoritmo de encriptacion y tendremos el mismo algoritmos.
        //
        private static readonly byte[] _Iv = new byte[16];

        public static string Encriptar(string contraseña)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _ClaveFija;
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
                aesAlg.Key = _ClaveFija;
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

        public static string GenerarContraseniaRecuperacion()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";

            // Generador de números aleatorios seguro
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Crear un array de bytes para almacenar los valores aleatorios generados
                byte[] randomBytes = new byte[6];
                rng.GetBytes(randomBytes);

                // Crear un array de caracteres para la contraseña
                char[] password = new char[6];

                // Llenar la contraseña con caracteres aleatorios
                for (int i = 0; i < 6; i++)
                {
                    // Convertir el byte aleatorio en un índice dentro de la cadena de caracteres permitidos
                    password[i] = chars[randomBytes[i] % chars.Length];
                }

                return new string(password);
            }
        }
    }
}
