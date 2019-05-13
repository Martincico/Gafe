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

namespace GAFE
{
    public partial class frmRegInventarioMovtos : Form
    {
        private int opcion, folMovto;

        private SqlDataAdapter DatosTbl;

        private String Modulo = "M01";
        private MsSql db = null;
        private String Foliador;

        //Configuración de Tipo de Movimiento
        private string _CveTipoMov;
        private string _Descripcion;
        private string _DescCorta;
        private string _EntSal;
        private string _CveClsMov;
        private string _Foliador;
        private int    _EditaFoli;
        private int    _EsTraspaso;
        private string _TipoMovRel;
        private string _FmtoImpresion;
        private int    _AfectaCosto;
        private int    _SugiereCosto;
        private int    _MuestraCosto;
        private int    _EditaCosto;
        private int    _SolicitaCosto;
        private int    _CalculaIva;

        //Configuración de Tipo de Movimiento RELACION
        private string _CveTipoMovRel;
        private string _DescripcionRel;
        private string _DescCortaRel;
        private string _EntSalRel;
        private string _CveClsMovRel;
        private string _FoliadorRel;
        private int _EditaFoliRel;
        private int _EsTraspasoRel;
        private string _TipoMovRelRel;
        private string _FmtoImpresionRel;
        private int _AfectaCostoRel = 0;
        private int _SugiereCostoRel;
        private int _MuestraCostoRel;
        private int _EditaCostoRel;
        private int _SolicitaCostoRel;
        private int _CalculaIvaRel;

        private int _AlmEsCompra;
        private int _AlmEsVenta;
        private int _AlmEsConsigna;
        private int _AlmNumRojo;

        private int _AlmEsCompraDest;
        private int _AlmEsVentaDest;
        private int _AlmEsConsignaDest;
        private int _AlmNumRojoDest;

        public frmRegInventarioMovtos()
        {
            InitializeComponent();
        }

        public frmRegInventarioMovtos(MsSql Odat, int Op, String TipoDocInv)
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;

            Foliador = "1";

            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyNoMovimiento = Foliador;
            pui.cmpFechaMovimiento = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now));

            //PENDIENTE Falta agregar los datos del almacen del usuario

            folMovto = pui.AgregarBlanco();

            if (folMovto >= 1)
              {
                LleCboClaseMov();
                LlecboAlmaOri("ALM022");
                OcultProvee(false);
                OcultAlmDest(false);
            }
            else
            {
                MessageBox.Show("Movimiento Inventario: Ha ocurrido un error.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
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
                case 1: Agregar(); break;
                case 2: Editar(); break;
                case 3: ConfirmarSalir(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            ConfirmarSalir();
        }

        private void Agregar()
        {
            String _cveinvmt = Convert.ToString(cboTipoMovtos.SelectedValue);
            String _AlmO  = Convert.ToString(cboAlmaOri.SelectedValue);
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            String CodProve = cboProveedor.Visible ? Convert.ToString(cboProveedor.SelectedValue) : "";
            String FolMov = pui.GetFolio(_Foliador);
            String DocM = _cveinvmt + _AlmO + folMovto;
            pui.keyNoMovimiento = Convert.ToString(folMovto);
            pui.cmpCveAlmacenMov = _AlmO;
            pui.cmpCveTipoMov = _cveinvmt;
            pui.cmpEntSal = _EntSal;
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
            pui.cmpCveUsarioCaptu = "USUARIO";
            pui.cmpCveAlmacenDes= "";
            pui.cmpCveTipoMovDest = "";
            pui.cmpEntSalDest = "";
            pui.cmpNoMovtoTra= "";
            pui.cmpDocTra = "";

            if (_EsTraspaso == 1)
            {
                pui.cmpCveAlmacenDes = Convert.ToString(cboAlmaDest.SelectedValue);
                pui.cmpCveTipoMovDest = _CveClsMovRel;
                pui.cmpEntSalDest = _EntSalRel;
            }
            if (_cveinvmt == "003" || _cveinvmt == "502")
            {
                pui.cmpCveTipoMovDest = _CveTipoMovRel;
                pui.cmpEntSalDest = _EntSalRel;
                pui.cmpCveAlmacenDes = Convert.ToString(cboAlmaDest.SelectedValue);
            }
            db.IniciaTrans();
            if (pui.AgregarInvMaster() >= 1)
            {
                if (pui.AgregarInvDet() >= 1)
                {
                    pui.keyNoMovimiento = Convert.ToString(folMovto);
                    pui.cmpCveAlmacenMov = _AlmO;
                    int rpp = 1;
                    if (_AfectaCosto==1)
                    {
                       rpp = pui.AfectaCostos();
                    }

                    if (pui.AfectaExistencias(_CveTipoMov,_EntSal) >= 1 && rpp >= 1)
                    {
                        if (_EsTraspaso == 1)
                        {
                            pui.keyNoMovimiento = Foliador;
                            pui.cmpFechaMovimiento = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                            int FolMovMaster = pui.AgregarBlanco();

                            if (FolMovMaster >= 1)
                            {
                                String FolMovDoc = pui.GetFolio(_FoliadorRel);
                                _AlmO = Convert.ToString(cboAlmaDest.SelectedValue);
                                _cveinvmt = Convert.ToString(cboTipoMovtos.SelectedValue);

                                pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                pui.cmpCveAlmacenMov = _AlmO;
                                pui.cmpCveTipoMov = _CveTipoMovRel;
                                pui.cmpEntSal = _EntSalRel;
                                pui.cmpNoDoc = FolMovDoc;
                                pui.cmpDocumento = _cveinvmt + _AlmO + FolMovMaster;
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
                                pui.cmpCveUsarioCaptu = "USUARIO";

                                pui.cmpNoMovtoTra = Convert.ToString(folMovto);
                                pui.cmpDocTra = DocM;
                                if (pui.AgregarInvMaster() >= 1)
                                {
                                    PuiAddPartidasMovInv PuiPart = new PuiAddPartidasMovInv(db);
                                    PuiPart.keyNoMovimiento = Convert.ToString(folMovto);
                                    PuiPart.keyNoPartida = FolMovMaster;

                                    if (PuiPart.MovParttoAlma() >= 1)
                                    {
                                        rpp = 1;
                                        pui.keyNoMovimiento = Convert.ToString(FolMovMaster);
                                        pui.cmpCveAlmacenMov = _AlmO;
                                        if (_AfectaCostoRel == 1)
                                        {
                                            rpp = pui.AfectaCostos();
                                        }
                                        
                                        if (pui.AfectaExistencias(_CveTipoMovRel, _EntSalRel) >= 1 && rpp == 1)
                                        {
                                            if (pui.AgregarInvDet() >= 1)
                                            {
                                                MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                                db.TerminaTrans();
                                                this.Close();
                                            }
                                            else
                                                db.CancelaTrans();
                                        }
                                        else
                                            db.CancelaTrans();
                                    }
                                    else
                                        db.CancelaTrans();
                                }
                                else
                                    db.CancelaTrans();
                            }
                            else
                              db.CancelaTrans();
                        }
                        else
                        {
                            MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                            db.TerminaTrans();
                            this.Close();
                        }
                    }
                    else
                        db.CancelaTrans();
                }
                else
                    db.CancelaTrans();
            }
            else
                db.CancelaTrans();
        }

        private void Editar()
        {

        }



        private void CargaInv_TipoMovtos()
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            pui.keyCveTipoMov = Convert.ToString(cboTipoMovtos.SelectedValue);
            pui.EditarTipoMov();

            _CveTipoMov = pui.keyCveTipoMov;
            _Descripcion = pui.cmpDescripcion;
            _DescCorta = pui.cmpDescCorta;
            _EntSal =  pui.cmpEntSal;
            _CveClsMov = pui.cmpCveClsMov;
            _TipoMovRel = pui.cmpTipoMovRel;
            _Foliador = pui.cmpCveFoliador;
            _EditaFoli = pui.cmpEditaFoli;
            _EsTraspaso = pui.cmpEsTraspaso;
            _FmtoImpresion = pui.cmpFmtoImpresion;
            _AfectaCosto = pui.cmpAfectaCosto;
            _SugiereCosto = pui.cmpSugiereCosto;
            _MuestraCosto = pui.cmpMuestraCosto;
            _EditaCosto = pui.cmpEditaCosto;
            _SolicitaCosto = pui.cmpSolicitaCosto;
            _CalculaIva = pui.cmpCalculaIva;
        }

        private void CargaInv_TipoMovtosRel()
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            pui.keyCveTipoMov = Convert.ToString(_TipoMovRel);
            pui.EditarTipoMov();

            _CveTipoMovRel = pui.keyCveTipoMov;
            _DescripcionRel = pui.cmpDescripcion;
            _DescCortaRel = pui.cmpDescCorta;
            _EntSalRel = pui.cmpEntSal;
            _CveClsMovRel = pui.cmpCveClsMov;
            _TipoMovRelRel = pui.cmpTipoMovRel;
            _FoliadorRel = pui.cmpCveFoliador;
            _EditaFoliRel = pui.cmpEditaFoli;
            _EsTraspasoRel = pui.cmpEsTraspaso;
            _FmtoImpresionRel = pui.cmpFmtoImpresion;
            _AfectaCostoRel = pui.cmpAfectaCosto;
            _SugiereCostoRel = pui.cmpSugiereCosto;
            _MuestraCostoRel = pui.cmpMuestraCosto;
            _EditaCostoRel = pui.cmpEditaCosto;
            _SolicitaCostoRel = pui.cmpSolicitaCosto;
            _CalculaIvaRel = pui.cmpCalculaIva;
        }

       

        private void cboTipoMovtos_SelectedValueChanged(object sender, EventArgs e)
        {
            OcultProvee(false);
            if (cboTipoMovtos.SelectedIndex >= 0)
            {
                CargaInv_TipoMovtos();
                String CodTipMo = Convert.ToString(cboTipoMovtos.SelectedValue);
                
                switch (CodTipMo)
                {
                    case "003": CargaInv_TipoMovtosRel(); break;
                    case "502": CargaInv_TipoMovtosRel(); break;
                    case "001":
                        OcultProvee(true);
                        //TipoVal = 2;
                        break;                }
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
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboProveedor.DataSource = lin.CboInv_CatAlmacenes();
            cboProveedor.ValueMember = "ClaveAlmacen";
            cboProveedor.DisplayMember = "Descripcion";
        }



    
        private void cboClaseMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoMovtos.DataSource = null;
            String val = Convert.ToString(cboClaseMov.SelectedValue);
            //MessageBox.Show("Error conn" + "----" + val + "----" + cboClaseMov.SelectedIndex);
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
                AddPartidaInvMovtos Addp = new AddPartidaInvMovtos(db, Modulo, Convert.ToString(folMovto), 1,
                    _CveTipoMov, _SugiereCosto, _EditaCosto, _MuestraCosto,
                    _SolicitaCosto, _EsTraspaso, _EntSal,_CalculaIva, 
                    Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now)),
                    _AlmNumRojo,_AlmNumRojoDest,0);
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
                DatosTbl = pui.ListarPartidas(Convert.ToString(folMovto));
                DataSet Ds = new DataSet();

                DatosTbl.Fill(Ds);
                //grdView.Rows.Clear();
                grdViewPart.DataSource = Ds.Tables[0];
                grdViewPart.Columns["NoMovimiento"].Visible = false;
                grdViewPart.Columns["Descuento"].Visible = false;
                grdViewPart.Columns["NoPartida"].Frozen = true;//Inmovilizar columna


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
                MessageBox.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int ValidaTipoMov()
        {
            int sig = 1;

            if (cboClaseMov.SelectedIndex <= 0)
            {
                sig = 0;
                MessageBox.Show("Movimiento es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (cboAlmaOri.SelectedIndex < 0)
                {
                    sig = 0;
                    MessageBox.Show("Almacén Origen es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (_EsTraspaso == 1)
                    {
                        String AlmOri = Convert.ToString(cboAlmaOri.SelectedValue);
                        String AlmDest = Convert.ToString(cboAlmaDest.SelectedValue);
                        if (AlmOri.Equals(AlmDest))
                        {
                            sig = 0;
                            MessageBox.Show("Almacén Origen y Destino: No puede ser el mismo.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (cboProveedor.Visible)
                    {
                        if (cboProveedor.SelectedIndex < 0)
                        {
                            sig = 0;
                            MessageBox.Show("Proveedor es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

            return sig;
        }

        private void btnEliminarPartida_Click(object sender, EventArgs e)
        {
            
            int Cp = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
            try { 
                if (MessageBox.Show("Esta seguro de eliminar el registro " + grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                    pui.keyNoMovimiento = grdViewPart[0, grdViewPart.CurrentRow.Index].Value.ToString();
                    pui.keyNoPartida = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
                    pui.EliminaPartida();
                    LlenaGridViewPart();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
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

        private void btnRestablecer_Click(object sender, EventArgs e)
        {

        }

        private void btnEditaPartida_Click(object sender, EventArgs e)
        {
            try
            {
                int Cp = Convert.ToInt32(grdViewPart[1, grdViewPart.CurrentRow.Index].Value.ToString());
                AddPartidaInvMovtos Addp = new AddPartidaInvMovtos(db, Modulo, Convert.ToString(folMovto), 2,
                        _CveTipoMov, _SugiereCosto, _EditaCosto, _MuestraCosto,
                        _SolicitaCosto, _EsTraspaso, _EntSal, _CalculaIva,
                        Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now)),
                        _AlmNumRojo, _AlmNumRojoDest, Cp);
                Addp.ShowDialog();
                LlenaGridViewPart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void frmRegInventarioMovtos_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ConfirmarSalir()
        {
            Boolean DellAll = true;

                PuiCatInventarioMov InvMast = new PuiCatInventarioMov(db);
                if (grdViewPart.RowCount > 0)
                {
                    switch (MessageBox.Show(this, "¿Desea guardar cambios?", "Salir del modulo ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            break;
                        default:
                            DellAll = false;
                            if (opcion == 1)
                            {
                                Agregar();
                            }
                            break;
                    }
                }

                if (DellAll)
                {
                    InvMast.keyNoMovimiento = Convert.ToString(folMovto);
                    InvMast.EliminaInventarioMov();
                }

                this.Close();
        }


        private void OpcionControles(Boolean Op)
        {
            cboClaseMov.Enabled =  Op;
            cboAlmaOri.Enabled = Op;
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

        private void frmRegInventarioMovtos_Load(object sender, EventArgs e)
        {

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



    }
}
