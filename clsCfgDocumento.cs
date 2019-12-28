using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
  public class clsCfgDocumento
    {
        public string CveDoc;
        public string Nombre;
        public string CargoAbono;
        public String CveTipoMov;
        public String Foliador;
        public int UsaSerie;
        public int EditaFecha;
        public int UsaCliente;
        public int UsaProveedor;
        public int Estatus;
        public int EsInterno;
        public int SolicitaAutorizar;
        public int AfectaInventario;
        public int UsaAlmTmp;
        public int UsaAlmDestino;
        public int DeshabilitaBotones;
        public int UsaFactura;
        public String DocRel;
        public String txtBotonDocRel;
        

        private MsSql db = null;
        //private SqlParameter[] ArrParametros;

        public clsCfgDocumento(string clavedoc, MsSql Odat)
        {
            CveDoc = clavedoc;
            db = Odat;
        }

        public clsCfgDocumento()
        {
            
        }

        public clsCfgDocumento ConfigDoc()
        {
            clsCfgDocumento Doc = new clsCfgDocumento();
            string Sql = "Select * " +
                         "from CfgDocumentos WHERE CveDoc = '" + this.CveDoc+"'";
            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.CveDoc = Convert.ToString(dr["CveDoc"]);
                Doc.Nombre = Convert.ToString(dr["Nombre"]);
                Doc.CargoAbono = Convert.ToString(dr["CargoAbono"]);
                Doc.CveTipoMov = Convert.ToString(dr["CveTipoMov"]);
                Doc.Foliador = Convert.ToString(dr["Foliador"]);
                Doc.UsaSerie = Convert.ToInt32(dr["UsaSerie"]);
                Doc.EditaFecha = Convert.ToInt32(dr["EditaFecha"]);
                Doc.UsaCliente= Convert.ToInt32(dr["UsaCliente"]);
                Doc.UsaProveedor = Convert.ToInt32(dr["UsaProveedor"]);
                Doc.EsInterno = Convert.ToInt32(dr["EsInterno"]);
                Doc.SolicitaAutorizar = Convert.ToInt32(dr["SolicitaAutorizar"]);
                Doc.AfectaInventario = Convert.ToInt32(dr["AfectaInventario"]);
                Doc.UsaAlmTmp = Convert.ToInt32(dr["UsaAlmTmp"]);
                Doc.UsaAlmDestino = Convert.ToInt32(dr["UsaAlmDestino"]);
                Doc.Estatus = Convert.ToInt32(dr["Estatus"]);
                Doc.DocRel = Convert.ToString(dr["DocRel"]);
                Doc.txtBotonDocRel = Convert.ToString(dr["txtBotonDocRel"]);
                Doc.DeshabilitaBotones = Convert.ToInt32(dr["DeshabilitaBotones"]);
                Doc.UsaFactura = Convert.ToInt32(dr["UsaFactura"]);
            }
            dr.Close();
            return Doc;
        }


    }
}
