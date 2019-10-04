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
                         "        Cantidad,CantidadPkt,Precio,Descuento,TotalDscto," +
                         "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
                         "        FechaMovimiento,NoMovtoTra,DocTra,PartTra) " +
                        " values( @NoMovimiento,@NoPartida,@CveAlmacenMov,@CveTipoMov,@EntSal," +
                         "        @NoDoc,@Documento,@CveArticulo,@Descripcion,@CveUMedida," +
                         "        @Cantidad,@CantidadPkt,@Precio,@Descuento,@TotalDscto," +
                         "        @CveImpuesto,@ImpuestoValor,@TotalIva,@SubTotal,@TotalPartida,@FolioDocOrigen," +
                         "        @FechaMovimiento,@NoMovtoTra,@DocTra,@PartTra)";

            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int UpdatePartida()
        {
            string sql = "Update Inv_MovtosDetalles set CveAlmacenMov = @CveAlmacenMov, CveTipoMov= @CveTipoMov,EntSal = @EntSal," +
                         "        NoDoc = @NoDoc,Documento = @Documento,CveArticulo = @CveArticulo,Descripcion = @Descripcion,CveUMedida = @CveUMedida," +
                         "        Cantidad = @Cantidad,CantidadPkt = @CantidadPkt,Precio = @Precio,Descuento = @Descuento,TotalDscto = @TotalDscto," +
                         "        CveImpuesto = @CveImpuesto,ImpuestoValor = @ImpuestoValor,TotalIva = @TotalIva,SubTotal = @SubTotal,TotalPartida = @TotalPartida,FolioDocOrigen = @FolioDocOrigen," +
                         "        FechaMovimiento = @FechaMovimiento,NoMovtoTra = @NoMovtoTra,DocTra = @DocTra,PartTra = @PartTra " +
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
            string Sql = "Select  NoMovimiento,NoPartida,CveArticulo,Descripcion,CveUMedida," +
                         "        Cantidad,Precio,Descuento,TotalDscto," +
                         "        TotalIva,SubTotal,TotalPartida " +
                         "from Inv_MovtosDetalles where NoMovimiento = @NoMovimiento AND Cancelado = 1 Order by NoPartida Desc ";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public int MovParttoAlmaSql()
        {
            string sql = "Insert into Inv_MovtosDetalles (NoMovimiento,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
             "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
             "        Cantidad,CantidadPkt,Precio,Descuento,TotalDscto," +
             "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
             "        FechaMovimiento,NoMovtoTra,DocTra,PartTra) " +
            "  SELECT @NoMovtoTra,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
             "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
             "        Cantidad,CantidadPkt,Precio,Descuento,TotalDscto," +
             "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
             "        FechaMovimiento,NoMovimiento,Documento,NoPartida " +
             " FROM Inv_MovtosDetalles" +
             " WHERE NoMovimiento = @NoMovimiento AND Cancelado = 1";

            return db.InsertarRegistro(sql, ArrParametros);
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
            string Sql = "Select NoMovimiento,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
                         "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
                         "        Cantidad,CantidadPkt,Precio,Descuento,TotalDscto," +
                         "        CveImpuesto,ImpuestoValor,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
                         "        FechaMovimiento,NoMovtoTra,DocTra,PartTra" +
                         " from Inv_MovtosDetalles " +
                         " where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida AND Cancelado = 1";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        /*

                public int UpdatePartida()
                {
                    string sql = "Update Inv_MovtosDetalles set CveAlmacenMov = @CveAlmacenMov,v CveTipoMov= @CveTipoMov,EntSal = @EntSal," +
                                 "        NoDoc = @NoDoc,Documento = @Documento,CveArticulo = @CveArticulo,Descripcion = @Descripcion,CveUMedida = @CveUMedida," +
                                 "        Cantidad = @Cantidad,CantidadPkt = @CantidadPkt,Precio = @Precio,Descuento = @Descuento,TotalDscto = @TotalDscto," +
                                 "        CveImpuesto = @CveImpuesto,TotalIva = @TotalIva,SubTotal = @SubTotal,TotalPartida = @TotalPartida,FolioDocOrigen = @FolioDocOrigen," +
                                 "        FechaMovimiento = @FechaMovimiento,NoMovtoTra = @NoMovtoTra,DocTra = @DocTra,PartTra = @PartTra " +
                                " Where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida";
                    return db.DeleteRegistro(sql, ArrParametros);
                }



        


                public SqlDataAdapter BuscaPartida(string bsq)
                {
                    SqlDataAdapter dt = null;
                    string sql = "Select NoMovimiento,NoPartida,NoDoc " +
                       "from Inv_MovtosDetalles " +
                       "where NoMovimiento like '%" + bsq + "%' OR " +
                       "NoPartida like '%" + bsq + "%' ";

                    dt = db.SelectDA(sql);
                    return dt;
                }

                */
    }
}
