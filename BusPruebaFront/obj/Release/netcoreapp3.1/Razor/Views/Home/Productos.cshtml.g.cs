#pragma checksum "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95b7b72bbd5a72f0a75fb4175600004195d7f62d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Productos), @"mvc.1.0.view", @"/Views/Home/Productos.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\_ViewImports.cshtml"
using BusPruebaFront;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\_ViewImports.cshtml"
using BusPruebaFront.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95b7b72bbd5a72f0a75fb4175600004195d7f62d", @"/Views/Home/Productos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1482267a0b2c4f035b91733eb6471cdc0675c067", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Productos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BusPruebaFront.Models.Productos>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
  

    ViewData["Title"] = "Productos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>LISTA PRODUCTOS</h1>

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Nombre Producto</th>
            <th scope=""col"">Numero Producto</th>
            <th scope=""col"">Estado</th>
            <th scope=""col"">Fecha Apertura</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
               Write(item.NombreProducto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
               Write(item.NumProducto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 24 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
                 if (item.Estado)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>ACTIVO</td>\r\n");
#nullable restore
#line 27 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>INACTIVO</td>\r\n");
#nullable restore
#line 31 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td> ");
#nullable restore
#line 32 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
                Write(item.FechaApertura.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Gregory\source\repos\BusPrueba\BusPruebaFront\Views\Home\Productos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BusPruebaFront.Models.Productos>> Html { get; private set; }
    }
}
#pragma warning restore 1591
