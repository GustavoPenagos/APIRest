using APIRest.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


//Aprendiendo a enviar peticiones en formato JSON
namespace APIRest.Controllers
{
    [ApiController]    
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;
        public HomeController(IConfiguration configuration)
        {
            _config = configuration;
        }
        [HttpPost]
        [Route("api/Listar")]
        public async Task<dynamic> ListaCliente(Cliente cliente, int opcion)
        {
            try
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
                        cliente.genero = r.RandomGenero(cliente.genero);
                        break;
                    default:
                        cliente.nombre = r.RandomNombre(cliente.nombre);
                        cliente.edad = cliente.edad + 10;
                        cliente.id = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(cliente.id));
                        cliente.genero = r.RandomGenero(cliente.genero);
                        break;
                }

                return new
                {
                    cliente.nombre,cliente.edad, cliente.id, cliente.genero
                    
                };
            }
            catch(Exception ex)
            {
                return new
                {
                    message = JsonSerializer.Serialize(ex.Message)
                };
            }
        }

        [HttpGet]
        [Route("api/Decode")]
        public async Task<dynamic> Decode(Code code)
        {
            try
            {
                Randoms randoms = new Randoms();
                var decode = new Randoms().RandomDecode(code);

                return new
                {
                    messagge= decode,
                };
            }
            catch(Exception ex)
            {
                return new
                {
                    messagge = ex.Message
                };
            }
        }

    }
}
