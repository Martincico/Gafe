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
    public partial class Menu : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        clsUtil ut;
        private MsSql db = null;
        Form Flg;
        public DatCfgUsuario user;
        clsStiloTemas NewColor = new clsStiloTemas();

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(MsSql Odat, Form lg, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            db = Odat;
            Flg = lg;
            user = DatUsr;
            ut = new clsUtil(db, user.CodPerfil);
            ut.CargaArbolAcceso();
            SelectFondoUser(user.Fondo);

            PuiSegUsuarioCfg team = new PuiSegUsuarioCfg(db);
            team.cmpStiloTema = user.StiloTema;
            Object[] reg = team.GetParamTema();
            NewColor.Encabezado = reg[0].ToString();
            NewColor.HoverEncabezado = reg[1].ToString();
            NewColor.FontColor = reg[2].ToString();

            this.ribMenu.Office2016ColorTable.Add(NewColor.StiloTeam());


        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
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
                up = ut.BuscarIdNodo("1Inv006");
                int CatGeo = up.Acceso;
                up = ut.BuscarIdNodo("1Inv009");
                int CatCla = up.Acceso;
                
                up = ut.BuscarIdNodo("1Inv007");
                int CatProve = up.Acceso;
                CatsProveedores.Enabled = (CatProve == 1) ? true : false;
                up = ut.BuscarIdNodo("1Inv008");
                int CatLstPre = up.Acceso;
                CatListaPrecios.Enabled = (CatLstPre == 1) ? true : false;

                CatArticulo.Enabled = (CatArt == 1) ? true : false;
                CatUMedidas.Enabled = (CatUMed == 1) ? true : false;
                CatLineas.Enabled = (CatLinea == 1) ? true : false;
                CatMarcas.Enabled = (CatMarca == 1) ? true : false;
                MnuGeografia.Enabled = (CatGeo == 1) ? true : false;
                CatClase.Enabled = (CatCla == 1) ? true : false;
                CatAlmacen.Enabled = (CatAlm == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv011");
                int Movinv = up.Acceso;
                MnuMovInventarios.Enabled = (Movinv == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv012");
                int kdx = up.Acceso;
                MnuKardexArt.Enabled = (kdx == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv013");
                int Exst = up.Acceso;
                MnuExitenciaArt.Enabled = (Exst == 1) ? true : false;


                /*
                    Carga la seguridad del modulo de PROVEEDORES.
                 */

                up = ut.BuscarIdNodo("1Prov");
                int ModP = up.Acceso;

                //Activa la cinta del modulo
                ModProveedores.Enabled = (ModP == 1) ? true : false;

                up = ut.BuscarIdNodo("1ProvR");
                ModP = up.Acceso;
                MnuRequisición.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvC");
                ModP = up.Acceso;
                MnuCotizacion.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvO");
                ModP = up.Acceso;
                MnuOrdenCompra.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvCO");
                ModP = up.Acceso;
                MnuCompras.Enabled = (ModP == 1) ? true : false;


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
            frmLstArticulos fm = new frmLstArticulos(db,NewColor, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatAlmacen_Click(object sender, EventArgs e)
        {
            frmCatAlmacenes fm = new frmCatAlmacenes(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }


        private void CatGeografia_Click(object sender, EventArgs e)
        {
            frmCatGeografia fm = new frmCatGeografia(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }
        
 

        private void CatsAsignaPer_Click(object sender, EventArgs e)
        {
            frmSegAccesos fm = new frmSegAccesos(db);
            Nav(fm, panelContenedor);
        }

        private void ribMenu_Click(object sender, EventArgs e)
        {

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
            
        }

        private void CatListaPrecios_Click(object sender, EventArgs e)
        {
            frmCatLstPrecios fm = new frmCatLstPrecios(db, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void Inv_TipoMov_Click(object sender, EventArgs e)
        {
            frmCatTipoMovtos tm = new frmCatTipoMovtos(db, user, NewColor);
            Nav(tm, panelContenedor);
        }
      
        private void MnuFoliadores_Click(object sender, EventArgs e)
        {
            frmCatCfgCatFoliadores fm = new frmCatCfgCatFoliadores(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuGeografia_Click(object sender, EventArgs e)
        {
            frmCatGeografia fm = new frmCatGeografia(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuMovInventarios_Click(object sender, EventArgs e)
        {
            frmLstInventarioMovtos fm = new frmLstInventarioMovtos(db, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void MnuKardexArt_Click(object sender, EventArgs e)
        {
            frmKardex fm = new frmKardex(db, user,NewColor);
            Nav(fm, panelContenedor);
        }

        private void MnuRequisición_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, user, NewColor, "M2001", "REQUISICIÓN");
            Nav(Lst, panelContenedor);
        }

        private void MnuOrdenCompra_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, user, NewColor, "M2003", "ORDEN DE COMPRA");
            Nav(Lst, panelContenedor);
        }

        private void MnuExitenciaArt_Click(object sender, EventArgs e)
        {
            frmExistencias fm = new frmExistencias(db, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void CatsUsuarios_Click(object sender, EventArgs e)
        {
            frmCatUsuarios fm = new frmCatUsuarios(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatsPerfiles_Click(object sender, EventArgs e)
        {
            frmCatPerfiles fm = new frmCatPerfiles(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatsUserCfg_Click(object sender, EventArgs e)
        {
            frmCatUsuariosCfg fm = new frmCatUsuariosCfg(db, user.CodPerfil);
            Nav(fm, panelContenedor);

        }

        private void CatsProveedores_Click(object sender, EventArgs e)
        {
            frmLstProveedores fm = new frmLstProveedores(db, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuDocProvee_Click(object sender, EventArgs e)
        {
            frmLstCfgDocumentos tm = new frmLstCfgDocumentos(db, user, NewColor);
            Nav(tm, panelContenedor);
        }

        private void MnuDocSeries_Click(object sender, EventArgs e)
        {
            frmLstCfgDocSerie tm = new frmLstCfgDocSerie(db, user, NewColor);
            Nav(tm, panelContenedor);
        }

        private void MnuCotizacion_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, user, NewColor, "M2002", "COTIZACIÓN");
            Nav(Lst, panelContenedor);
        }

        private void MnuCompras_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, user, NewColor, "M2004", "COMPRAS");
            Nav(Lst, panelContenedor);

        }
    }
}
