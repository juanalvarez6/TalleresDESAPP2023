﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TallerTres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerTresController : ControllerBase
    {
        public static List<ClsUsuario> ListUsuario = new List<ClsUsuario>()
        {
            new ClsUsuario()
            {
                Nombre = "Juan",
                Cedula = "123444534",
                Direccion = "Cra 12 # 27-42",
                Telefono = "32156677567",
                FNacimiento = "04/03/2000"
            },

            new ClsUsuario()
            {
                Nombre = "Andres",
                Cedula = "189765432",
                Direccion = "Cra 11 # 2-34",
                Telefono = "3126543279",
                FNacimiento = "06/07/2005"
            },

            new ClsUsuario()
            {
                Nombre = "Luis",
                Cedula = "18832678",
                Direccion = "Cra 8 # 4-112",
                Telefono = "3115438990",
                FNacimiento = "22/11/1981"
            },

        };

        public static List<ClsProducto> ListProductos = new List<ClsProducto>()
        {

            new ClsProducto()
            {
                Nombre = "Samsung Galaxy S21 FE",
                Codigo = "SG_001",
                Precio = 2699900,
                Estado = "Disponible"
            },

            new ClsProducto()
            {
                Nombre = "Samsung S22 Ultra",
                Codigo = "SG_002",
                Precio = 5749900,
                Estado = "Disponible"
            },

            new ClsProducto()
            {
                Nombre = "Samsung Galaxy Green S20 Fe",
                Codigo = "SG_003",
                Precio = 2249900,
                Estado = "Agotado"
            },


        };

        [HttpGet("MostrarUsuarios")]
        public List<ClsUsuario> mostrarUsuarios()
        {
            return ListUsuario;
        }

        [HttpGet("MostrarProductos")]
        public List<ClsProducto> mostrarProductos()
        {
            return ListProductos;
        }
    }
}
