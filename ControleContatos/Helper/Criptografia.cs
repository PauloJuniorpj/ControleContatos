using System.Security.Cryptography;
using System.Text;

namespace ControleContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var  hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var stringBuilder = new StringBuilder();

            foreach (var item in array)
            {
                stringBuilder.Append(item.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
