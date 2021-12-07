using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public double PrecioFinal { get; set; }
        public double PrecioEnvio { get; set; }
        public double PrecioProducto { get; set; }
        public string FechaConsulta { get; set; }
        public double PrecioDolares { get; set; }
        public double PrecioEuros { get; set; }
        public ML.Sucursal Sucursal { get; set; }
    }
}
