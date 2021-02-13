using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusPruebaFront.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public string NumProducto { get; set; }
        public string NombreProducto { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaApertura { get; set; }
    }
}
