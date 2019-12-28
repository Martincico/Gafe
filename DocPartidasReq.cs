using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAFE
{
    public partial class DocPartidasReq
    {
        public bool Autorizado { get; set; }
        public string idMov { get; set; }
        public string Documento { get; set; }
        public string Serie { get; set; }
        public long Numdoc { get; set; }
        public string ClaveAlmacen { get; set; }
        public int Partida { get; set; }

        public string CveArticulo { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double PrecioNeto { get; set; }
        public double SubTotal { get; set; }
        public double Impuesto { get; set; }
        public double TotalIEPS { get; set; }
        public double Total { get; set; }
        public string CveUmedida1 { get; set; }
        public string CveImpuesto { get; set; }
        
        public double ImpuestoValor { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaModificacion { get; set; }

        public string Marca { get; set; }
        public string Linea { get; set; }

        public string CveImpIEPS { get; set; }
        public double ImpIEPSValor { get; set; }
        public string CveImpRetIVA { get; set; }
        public double ImpRetIVAValor { get; set; }
        public double TotalRetIVA { get; set; }
        public string CveImpRetISR { get; set; }
        public double ImpRetISRValor { get; set; }
        public double TotalRetISR { get; set; }
        public string CveImpOtro { get; set; }
        public double ImpValorOtro { get; set; }
        public double TotalImpOtro { get; set; }



    }
}
