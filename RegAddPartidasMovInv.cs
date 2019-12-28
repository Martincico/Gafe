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
    class RegAddPartidasMovInv
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegAddPartidasMovInv(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegAddPartidasMovInv(MsSql Odat) { db = Odat; }

    


        public int AddRegPartida()
        {
            string sql = "Insert into Inv_MovtosDetalles (NoMovimiento,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
                         "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
                         "        Cantidad,CantidadPkt,Costo,Precio,Descuento,TotalDscto," +
                         "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
                         "        NoMovtoTra,DocTra,PartTra," +
                         "        FechaMovimiento," +
                         "        CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
                         "        TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro, " +
                         "        ImpValorOtro, TotalImpOtro) " +
                        " values( @NoMovimiento,@NoPartida,@CveAlmacenMov,@CveTipoMov,@EntSal," +
                         "        @NoDoc,@Documento,@CveArticulo,@Descripcion,@CveUMedida," +
                         "        @Cantidad,@CantidadPkt,@Costo,@Precio,@Descuento,@TotalDscto," +
                         "        @CveImpuesto,@ImpuestoValor,@TotalIva,@SubTotal,@TotalPartida,@FolioDocOrigen," +
                         "        @NoMovtoTra,@DocTra,@PartTra, " +
                         "        (CONVERT(DATETIME, @FechaMovimiento) + CONVERT(DATETIME, CONVERT(time, GETDATE())))," +
                         "       @CveImpIEPS, @ImpIEPSValor, @TotalIEPS, @CveImpRetIVA, @ImpRetIVAValor, " +
                         "       @TotalRetIVA, @CveImpRetISR, @ImpRetISRValor, @TotalRetISR, @CveImpOtro, " +
                         "       @ImpValorOtro, @TotalImpOtro )";

            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int UpdatePartida()
        {
            string sql = "Update Inv_MovtosDetalles set CveAlmacenMov = @CveAlmacenMov, CveTipoMov= @CveTipoMov,EntSal = @EntSal," +
                         "        NoDoc = @NoDoc,Documento = @Documento,CveArticulo = @CveArticulo,Descripcion = @Descripcion,CveUMedida = @CveUMedida," +
                         "        Cantidad = @Cantidad,CantidadPkt = @CantidadPkt,Costo=@Costo,Precio = @Precio,Descuento = @Descuento,TotalDscto = @TotalDscto," +
                         "        CveImpuesto = @CveImpuesto,ImpuestoValor = @ImpuestoValor,TotalIva = @TotalIva,SubTotal = @SubTotal,TotalPartida = @TotalPartida,FolioDocOrigen = @FolioDocOrigen," +
                         "        FechaMovimiento = @FechaMovimiento,NoMovtoTra = @NoMovtoTra,DocTra = @DocTra,PartTra = @PartTra, " +
                         "        CveImpIEPS = @CveImpIEPS, ImpIEPSValor = @ImpIEPSValor, TotalIEPS = @TotalIEPS, CveImpRetIVA = @CveImpRetIVA, " +
                         "        ImpRetIVAValor = @ImpRetIVAValor, TotalRetIVA = @TotalRetIVA, CveImpRetISR = @CveImpRetISR, ImpRetISRValor = @ImpRetISRValor, " +
                         "       TotalRetISR = @TotalRetISR, CveImpOtro = @CveImpOtro, ImpValorOtro = @ImpValorOtro, TotalImpOtro = @TotalImpOtro " +
                        " Where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeletePartida()//Elimina partida
        {
            string sql = "Delete from Inv_MovtosDetalles " +
                         " where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida";
            int dv = db.UpdateRegistro(sql, ArrParametros);
            if (dv >= 1)
            {
                sql = "Update Inv_MovtosDetalles set NoPartida = (NoPartida * -1)" +
                       " Where NoMovimiento = @NoMovimiento";
                dv = db.DeleteRegistro(sql, ArrParametros);
            }
            return dv;
        }

        public int UpdateIdxPart()
        {
            string sql = "Update Inv_MovtosDetalles set NoPartida = @PartNew" +
                        " Where NoMovimiento = @NoMovimiento AND NoPartida = @PartAnt";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int GetFolioPart(String NoMov)
        {
            String Sql = "SELECT TOP 1   NoPartida FROM Inv_MovtosDetalles where NoMovimiento = '" + NoMov + "' AND Cancelado = 1 ORDER BY NoPartida DESC ";
            return db.GetRegGenerico(Sql);
        }

        public SqlDataAdapter BusPrecio(String ModLlama)
        {
            SqlDataAdapter dt = null;
            if (ModLlama.Equals("MProv") || ModLlama.Equals("Minv"))
            {
                string Sql = "SELECT ClaveArticulo,ClaveAlmacen,Cantidad,stockMin,stockMax," +
                            "        CantApartada,CostoPromedio,CostoUltimo,CostoActual " +
                            " FROM Inv_Existencias WHERE ClaveArticulo = @CveArticulo and ClaveAlmacen=@CveAlmacen";
                dt = db.SelectDA(Sql, ArrParametros);
            }
            return dt;
        }

        public SqlDataAdapter ListPartidas()
        {//Se usa en otro metodo
            SqlDataAdapter dt = null;
            string Sql = "Select  MD.NoMovimiento,MD.NoPartida,A.CodigoBarra, MD.CveArticulo,MD.Descripcion," +
                         "        MD.Cantidad,MD.Precio,MD.Descuento," +
                         "        MD.TotalIva, MD.TotalIEPS ," +
                         "        MD.SubTotal,MD.TotalPartida " +
                         " from Inv_MovtosDetalles MD " +
                         " INNER JOIN inv_CatArticulos AS A ON A.CveArticulo = MD.CveArticulo" +
                         " where MD.NoMovimiento = @NoMovimiento AND MD.Cancelado = 1 " +
                         " Order by MD.NoPartida Desc ";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public int MovParttoAlmaSql()
        {
            string sql = "Insert into Inv_MovtosDetalles (NoMovimiento,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
             "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
             "        Cantidad,CantidadPkt,Costo,Precio,Descuento,TotalDscto," +
             "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
             "        FechaMovimiento,NoMovtoTra,DocTra,PartTra," +
             "        CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
             "        TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro," +
             "        ImpValorOtro, TotalImpOtro) " +
            "  SELECT @NoMovtoTra,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
             "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
             "        Cantidad,CantidadPkt,Costo,Precio,Descuento,TotalDscto," +
             "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
             "        FechaMovimiento,NoMovimiento,Documento,NoPartida, " +
             "        CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
             "        TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro," +
             "        ImpValorOtro, TotalImpOtro " +
             " FROM Inv_MovtosDetalles" +
             " WHERE NoMovimiento = @NoMovimiento AND Cancelado = 1";

            int R = db.InsertarRegistro(sql, ArrParametros);

            return R;
        }

        public SqlDataAdapter GetDuplicadoSql()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select NoMovimiento,NoPartida,CveArticulo " +
                         " from Inv_MovtosDetalles " +
                         " where NoMovimiento = @NoMovimiento  AND CveArticulo = @NoPartida AND Cancelado = 1";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select MD.NoMovimiento,MD.NoPartida,MD.CveAlmacenMov,MD.CveTipoMov,MD.EntSal," +
                         "        MD.NoDoc,MD.Documento,MD.CveArticulo,MD.Descripcion,MD.CveUMedida," +
                         "        MD.Cantidad,MD.CantidadPkt,MD.Precio,MD.Descuento,MD.TotalDscto," +
                         "        MD.CveImpuesto,MD.ImpuestoValor,MD.TotalIva,MD.SubTotal,MD.TotalPartida,MD.FolioDocOrigen," +
                         "        MD.FechaMovimiento,MD.NoMovtoTra,MD.DocTra,MD.PartTra,MD.Costo, Art.CodigoBarra" +
                         " from Inv_MovtosDetalles MD " +
                         " INNER JOIN inv_CatArticulos Art ON Art.CveArticulo  = MD.CveArticulo " +
                         " where MD.NoMovimiento = @NoMovimiento AND MD.NoPartida = @NoPartida AND MD.Cancelado = 1";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }
        
    }
}
