using System.Diagnostics.CodeAnalysis;

namespace APIRest.Model
{
    public class Randoms
    {
        public string RandomGenero()
        {
            Random r = new Random();
            int value = r.Next(1, 10);

            if(value <= 5 && value >= 1)
            {
                return "gay o lesbiana";
            }
            if(value <= 10 && value >= 5)
            {
                return "Hmbre o Mujer";
            }

            return "Error";
        }
        public string RandomNombre(string nombre) 
        {
            char[] partNombre = nombre.ToCharArray();
            List<string> parts = new List<string>();
            List<string> parts2 = new List<string>();
            int counter = 0;
            string completo = "";
            while (parts.Count < partNombre.Length) 
            {
                Random r = new Random();
                int value = r.Next(0, partNombre.Length);
                parts2.Add(string.Join("", partNombre[value]));
                counter++;
                if (parts.Count <= 0)
                {
                    parts.Add(string.Join("", partNombre[value]));
                    completo = string.Join("", parts);
                }
                else
                {
                    for (int k = 0; k < counter; k++)
                    {
                        var parts1 = parts2[k];
                        if (!completo.Contains(parts1))
                        {
                            parts.Add(string.Join("", partNombre[value]));
                            completo = string.Join("", parts);
                        }
                    }
                }
            }
            return completo;
        }
    }
}
