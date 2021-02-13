using BusPruebaFront.Data;
using BusPruebaFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusPruebaFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseDatosContext _context;

        public HomeController(BaseDatosContext clientes)
        {
            _context = clientes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Clientes()
        {
            List<Clientes> clientes = await _context.Clientes.ToListAsync();
            foreach (var item in clientes)
            {
                int numProductos = 0;
                numProductos = await _context.Productos.Where(a => a.IdCliente == item.IdCliente).CountAsync();
                item.NumProductos = numProductos;
            }
            return View(clientes);
        }
        

        [HttpPost]
        public async Task<IActionResult> Clientes(string nombre, string identificacion)
        {
            
           
            string respuesta = string.Empty;
            try
            {
                string Url = "http://localhost:7080/RestAdapter";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JObject data = new JObject();
                    data.Add("Nombre", nombre);
                    data.Add("Identificacion", identificacion);
                    string postData = JsonConvert.SerializeObject(data);
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusDescription == "OK")
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        JObject resultService = JObject.Parse(streamReader.ReadToEnd());
                        respuesta = resultService.Value<string>("Descripcion");
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.ToString();
                List<Clientes> clientess = await _context.Clientes.ToListAsync();
                foreach (var item in clientess)
                {
                    int numProductos = 0;
                    numProductos = await _context.Productos.Where(a => a.IdCliente == item.IdCliente).CountAsync();
                    item.NumProductos = numProductos;
                }
                return View(clientess);
            }
            List<Clientes> clientes = await _context.Clientes.ToListAsync();
            foreach (var item in clientes)
            {
                int numProductos = 0;
                numProductos = await _context.Productos.Where(a => a.IdCliente == item.IdCliente).CountAsync();
                item.NumProductos = numProductos;
            }
            return View(clientes);
        }

       

        public async Task<IActionResult> Productos(int id)
        {
            List<Productos> productos = await _context.Productos.Where(a => a.IdCliente == id).ToListAsync();
            return View(productos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
