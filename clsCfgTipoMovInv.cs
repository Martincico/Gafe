using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
  public class clsCfgTipoMovInv
    {
        public string CveTipoMov;
        public string Descripcion;
        public string DescCorta;
        public string EntSal;
        public string CveClsMov;
        public string CveFoliador;
        public int EditaFoli;
        public int EsTraspaso;
        public string TipoMovRel;
        public string FmtoImpresion;
        public int AfectaCosto;
        public int SugiereCosto;
        public int MuestraCosto;
        public int EditaCosto;
        public int SolicitaCosto;
        public int PideCentroCosto;
        public int CalculaIva;
        public int Estatus;
        public int EsInterno;
        public int SolicitaSucursal;


        private MsSql db = null;
        //private SqlParameter[] ArrParametros;

        public clsCfgTipoMovInv(string CveTMov, MsSql Odat)
        {
            CveTipoMov = CveTMov;
            db = Odat;
        }

        public clsCfgTipoMovInv()
        {
            
        }

        public clsCfgTipoMovInv ConfigMovInv()
        {
            clsCfgTipoMovInv Tm = new clsCfgTipoMovInv();
            string Sql = "Select * " +
                         " from Inv_TipoMovtos where CveTipoMov = '"+CveTipoMov+"'";

            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Tm.CveTipoMov = Convert.ToString(dr["CveTipoMov"]);
                Tm.Descripcion = Convert.ToString(dr["Descripcion"]);
                Tm.DescCorta = Convert.ToString(dr["DescCorta"]);
                Tm.EntSal = Convert.ToString(dr["EntSal"]);
                Tm.CveClsMov = Convert.ToString(dr["CveClsMov"]);
                Tm.CveFoliador = Convert.ToString(dr["Foliador"]);
                Tm.EditaFoli = Convert.ToInt32(dr["EditaFoli"]);
                Tm.EsTraspaso = Convert.ToInt32(dr["EsTraspaso"]);
                Tm.TipoMovRel = Convert.ToString(dr["TipoMovRel"]);
                Tm.FmtoImpresion = Convert.ToString(dr["FmtoImpresion"]);
                Tm.AfectaCosto = Convert.ToInt32(dr["AfectaCosto"]);
                Tm.SugiereCosto = Convert.ToInt32(dr["SugiereCosto"]);
                Tm.MuestraCosto = Convert.ToInt32(dr["MuestraCosto"]);
                Tm.EditaCosto = Convert.ToInt32(dr["EditaCosto"]);
                Tm.SolicitaCosto = Convert.ToInt32(dr["SolicitaCosto"]);
                Tm.PideCentroCosto = Convert.ToInt32(dr["PideCentroCosto"]);
                Tm.CalculaIva = Convert.ToInt32(dr["CalculaIva"]);
                Tm.Estatus = Convert.ToInt32(dr["Estatus"]);
                Tm.EsInterno = Convert.ToInt32(dr["EsInterno"]);
                Tm.SolicitaSucursal = Convert.ToInt32(dr["SolicitaSucursal"]);
            }
            dr.Close();
            return Tm;
        }


    }
}
