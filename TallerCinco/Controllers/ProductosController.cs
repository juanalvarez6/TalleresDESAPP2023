using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerCinco.Models;

namespace TallerCinco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public readonly WebApiContext _dbcontex;


        public ProductosController(WebApiContext _contex)
        {
            _dbcontex = _contex;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {

            List<Producto> listProd = new List<Producto>();

            try
            {
                listProd = _dbcontex.Productos.ToList();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Consulta Exitosa",
                    Detail = listProd
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "OK",
                    message = "Error al consultar",
                    Detail = ex.Message
                });

            }

        }
    }
}
