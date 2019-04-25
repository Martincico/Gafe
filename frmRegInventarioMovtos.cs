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
        private int opcion, TipoVal = 0;
        private MsSql db = null;
        private int folMovto;

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
        private int    _PideCentroCosto;
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
        private int _AfectaCostoRel;
        private int _SugiereCostoRel;
        private int _MuestraCostoRel;
        private int _EditaCostoRel;
        private int _SolicitaCostoRel;
        private int _PideCentroCostoRel;
        private int _CalculaIvaRel;



        public frmRegInventarioMovtos()
        {
            InitializeComponent();
        }

        public frmRegInventarioMovtos(MsSql Odat, int Op, String TipoDocInv)
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyNoMovimiento = "1";
            pui.cmpFechaMovimiento = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            pui.cmpCveAlmacenMov = "";
            pui.cmpCveTipoMov = "";
            pui.cmpEntSal = "";
            pui.cmpNoDoc = "";
            pui.cmpDocumento = "";
            pui.cmpCveAlmacenDes = "";
            pui.cmpCveTipoMovDest = "";
            pui.cmpEntSalDest = "";
            pui.cmpModulo = "";
            pui.cmpTipoDoc = "";
            pui.cmpSerieDoc = "";
            pui.cmpFolioDocOrigen = "";
            pui.cmpDescuento = 0;
            pui.cmpTotalDscto = 0;
            pui.cmpTIva = 0;
            pui.cmpSubTotal = 0;
            pui.cmpTotalDoc = 0;
            pui.cmpCveProveedor = "";
            pui.cmpCveCliente = "";
            pui.cmpCancelado = 1;
            pui.cmpCveUsarioCaptu = "";
            pui.cmpCveCentroCosto = "";
            pui.cmpNoMovtoTra = "";
            pui.cmpDocTra = "";


//            if(pui.AgregarBlanco() >=1);
  //          {
                LleCboClaseMov();
                LlecboAlmaOri("ALM022");
                OcultProvee(false);
                OcultAlmDest(false);
                
    //        }

            
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
                case 1: Agregar(); break;
                case 2: Editar(); break;
                case 3: this.Close(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar()
        {
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
            _Foliador = pui.cmpFoliador;
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
            _FoliadorRel = pui.cmpFoliador;
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
                        TipoVal = 2;
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
                TipoVal = 1;
            }
            else
            {
                OcultAlmDest(false);
                TipoVal = 0;
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
                AddPartidaInvMovtos Addp = new AddPartidaInvMovtos(db, 1, "");
                Addp.ShowDialog();
            }
        }

        private int ValidaTipoMov()
        {
            int sig = 1;

            if (cboAlmaOri.SelectedIndex < 0)
            {
                sig = 0;
                MessageBox.Show("Almacén Origen es incorrecto.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (_EsTraspaso == 1)
            {
                String AlmOri = Convert.ToString(cboAlmaOri.SelectedValue);
                String AlmDest = Convert.ToString(cboAlmaDest.SelectedValue);
                if(AlmOri.Equals(AlmDest))
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


            //Validad si Proveedor esta visible haya seleccionado uno

            return sig;
        }


        private void OcultAlmDest(Boolean op)
        {
            lblAlmaDest.Visible = op;
            cboAlmaDest.Visible = op;
            if (op)
                LlecboAlmaDest();
            else
                cboAlmaDest.DataSource = null;
        }
    }
}
