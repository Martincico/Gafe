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
    public partial class frmRegInventarioMovtos : MetroForm
    {
        private int opcion, folMovto;

        private SqlDataAdapter DatosTbl;

        private String Modulo = "M01";
        private MsSql db = null;
        private String Foliador = "1";

        public DatCfgUsuario user;

        private Boolean isDataSaved = false;

        clsCfgTipoMovInv CfgMovInv;
        clsCfgTipoMovInv CfgMovInvRel;

        private int _AlmEsCompra;
        private int _AlmEsVenta;
        private int _AlmEsConsigna;
        private int _AlmNumRojo;

        private int _AlmEsCompraDest;
        private int _AlmEsVentaDest;
        private int _AlmEsConsignaDest;
        private int _AlmNumRojoDest;

        string strCboTipoMovInv; //Tomará el valor del combo de Tipo de Movimiento Inventario

        public clsStiloTemas StiloColor;

        public frmRegInventarioMovtos()
        {
            InitializeComponent();
        }

        public frmRegInventarioMovtos(MsSql Odat, int Op, String TipoDocInv, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            StiloColor = NewColor;
            user = DatUsr;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyNoMovimiento = Foliador;
            pui.cmpFechaMovimiento = user.FecServer;

            lblFecha.Text = Convert.ToString(pui.cmpFechaMovimiento);
            //PENDIENTE Falta agregar los datos del almacen del usuario

            folMovto = pui.AgregarBlanco();
            OcultTitulos(false);
            OpcionControles(true);

            if (folMovto >= 1)
              {
                LleCboClaseMov();
                LlecboAlmaOri(user.AlmacenUsa);
                OcultProvee(false);
                OcultAlmDest(false);
            }
            else
            {
                MessageBoxAdv.Show("Movimiento Inventario: Ha ocurrido un error.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Para Editar
        public frmRegInventarioMovtos(MsSql Odat, clsStiloTemas NewColor, int Op, String TipoDocInv, String Cod)
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            StiloColor = NewColor;

            folMovto = Convert.ToInt32(Cod);

            LleCboClaseMov();
            LlenaGridViewPart();
            OpcionControles(false);
            isDataSaved = true;
            GetRegistro();

            btnAddPartida.Enabled = false;
            btnEditaPartida.Enabled = false;
            btnEliminarPartida.Enabled = false;
            OcultTitulos(true);

        }

        //Para insertar registro relacionado de Documentos
        public frmRegInventarioMovtos(MsSql Odat, clsStiloTemas NewColor,  String TipoDocInv, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            db = Odat;
            StiloColor = NewColor;
            user = DatUsr;
                        
        }





        private void frmRegInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ConfirmarSalir();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case 1: int rsp = Agregar("");
                    if (rsp != 0)
                    {
                        string msj = "";
                        switch (rsp)
                        {
                            case 1: msj = "Al guardar cabecero"; break;
                            case 2: msj = "Al guardar detalle partidas"; break;
                            case 3: msj = "Al afectar existencias"; break;
                            case 4: msj = "Traspaso: Registro en blanco"; break;
                            case 5: msj = "Traspaso: Al guardar cabecero"; break;
                            case 6: msj = "Traspaso: Al guardar detalle partidas"; break;
                            case 7: msj = "Traspaso: Al afectar existencias"; break;
                            case 8: msj = "Traspaso: Al actualizar detalle partidas"; break;
                            default: msj = "Error desconocido"; break;
                        }
                        MessageBoxAdv.Show(msj, "Error al guardar el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 2: ConfirmarSalir(); break;
                case 3: this.Close(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            ConfirmarSalir();
        }

        private int Agregar(String DcOrigen)
        {
            int rsp = -1;
            //strCboTipoMovInv == String _cveinvmt = Convert.ToString(cboTipoMovtos.SelectedValue);
            String _AlmO  = Convert.ToString(cboAlmaOri.SelectedValue);
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            String CodProve = cboProveedor.Visible ? Convert.ToString(cboProveedor.SelectedValue) : "";
            String FolMov = pui.GetFolio(CfgMovInv.CveFoliador);//_Foliador
            String DocM = strCboTipoMovInv + _AlmO + folMovto;
            pui.keyNoMovimiento = Convert.ToString(folMovto);
            pui.cmpCveAlmacenMov = _AlmO;
            pui.cmpCveTipoMov = strCboTipoMovInv;
            pui.cmpEntSal = CfgMovInv.EntSal;//_EntSal
            pui.cmpNoDoc = FolMov;
            pui.cmpModulo = Modulo;
            pui.cmpDocumento = DocM;
            pui.cmpDescuento = Convert.ToDouble(txtDescuento.Text);
            pui.cmpTotalDscto = Convert.ToDouble(txtTotDesc.Text);
            pui.cmpTIva = Convert.ToDouble(txtIva.Text);
            pui.cmpSubTotal = Convert.ToDouble(txtSubTotal.Text);
            pui.cmpTotalDoc = Convert.ToDouble(txtTotal.Text);
            pui.cmpCveProveedor = CodProve;
            pui.cmpCancelado = 1;
            pui.cmpCveUsarioCaptu = user.CodPerfil;
            pui.cmpCveAlmacenDes= "";
            pui.cmpCveTipoMovDest = "";
            pui.cmpEntSalDest = "";
            pui.cmpNoMovtoTra= "";
            pui.cmpDocTra = "";
            pui.cmpDocOrigen = DcOrigen;

            if (CfgMovInv.EsTraspaso == 1)//  _EsTraspaso 
            {
                pui.cmpCveAlmacenDes = Convert.ToString(cboAlmaDest.SelectedValue);
                pui.cmpCveTipoMovDest = CfgMovInvRel.CveClsMov; //_CveClsMovRel
                pui.cmpEntSalDest = CfgMovInvRel.EntSal; //_EntSalRel
            }
            if (strCboTipoMovInv == "003" || strCboTipoMovInv == "502")
            {
                pui.cmpCveTipoMovDest = CfgMovInvRel.CveTipoMov;//_CveTipoMovRel
                pui.cmpEntSalDest = CfgMovInvRel.EntSal; //_EntSalRel
                pui.cmpCveAlmacenDes = Convert.ToString(cboAlmaDest.SelectedValue);
            }
            db.IniciaTrans();
            if (pui.AgregarInvMaster(DcOrigen) >= 1)
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

                    if (pui.AfectaExistencias(CfgMovInv.EntSal, 1) >= 1 && rpp >= 1) // _EntSal
                    {
                        if (CfgMovInv.EsTraspaso == 1) //_EsTraspaso
                        {
                            pui.keyNoMovimiento = Foliador;
                            pui.cmpFechaMovimiento = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                            int FolMovMaster = pui.AgregarBlanco();

                            if (FolMovMaster >= 1)
                            {
                                String FolMovDoc = pui.GetFolio(CfgMovInvRel.CveFoliador); //_FoliadorRel
                                _AlmO = Convert.ToString(cboAlmaDest.SelectedValue);

                                pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                pui.cmpCveAlmacenMov = _AlmO;
                                pui.cmpCveTipoMov = CfgMovInvRel.CveTipoMov;//_CveTipoMovRel
                                pui.cmpEntSal = CfgMovInvRel.EntSal;//_EntSalRel
                                pui.cmpNoDoc = FolMovDoc;
                                pui.cmpDocumento = strCboTipoMovInv + _AlmO + FolMovMaster;
                                pui.cmpCveAlmacenDes = "";
                                pui.cmpCveTipoMovDest = "";
                                pui.cmpEntSalDest = "";
                                pui.cmpModulo = Modulo;

                                pui.cmpDescuento = Convert.ToDouble(txtDescuento.Text);
                                pui.cmpTotalDscto = Convert.ToDouble(txtTotDesc.Text);
                                pui.cmpTIva = Convert.ToDouble(txtIva.Text);
                                pui.cmpSubTotal = Convert.ToDouble(txtSubTotal.Text);
                                pui.cmpTotalDoc = Convert.ToDouble(txtTotal.Text);

                                pui.cmpCveProveedor = CodProve;
                                pui.cmpCancelado = 1;
                                pui.cmpCveUsarioCaptu = user.CodPerfil;

                                pui.cmpNoMovtoTra = Convert.ToString(folMovto);
                                pui.cmpDocTra = DocM;
                                if (pui.AgregarInvMaster("") >= 1)
                                {
                                    PuiAddPartidasMovInv PuiPart = new PuiAddPartidasMovInv(db);
                                    PuiPart.keyNoMovimiento = Convert.ToString(folMovto);
                                    PuiPart.keyNoPartida = FolMovMaster;

                                    if (PuiPart.MovParttoAlma() >= 1)
                                    {
                                        rpp = 1;
                                        pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                        pui.cmpCveAlmacenMov = _AlmO;
                                        if (CfgMovInvRel.AfectaCosto == 1) //_AfectaCostoRel
                                        {
                                            rpp = pui.AfectaCostos(CfgMovInvRel.CveTipoMov, 1); //_CveTipoMovRel
                                        }

                                        if (pui.AfectaExistencias(CfgMovInvRel.EntSal, 1) >= 1 && rpp == 1) //_EntSalRel
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
                    rsp = 2;
            }
            else
                rsp = 1;

            if(rsp==0)
            {
                MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                db.TerminaTrans();
                isDataSaved = true;
                this.Close();
            }
            else
                db.CancelaTrans();

            return rsp;
        }

        private void cboTipoMovtos_SelectedValueChanged(object sender, EventArgs e)
        {
            OcultProvee(false);
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
                        case "003":
                                clsCfgTipoMovInv cdR = new clsCfgTipoMovInv(CfgMovInv.TipoMovRel, db);
                                CfgMovInvRel = cdR.ConfigMovInv();
                            break;
                        case "502":
                                clsCfgTipoMovInv cdRr = new clsCfgTipoMovInv(CfgMovInv.TipoMovRel, db);
                                CfgMovInvRel = cdRr.ConfigMovInv(); break;
                        case "001":
                            OcultProvee(true);
                            //TipoVal = 2;
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

        private void LlecboAlmaOri(String CveUser)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmaOri.DataSource = lin.CboInv_CatAlmacenes();
            cboAlmaOri.ValueMember = "ClaveAlmacen";
            cboAlmaOri.DisplayMember = "Descripcion";

            cboAlmaOri.SelectedValue = CveUser;
            CargaParamAlma(CveUser);
        }

        private void LlecboAlmaDest()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmaDest.DataSource = lin.CboInv_CatAlmacenes();
            cboAlmaDest.ValueMember = "ClaveAlmacen";
            cboAlmaDest.DisplayMember = "Descripcion";
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

        private void btnAddPartida_Click(object sender, EventArgs e)
        {
            if(ValidaTipoMov()==1)
            {
                AddPartidaInvMovtos Addp = new AddPartidaInvMovtos(db, StiloColor, Modulo, Convert.ToString(folMovto), 1,
                    CfgMovInv.CveTipoMov, CfgMovInv.SugiereCosto, CfgMovInv.EditaCosto, CfgMovInv.MuestraCosto, //_CveTipoMov, _SugiereCosto, _EditaCosto, _MuestraCosto,
                    CfgMovInv.SolicitaCosto, CfgMovInv.EsTraspaso, CfgMovInv.EntSal, CfgMovInv.CalculaIva,  //_SolicitaCosto, _EsTraspaso, _EntSal,_CalculaIva, 
                    Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now)),
                    _AlmNumRojo,_AlmNumRojoDest,0,user.CodPerfil);
                 
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
                grdViewPart.Columns.Clear();
                
                grdViewPart.DataSource = Ds.Tables[0];
                grdViewPart.Columns["NoPartida"].Frozen = true;//Inmovilizar columna
                grdViewPart.Columns["NoMovimiento"].Visible = false;
                grdViewPart.Columns["Descuento"].Visible = false;



                /*
                DataTable dbdataset = new DataTable();

                DatosTbl.Fill(dbdataset);
                //grdViewPart.Rows.Clear();

                BindingSource bSoucer = new BindingSource();

                bSoucer.DataSource = dbdataset;
                grdViewPart.DataSource = bSoucer;
                DatosTbl.Update(dbdataset);
                */
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
            
            int Cp = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
            try { 
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
            double TotalDesc = 0;
            double TotalIva = 0;
            double SubTotal = 0;
            double TotalPartida = 0;
            foreach (DataGridViewRow row in grdViewPart.Rows)
            {
                Descuento = Descuento + Convert.ToDouble(row.Cells["Descuento"].Value.ToString());
                TotalDesc = TotalDesc + Convert.ToDouble(row.Cells["TotalDscto"].Value.ToString());
                TotalIva = TotalIva + Convert.ToDouble(row.Cells["TotalIva"].Value.ToString());
                SubTotal = SubTotal + Convert.ToDouble(row.Cells["SubTotal"].Value.ToString());
                TotalPartida = TotalPartida + Convert.ToDouble(row.Cells["TotalPartida"].Value.ToString());
            }
            txtDescuento.Text = Convert.ToString(Descuento);
            txtTotDesc.Text = Convert.ToString(TotalDesc);
            txtIva.Text = Convert.ToString(TotalIva);
            txtSubTotal.Text = Convert.ToString(SubTotal);
            txtTotal.Text = Convert.ToString(TotalPartida);
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
                AddPartidaInvMovtos Addp = new AddPartidaInvMovtos(db, StiloColor, Modulo, Convert.ToString(folMovto), 2,
                        CfgMovInv.CveTipoMov, CfgMovInv.SugiereCosto, CfgMovInv.EditaCosto, CfgMovInv.MuestraCosto,
                        CfgMovInv.SolicitaCosto, CfgMovInv.EsTraspaso, CfgMovInv.EntSal, CfgMovInv.CalculaIva,
                        Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now)),
                        _AlmNumRojo, _AlmNumRojoDest, Cp, user.CodPerfil);
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


        private void ConfirmarSalir()
        {
            if (opcion != 3)
            {
                Boolean DellAll = true;

                PuiCatInventarioMov InvMast = new PuiCatInventarioMov(db);
                if (grdViewPart.RowCount > 0)
                {
                    switch (MessageBoxAdv.Show(this, "¿Desea guardar cambios?", "Salir del modulo ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            break;
                        default:
                            DellAll = false;
                            if (opcion == 1)
                            {
                                Agregar("");
                            }
                            break;
                    }
                }

                if (DellAll)
                {
                    InvMast.keyNoMovimiento = Convert.ToString(folMovto);
                    InvMast.EliminaInventarioMov();
                }
                isDataSaved = true;
                this.Close();
            }
            else
            {
                isDataSaved = true;
                this.Close();
            }

        }


        private void OpcionControles(Boolean Op)
        {
            cboClaseMov.Enabled =  Op;
            cboAlmaOri.Enabled = Op ? (user.CambiaAlmacen == 1 ? true : false) : false;
            cboAlmaDest.Enabled = Op;
            cboTipoMovtos.Enabled = Op;
            cboProveedor.Enabled = Op;
        }

        
        private void CargaParamAlma(String CveAlm)
        {
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.cmpCveAlmacenMov = CveAlm;
            pui.GetParamAlma();

            _AlmEsCompra = pui.cmpEsDeCompra;
            _AlmEsVenta = pui.cmpEsDeVenta;
            _AlmEsConsigna = pui.cmpEsDeConsigna;
            _AlmNumRojo = pui.cmpNumRojo;
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
                ConfirmarSalir();
                e.Cancel = true;
            }
            else
            {
                //MessageBoxAdv.Show("Goodbye.");
                e.Cancel = false;
            }
        }

        private void CargaParamAlmaDest(String CveAlm)
        {
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.cmpCveAlmacenMov = CveAlm;
            pui.GetParamAlma();

            _AlmEsCompraDest = pui.cmpEsDeCompra;
            _AlmEsVentaDest = pui.cmpEsDeVenta;
            _AlmEsConsignaDest = pui.cmpEsDeConsigna;
            _AlmNumRojoDest = pui.cmpNumRojo;
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
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);

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

        public int MigrarDocDetToMovDet(String MInv, String CveProv, String IdDoc, String DcOrigen)
        {
            int rsp = -1;
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyNoMovimiento = Foliador;
            pui.cmpFechaMovimiento = user.FecServer;

            lblFecha.Text = Convert.ToString(pui.cmpFechaMovimiento);

            folMovto = pui.AgregarBlanco();

            if (folMovto >= 1)
            {
                LlecboAlmaOri(user.AlmacenUsa);
                OcultProvee(false);

                strCboTipoMovInv = MInv;

                clsCfgTipoMovInv cd = new clsCfgTipoMovInv(strCboTipoMovInv, db);
                CfgMovInv = cd.ConfigMovInv();

                LlecboProveedor();
                cboProveedor.SelectedValue = CveProv;

                pui.keyNoMovimiento = Convert.ToString(folMovto);
                pui.cmpCveTipoMov = IdDoc;

                rsp = pui.AddPartMigraDoc();
                if (rsp > 0)
                {
                    rsp = Agregar(DcOrigen);
                    if(rsp!=0) //En esta parte hay que eliminar todo, ya que hubo un error
                    { //Registro cabecero y detalle
                        int s = 0;
                    }
                }

                else
                    rsp = 9;
            }
            else
            {
                MessageBoxAdv.Show("Movimiento Inventario: Ha ocurrido un error.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return rsp;
        }

    }
}
