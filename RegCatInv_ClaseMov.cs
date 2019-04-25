using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatInv_ClaseMov
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatInv_ClaseMov(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatInv_ClaseMov(MsSql Odat) { db = Odat; }

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
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    */

        public int AddRegInv_ClaseMov()
        {
            string sql = "Insert into Inv_ClaseMov (CveClsMov,Descripción) " +
                         "values(@CveClsMov,@Descripcion)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateInv_ClaseMov()
        {
            string sql = "Update Inv_ClaseMov set Descripcion = @Descripcion " +
                         "Where CveClsMov = @CveClsMov";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteInv_ClaseMov()
        {
            string sql = "Delete from Inv_ClaseMov where CveClsMov = @CveClsMov";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListInv_ClaseMov()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClsMov,Descripcion " +
                         "from Inv_ClaseMov";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClsMov,Descripcion" +
                          "from Inv_ClaseMov where CveClsMov =@CveClsMov";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaInv_ClaseMov(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveClsMov,Descripcion " +
               "from Inv_ClaseMov " +
               "where CveClsMov like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public SqlDataAdapter CboInv_ClaseMov()
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT '0' as CveClsMov, 'SELECCIONE' as Descripcion UNION Select CveClsMov, Descripcion " +
                         "from Inv_ClaseMov";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
