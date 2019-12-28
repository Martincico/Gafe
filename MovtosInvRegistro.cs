using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatSql;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class MovtosInvRegistro : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        private int opcion ;
        private String folMovto;
        private SqlDataAdapter DatosTbl;

        private String Modulo = "Minv";
        private MsSql db = null;

        public DatCfgUsuario user;

        private Boolean isDataSaved = false;

        clsCfgTipoMovInv CfgMovInv;
        clsCfgTipoMovInv CfgMovInvRel;

        clsCfgAlmacen cfgAlma;
        clsCfgAlmacen cfgAlmaDest;

        string strCboTipoMovInv; //Tomará el valor del combo de Tipo de Movimiento Inventario

        public clsStiloTemas StiloColor;

        ClsUtilerias Util;

        public MovtosInvRegistro()
        {
            InitializeComponent();
        }

        public MovtosInvRegistro(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int Op, String TipoDocInv,  
                                 String folMvto)
        {
            InitializeComponent();
            //LocalizationProvider.Provider = new localizer();
            opcion = Op;
            db = Odat;
            StiloColor = NewColor;
            user = DatUsr;
            ParamSystem = ParamS;
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            lblFecha.Text = Convert.ToString(user.FecServer);

            OcultTitulos(false);
            OpcionControles(true);

            LleCboClaseMov();
            LlecboAlmaOri(user.AlmacenUsa);
            OcultProvee(false);
            OcultAlmDest(false);

            Util = new ClsUtilerias(ParamSystem.NumDec);

            folMovto = folMvto;
            cboAlmaOri.Enabled = user.CambiaAlmacen == 1 ? true : false;
            cboAlmaDest.Enabled = user.CambiaAlmacen == 1 ? true : false;

            if(opcion >1)
            {
                isDataSaved = true;
                LlenaGridViewPart();
                OpcionControles(false);
                GetRegistro();

                btnAddPartida.Enabled = false;
                btnEditaPartida.Enabled = false;
                btnEliminarPartida.Enabled = false;
                OcultTitulos(true);
            }
        }


        //Para insertar registro relacionado de Documentos
        public MovtosInvRegistro(MsSql Odat, DatCfgParamSystem ParamS, clsStiloTemas NewColor,  String TipoDocInv, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            db = Odat;
            StiloColor = NewColor;
            user = DatUsr;
            OcultProvee(true);
            ParamSystem = ParamS;
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;


            Util = new ClsUtilerias(ParamSystem.NumDec);
        }

        private void frmRegInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case 1:
                    if (ValidaTipoMov() == 1)
                    {
                        if (grdViewPart.RowCount > 0)
                        {
                            DialogResult ans = MessageBoxAdv.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ans == DialogResult.Yes)
                            {
                                String CodProve = cboProveedor.Visible ? Convert.ToString(cboProveedor.SelectedValue) : "";
                                int rsp = Agregar("", CodProve);
                                if (rsp != 0)
                                {
                                    string msj = "";
                                    switch (rsp)
                                    {
                                        case 1: msj = "Al guardar cabecero"; break;
                                        case 2: msj = "Al guardar detalle partidas"; break;
                                        case 3: msj = "Al afectar existencias"; break;
                                        case 13: msj = "Al afectar costos"; break;
                                        case 4: msj = "Traspaso: Registro en blanco"; break;
                                        case 5: msj = "Traspaso: Al guardar cabecero"; break;
                                        case 6: msj = "Traspaso: Al guardar detalle partidas"; break;
                                        case 7: msj = "Traspaso: Al afectar existencias"; break;
                                        case 17: msj = "Traspaso: Al afectar costos"; break;
                                        case 8: msj = "Traspaso: Al actualizar detalle partidas"; break;
                                        //case 9: msj = Se usa al migrar datos en detalles;
                                        default: msj = "Error desconocido"; break;
                                    }
                                    MessageBoxAdv.Show(msj, "Error al guardar el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    isDataSaved = false;
                                }
                                else
                                {
                                    isDataSaved = true;
                                    this.Close();
                                }
                            }
                        }
                    }
                    break;
                case 2: isDataSaved = true; this.Close(); break;
                case 3: isDataSaved = true;  this.Close(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Agregar(String DcOrigen, String CodProve, String CvSuc = "")//CvSuc Vendra de la migración de documentos.
        {
            int rsp = -1;
            try
            {
                String _AlmO = Convert.ToString(cboAlmaOri.SelectedValue);
                MovtosInvPui pui = new MovtosInvPui(db);
                pui.keyNoMovimiento = Convert.ToString(folMovto);
                pui.cmpCveAlmacenMov = _AlmO;
                pui.cmpCveTipoMov = strCboTipoMovInv;
                pui.cmpEntSal = CfgMovInv.EntSal;//_EntSal
                pui.cmpModulo = Modulo;
                pui.cmpDescuento = Convert.ToDouble(Util.LimpiarTxt(txtDescuento.Text));
                //            pui.cmpTotalDscto = Convert.ToDouble(txtTotDesc.Text);
                pui.cmpTIva = Convert.ToDouble(Util.LimpiarTxt(txtIVA.Text));
                pui.cmpSubTotal = Convert.ToDouble(Util.LimpiarTxt(txtSubTotal.Text));
                pui.cmpTotalDoc = Convert.ToDouble(Util.LimpiarTxt(txtTotal.Text));
                pui.cmpCveProveedor = CodProve;
                pui.cmpCancelado = 1;
                pui.cmpCveUsarioCaptu = user.Usuario;
                pui.cmpCveAlmacenDes = "";
                pui.cmpCveTipoMovDest = "";
                pui.cmpEntSalDest = "";
                pui.cmpNoMovtoTra = "";
                pui.cmpDocTra = "";
                pui.cmpDocOrigen = DcOrigen;
                pui.cmpCveSucursal = CvSuc;
                if (CfgMovInv.EsTraspaso == 1)//  _EsTraspaso 
                {
                    pui.cmpCveAlmacenDes = Convert.ToString(cboAlmaDest.SelectedValue);
                    pui.cmpCveTipoMovDest = CfgMovInvRel.CveClsMov; //_CveClsMovRel
                    pui.cmpEntSalDest = CfgMovInvRel.EntSal; //_EntSalRel
                    if (CfgMovInv.SolicitaSucursal == 1)
                        pui.cmpCveSucursal = Convert.ToString(cboSucursal.SelectedValue);

                }

                db.IniciaTrans();
                if (pui.AgregarInvMaster(int.Parse(CfgMovInv.CveFoliador), CfgMovInv.CveTipoMov, opcion, DcOrigen) >= 1)
                {
                    if (pui.AgregarInvDet() >= 1)
                    {
                        pui.keyNoMovimiento = Convert.ToString(folMovto);
                        pui.cmpCveAlmacenMov = _AlmO;
                        int rpp = 1;
                        if (CfgMovInv.AfectaCosto == 1)//_AfectaCosto
                        {
                            rpp = pui.AfectaCostos(CfgMovInv.CveTipoMov, 1);//_CveTipoMov
                        }
                        if (rpp >= 1)
                        {
                            if (pui.AfectaExistencias(CfgMovInv.EntSal, 1) >= 1) // _EntSal
                            {
                                if (CfgMovInv.EsTraspaso == 1) //_EsTraspaso
                                {
                                    String FolMovMaster = pui.AgregarBlanco(1, user.FecServer);

                                    if (FolMovMaster.CompareTo("Error") != 0)
                                    {
                                        //String FolMovDoc = pui.GetFolio(CfgMovInvRel.CveFoliador); //_FoliadorRel
                                        _AlmO = Convert.ToString(cboAlmaDest.SelectedValue);

                                        pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                        pui.cmpCveAlmacenMov = _AlmO;
                                        pui.cmpCveTipoMov = CfgMovInvRel.CveTipoMov;//_CveTipoMovRel
                                        pui.cmpEntSal = CfgMovInvRel.EntSal;//_EntSalRel
                                        pui.cmpDocTra = pui.cmpDocumento;
                                        pui.cmpCveAlmacenDes = "";
                                        pui.cmpCveTipoMovDest = "";
                                        pui.cmpEntSalDest = "";
                                        pui.cmpModulo = Modulo;

                                        pui.cmpDescuento = Convert.ToDouble(txtDescuento.Text);
                                        //                                    pui.cmpTotalDscto = Convert.ToDouble(txtTotDesc.Text);
                                        pui.cmpTIva = Convert.ToDouble(txtIVA.Text);
                                        pui.cmpSubTotal = Convert.ToDouble(txtSubTotal.Text);
                                        pui.cmpTotalDoc = Convert.ToDouble(txtTotal.Text);

                                        pui.cmpCveProveedor = CodProve;
                                        pui.cmpCancelado = 1;
                                        pui.cmpCveUsarioCaptu = user.Usuario;

                                        pui.cmpNoMovtoTra = Convert.ToString(folMovto);
                                        if (pui.AgregarInvMaster(int.Parse(CfgMovInvRel.CveFoliador), CfgMovInvRel.CveTipoMov, opcion, "") >= 1)
                                        {
                                            PuiAddPartidasMovInv PuiPart = new PuiAddPartidasMovInv(db);
                                            PuiPart.keyNoMovimiento = Convert.ToString(folMovto);
                                            PuiPart.cmpNoMovtoTra = FolMovMaster;

                                            if (PuiPart.MovParttoAlma() >= 1)
                                            {
                                                rpp = 1;
                                                pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                                pui.cmpCveAlmacenMov = _AlmO;
                                                if (CfgMovInvRel.AfectaCosto == 1) //_AfectaCostoRel
                                                {
                                                    rpp = pui.AfectaCostos(CfgMovInvRel.CveTipoMov, 1); //_CveTipoMovRel
                                                }
                                                if (rpp >= 1)
                                                {
                                                    if (pui.AfectaExistencias(CfgMovInvRel.EntSal, 1) >= 1) //_EntSalRel
                                                    {
                                                        if (pui.AgregarInvDet() >= 1)
                                                            rsp = 0;//Guardamos
                                                        else
                                                            rsp = 8;
                                                    }
                                                    else
                                                        rsp = 7;
                                                }
                                                else
                                                    rsp = 17;
                                            }
                                            else
                                                rsp = 6;
                                        }
                                        else
                                            rsp = 5;
                                    }
                                    else
                                        rsp = 4;
                                }
                                else
                                    rsp = 0;//Guardamos
                            }
                            else
                                rsp = 3;
                        }
                        else
                            rsp = 13;
                    }
                    else
                        rsp = 2;
                }
                else
                    rsp = 1;

                if (rsp == 0)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    db.TerminaTrans();
                    isDataSaved = true;
                    this.Close();
                }
                else
                    db.CancelaTrans();
            }

            catch (Exception ex)
            {
                
            }



            return rsp;
        }

        private void cboTipoMovtos_SelectedValueChanged(object sender, EventArgs e)
        {
            OcultProvee(false);
            //OcultSucursal(false);
            if (cboTipoMovtos.SelectedIndex >= 0)
            {
                strCboTipoMovInv = Convert.ToString(cboTipoMovtos.SelectedValue);
                if (!strCboTipoMovInv.Equals("System.Data.DataRowView"))
                {
                    //String CodTipMo = Convert.ToString(cboTipoMovtos.SelectedValue);
                    clsCfgTipoMovInv cd = new clsCfgTipoMovInv(strCboTipoMovInv, db);
                    CfgMovInv = cd.ConfigMovInv();
                    switch (strCboTipoMovInv)
                    {
                        case "001":
                            OcultProvee(true);
                            //TipoVal = 2;
                            break;
                        default: 
                            if(CfgMovInv.EsTraspaso ==1 )
                            {
                                clsCfgTipoMovInv cdR = new clsCfgTipoMovInv(CfgMovInv.TipoMovRel, db);
                                CfgMovInvRel = cdR.ConfigMovInv();
                                //OcultSucursal((CfgMovInv.SolicitaSucursal == 1) ? true : false);
                            }
                        break;
                    }
                }
            }

        }


        private void LleCboClaseMov()
        {
            PuiCatInv_ClaseMov lin = new PuiCatInv_ClaseMov(db);
            cboClaseMov.DataSource = lin.CboInv_ClaseMov();
            cboClaseMov.ValueMember = "CveClsMov";
            cboClaseMov.DisplayMember = "Descripcion";

        }

        private void LlecboAlmaOri(String CveUser, int OmiInternos = 1)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmaOri.DataSource = lin.CboCatAlmacenes(OmiInternos);
            cboAlmaOri.ValueMember = "ClaveAlmacen";
            cboAlmaOri.DisplayMember = "Descripcion";

            cboAlmaOri.SelectedValue = CveUser;
            CargaParamAlma(CveUser);
        }

        private void LlecboAlmaDest(String AlmDst1 = "", int OmiInternos = 1)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmaDest.DataSource = lin.CboCatAlmacenes(OmiInternos);
            cboAlmaDest.ValueMember = "ClaveAlmacen";
            cboAlmaDest.DisplayMember = "Descripcion";

            cboAlmaDest.SelectedValue = (AlmDst1.Equals(""))?user.AlmacenUsa:AlmDst1;
        }

        private void LlecboTipoMovtos(String cve)
        {
            PuiCatTipoMovtos lin = new PuiCatTipoMovtos(db);
            cboTipoMovtos.DataSource = lin.CboInv_TipoMovtos(cve);
            cboTipoMovtos.ValueMember = "CveTipoMov";
            cboTipoMovtos.DisplayMember = "Descripcion";
        }

        private void LlecboProveedor()
        {
            PuiCatProveedores lin = new PuiCatProveedores(db);
            cboProveedor.DataSource = lin.LLenaCboProveedores();
            cboProveedor.ValueMember = "Clave";
            cboProveedor.DisplayMember = "Descripcion";
        }

        private void LlecboSucursal(String Sc = "")
        {
            PuiCatSucursales lin = new PuiCatSucursales(db);
            cboSucursal.DataSource = lin.LLenaCboSucursales();
            cboSucursal.ValueMember = "Clave";
            cboSucursal.DisplayMember = "Descripcion";


            if(!Sc.Equals(""))
                cboAlmaDest.SelectedValue = Sc;
        }


        private void cboClaseMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoMovtos.DataSource = null;
            String val = Convert.ToString(cboClaseMov.SelectedValue);
            //MessageBoxAdv.Show("Error conn" + "----" + val + "----" + cboClaseMov.SelectedIndex);
            LlecboTipoMovtos(val);
            if (cboClaseMov.Text == "TRASPASO")
            {
                OcultAlmDest(true);
            }
            else
            {
                OcultAlmDest(false);
            }
        }

        private void OcultProvee(Boolean op)
        {
            lblProveedor.Visible = op;
            cboProveedor.Visible = op;
            if (op)
                LlecboProveedor();
            else
                cboProveedor.DataSource = null;
        }

        /*
        private void OcultSucursal(Boolean Op)
        {
            lblSucursal.Visible = Op;
            cboSucursal.Visible = Op;
            if (Op)
                LlecboSucursal();
            else
                cboSucursal.DataSource = null;
        }
        */


        private void btnAddPartida_Click(object sender, EventArgs e)
        {
            if(ValidaTipoMov()==1)
            {
                MovtosInvPart Addp = new MovtosInvPart(db, ParamSystem, StiloColor,user, Modulo, Convert.ToString(folMovto), 1,
                    CfgMovInv, cfgAlma,0, Convert.ToString(cboAlmaOri.SelectedValue));

                Addp.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Addp.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Addp.ShowDialog();
                LlenaGridViewPart();
                OpcionControles(false);
            }
        }

        private void LlenaGridViewPart()
        {
            try
            {
                PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                pui.keyNoMovimiento = Convert.ToString(folMovto);
                DatosTbl = pui.ListarPartidas();
                DataSet Ds = new DataSet();

                DatosTbl.Fill(Ds);
                //grdViewPart.Columns.Clear();


                grdViewPart.DataSource = Ds.Tables[0];
                grdViewPart.Columns["NoPartida"].Frozen = true;//Inmovilizar columna
                grdViewPart.Columns["NoPartida"].Width = 30;
                grdViewPart.Columns["NoMovimiento"].Visible = false;


                grdViewPart.Columns["CodigoBarra"].Frozen = true;//Inmovilizar columna
                grdViewPart.Columns["CodigoBarra"].Width = 100;
                grdViewPart.Columns["CodigoBarra"].HeaderText = "Código B";

                grdViewPart.Columns["Descripcion"].Frozen = true;//Inmovilizar columna
                grdViewPart.Columns["Descripcion"].Width = 300;


                if (ParamSystem.HideCveArt == 1)
                {
                    grdViewPart.Columns["CveArticulo"].Visible = false;
                }
                else
                {
                    grdViewPart.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
                    grdViewPart.Columns["CveArticulo"].Width = 100;
                    grdViewPart.Columns["CveArticulo"].HeaderText = "Clave";
                }





                grdViewPart.Columns["Precio"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewPart.Columns["Descuento"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewPart.Columns["TotalIva"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["TotalIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewPart.Columns["TotalIEPS"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["TotalIEPS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewPart.Columns["SubTotal"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewPart.Columns["TotalPartida"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewPart.Columns["TotalPartida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                
                CalculaTotales();


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int ValidaTipoMov()
        {
            int sig = 1;

            if (cboClaseMov.SelectedIndex <= 0)
            {
                sig = 0;
                MessageBoxAdv.Show("Movimiento es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (cboAlmaOri.SelectedIndex < 0)
                {
                    sig = 0;
                    MessageBoxAdv.Show("Almacén Origen es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (CfgMovInv.EsTraspaso == 1)
                    {
                        String AlmOri = Convert.ToString(cboAlmaOri.SelectedValue);
                        String AlmDest = Convert.ToString(cboAlmaDest.SelectedValue);
                        if (AlmOri.Equals(AlmDest))
                        {
                            sig = 0;
                            MessageBoxAdv.Show("Almacén Origen y Destino: No puede ser el mismo.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (cboSucursal.SelectedIndex < 0 && CfgMovInv.SolicitaSucursal==1)
                        {
                            sig = 0;
                            MessageBoxAdv.Show("Sucursal es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (cboProveedor.Visible)
                    {
                        if (cboProveedor.SelectedIndex < 0)
                        {
                            sig = 0;
                            MessageBoxAdv.Show("Proveedor es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if(cboTipoMovtos.SelectedIndex < 0)
                    {
                        sig = 0;
                        MessageBoxAdv.Show("Movimiento es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return sig;
        }

        private void btnEliminarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                int Cp = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
            
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                    db.IniciaTrans();
                    pui.keyNoMovimiento = grdViewPart[0, grdViewPart.CurrentRow.Index].Value.ToString();
                    pui.keyNoPartida = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
                    if (pui.EliminaPartida() >= 0)
                        db.TerminaTrans();
                    else
                    {
                        db.CancelaTrans();
                        MessageBoxAdv.Show("Existe un error al eliminar registro\n" , "Alerta", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
            LlenaGridViewPart();
        }

        private void CalculaTotales()
        {
            double Descuento = 0;
 //           double TotalDesc = 0;
            double TotalIva = 0;
            double TotalIEPS = 0;
            double SubTotal = 0;
            double TotalPartida = 0;
            foreach (DataGridViewRow row in grdViewPart.Rows)
            {
                Descuento = Descuento + Convert.ToDouble(Util.LimpiarTxt(row.Cells["Descuento"].Value.ToString()));
//                TotalDesc = TotalDesc + Convert.ToDouble(Util.LimpiarTxt(row.Cells["TotalDscto"].Value.ToString()));
                TotalIva = TotalIva + Convert.ToDouble(Util.LimpiarTxt(row.Cells["TotalIva"].Value.ToString()));
                TotalIEPS = TotalIEPS + Convert.ToDouble(Util.LimpiarTxt(row.Cells["TotalIEPS"].Value.ToString()));
                SubTotal = SubTotal + Convert.ToDouble(Util.LimpiarTxt(row.Cells["SubTotal"].Value.ToString()));
                TotalPartida = TotalPartida + Convert.ToDouble(Util.LimpiarTxt(row.Cells["TotalPartida"].Value.ToString()));
            }
            txtDescuento.Text = Convert.ToString(Descuento);//Util.FormtDouDec(Descuento);
            //            txtTotDesc.Text = Convert.ToString(TotalDesc);
            txtIVA.Text = Util.FormtDouDec(TotalIva);
            txtIeps.Text = Util.FormtDouDec(TotalIEPS);
            txtSubTotal.Text = Util.FormtDouDec(SubTotal);
            txtTotal.Text = Util.FormtDouDec(TotalPartida);
        }

        private void OcultAlmDest(Boolean op)
        {
            if (op)
                LlecboAlmaDest();
            else
                cboAlmaDest.DataSource = null;

            lblAlmaDest.Visible = op;
            cboAlmaDest.Visible = op;
        }

        private void OcultTitulos(Boolean op)
        {
            lblTitFolio.Visible = op;
            lblFolio.Visible = op;
            lblTitDocumento.Visible = op;
            lblDocumento.Visible = op;
        }


        private void btnEditaPartida_Click(object sender, EventArgs e)
        {
            try
            {
                int Cp = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
                MovtosInvPart Addp = new MovtosInvPart(db,ParamSystem, StiloColor,user, Modulo, Convert.ToString(folMovto), 2,
                        CfgMovInv, cfgAlma, Cp, Convert.ToString(cboAlmaOri.SelectedValue));

                Addp.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Addp.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Addp.ShowDialog();
                LlenaGridViewPart();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void OpcionControles(Boolean Op)
        {
            cboClaseMov.Enabled =  Op;
            cboAlmaOri.Enabled = (user.CambiaAlmacen == 1 ? Op : false);
            cboAlmaDest.Enabled = (user.CambiaAlmacen == 1 ? Op : false);
            cboTipoMovtos.Enabled = Op;
            cboProveedor.Enabled = Op;
            cboSucursal.Enabled = Op;
        }

        
        private void CargaParamAlma(String CveAlm)
        {
            clsCfgAlmacen cd = new clsCfgAlmacen(db, CveAlm);
            cfgAlma = cd.ConfigAlmacen();

        }

        private void cboAlmaOri_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmaOri.SelectedValue);
            if (!val.Equals("System.Data.DataRowView"))
            {
                CargaParamAlma(val);
            }
        }

        private void cboAlmaDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmaDest.SelectedValue);
            if (cboAlmaDest.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    CargaParamAlmaDest(val);
                }
            }
        }

        private void frmRegInventarioMovtos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDataSaved)
            {
                if (opcion != 3)
                {
                    switch (MessageBoxAdv.Show(this, "¿En realidad desea salir del movimiento?", "Movimiento inventario ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            e.Cancel = true;
                            break;
                        default:
                            Boolean rp = false;
                            if (grdViewPart.RowCount > 0)
                            {
                                cmdAceptar_Click(sender, e);
                                rp = isDataSaved;
                            }
                            if (!rp)
                            {
                                MovtosInvPui InvMast = new MovtosInvPui(db);
                                InvMast.keyNoMovimiento = Convert.ToString(folMovto);
                                InvMast.EliminaInventarioMov();
                            }
                            e.Cancel = false;
                            break;
                    }
                }
                else
                {
                    e.Cancel = false;
                }

            }
            else
            {
                e.Cancel = false;
            }
        }

        private void CargaParamAlmaDest(String CveAlm)
        {
            clsCfgAlmacen cd = new clsCfgAlmacen(db, CveAlm);
            cfgAlmaDest = cd.ConfigAlmacen();
        }

        private void frmRegInventarioMovtos_Load(object sender, EventArgs e)
        {
            /*
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            Art = new PuiCatArticulos(db);
            

            clsUsPerfil up = uT.BuscarIdNodo("1Inv001A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;
            */

        }

        private void GetRegistro()
        {
            MovtosInvPui pui = new MovtosInvPui(db);

            pui.keyNoMovimiento = Convert.ToString(folMovto);
            pui.EditarInventarioMov();

            LlecboAlmaOri(pui.cmpCveAlmacenMov);
            cboClaseMov.SelectedValue = pui.cmpCveClaseTipoMov;

            LlecboTipoMovtos(pui.cmpCveClaseTipoMov);
            cboTipoMovtos.SelectedValue = pui.cmpCveTipoMov;

            LlecboAlmaDest();
            cboAlmaDest.SelectedValue = pui.cmpCveAlmacenDes;

            LlecboProveedor();
            cboProveedor.SelectedValue = pui.cmpCveProveedor;

            
            lblFecha.Text =Convert.ToString(pui.cmpFechaMovimiento);
            lblFolio.Text = pui.cmpNoDoc;
            lblDocumento.Text = pui.cmpDocumento ;
        }

        public int MigrarDocDetToMovDet(String MInv, String CveProv, String DcOrigen, String Alm, String AlmDst="", String CvSuc = "")
        {
            int rsp = -1;
            MovtosInvPui pui = new MovtosInvPui(db);
            lblFecha.Text = Convert.ToString(user.FecServer);

            GetRegistroDocumento(DcOrigen);
            folMovto = pui.AgregarBlanco(1, user.FecServer);
            if (folMovto.CompareTo("Error") != 0)//if (movimiento.CompareTo("Error") != 0)
            {
                LlecboAlmaOri(Alm, 0);

                
                OcultProvee(false);

                strCboTipoMovInv = MInv;

                clsCfgTipoMovInv cd = new clsCfgTipoMovInv(strCboTipoMovInv, db);
                CfgMovInv = cd.ConfigMovInv();

                if (CfgMovInv.EsTraspaso == 1)
                {
                    if (AlmDst.Equals(CvSuc))//Entramos para obtener el almacen destino
                    {
                        PuiCatAlmacenes puiAlm = new PuiCatAlmacenes(db);

                        puiAlm.keyClaveAlmacen = AlmDst;
                        puiAlm.GetAlmaPorSuc();
                        AlmDst = puiAlm.keyClaveAlmacen;
                    }
                    LlecboAlmaDest(AlmDst,0);

                    clsCfgTipoMovInv cdR = new clsCfgTipoMovInv(CfgMovInv.TipoMovRel, db);
                    CfgMovInvRel = cdR.ConfigMovInv();
                }


                pui.keyNoMovimiento = Convert.ToString(folMovto);
                pui.cmpDocOrigen = DcOrigen;

                rsp = pui.AddPartMigraDoc();
                if (rsp > 0)
                {
                    rsp = Agregar(DcOrigen, CveProv, CvSuc);
                    if(rsp!=0) 
                    { //Registro cabecero y detalle
                        pui.EliminaInventarioMov();
                    }
                }
                else
                {
                    rsp = 9;
                    pui.EliminaInventarioMov();
                }
                    
            }
            else
            {
                pui.EliminaInventarioMov();
                MessageBoxAdv.Show("Movimiento Inventario: Ha ocurrido un error.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return rsp;
        }

        private void GetRegistroDocumento(String DcOrigen)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            rq.keyidMov = DcOrigen;
            rq.GetDocumento();
            txtDescuento.Text = Util.FormtDouDec(rq.cmpDescuento);
            //txtTotDesc.Text = "0";
            txtIVA.Text = Util.FormtDouDec(rq.cmpImpuesto);
            //txtIeps.Text = Convert.ToString(rq.cmp);
            txtSubTotal.Text = Util.FormtDouDec(rq.cmpSubTotal);
            txtTotal.Text =Util.FormtDouDec(rq.cmpTotal);

        }
    }
}
