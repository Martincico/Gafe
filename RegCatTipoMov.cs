using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DatSql;
using System.Windows.Forms;



namespace GAFE
{
    class RegCatTipoMov
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatTipoMov(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatTipoMov(MsSql Odat) { db = Odat; }

        /*
        public void Conn()
        {
            /*db = new DatSql.MsSql(
                   ConfigurationSettings.AppSettings.Get("Servidor"),
                   ConfigurationSettings.AppSettings.Get("Datos"),
                   ConfigurationSettings.AppSettings.Get("Usuario"),
                   ConfigurationSettings.AppSettings.Get("Password")
                   );
            
            db = new DatSql.MsSql("SIGMA6\\SQL14", "CtrlAcceso", "sa", "Remolachas1");
                   
            if (db.Conectar() < 1)
                MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    */

        

        public int AddRegTipoMov()
        {
            //CveTipoMov,Descripcion,DescCorta,EntSal,CveClsMov,Foliador,EditaFoli,EsTraspaso,TipoMovRel,FmtoImpresion,AfectaCosto,SugiereCosto,MuestraCosto,EditaCosto,SolicitaCosto,PideCentroCosto,CalculaIva,Estatus
            string sql = "Insert into Inv_TipoMovtos (CveTipoMov,Descripcion,DescCorta,EntSal,CveClsMov," +
                         "          Foliador,EditaFoli,EsTraspaso,TipoMovRel,FmtoImpresion," +
                         "          AfectaCosto,SugiereCosto,MuestraCosto,EditaCosto,SolicitaCosto," +
                         "          PideCentroCosto,CalculaIva,EsInterno,Estatus, SolicitaSucursal) " +
                         "values( @CveTipoMov,@Descripcion,@DescCorta,@EntSal,@CveClsMov," +
                         "          @CveFoliador,@EditaFoli,@EsTraspaso,@TipoMovRel,@FmtoImpresion," +
                         "          @AfectaCosto,@SugiereCosto,@MuestraCosto,@EditaCosto,@SolicitaCosto," +
                         "          @PideCentroCosto,@CalculaIva,@EsInterno,@Estatus,@SolicitaSucursal)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int AddRegCfgFoliadores()
        {
            string sql = "Insert into CfgFoliadores (CveFoliador,CveAlmacen,FolioActual, FolioSiguiente) " +
                         "values( @CveFoliador,'',0,1)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateTipoMov()
        {
            string sql = "Update Inv_TipoMovtos set Descripcion = @Descripcion,DescCorta = @DescCorta,EntSal = @EntSal,CveClsMov = @CveClsMov," +
                         "          Foliador = @CveFoliador,EditaFoli = @EditaFoli,EsTraspaso = @EsTraspaso,TipoMovRel = @TipoMovRel,FmtoImpresion = @FmtoImpresion," +
                         "          AfectaCosto = @AfectaCosto,SugiereCosto =  @SugiereCosto,MuestraCosto = @MuestraCosto,EditaCosto = @EditaCosto,SolicitaCosto = @SolicitaCosto," +
                         "          PideCentroCosto = @PideCentroCosto,CalculaIva = @CalculaIva,EsInterno=@EsInterno,Estatus = @Estatus, " +
                         "          SolicitaSucursal = @SolicitaSucursal " +
                         "Where CveTipoMov = @CveTipoMov";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteTipoMov()
        {
            string sql = "Delete from Inv_TipoMovtos where CveTipoMov = @CveTipoMov";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListTipoMovtos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveTipoMov,Descripcion " +
                         "from Inv_TipoMovtos";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter CboLstClaseMov()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClsMov, Descripcion " +
                         "from Inv_ClaseMov";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter CboLstMovRel()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveTipoMov, Descripcion " +
                         "from Inv_TipoMovtos";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveTipoMov,Descripcion,DescCorta,EntSal,CveClsMov," +
                         "          Foliador,EditaFoli,EsTraspaso,TipoMovRel,FmtoImpresion," +
                         "          AfectaCosto,SugiereCosto,MuestraCosto,EditaCosto,SolicitaCosto," +
                         "          PideCentroCosto,CalculaIva,EsInterno, Estatus, SolicitaSucursal " +
                         " from Inv_TipoMovtos where CveTipoMov =@CveTipoMov";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaTipoMov(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveTipoMov,Descripcion " +
               "from Inv_TipoMovtos " +
               "where CveTipoMov like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter CboInv_TipoMovtos(String cve="", int OmiteInter = 1)
        {
            SqlDataAdapter dt = null;
            String Str = (!cve.Equals(""))? (" AND CveClsMov = '" + cve+"'"):" ";
            Str += (OmiteInter==1) ? (" AND EsInterno =  0") : " ";

            string Sql = "Select CveTipoMov, Descripcion " +
                         "from Inv_TipoMovtos WHERE estatus = 1  " + Str;
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
