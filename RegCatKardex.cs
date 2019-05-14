using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatKardex
    {

        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg
        public RegCatKardex(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public SqlDataAdapter Kardex()
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT  D.FechaMovimiento as Fecha, IIF(D.EntSal='E','Entrada', '       '+A.Descripcion)  as 'Concepto', " +
                "IIF(D.EntSal='E',D.Cantidad, null) as 'Cantidad Entrada', IIF(D.EntSal='E',D.Precio, null) as 'Precio Entrada', IIF(D.EntSal='E',D.Precio*D.Cantidad, null) as 'Total Entrada'," +
                "IIF(D.EntSal='S',D.Cantidad, null) as 'Cantidad Salida', null as 'Precio Salida', IIF(D.EntSal='S',D.Precio*D.Cantidad, null) as 'Total Salida'," +
                "null as 'Cantidad Saldo', null as 'Precio Prom', null as 'Total Saldo' " +
                "FROM Inv_MovtosDetalles D JOIN Inv_CatAlmacenes A ON D.CveAlmacenMov=A.ClaveAlmacen " +
                "WHERE D.CveArticulo = @CveArticulo AND D.CveAlmacenMov = @CveAlmacenMov " +
                "ORDER BY Fecha ASC";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }
    }
}