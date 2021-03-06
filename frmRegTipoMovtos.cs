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
    public partial class frmRegTipoMovtos : MetroForm
    {
        private int opcion;
        private MsSql db = null;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        public frmRegTipoMovtos()
        {
            InitializeComponent();
        }

        public frmRegTipoMovtos(MsSql Odat, DatCfgParamSystem ParamS, int Op, String Cod="")
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            LimpiarControles();
            OpcionControles(true);
            LleCboClaseMov();
            switch (opcion)
            {
                case 1://Nuevo
                    OpcionControles(true);
                    LlecboCfgCatFoliadores(0);
                    break;
                case 2://Edita
                    LlecboCfgCatFoliadores(1);
                    get_Campos(Cod);
                    txtClaveTipoMov.Enabled = false;
                    cboCfgCatFoliadores.Enabled = false;
                break;
                case 3://Consulta
                    LlecboCfgCatFoliadores(1);
                    get_Campos(Cod);
                    OpcionControles(false);
                    cboTipoMovRel.Enabled = false;
                    cboCfgCatFoliadores.Enabled = false;
                    break;
            }
            
        }

        private void get_Campos(String Cod)
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            pui.keyCveTipoMov = Cod;
            pui.EditarTipoMov();

            txtClaveTipoMov.Text = pui.keyCveTipoMov;
            txtDescripcion.Text = pui.cmpDescripcion;
            txtDescCorta.Text = pui.cmpDescCorta;
            rdbEntrada.Checked = pui.cmpEntSal == "E" ? true : false;
            rdbSalida.Checked = pui.cmpEntSal == "S" ? true : false;
            cboCveClsMov.SelectedValue = pui.cmpCveClsMov;
            cboTipoMovRel.SelectedValue = pui.cmpTipoMovRel;
            cboCfgCatFoliadores.SelectedValue = pui.cmpCveFoliador;
            chkEditaFoli.Checked = pui.cmpEditaFoli == 1 ? true : false;
            chkEstraspaso.Checked = pui.cmpEsTraspaso == 1 ? true : false;
            txtFmtoImpresion.Text = pui.cmpFmtoImpresion;
            chkAfectaCosto.Checked = pui.cmpAfectaCosto == 1 ? true : false;
            chkSugiereCosto.Checked = pui.cmpSugiereCosto == 1 ? true : false;
            chkMuestraCosto.Checked = pui.cmpMuestraCosto == 1 ? true : false;
            chkEditaCosto.Checked = pui.cmpEditaCosto == 1 ? true : false;

            chkSolicitaCosto.Checked = pui.cmpSolicitaCosto == 1 ? true : false;
            chkCalculaIva.Checked = pui.cmpCalculaIva == 1 ? true : false;
            //chkCentroCosto.Checked = pui.cmpPideCentroCosto == 1 ? true : false;
            chkInterno.Checked = pui.cmpEsInterno == 1 ? true : false;
            chkEstatus.Checked = pui.cmpEstatus == 1 ? true : false;
            chkSolicitaSucursal.Checked = pui.cmpSolicitaSucursal == 1 ? true : false;

        }


        private void frmRegTipoMovtos_KeyDown(object sender, KeyEventArgs e)
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
                //PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);

                //if (pui.AgregarTipoMov() >= 1)
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
                    //if (pui.ActualizaTipoMov() >= 0)
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
            string _tipomovrel = (cboCveClsMov.Text == "TRASPASO") ? Convert.ToString(cboTipoMovRel.SelectedValue) : "";
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            pui.keyCveTipoMov = txtClaveTipoMov.Text;
            pui.cmpDescripcion = txtDescripcion.Text;
            pui.cmpDescCorta = txtDescCorta.Text;
            pui.cmpEntSal = rdbEntrada.Checked ? "E" : "S";
            pui.cmpCveClsMov =  Convert.ToString(cboCveClsMov.SelectedValue);
            pui.cmpTipoMovRel = _tipomovrel;
            pui.cmpCveFoliador = Convert.ToString(cboCfgCatFoliadores.SelectedValue);
            pui.cmpEditaFoli = chkEditaFoli.Checked ? 1 : 0;
            pui.cmpEsTraspaso = chkEstraspaso.Checked ? 1 : 0;
            pui.cmpFmtoImpresion = txtFmtoImpresion.Text;
            pui.cmpAfectaCosto = chkAfectaCosto.Checked ? 1 : 0;
            pui.cmpSugiereCosto = chkSugiereCosto.Checked ? 1 : 0;
            pui.cmpMuestraCosto = chkMuestraCosto.Checked ? 1 : 0;
            pui.cmpEditaCosto = chkEditaCosto.Checked ? 1 : 0;
            pui.cmpSolicitaCosto = chkSolicitaCosto.Checked ? 1 : 0;
            pui.cmpCalculaIva = chkCalculaIva.Checked ? 1 : 0;
            pui.cmpEsInterno = chkInterno.Checked ? 1 : 0;
            pui.cmpPideCentroCosto = 0;
            pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;
            pui.cmpSolicitaSucursal = chkSolicitaSucursal.Checked ? 1 : 0;
            if (opcion==1)
            {
                db.IniciaTrans();
                if(pui.AgregarTipoMov()==1)
                {
                    //PuiCatTipoMovtos pui2 = new PuiCatTipoMovtos(db);
                    pui.cmpCveFoliador = Convert.ToString(cboCfgCatFoliadores.SelectedValue);
                    if(pui.AddRegCfgFoliadores()==1)
                    {
                        rsp = 1;
                        db.TerminaTrans();
                    }
                    else
                        db.CancelaTrans();

                }
                else
                    db.CancelaTrans();
            }
            else
                rsp =pui.ActualizaTipoMov();


            return rsp;
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            if (String.IsNullOrEmpty(txtClaveTipoMov.Text))
            {
                MessageBoxAdv.Show("Código: No puede ir vacío.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveTipoMov.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (String.IsNullOrEmpty(txtDescCorta.Text))
            {
                MessageBoxAdv.Show("Descripción Corta: No puede ir vacío.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtDescCorta.Text))
                {
                    MessageBoxAdv.Show("Descripción Corta: Contiene caracteres no validos.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }
            
            if (!String.IsNullOrEmpty(txtFmtoImpresion.Text))
            {
                if (!Util.Letras(txtFmtoImpresion.Text))
                {
                    MessageBoxAdv.Show("Nombre Fmto Impr: Contiene caracteres no validos.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (string.IsNullOrEmpty(Convert.ToString(cboCfgCatFoliadores.SelectedValue)))
            {
                MessageBoxAdv.Show("Foliador: No puede ir vacío.", "Configuración de tipo de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }

            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            txtClaveTipoMov.Enabled = Op;
            txtDescripcion.Enabled = Op;

            txtDescCorta.Enabled = Op;
            rdbEntrada.Enabled = Op;
            rdbSalida.Enabled = Op;
            cboCveClsMov.Enabled = Op;
            cboCfgCatFoliadores.Enabled = Op;
            chkEditaFoli.Enabled = Op;
            chkEstraspaso.Enabled = Op;
            txtFmtoImpresion.Enabled = Op;
            chkAfectaCosto.Enabled = Op;
            chkSugiereCosto.Enabled = Op;
            chkMuestraCosto.Enabled = Op;
            chkEditaCosto.Enabled = Op;
            chkSolicitaCosto.Enabled = Op;
            chkCalculaIva.Enabled = Op;
            chkInterno.Enabled = Op;
            chkEstatus.Enabled = Op;
            chkSolicitaSucursal.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveTipoMov.Text = "";
            txtDescripcion.Text = "";
        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LleCboClaseMov()
        {
            PuiCatInv_ClaseMov lin = new PuiCatInv_ClaseMov(db);
            cboCveClsMov.DataSource = lin.CboInv_ClaseMov();
            cboCveClsMov.ValueMember = "CveClsMov";
            cboCveClsMov.DisplayMember = "Descripcion";
        }


        private void LleCboMovRel()
        {
            PuiCatTipoMovtos lin = new PuiCatTipoMovtos(db);
            cboTipoMovRel.DataSource = lin.CboInv_TipoMovtos();
            cboTipoMovRel.ValueMember = "CveTipoMov";
            cboTipoMovRel.DisplayMember = "Descripcion";

        }

        private void LlecboCfgCatFoliadores(int SinUso)
        {
            PuiCatCfgCatFoliadores lin = new PuiCatCfgCatFoliadores(db);
            cboCfgCatFoliadores.DataSource = lin.cboCfgCatFoliadores(SinUso);
            cboCfgCatFoliadores.ValueMember = "CveFoliador";
            cboCfgCatFoliadores.DisplayMember = "Descripcion";
        }
        
        private void cboCveClsMov_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCveClsMov.Text == "TRASPASO")
            {
                cboTipoMovRel.Enabled = true;
                LleCboMovRel();
            }
            else
            {
                cboTipoMovRel.Enabled = false;
                cboTipoMovRel.Text = "";
            }

        }

        private void txtClaveTipoMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        /*Recorre un cbo y retorna el index
         * 
        private static int GetCboSelectIndex(ComboBox combobx, string value)
        {
            for (int i = 0; i <= combobx.Items.Count - 1; i++)
            {
                DataRowView cb = (DataRowView)combobx.Items[i];
                MessageBoxAdv.Show("Registro " + cb.Row.ItemArray[0].ToString(), "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                if (cb.Row.ItemArray[0].ToString() == value)
                    return i;
            }
            return -1;
        }
        */
    }
}
