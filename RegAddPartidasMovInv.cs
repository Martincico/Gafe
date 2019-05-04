﻿using System;
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
                         "        CveImpuesto,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
                         "        FechaMovimiento,NoMovtoTra,DocTra,PartTra) " +
                        " values( @NoMovimiento,@NoPartida,@CveAlmacenMov,@CveTipoMov,@EntSal," +
                         "        @NoDoc,@Documento,@CveArticulo,@Descripcion,@CveUMedida," +
                         "        @Cantidad,@CantidadPkt,@Precio,@Descuento,@TotalDscto," +
                         "        @CveImpuesto,@TotalIva,@SubTotal,@TotalPartida,@FolioDocOrigen," +
                         "        @FechaMovimiento,@NoMovtoTra,@DocTra,@PartTra)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


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

        public int DeletePartida()
        {
            string sql = "Delete from Inv_MovtosDetalles " +
                         " where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListPartidas(String NoMov)
        {
            SqlDataAdapter dt = null;
            string Sql = "Select  NoMovimiento,NoPartida,CveArticulo,Descripcion,CveUMedida," +
                         "        Cantidad,Precio,Descuento,TotalDscto," +
                         "        TotalIva,SubTotal,TotalPartida " +
                         "from Inv_MovtosDetalles where NoMovimiento = '" + NoMov + "' ";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select NoMovimiento,NoPartida,CveAlmacenMov,CveTipoMov,EntSal," +
                         "        NoDoc,Documento,CveArticulo,Descripcion,CveUMedida," +
                         "        Cantidad,CantidadPkt,Precio,Descuento,TotalDscto," +
                         "        CveImpuesto,TotalIva,SubTotal,TotalPartida,FolioDocOrigen," +
                         "        FechaMovimiento,NoMovtoTra,DocTra,PartTra) " +
                         " from Inv_MovtosDetalles " +
                         " where NoMovimiento = @NoMovimiento AND NoPartida = @NoPartida";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
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

        public SqlDataAdapter BusPrecio(String ModLlama)
        {
            SqlDataAdapter dt = null;
            if (ModLlama.Equals("M02") || ModLlama.Equals("M01"))
            {
                string Sql = "SELECT ClaveArticulo,ClaveAlmacen,Cantidad,stockMin,stockMax," +
                            "        CantApartada,CostoPromedio,CostoUltimo,CostoActual " +
                            " FROM Inv_Existencias WHERE ClaveArticulo = @CveArticulo and ClaveAlmacen=@CveAlmacen";
                dt = db.SelectDA(Sql, ArrParametros);
            }
            return dt;
        }

    }
}
