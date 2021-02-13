using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusPruebaFront.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        [NotMapped]
        public int NumProductos { get; set; }
    }
}
