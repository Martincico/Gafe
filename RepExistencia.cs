using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAFE
{
    class RepExistencia
    {
        public string ClaveArticulo { get; set; }
        public string DscArticulo { get; set; }
        public string DscLinea { get; set; }
        public string ClaveAlmacen { get; set; }
        public string Cantidad { get; set; }
        public string CantidaApartada { get; set; }
        public string ExTotal { get; set; }
        public string stockMin { get; set; }
        public string stockMax { get; set; }
        public string CostoPromedio { get; set; }
        public string CostoUltimo { get; set; }
        public string CostoActual { get; set; }
        public string Ubicacion { get; set; }

        public RepExistencia()
        {  }

        public RepExistencia(RepExistencia Reg) {
            ClaveArticulo = Reg.ClaveArticulo;
            DscArticulo = Reg.DscArticulo;
            DscLinea = Reg.DscLinea;
            ClaveAlmacen = Reg.ClaveAlmacen;
            Cantidad = Reg.Cantidad;
            CantidaApartada = Reg.CantidaApartada;
            ExTotal = Reg.ExTotal;
            stockMin = Reg.stockMin;
            stockMax = Reg.stockMax;
            CostoPromedio = Reg.CostoPromedio;
            CostoUltimo = Reg.CostoUltimo;
            CostoActual = Reg.CostoActual;
            Ubicacion = Reg.Ubicacion;
        }
    }
}
