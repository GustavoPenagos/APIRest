using APIRest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIRest.Controllers
{
    [ApiController]
    
    public class HomeController : ControllerBase
    {
        // GET: HomeController
        [HttpPost]
        [Route("api/Listar")]
        public dynamic ListaCliente(Cliente cliente, int opcion)
        {
            Randoms r = new Randoms();
            switch (opcion)
            {
                case 1:
                    cliente.nombre = r.RandomNombre(cliente.nombre);
                    break;
                case 2:
                    cliente.edad = cliente.edad + 10;
                    break;
                case 3:
                    cliente.id = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(cliente.id));
                    break;
                case 4:
                    cliente.genero = r.RandomGenero();
                    break;
                default:
                    cliente.nombre = r.RandomNombre(cliente.nombre);
                    cliente.edad = cliente.edad + 10;
                    cliente.id = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(cliente.id));
                    cliente.genero = r.RandomGenero();
                    break;
            }
            

            return new
            {
                message = JsonSerializer.Serialize(cliente)
            };
        }
    }
}
