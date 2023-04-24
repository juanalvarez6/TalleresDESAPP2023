using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TallerCuatro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerUsuario : ControllerBase
    {

        public static List<ClsUsuario> ListItem = new List<ClsUsuario>()
        {
            new ClsUsuario
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                FNacimiento = "04/03/2000",
                Telefono = "3215677567",
                Direccion = "Cra 12 # 27-42"
            },

            new ClsUsuario
            {
                Id = 2,
                Nombre = "Andres",
                Apellido = "Gomez",
                FNacimiento = "06/07/2005",
                Telefono = "3126543279",
                Direccion = "Cra 11 # 2-34"
            },

            new ClsUsuario
            {
                Id = 3,
                Nombre = "Luis",
                Apellido = "Ramirez",
                FNacimiento = "22/11/1981",
                Telefono = "3115438990",
                Direccion = "Cra 8 # 4-112"
            },
        };

        [HttpGet("Search")]
        public dynamic Search(int Id)
        {
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("Admin")).FirstOrDefault();

            if (hdr_key.Value != "UsuAdmin_key")
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API002",
                    message = "No autorizado",
                    detail = "La clave de autenticación es inválida"
                });
            }
            else
            {
                var item = ListItem.Where(x => x.Id == Id).ToList();
                if (item.Count > 0)
                {
                    return item;
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        code = "API001",
                        message = "No se encontraron datos",
                        Detail = "N/A"
                    });
                }
            }
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] ClsUsuario item)
        {
            var hdr_key = Request.Headers.FirstOrDefault(x => x.Key.Equals("Admin"));
            if (hdr_key.Value != "UsuAdmin_key")
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API002",
                    message = "No autorizado",
                    detail = "La clave de autenticación es inválida"
                });
            }
            else
            {
                ListItem.Add(item);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    code = "OK",
                    message = "Datos Almacenados",
                    Detail = item
                });
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] ClsUsuario item)
        {
            var hdr_key = Request.Headers.FirstOrDefault(x => x.Key.Equals("Admin"));
            if (hdr_key.Value != "UsuAdmin_key")
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API002",
                    message = "No autorizado",
                    detail = "La clave de autenticación es inválida"
                });
            }
            else
            {
                foreach (var det in ListItem.Where(x => x.Id == item.Id).ToList())
                {
                    det.Nombre = item.Nombre;
                    det.Apellido = item.Apellido;
                    det.FNacimiento = item.FNacimiento;
                    det.Telefono = item.Telefono;
                    det.Direccion = item.Direccion;
                }

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Datos Modificados",
                    Detail = item
                });
            }
        }

        [HttpDelete("Delete")]
        public IActionResult delete(int id)
        {
            var hdr_key = Request.Headers.FirstOrDefault(x => x.Key.Equals("Admin"));
            if (hdr_key.Value != "UsuAdmin_key")
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API002",
                    message = "No autorizado",
                    detail = "La clave de autenticación es inválida"
                });
            }
            else
            {
                ClsUsuario objprueba = (ClsUsuario)ListItem.Where(x => x.Id == id).First();
                if (objprueba != null)
                    ListItem.Remove(objprueba);

                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Datos Eliminados",
                    Detail = id
                });
            }
        }
    }
}