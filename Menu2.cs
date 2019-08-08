using Microsoft.Win32;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Syncfusion.Windows.Forms;

using DatSql;

namespace GAFE
{
    public partial class Menu2 : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        clsUtil ut;
        private MsSql db = null;
        Form Flg;
        public DatCfgUsuario user;
        clsStiloTemas NewColor = new clsStiloTemas();

        public Menu2()
        {
            InitializeComponent();
        }

        public Menu2(MsSql Odat, Form lg, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            db = Odat;
            Flg = lg;
            user = DatUsr;
            ut = new clsUtil(db, user.CodPerfil);
            ut.CargaArbolAcceso();
            SelectTemaUser(user.StiloTema);
            SelectFondoUser(user.Fondo);

        }

        private void Menu2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
        }

        private void Menu2_Load(object sender, EventArgs e)
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
                up = ut.BuscarIdNodo("1Inv006");
                int CatGeo = up.Acceso;
                up = ut.BuscarIdNodo("1Inv009");
                int CatCla = up.Acceso;
                
                up = ut.BuscarIdNodo("1Inv007");
                int CatProve = up.Acceso;
                CatProveedores.Enabled = (CatProve == 1) ? true : false;
                up = ut.BuscarIdNodo("1Inv008");
                int CatLstPre = up.Acceso;
                CatListaPrecios.Enabled = (CatLstPre == 1) ? true : false;

                CatArticulo.Enabled = (CatArt == 1) ? true : false;
                CatUMedidas.Enabled = (CatUMed == 1) ? true : false;
                CatLineas.Enabled = (CatLinea == 1) ? true : false;
                CatMarcas.Enabled = (CatMarca == 1) ? true : false;
                CatGeografia.Enabled = (CatGeo == 1) ? true : false;
                CatClase.Enabled = (CatCla == 1) ? true : false;
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

        private void Nav(MetroForm form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Encabezado);
            form.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            form.Show();
        }

        private void CatLineas_Click(object sender, EventArgs e)
        {
            frmCatLineas fm = new frmCatLineas(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }
        private void CatMarcas_Click(object sender, EventArgs e)
        {
            frmCatMarcas fm = new frmCatMarcas(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }


        private void CatClase_Click(object sender, EventArgs e)
        {
            frmCatClases fm = new frmCatClases(db, user.CodPerfil);
            Nav(fm, panelContenedor);

        }
        private void CatUMedidas_Click(object sender, EventArgs e)
        {
            frmCatUMedidas fm = new frmCatUMedidas(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos fm = new frmLstArticulos(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatAlmacen_Click(object sender, EventArgs e)
        {
            frmCatAlmacenes fm = new frmCatAlmacenes(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void OpMovInv_Click(object sender, EventArgs e)
        {
            frmLstInventarioMovtos fm = new frmLstInventarioMovtos(db, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void OpKardex_Click(object sender, EventArgs e)
        {
            frmKardex fm = new frmKardex(db, user);
            Nav(fm, panelContenedor);
        }

        private void OpExistencia_Click(object sender, EventArgs e)
        {
            frmExistencias fm = new frmExistencias(db, user);
            Nav(fm, panelContenedor);
        }

        private void CatGeografia_Click(object sender, EventArgs e)
        {
            
        }
        
 

        private void CatsAsignaPer_Click(object sender, EventArgs e)
        {
            frmSegAccesos fm = new frmSegAccesos(db);
            Nav(fm, panelContenedor);
        }

        private void stilDefault_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Naranja");
        }

        private void stilClaro_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Claro");
        }

        private void stilNegro_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Negro");
        }

        private void stilAzul_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Azul");
        }
        private void ActualizaTemaUser(String team)
        {
            int fr = this.panelContenedor.Controls.Count;
            if (fr > 0)
            {
                this.panelContenedor.Controls.Clear();
            }

            PuiSegUsuarios us = new PuiSegUsuarios(db);
            us.keySusuario = user.Usuario;
            us.cmpNombre = team;
            us.ActTemaUsuario();
            SelectTemaUser(team);

        }
        private void SelectTemaUser(String tema)
        {
            /*
            PuiSegUsuarios us = new PuiSegUsuarios(db);
            us.keySusuario = tema;
            us.getEstiloUser();
            NewColor.Encabezado = us.keySusuario;
            NewColor.HoverEncabezado = us.cmpNombre;
            NewColor.FontColor = us.cmpPassword;
            this.ribMenu.Office2016ColorTable.Add(NewColor.StiloTeam());

            //this.ribMenu.RibbonStyle = RibbonStyle.Office2007;
            //this.ribMenu.Office2016ColorScheme = Office2016ColorScheme.DarkGray;
            */
        }

        private void stilVerde_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Verde");
        }

        

        private void ribMenu_Click(object sender, EventArgs e)
        {

        }

        private void stilRosado_Click(object sender, EventArgs e)
        {
            ActualizaTemaUser("Rosa");
        }

        private void PerFondo1_Click(object sender, EventArgs e)
        {
            ActualizaFondoUser("Fondo1");
        }

        private void PerFondo2_Click(object sender, EventArgs e)
        {
            ActualizaFondoUser("Fondo2");
        }

        private void PerFondo3_Click(object sender, EventArgs e)
        {
            ActualizaFondoUser("Fondo3");
        }

        private void PerFondo4_Click(object sender, EventArgs e)
        {
            ActualizaFondoUser("Fondo4");
        }

        private void PerFondoNone_Click(object sender, EventArgs e)
        {
            ActualizaFondoUser("none");
        }

        private void ActualizaFondoUser(String team)
        {


            PuiSegUsuarios us = new PuiSegUsuarios(db);
            us.keySusuario = user.Usuario;
            us.cmpNombre = team;
            us.ActFondoUsuario();
            SelectFondoUser(team);
        }

        private void SelectFondoUser(String tema)
        {
            switch (tema)
            {
                case "Fondo1": this.panelContenedor.BackgroundImage = global::GAFE.Properties.Resources.Fondo1; break;
                case "Fondo2": this.panelContenedor.BackgroundImage = global::GAFE.Properties.Resources.Fondo2; break;
                case "Fondo3": this.panelContenedor.BackgroundImage = global::GAFE.Properties.Resources.Fondo3; break;
                case "Fondo4": this.panelContenedor.BackgroundImage = global::GAFE.Properties.Resources.Fondo4; break;
                default: this.panelContenedor.BackgroundImage = null; break;
            }
        }

        private void CatProveedores_Click(object sender, EventArgs e)
        {
            frmLstProveedores fm = new frmLstProveedores(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatListaPrecios_Click(object sender, EventArgs e)
        {
            frmCatLstPrecios fm = new frmCatLstPrecios(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void Inv_TipoMov_Click(object sender, EventArgs e)
        {
            frmCatTipoMovtos tm = new frmCatTipoMovtos(db, user, NewColor);
            Nav(tm, panelContenedor);
        }

        private void Prov_TipoMov_Click(object sender, EventArgs e)
        {
            frmLstCfgTipoMovProv tm = new frmLstCfgTipoMovProv(db, user, NewColor);
            Nav(tm, panelContenedor);
        }

        private void Prov_SereDoc_Click(object sender, EventArgs e)
        {
            frmLstCfgDocProv tm = new frmLstCfgDocProv(db, user, NewColor);
            Nav(tm, panelContenedor);
        }


        private void MnuCfgFoliadores_Click(object sender, EventArgs e)
        {
            frmCatCfgCatFoliadores fm = new frmCatCfgCatFoliadores(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }
        
        private void InvMenDocumentos_Click(object sender, EventArgs e)
        {
            /*
            FrmSlcDocumentos fm = new FrmSlcDocumentos(db, user, NewColor);
            Nav(fm, panelContenedor);
            */
        }
    }
}
