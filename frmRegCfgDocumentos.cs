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
    public partial class frmRegCfgDocumentos : MetroForm
    {
        private int opcion;
        private MsSql db = null;

        PuiCatArticulos Art;
        private clsUtil uT;

        public DatCfgUsuario user;

        public frmRegCfgDocumentos()
        {
            InitializeComponent();
        }

        public frmRegCfgDocumentos(MsSql Odat, DatCfgUsuario DatUsr, int Op, String Alm= "", String TMov = "", String ser= "")
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            user = DatUsr;


            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            LimpiarControles();
            OpcionControles(true);
            LlecboAlmacen();
            LlecboTMovtoProv();
            LlecboCfgCatFoliadores();

            switch (opcion)
            {
                case 1://Nuevo
                    OpcionControles(true);
                break;
                case 2://Edita
                    get_Campos(Alm,TMov,ser);
                    txtSerie.Enabled = false;
                    cboAlmacen.Enabled = false;
                    cboTMovtoProv.Enabled = false;
                    break;
                case 3://Consulta
                    get_Campos(Alm, TMov, ser);
                    OpcionControles(false);
                break;

            }
            
        }

        private void get_Campos(String Alm, String TMov, String ser)
        {
            
            PuiCatCfgDocumentos pui = new PuiCatCfgDocumentos(db);
            pui.keyCveAlmacen = Alm;
            pui.keyCodMovProv = TMov;
            pui.keySerie = ser;

            pui.EditarCfgDocProv();

            cboAlmacen.SelectedValue = Alm;
            cboTMovtoProv.SelectedValue = TMov;
            txtSerie.Text = ser;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboCfgCatFoliadores.SelectedValue = pui.cmpCodFoliador;
            txtFmtoImpresion.Text = pui.cmpFmtoImpresion;
            txtNombreImpresora.Text = pui.cmpNombImpresora;
            chkEstatus.Checked = pui.cmpEstatus == 1 ? true : false;
            chkEditaFoli.Checked = pui.cmpEditaFolio == 1 ? true : false;
            chkPregImpresion.Checked = pui.cmpPregImpresion == 1 ? true : false;
            
        }


        private void frmRegCfgDocumentos_KeyDown(object sender, KeyEventArgs e)
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
            LimpiarControles();
            OpcionControles(true);
            this.Close();
        }

        private void Agregar()
        {
            if (Validar())
            {
                if (set_Campos() >= 1)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    if (set_Campos() >= 0)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        public int set_Campos()
        {
            int rsp = -1;
            PuiCatCfgDocumentos pui = new PuiCatCfgDocumentos(db);

            pui.keyCveAlmacen = Convert.ToString(cboAlmacen.SelectedValue);
            pui.keyCodMovProv = Convert.ToString(cboTMovtoProv.SelectedValue);
            pui.keySerie = txtSerie.Text;
            pui.cmpDescripcion = txtDescripcion.Text;
            pui.cmpCodFoliador = Convert.ToString(cboCfgCatFoliadores.SelectedValue);
            pui.cmpFmtoImpresion = txtFmtoImpresion.Text;
            pui.cmpNombImpresora = txtNombreImpresora.Text;
            pui.cmpNoCopiasImp = 1;
            pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;
            pui.cmpEditaFolio = chkEditaFoli.Checked ? 1 : 0;
            pui.cmpPregImpresion = chkPregImpresion.Checked ? 1 : 0;

            if (opcion==1)
            {
                db.IniciaTrans();
                if(pui.AgregarCfgDocProv()==1)
                {
                    if(pui.AddRegCfgFoliadores()==1)
                    {
                        rsp = 1;
                        db.TerminaTrans();
                    }
                    else
                        db.CancelaTrans();

                }
            }
            else
                rsp =pui.ActualizaCfgDocProv();

            return rsp;
        }


        private Boolean Validar()
        {
            
            Boolean dv = true;

            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBoxAdv.Show("Serie: No puede ir vacío.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtSerie.Text))
                {
                    MessageBoxAdv.Show("Serie: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (!String.IsNullOrEmpty(txtFmtoImpresion.Text))
            {
                if (!Util.LetrasNum(txtFmtoImpresion.Text))
                {
                    MessageBoxAdv.Show("Formato de impresión Corta: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            if (!String.IsNullOrEmpty(txtNombreImpresora.Text))
            {
                if (!Util.Letras(txtNombreImpresora.Text))
                {
                    MessageBoxAdv.Show("Nombre de impresora: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            cboAlmacen.Enabled = Op?(user.CambiaAlmacen == 1?true:false) : false;

            cboTMovtoProv.Enabled = Op;
            txtSerie.Enabled = Op;
            txtDescripcion.Enabled = Op;
            cboCfgCatFoliadores.Enabled = Op;
            txtFmtoImpresion.Enabled = Op;
            txtNombreImpresora.Enabled = Op;
            chkEditaFoli.Enabled = Op;
            chkEstatus.Enabled = Op;
            chkPregImpresion.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtSerie.Text = "";
            txtDescripcion.Text = "";
            txtFmtoImpresion.Text = "";
            txtNombreImpresora.Text = "";
        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlecboAlmacen()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmacen.DataSource = lin.CboInv_CatAlmacenes();
            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";
        }
      
        private void LlecboTMovtoProv()
        {
            PuiCatCfgTipoMovProv lin = new PuiCatCfgTipoMovProv(db);
            cboTMovtoProv.DataSource = lin.cboTipoMovProvee();
            cboTMovtoProv.ValueMember = "Clave";
            cboTMovtoProv.DisplayMember = "Descripcion";
        }

        private void LlecboCfgCatFoliadores()
        {
            PuiCatCfgCatFoliadores lin = new PuiCatCfgCatFoliadores(db);
            cboCfgCatFoliadores.DataSource = lin.cboCfgCatFoliadores(0);
            cboCfgCatFoliadores.ValueMember = "CveFoliador";
            cboCfgCatFoliadores.DisplayMember = "Descripcion";
        }

        private void frmRegCfgDocProv_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            Art = new PuiCatArticulos(db);

            /*
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
    }
}
