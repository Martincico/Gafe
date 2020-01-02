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

using System.Threading.Tasks;

using Syncfusion.Windows.Forms;

using DatSql;

namespace GAFE
{
    public partial class Menu : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        clsUtil ut;
        private MsSql db = null;
        Form Flg;
        DatCfgUsuario user;
        DatCfgParamSystem ParamSystem;
        DatCfgSystem CfgSystem;
        clsStiloTemas NewColor = new clsStiloTemas();
        String Servidor = "";


        public Menu()
        {
            InitializeComponent();
        }

        public Menu(MsSql Odat, Form lg, String PUsr, String srv)
        {
            InitializeComponent();
            db = Odat;
            Flg = lg;
            Servidor = srv;
            CargaCfgUsuario(PUsr);

            //DateTime myDate = DateTime.Now.ChangeTime(10, 10, 10, 0);

        }

        private void CargaCfgUsuario(String PUsr)
        {
            DatCfgParamSystem PSyst = new DatCfgParamSystem(db);
            ParamSystem = PSyst.ParaSystem();

            DatCfgUsuario CUser = new DatCfgUsuario(PUsr, db);
            user = CUser.CfgUsario();

            SelectFondoUser(user.Fondo);

            DatCfgSystem CfgSys = new DatCfgSystem(db);
            CfgSystem = CfgSys.CfgSistema();


            PuiSegUsuarioCfg team = new PuiSegUsuarioCfg(db);
            team.cmpStiloTema = user.StiloTema;
            Object[] reg = team.GetParamTema();
            NewColor.Encabezado = reg[0].ToString();
            NewColor.HoverEncabezado = reg[1].ToString();
            NewColor.FontColor = reg[2].ToString();
            NewColor.Pant1 = reg[3].ToString();
            NewColor.Pant2 = reg[4].ToString();
            NewColor.Pant3 = reg[5].ToString();
            NewColor.Pant4 = reg[6].ToString();
            NewColor.Pant5 = reg[7].ToString();

            ut = new clsUtil(db, user.CodPerfil);
            ut.CargaArbolAcceso();

            this.ribMenu.Office2016ColorTable.Add(NewColor.StiloTeam());
            this.PieStatus.MetroColor = ColorTranslator.FromHtml(NewColor.Encabezado);
            this.PieStatus.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);

            this.lblUsuario.Text = user.Nombre;
            this.lblNombre.Text = user.Usuario;
            this.lblServidor.Text = Servidor;

            CargarSeguridad();
        }


        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            CargarSeguridad();
        }

        private void CargarSeguridad()
        {
            try
            {
                clsUsPerfil up = ut.BuscarIdNodo("1Inv");
                int ModInv = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv00");
                int CatInve = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv01");
                int OpeInv = (up == null) ? 0 : up.Acceso;

                /*
                    Carga la seguridad del modulo de Inventarios.
                 */
                //Activa la cinta del modulo
                ModInventario.Enabled = (ModInv == 1) ? true : false;
                //Activa los grupos del modulo
                CatInven.Enabled = (CatInve == 1) ? true : false;
                ProcInven.Enabled = (OpeInv == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv001");
                int CatArt = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv002");
                int CatUMed = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv003");
                int CatLinea = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv004");
                int CatMarca = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv005");
                int CatAlm = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv006");
                int CatGeo = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv009");
                int CatCla = (up == null) ? 0 : up.Acceso;
                up = ut.BuscarIdNodo("1Inv010");
                int CatImp = (up == null) ? 0 : up.Acceso;

                up = ut.BuscarIdNodo("1Inv007");
                int CatProve = (up == null) ? 0 : up.Acceso;
                CatsProveedores.Enabled = (CatProve == 1) ? true : false;
                up = ut.BuscarIdNodo("1Inv008");
                int CatLstPre = (up == null) ? 0 : up.Acceso;
                CatListaPrecios.Enabled = (CatLstPre == 1) ? true : false;

                CatArticulo.Enabled = (CatArt == 1) ? true : false;
                CatUMedidas.Enabled = (CatUMed == 1) ? true : false;
                CatLineas.Enabled = (CatLinea == 1) ? true : false;
                CatMarcas.Enabled = (CatMarca == 1) ? true : false;
                MnuGeografia.Enabled = (CatGeo == 1) ? true : false;
                CatClase.Enabled = (CatCla == 1) ? true : false;
                CatAlmacen.Enabled = (CatAlm == 1) ? true : false;
                CatImpuesto.Enabled = (CatImp == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv011");
                int Movinv = (up == null) ? 0 : up.Acceso;
                MnuMovInventarios.Enabled = (Movinv == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv012");
                int kdx = (up == null) ? 0 : up.Acceso;
                MnuKardexArt.Enabled = (kdx == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv013");
                int Exst = (up == null) ? 0 : up.Acceso;
                MnuExitenciaArt.Enabled = (Exst == 1) ? true : false;

                up = ut.BuscarIdNodo("1Inv014");
                int InvSuc = (up == null) ? 0 : up.Acceso;
                CatSucursal.Enabled = (InvSuc == 1) ? true : false;

                /*
                    Carga la seguridad del modulo de PROVEEDORES.
                 */

                up = ut.BuscarIdNodo("1Prov");
                int ModP = (up == null) ? 0 : up.Acceso;

                //Activa la cinta del modulo
                ModProveedores.Enabled = (ModP == 1) ? true : false;

                up = ut.BuscarIdNodo("1ProvR");
                ModP = (up == null) ? 0 : up.Acceso;
                MnuRequisición.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvC");
                ModP = (up == null) ? 0 : up.Acceso;
                MnuCotizacion.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvO");
                ModP = (up == null) ? 0 : up.Acceso;
                MnuOrdenCompra.Enabled = (ModP == 1) ? true : false;
                up = ut.BuscarIdNodo("1ProvCO");
                ModP = (up == null) ? 0 : up.Acceso;
                MnuCompras.Enabled = (ModP == 1) ? true : false;

                up = ut.BuscarIdNodo("1ProvOS");
                ModP = (up == null) ? 0 : up.Acceso;
                MnuOrdSalida.Enabled = (ModP == 1) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Existe un error: \n" + ex.Message, "Cargando menú", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                Flg.Close();
            }
        }

        private void Nav(MetroForm form, Panel panel)
        {
            CargaCfgUsuario(user.Usuario);
            form.TopLevel = false;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Pant1);
            form.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            form.Show();
        }

        private void CatLineas_Click(object sender, EventArgs e)
        {
            frmCatLineas fm = new frmCatLineas(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }
        private void CatMarcas_Click(object sender, EventArgs e)
        {
            frmCatMarcas fm = new frmCatMarcas(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }


        private void CatClase_Click(object sender, EventArgs e)
        {
            frmCatClases fm = new frmCatClases(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);

        }
        private void CatUMedidas_Click(object sender, EventArgs e)
        {
            frmCatUMedidas fm = new frmCatUMedidas(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos fm = new frmLstArticulos(db, ParamSystem, user,NewColor);
            Nav(fm, panelContenedor);
        }

        private void CatAlmacen_Click(object sender, EventArgs e)
        {
            frmCatAlmacenes fm = new frmCatAlmacenes(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }


        private void CatGeografia_Click(object sender, EventArgs e)
        {
            frmCatGeografia fm = new frmCatGeografia(db, ParamSystem, user.CodPerfil);
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
            frmCatLstPrecios fm = new frmCatLstPrecios(db, user, ParamSystem, NewColor);
            Nav(fm, panelContenedor);
        }

        private void Inv_TipoMov_Click(object sender, EventArgs e)
        {
            frmLstTipoMovtos tm = new frmLstTipoMovtos(db, ParamSystem, user, NewColor);
            Nav(tm, panelContenedor);
        }
      
        private void MnuFoliadores_Click(object sender, EventArgs e)
        {
            frmCatCfgCatFoliadores fm = new frmCatCfgCatFoliadores(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuGeografia_Click(object sender, EventArgs e)
        {
            frmCatGeografia fm = new frmCatGeografia(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuMovInventarios_Click(object sender, EventArgs e)
        {
            MovtosInvLst fm = new MovtosInvLst(db, ParamSystem, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void MnuKardexArt_Click(object sender, EventArgs e)
        {
            frmKardex fm = new frmKardex(db, ParamSystem, user,NewColor);
            Nav(fm, panelContenedor);
        }


        private void MnuExitenciaArt_Click(object sender, EventArgs e)
        {
            frmExistencias fm = new frmExistencias(db, ParamSystem, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void CatsUsuarios_Click(object sender, EventArgs e)
        {
            frmCatUsuarios fm = new frmCatUsuarios(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatsPerfiles_Click(object sender, EventArgs e)
        {
            frmCatPerfiles fm = new frmCatPerfiles(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void CatsUserCfg_Click(object sender, EventArgs e)
        {
            frmCatUsuariosCfg fm = new frmCatUsuariosCfg(db, ParamSystem, user);
            Nav(fm, panelContenedor);

        }

        private void CatsProveedores_Click(object sender, EventArgs e)
        {
            frmLstProveedores fm = new frmLstProveedores(db, ParamSystem, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void MnuDocProvee_Click(object sender, EventArgs e)
        {
            frmLstCfgDocumentos tm = new frmLstCfgDocumentos(db, ParamSystem, user, NewColor);
            Nav(tm, panelContenedor);
        }

        private void MnuDocSeries_Click(object sender, EventArgs e)
        {
            frmLstCfgDocSerie tm = new frmLstCfgDocSerie(db, ParamSystem, user, NewColor);
            Nav(tm, panelContenedor);
        }


        private void CatImpuesto_Click(object sender, EventArgs e)
        {
            frmCatImpuestos fm = new frmCatImpuestos(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void MnuParamSystem_Click(object sender, EventArgs e)
        {
            frmCatParamSystem fm = new frmCatParamSystem(db, ParamSystem, user.CodPerfil);
            Nav(fm, panelContenedor);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void MnuMovInvLst_Click(object sender, EventArgs e)
        {
            frmLstTipoMovtos fm = new frmLstTipoMovtos(db, ParamSystem, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void CatSucursal_Click(object sender, EventArgs e)
        {
            frmLstSucursales fm = new frmLstSucursales(db, ParamSystem, user, NewColor);
            Nav(fm, panelContenedor);
        }

        private void MnuOrdSalida_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem, ParamSystem, user, NewColor, "M2005", "ORDEN DE SALIDA");
            Nav(Lst, panelContenedor);
        }

        private void MnuOrdEntrada_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem, ParamSystem, user,  NewColor, "M2006", "ORDEN DE ENTRADA");
            Nav(Lst, panelContenedor);
        }

        private void MnuRequisición_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem, ParamSystem, user, NewColor, "M2001", "REQUISICIÓN");
            Nav(Lst, panelContenedor);
        }

        private void MnuOrdenCompra_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem,ParamSystem, user, NewColor, "M2003", "ORDEN DE COMPRA");
            Nav(Lst, panelContenedor);
        }


        private void MnuCotizacion_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem, ParamSystem, user, NewColor, "M2002", "COTIZACIÓN");
            Nav(Lst, panelContenedor);
        }

        private void MnuCompras_Click(object sender, EventArgs e)
        {
            DocLstRequisiciones Lst = new DocLstRequisiciones(db, CfgSystem, ParamSystem, user, NewColor, "M2004", "COMPRAS");
            Nav(Lst, panelContenedor);

        }

    }
}
