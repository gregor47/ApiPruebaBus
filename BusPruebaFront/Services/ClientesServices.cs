using BusPruebaFront.Data;
using BusPruebaFront.Interfaces;
using BusPruebaFront.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPruebaFront.Services
{
    public class ClientesServices : IClientesService
    {
        private readonly BaseDatosContext _context;

        public ClientesServices(BaseDatosContext context)
        {
            _context = context;
        }
        public async Task<JObject> ConsultarClientes()
        {
            JObject response = new JObject();
            try
            {
                List<Clientes> clientes = await _context.Clientes.ToListAsync();
                JArray cli = new JArray();
                foreach (var item in clientes)
                {
                    JObject cliente = new JObject();
                    cliente.Add("Nombre", item.Nombre);
                    cliente.Add("Identificacion", item.Identificacion);
                    cli.Add(cliente);
                }
                response.Add("Codigo", "00");
                response.Add("Descripcion", "Exitoso");
                response.Add("Clientes", cli);
            }
            catch (Exception ex)
            {
                response = new JObject();
                response.Add("Codigo", "01");
                response.Add("Descripcion", "Error: " + ex.Message);
                response.Add("Clientes", null);
            }
            return response;
        }
        public async Task<JObject> ConsultarProductosById(string idCliente)
        {
            JObject response = new JObject();
            try
            {
                int id = await _context.Clientes.Where(b => b.Identificacion == idCliente).Select(a => a.IdCliente).FirstOrDefaultAsync();
                if(id != 0)
                {
                    List<Productos> productos = await _context.Productos.Where(a => a.IdCliente == id).ToListAsync();
                    JArray pro = new JArray();
                    foreach (var item in productos)
                    {
                        JObject Producto = new JObject();
                        Producto.Add("Nombre", item.NombreProducto);
                        Producto.Add("Numero", item.NumProducto);
                        Producto.Add("Estado", item.Estado ? "ACTIVO" : "INACTIVO");
                        Producto.Add("Fecha Apertura", item.FechaApertura.ToString("dd/MM/yyyy"));
                        pro.Add(Producto);
                    }
                    response.Add("Codigo", "00");
                    response.Add("Descripcion", "Exitoso");
                    response.Add("Productos", pro);
                }
                else
                {
                    response.Add("Codigo", "01");
                    response.Add("Descripcion", "No se encontro Cliente");
                    response.Add("Productos", null);
                }
            }
            catch (Exception ex)
            {
                response = new JObject();
                response.Add("Codigo", "01");
                response.Add("Descripcion", "Error: " + ex.Message);
                response.Add("Productos", null);
            }
            return response;
        }
        public async Task<JObject> CrearCliente(JObject cliente)
        {
            JObject response = new JObject();
            try
            {
                string identificacion = cliente.Value<string>("Identificacion");
                if (String.IsNullOrEmpty(identificacion) || String.IsNullOrEmpty(cliente.Value<string>("Nombre")))
                {
                    response.Add("Codigo", "01");
                    response.Add("Descripcion", "Error en parametros");
                    return response;
                }
                bool existe = await _context.Clientes.Where(a => a.Identificacion == identificacion).AnyAsync();
                if (!existe)
                {
                    Clientes cli = new Clientes()
                    {
                        Nombre = cliente.Value<string>("Nombre"),
                        Identificacion = identificacion,
                        TipoIdentificacion = 1,
                        FechaCreacion = DateTime.Now
                    };
                    _context.Clientes.Add(cli);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        response.Add("Codigo", "00");
                        response.Add("Descripcion", "Se ha creado cliente Exitosamente");
                    }
                    else
                    {
                        response.Add("Codigo", "00");
                        response.Add("Descripcion", "No se ha podido crear cliente");
                    }
                }
                else
                {
                    response.Add("Codigo", "01");
                    response.Add("Descripcion", "Cliente ya existe");
                }
            }
            catch (Exception ex)
            {
                response = new JObject();
                response.Add("Codigo", "01");
                response.Add("Descripcion", "Error: " + ex.Message);
            }
            return response;
        }
        public async Task<JObject> CrearProducto(JObject cliente)
        {
            JObject response = new JObject();
            string idCliente;
            string tipoProd;
            try
            {
                idCliente = cliente.Value<string>("IdCliente");
                int id = await _context.Clientes.Where(b => b.Identificacion == idCliente).Select(a => a.IdCliente).FirstOrDefaultAsync();
                if (id != 0)
                {
                    tipoProd = cliente.Value<string>("TipoProducto");
                    Productos prod = new Productos()
                    {
                        Estado = true,
                        IdCliente = id,
                        NombreProducto = tipoProd.Equals("1") ? "CUENTA DE AHORROS" : "TARJETA DE CREDITO",
                        FechaApertura = DateTime.Now,
                        NumProducto = tipoProd.Equals("1") ? GenerarNumProducto(1) : GenerarNumProducto(2)
                    };
                    _context.Productos.Add(prod);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        response.Add("Codigo", "00");
                        response.Add("Descripcion", "Se ha creado el producto exitosamente");
                        response.Add("Nombre Producto", prod.NombreProducto);
                        response.Add("Numero de Producto", prod.NumProducto);
                    }
                    else
                    {
                        response.Add("Codigo", "00");
                        response.Add("Descripcion", "No se ha podido crear el producto");
                        response.Add("Nombre Producto", null);
                        response.Add("Numero de Producto", null);
                    }
                }
                else
                {
                    response.Add("Codigo", "00");
                    response.Add("Descripcion", "No se ha encontrado el cliente");
                    response.Add("Nombre Producto", null);
                    response.Add("Numero de Producto", null);
                }
            }
            catch (Exception ex)
            {
                response = new JObject();
                response.Add("Codigo", "01");
                response.Add("Descripcion", "Error: " + ex.Message);
                response.Add("Nombre Producto", null);
                response.Add("Numero de Producto", null);
            }
            return response;
        }
        public string GenerarNumProducto(int tipo)
        {
            StringBuilder buidler = new StringBuilder();
            if (tipo == 1)
            {
                buidler.Append(RandomNumber(100000, 999999));
                buidler.Append(RandomNumber(100000, 999999));
            }
            else
            {
                buidler.Append(RandomNumber(10000000, 99999999));
                buidler.Append(RandomNumber(10000000, 99999999));
            }
            return buidler.ToString();
        }
        public string RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max).ToString();
        }
    }
}
