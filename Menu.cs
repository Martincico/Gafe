﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatSql;


namespace GAFE
{
    public partial class Menu : Form
    {

        clsUtil ut;
        private MsSql db = null;
        Form Flg;
        private string Perfil;


        public Menu()
        {
            InitializeComponent();
        }
        


        public Menu(MsSql Odat, Form lg, string perfil)
        {
            InitializeComponent();
            db = Odat;
            Flg = lg;
            Perfil = perfil;
            ut = new clsUtil(db, Perfil);
            ut.CargaArbolAcceso();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            frmCatAlmacenes falm = new frmCatAlmacenes();
            falm.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
        }

        private void sAsignaPermisos_Click(object sender, EventArgs e)
        {
            frmSegAccesos fac = new frmSegAccesos(db);
            fac.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                clsUsPerfil up = ut.BuscarIdNodo("1Inv");
                int ModInv = up.Acceso;
                up = ut.BuscarIdNodo("1Inv00");
                int CatInve = up.Acceso;
                up = ut.BuscarIdNodo("1Inv01");
                int OpeInv = up.Acceso;
                
                /*
                    Carga la seguridad del modulo de Inventarios.
                 */
                //Activa la cinta del modulo
                ModInventario.Enabled = (ModInv == 1) ? true : false;
                //Activa los grupos del modulo
                CatInven.Enabled = (CatInve == 1) ? true : false;
                ProcInven.Enabled = (OpeInv == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv001");
                int CatArt = up.Acceso;
                up = ut.BuscarIdNodo("1Inv002");
                int CatUMed = up.Acceso;
                up = ut.BuscarIdNodo("1Inv003");
                int CatLinea = up.Acceso;
                up = ut.BuscarIdNodo("1Inv004");
                int CatMarca = up.Acceso;
                up = ut.BuscarIdNodo("1Inv005");
                int CatAlm = up.Acceso;
                
                CatArticulo.Enabled = (CatArt == 1) ? true : false;
                CatUMedidas.Enabled = (CatUMed == 1) ? true : false;
                CatLineas.Enabled = (CatLinea == 1)  ? true : false;
                CatMarcas.Enabled = (CatMarca == 1) ? true : false;
                CatAlmacen.Enabled = (CatAlm == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv011");
                int Movinv = up.Acceso;
                OpMovInv.Enabled = (Movinv == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv012");
                int kdx = up.Acceso;
                OpKardex.Enabled = (kdx == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv013");
                int Exst = up.Acceso;
                OpExistencia.Enabled = (Exst == 1) ? true : false;

            }
            catch (Exception ex)
            {

            }
        }

        private void CatMarcas_Click(object sender, EventArgs e)
        {
            frmCatMarcas fm = new frmCatMarcas(db, Perfil);
            fm.ShowDialog();
        }
    }
}
