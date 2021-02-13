using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPruebaFront.Interfaces
{
    public interface IClientesService
    {
        Task<JObject> ConsultarClientes();
        Task<JObject> ConsultarProductosById(string idCliente);
        Task<JObject> CrearCliente(JObject cliente);
        Task<JObject> CrearProducto(JObject cliente);
    }
}
