using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto
    {
        public int ID { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set;}
        public decimal Impuesto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }

    }//cierre de clase
}//cierre namespace
