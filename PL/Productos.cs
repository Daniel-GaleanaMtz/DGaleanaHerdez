using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Productos
    {
        public static void GetById()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingresa el codigo de un producto: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Productos.GetById(producto);

            if (result.Correct)
            {
                producto.PrecioFinal = ((ML.Producto)result.Object).PrecioFinal;
                producto.PrecioEnvio = ((ML.Producto)result.Object).PrecioEnvio;

                Console.WriteLine("Producto Seleccionado:");
                Console.WriteLine("Nombre:" + ((ML.Producto)result.Object).Nombre);
                Console.WriteLine("Precio de envio:" + ((ML.Producto)result.Object).PrecioEnvio);
                Console.WriteLine("Distancia estimada:" + ((ML.Producto)result.Object).Sucursal.DistanciaEstimada);
                Console.WriteLine("Precio:" + ((ML.Producto)result.Object).Precio);
                Console.WriteLine("Iva:" + ((ML.Producto)result.Object).Iva);
                Console.WriteLine("Precio final:" + ((ML.Producto)result.Object).PrecioFinal);              
            }
            Console.WriteLine("Ingrese la fecha para consultar el tipo de cambio de la divisa(dd/MM/yyyy): ");
            producto.FechaConsulta = (Console.ReadLine());
            DGaleanaHerdezService.Service1Client service = new DGaleanaHerdezService.Service1Client();
            var resultWCF = service.CambiarDivisas(producto);
            ML.Result resultDivisas = new ML.Result();
            resultDivisas.Correct = resultWCF.Correct;
            resultDivisas.Object = resultWCF.Object;
            if (resultDivisas.Correct)
            {
                Console.WriteLine("El precio final en Dolares es: " + ((ML.Producto)resultDivisas.Object).PrecioDolares);
                Console.WriteLine("El precio final en Euros es: " + ((ML.Producto)resultDivisas.Object).PrecioEuros);
            }
            Console.ReadKey();
        }
    }
}
