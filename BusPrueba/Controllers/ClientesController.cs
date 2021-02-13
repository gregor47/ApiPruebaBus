using BusPruebaFront.Data;
using BusPruebaFront.Interfaces;
using BusPruebaFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPrueba.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientes;

        public ClientesController(IClientesService clientesService)
        {
            _clientes = clientesService;
        }
        [Route("GetClientes")]
        [HttpGet]
        public async Task<JObject> GetClientes()
        {
            return await _clientes.ConsultarClientes();
        }
        [Route("GetProduct")]
        [HttpGet]
        public async Task<JObject> GetProduct(string id)
        {
            return await _clientes.ConsultarProductosById(id);
        }
        [Route("CreateClient")]
        [HttpPost]
        public async Task<JObject> CreateClient([FromBody] JObject data)
        {
            return await _clientes.CrearCliente(data);
        }
        [Route("CreateProduct")]
        [HttpPost]
        public async Task<JObject> CreateProduct([FromBody] JObject data)
        {
            return await _clientes.CrearProducto(data);
        }
    }
}
