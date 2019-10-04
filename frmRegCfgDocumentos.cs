﻿using System;
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
        private MsSql db = null;
        private int opcion;
        private string Perfil;


        PuiCatArticulos Art;
        private clsUtil uT;


        public frmRegCfgDocumentos()
        {
            InitializeComponent();
        }

        public frmRegCfgDocumentos(MsSql Odat, string perfil, int op, String Cod = "")
        {
            InitializeComponent();
            opcion = op;
            db = Odat;
            Perfil = perfil;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            LimpiarControles();
            OpcionControles(true);
            LleCboTipoMov();
            LlecboCfgCatFoliadores();
            LlecboCfgDocumentosRel();
            switch (opcion)
            {
                case 1://Nuevo
                    OpcionControles(true);
                break;
                case 2://Edita
                    get_Campos(Cod);
                    txtClaveTipoMov.Enabled = false;
                break;
                case 3://Consulta
                    get_Campos(Cod);
                    OpcionControles(false);
                    cboTipoMov.Enabled = false;
                break;

            }
            
        }

        private void get_Campos(String Cod)
        {
            PuiCatCfgDocumentos pui = new PuiCatCfgDocumentos(db);
            pui.keyCveDoc = Cod;
            pui.EditarCfgDocumentos();
            txtClaveTipoMov.Text = pui.keyCveDoc;
            txtDescripcion.Text = pui.cmpNombre;
            cboTipoMov.SelectedValue = pui.cmpCveTipoMov;
            cboCfgCatFoliadores.SelectedValue = pui.cmpFoliador;
            chkUsaSerie.Checked = pui.cmpUsaSerie == 1 ? true : false;
            chkEditaFecha.Checked = pui.cmpEditaFecha== 1 ? true : false;
            chkAutoriza.Checked = pui.cmpSolicitaAutorizar == 1 ? true : false;
            chkAfectaInventario.Checked = pui.cmpAfectaInventario == 1 ? true : false;
            if (pui.cmpCargoAbono == "C")
            {
                optCargo.Checked = true;
                optAbono.Checked = false;
            }
            else
            {
                optCargo.Checked = false;
                optAbono.Checked = true;
            }
            if (pui.cmpUsaCliente == 1)
            {
                optCliente.Checked = true;
                optProveedor.Checked = false;
            }
            else
            {
                optCliente.Checked = false;
                optProveedor.Checked = true;
            }
            chkEsInterno.Checked = pui.cmpEsInterno == 1 ? true : false;
            chkEstatus.Checked = pui.cmpEstatus == 1 ? true : false;


            cboDocRel.SelectedValue = pui.cmpDocRel;
            txtBotonDocRel.Text = pui.cmptxtBotonDocRel;
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
        /*
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Close();
        }
        */

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
            
            pui.keyCveDoc = txtClaveTipoMov.Text;
            pui.cmpNombre = txtDescripcion.Text;
            pui.cmpCveTipoMov = Convert.ToString(cboTipoMov.SelectedValue);
            pui.cmpFoliador = Convert.ToString(cboCfgCatFoliadores.SelectedValue);
            pui.cmpCargoAbono = optAbono.Checked ? "A" : "C";
            pui.cmpUsaSerie = chkUsaSerie.Checked ? 1 : 0;
            pui.cmpEditaFecha = chkEditaFecha.Checked ? 1 : 0;
            pui.cmpSolicitaAutorizar = chkAutoriza.Checked ? 1 : 0;
            pui.cmpAfectaInventario = chkAfectaInventario.Checked ? 1 : 0;
            pui.cmpEsInterno = chkEsInterno.Checked ? 1 : 0;
            pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;
            pui.cmpUsaCliente = optCliente.Checked ? 1 : 0;
            pui.cmpUsaProvee = optProveedor.Checked ? 1 : 0;
            pui.cmpDocRel = Convert.ToString(cboDocRel.SelectedValue);
            pui.cmptxtBotonDocRel = "";
            if (!pui.cmpDocRel.Equals(""))
                pui.cmptxtBotonDocRel = txtBotonDocRel.Text;

            if (opcion==1)
            {
                db.IniciaTrans();
                if (pui.AgregarCfgDocumentos()==1)
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
                rsp =pui.ActualizaCfgDocumentos();
            


            return rsp;
        }


        private Boolean Validar()
        {
            
            Boolean dv = true;
            
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveTipoMov.Text))
            {
                MessageBoxAdv.Show("Código: No puede ir vacío.", "Configuración de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveTipoMov.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "Configuración de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "Configuración de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "Configuración de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            String val = Convert.ToString(cboTipoMov.SelectedValue);
            if (val.Equals(""))
            {
                MessageBoxAdv.Show("Módulo: No puede ir vacío.", "Configuración de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }

            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            txtClaveTipoMov.Enabled = Op;
            txtDescripcion.Enabled = Op;
            optCargo.Enabled = Op;
            optAbono.Enabled = Op;
            cboCfgCatFoliadores.Enabled = Op;
            chkUsaSerie.Enabled = Op;
            chkEditaFecha.Enabled = Op;
            chkAutoriza.Enabled = Op;
            chkAfectaInventario.Enabled = Op;
            chkEsInterno.Enabled = Op;
            chkEstatus.Enabled = Op;
            cboDocRel.Enabled = Op;
            txtBotonDocRel.Enabled = Op;

        }

        private void LimpiarControles()
        {
            txtClaveTipoMov.Text = "";
            txtDescripcion.Text = "";
            txtEmail.Text = "";
            txtBotonDocRel.Text = "";
            cboDocRel.SelectedValue = "";

        }

        private void LleCboTipoMov()
        {
            PuiCatTipoMovtos lin = new PuiCatTipoMovtos(db);
            DataTable dt = lin.CboInv_TipoMovtos("",0);
            DataRow row = dt.NewRow();
            row["CveTipoMov"] = "0";
            row["Descripcion"] = "NINGUNO ";
            dt.Rows.Add(row);

            cboTipoMov.DataSource = dt;


            cboTipoMov.ValueMember = "CveTipoMov";
            cboTipoMov.DisplayMember = "Descripcion";

            cboTipoMov.SelectedValue = 0;
        }

        private void LlecboCfgCatFoliadores()
        {
            PuiCatCfgCatFoliadores lin = new PuiCatCfgCatFoliadores(db);
            cboCfgCatFoliadores.DataSource = lin.cboCfgCatFoliadores(1);
            cboCfgCatFoliadores.ValueMember = "CveFoliador";
            cboCfgCatFoliadores.DisplayMember = "Descripcion";
        }

        private void LlecboCfgDocumentosRel()
        {
            PuiCatCfgDocumentos lin = new PuiCatCfgDocumentos(db);
            DataTable dt = lin.cboCfgDocumentos();
            DataRow row = dt.NewRow();
            row["Clave"] = "";
            row["Descripcion"] = "NINGUNO";
            dt.Rows.Add(row);


            cboDocRel.DataSource = dt;
            cboDocRel.ValueMember = "Clave";
            cboDocRel.DisplayMember = "Descripcion";

            cboDocRel.SelectedValue = "";


        }

        private void txtClaveTipoMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void frmRegCfgDocumentos_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, Perfil);
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

        private void frmRegCfgDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cboDocRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            String val = Convert.ToString(cboDocRel.SelectedValue);
            if (cboDocRel.Text == "NINGUNO")
            {
                txtBotonDocRel.Enabled = false;
                txtBotonDocRel.Text = "";
            }
            else
            {
                txtBotonDocRel.Enabled = true;
            }
        }

        private void cboDocRel_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}
