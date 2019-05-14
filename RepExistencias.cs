using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAFE
{
    class RepExistencias
    {
        public string ClaveArticulo { get; set; }
        public string DscArticulo { get; set; }
        public string DscLinea { get; set; }
        public string ClaveAlmacen { get; set; }
        public double Cantidad { get; set; }
        public double CantidaApartada { get; set; }
        public double ExTotal { get; set; }
        public double stockMin { get; set; }
        public double stockMax { get; set; }
        public double CostoPromedio { get; set; }
        public double CostoUltimo { get; set; }
        public double CostoActual { get; set; }
        public string Ubicacion { get; set; }

        public RepExistencias()
        {  }

        public RepExistencias(RepExistencias Reg) {
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
