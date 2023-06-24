using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text;
using System.Reflection.Emit;
using System.IO;
using System.Linq;

namespace APIRest.Model
{
    public class Randoms
    {
        public string RandomGenero(string genero)
        {
            try
            {
                Random r = new Random();
                int value = r.Next(1, 10);

                if (value <= 5 && value >= 1)
                {
                    return "gay o lesbiana";
                }
                if (value <= 10 && value >= 5)
                {
                    return "Hmbre o Mujer";
                }

                return genero;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public string RandomNombre(string nombre) 
        {
            try
            {
                char[] partNombre = nombre.ToCharArray();
                List<string> parts = new List<string>();
                List<string> parts2 = new List<string>();
                Random random = new Random();
                for(int i = 0; i < partNombre.Length; i++)
                {
                    parts2.Add(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(partNombre[i].ToString())));
                }
                for (int i = partNombre.Length-1; i >= 0; i--)
                {
                    parts.Add(string.Join("", parts2[i].Replace("=", "+")));
                }
                
                return string.Join("",parts);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string RandomDecode(Code guid)
        {
            try
            {
                string code = guid.GetHashCode().ToString();

                char[] separar = code.ToCharArray();
                int value;
                List<string> unir = new List<string>();
                for (int i = 0; i < separar.Length; i++)
                {
                    if (separar[i] == ' ')
                    {
                        separar[i] = '=';
                    }
                    unir.Add(string.Join("", separar[i].ToString()));
                }
                //
                code = string.Join("",unir);
                char[] partCode = separar;
                List<string> cuenta = new List<string>();
                List<string> cuenta2 = new List<string>();

                List<string> strings = new List<string>();
                string part = "";
                for(int i=0; i < partCode.Length;i+=4)
                {
                    part = code.Substring(i, 4);
                    cuenta.Add(string.Join("", part));
                    part = "";
                }


                for (int i = 0; i < cuenta.Count; i++)
                {
                    var codeCode = cuenta[i];
                    var base64EncodedBytes = System.Convert.FromBase64String(codeCode);
                    var base64Strings = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    cuenta2.Add(base64Strings);
                }

                for (int i = cuenta2.Count - 1; i >= 0; i--)
                {
                    strings.Add(string.Join("", cuenta2[i]));
                }


                return string.Join("", strings);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
