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
    class RegSegUsuarios
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegSegUsuarios(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegSegUsuarios(MsSql Odat) { db = Odat; }



        public int AddRegUsuario()
        {
            string sql = "Insert into SUsuarios (Usuario,Nombre,Password,CodPerfil) " +
                         "values (@Usuario,@Nombre,@Password,@CodPerfil)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateUsuario()
        {
            string sql = "Update SUsuarios set Nombre = @Nombre, " +
                         "Password = @Password, " +
                         "CodPerfil = @CodPerfil " +
                         "Where Usuario = @Usuario";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int UpdTemaUsuario()
        {
            string sql = "Update SUsuarios set  " +
                         "StiloTema = @StiloTema  " +
                         "Where Usuario = @Usuario";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int UpdFondoUsuario()
        {
            string sql = "Update SUsuarios set  " +
                         "Fondo = @Fondo  " +
                         "Where Usuario = @Usuario";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteUsuario()
        {
            string sql = "Delete from SUsuarios where Usuario = @Usuario";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListUsuarios()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select Usuario,Nombre,CodPerfil " +
                         "from SUsuarios";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT Usr.Usuario, Usr.Nombre,Usr.Password,Usr.CodPerfil,UsrCfg.CveAlmacen, " +
                         "        UsrCfg.CambiaAlmacen, Alm.EsDeCompra,Alm.EsDeVenta,Alm.EsDeConsigna,Alm.NumRojo, " +
                         "        UsrCfg.Fondo,UsrCfg.StiloTema,CONVERT (date, GETDATE()), Alm.CveSucursal " +
                         " FROM dbo.SUsuarios AS Usr " +
                         " INNER JOIN SUsuarioConf AS UsrCfg ON UsrCfg.CveUsuario = Usr.Usuario " +
                         " INNER JOIN Inv_CatAlmacenes AS Alm ON UsrCfg.CveAlmacen = Alm.ClaveAlmacen " +
                         " WHERE Usr.Usuario = @Usuario";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaUsuario(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select Usuario,Nombre " +
               "from SUsuarios " +
               "where Usuario like '%" + bsq + "%' OR " +
               "Nombre like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }


        public SqlDataAdapter PerfilUsuario()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select  CodPerfil,idNodo,idPadre,Acceso " +
                          "from SAccesos where CodPerfil =@CodPerfil";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter CboUsuarios(int SinConfg)
        {
            SqlDataAdapter dt = null;

            String Str = (SinConfg == 1) ? " WHERE Usr.Usuario not IN (SELECT  CveUsuario FROM SUsuarioConf) " : " INNER JOIN dbo.SUsuarioConf AS UsrCfg ON UsrCfg.CveUsuario = Usr.Usuario ";

            string Sql = " SELECT Usr.Usuario Clave, Usr.Nombre Descripcion FROM SUsuarios AS Usr " + Str;
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
