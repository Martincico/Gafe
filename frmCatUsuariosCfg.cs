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
using System.Xml;
using System.IO;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmCatUsuariosCfg : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        private int opcion;
        private int idxG;
        public string KeyCampo;
        private MsSql db = null;
        public DatCfgUsuario user;
        private clsUtil uT;

        public frmCatUsuariosCfg()
        {
            InitializeComponent();
        }

        public frmCatUsuariosCfg(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            ParamSystem = ParamS;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmCatUsuariosCfg_Load(object sender, EventArgs e)
        {
         
            this.Size = this.MinimumSize;
            LlenaGridView();
            LlecboAlmacen();
            LlecboUsuario(1);
            LlecboTema();
            LlecboFondo();
            cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;

        }
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 1;
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            LlecboUsuario(0);
            this.Size = this.MaximumSize;
            opcion = 2;

            idxG = grdView.CurrentRow.Index;

            getValues();


            cboUsuario.Enabled = false;

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            LlecboUsuario(0);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;
            getValues();

            OpcionControles(false);
        }

        private void getValues()
        {
            PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);

            pui.keySUsrCfg = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarUsrCfg();
            cboUsuario.SelectedValue = pui.keySUsrCfg;
            cboAlmacen.SelectedValue = pui.cmpCveAlmacen;
            chkCambiaAlmacen.Checked = pui.cmpCambiaAlmacen == 1? true: false;
            cboFondo.SelectedValue = pui.cmpFondo;
            cboTema.SelectedValue = pui.cmpStiloTema;


        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);
                    pui.keySUsrCfg = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaUsrCfg();
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);
            DatosTbl = pui.BuscaUsrCfg(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);

            grdView.Rows.Clear();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
        }

        
        private void cmdAceptar_Click(object sender, EventArgs e)
        {

            switch (opcion)
            {
                case 1: Agregar(); 
                    break;
                case 2: Editar(); break;
                case 3: this.Size = this.MinimumSize; break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            LimpiarControles();
            OpcionControles(true);
        }


        private void LlenaGridView()
        {
            PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);
            DatosTbl = pui.ListarUsrCfg();
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Rows.Clear();

                for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                {
                    object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                    grdView.Rows.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Agregar()
        {
            if (Validar())
            {
                PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);
                SetValues(pui);

                if (pui.AgregarUsrCfg() >= 1)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiSegUsuarioCfg pui = new PuiSegUsuarioCfg(db);
                    SetValues(pui);
                    if (pui.ActualizaUsrCfg() >= 0)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    LlenaGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetValues(PuiSegUsuarioCfg pui)
        {
            pui.keySUsrCfg = cboUsuario.SelectedValue.ToString();
            pui.cmpCveAlmacen = cboAlmacen.SelectedValue.ToString();
            pui.cmpCambiaAlmacen = (chkCambiaAlmacen.Checked) ? 1 : 0;
            pui.cmpFondo = cboFondo.SelectedValue.ToString();
            pui.cmpStiloTema = cboTema.SelectedValue.ToString();

        }

        private Boolean Validar()
        {
            Boolean dv = true;
            string msg = "";
            if (cboAlmacen.SelectedIndex < 0)
            {
                msg = "Seleccioné un almacén \n";
                dv = false;
            }

            if (cboUsuario.SelectedIndex < 0)
            {
                msg = "Seleccioné un usurio. \n";
                dv = false;
            }

            if (cboTema.SelectedIndex < 0)
            {
                msg = "Seleccioné un tema. \n";
                dv = false;
            }

            if (cboFondo.SelectedIndex < 0)
            {
                msg = "Seleccioné un fondo. \n";
                dv = false;
            }

            if(!dv)
            {
                MessageBoxAdv.Show("Se encontraron los siguientes errores: \n" + msg, " Configuración de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            cboUsuario.Enabled = Op;
            cboAlmacen.Enabled = Op;
            cboFondo.Enabled = Op;
            cboTema.Enabled = Op;
            chkCambiaAlmacen.Enabled = Op;
        }

        private void LimpiarControles()
        {
            LlecboUsuario(1);
            LlecboAlmacen();
            LlecboFondo();
            LlecboTema();
        }

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmEditar_Click(sender, e);

        }

        private void LlecboAlmacen()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmacen.DataSource = lin.CboCatAlmacenes(1);
            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";
        }

        private void LlecboUsuario(int SinConfg)
        {
            PuiSegUsuarios lin = new PuiSegUsuarios(db);
            cboUsuario.DataSource = lin.CboUsuarios(SinConfg);
            cboUsuario.ValueMember = "Clave";
            cboUsuario.DisplayMember = "Descripcion";
        }

        private void LlecboTema()
        {
            PuiSegUsuarioCfg lin = new PuiSegUsuarioCfg(db);
            cboTema.DataSource = lin.CboTemas();
            cboTema.ValueMember = "Clave";
            cboTema.DisplayMember = "Descripcion";
        }

        private void LlecboFondo()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboFondo.DataSource = lin.CboCatAlmacenes(1);
            cboFondo.ValueMember = "ClaveAlmacen";
            cboFondo.DisplayMember = "Descripcion";
        }

        private void cmdAgregar_Click_1(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 1;
        }

        private void frmCatUsuariosCfg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }
    }
}
