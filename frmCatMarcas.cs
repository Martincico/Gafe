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
using System.Xml;
using System.IO;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmCatMarcas : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;
        private int opcion;
        public String idxG;
        public string[] dv = new string[2];
        private int AcCOPSelec;
        private int AcCOPEdit;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        public frmCatMarcas()
        {
            
            InitializeComponent();
        }


        public frmCatMarcas(MsSql Odat, DatCfgParamSystem ParamS, string perfil, int opc=0)
        {
            InitializeComponent();
            db = Odat;
            Perfil = perfil;
            opcion = opc;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatMarcas_Load(object sender, EventArgs e)
        {

            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv004A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004E");
            AcCOPSelec = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOPSelec == 1) ? true : false;

            cmdSeleccionar.Visible = false;

            this.Size = this.MinimumSize;
            LlenaGridView();

            if (opcion >3)
            {
                //                cmdAgregar.Visible = false;
                cmdEliminar.Visible = false;
                //                cmdEditar.Visible = false;
                cmdSeleccionar.Visible = true;
            }

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
            if(AcCOPEdit == 1)
            {
                LimpiarControles();
                OpcionControles(true);
                this.Size = this.MaximumSize;
                opcion = 2;

                //idxG = grdView.CurrentRow.Index;

                PuiCatMarcas pui = new PuiCatMarcas(db);

                pui.keyCveMarca = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarMarcas();
                txtClaveMarcas.Text = pui.keyCveMarca;
                txtDescripcion.Text = pui.cmpDescripcion;
                chkEstatus.Checked = (pui.cmpEstatus == 1) ? true : false;

                txtClaveMarcas.Enabled = false;
            }
            else
            {
                MessageBoxAdv.Show("No tienes privilegios suficientes",
                "Error al editar registro", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }            
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            //idxG = grdView.CurrentRow.Index;

            PuiCatMarcas pui = new PuiCatMarcas(db);

            pui.keyCveMarca = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarMarcas();
            txtClaveMarcas.Text = pui.keyCveMarca;
            txtDescripcion.Text = pui.cmpDescripcion;
            chkEstatus.Checked = (pui.cmpEstatus == 1) ? true : false;

            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBoxAdv.Show(this, "Esta seguro de eliminar el registro?" + grdView[0, grdView.CurrentRow.Index].Value.ToString(), "Confirmar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatMarcas pui = new PuiCatMarcas(db);
                    pui.keyCveMarca = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaMarcas();
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
            PuiCatMarcas pui = new PuiCatMarcas(db);
            DatosTbl = pui.BuscaMarcas(txtBuscar.Text);
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
                case 1: Agregar(); break;
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

        private void frmCatMarcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        
        private void LlenaGridView()
        {
            PuiCatMarcas pui = new PuiCatMarcas(db);
            DatosTbl = pui.ListarMarcas();
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
                PuiCatMarcas pui = new PuiCatMarcas(db);

                pui.keyCveMarca = txtClaveMarcas.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;


                if (pui.AgregarMarcas() >= 1)
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
                if (AcCOPEdit == 1)
                {
                    if (Validar())
                    {
                        PuiCatMarcas pui = new PuiCatMarcas(db);

                        pui.keyCveMarca = txtClaveMarcas.Text;
                        pui.cmpDescripcion = txtDescripcion.Text;
                        pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;

                        if (pui.ActualizaMarcas() >= 0)
                        {
                            MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information);
                            this.Size = this.MinimumSize;
                        }
                        LlenaGridView();
                        //grdView.CurrentRow.Index = idxG;  
                    }
                }
                else
                    {
                    MessageBoxAdv.Show("No tienes privilegios suficientes",
                     "Error al editar registro", MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            if (String.IsNullOrEmpty(txtClaveMarcas.Text))
            {
                MessageBoxAdv.Show("Código: No puede ir vacío.", "CatLineaes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveMarcas.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtClaveMarcas.Enabled = Op;
            txtDescripcion.Enabled = Op;
            chkEstatus.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveMarcas.Text = "";
            txtDescripcion.Text = "";
        }

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void txtClaveMarcas_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void grdView_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            //Checamos click ha sido en el encabezado?
            if (grdView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
            {
                //creamos un menu
                ContextMenu mnugrid = new ContextMenu();

                //Agregamos submenus
                foreach (DataGridViewColumn cols in grdView.Columns)
                {
                    MenuItem _items = new MenuItem();

                    _items.Text = cols.HeaderText;
                    _items.Checked = cols.Visible;

                    //Agregando evento al submenu al click
                    _items.Click += (obj, ea) =>
                    {
                        cols.Visible = !_items.Checked;

                        _items.Checked = cols.Visible;

                        mnugrid.Show(grdView, e.Location);
                    };

                    mnugrid.MenuItems.Add(_items);
                }

                //Mostrando menú
                mnugrid.Show(grdView, e.Location);
            }
            */
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AcCOPSelec == 1)
                {
                    idxG = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[0] = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[1] = grdView[1, grdView.CurrentRow.Index].Value.ToString();

                    this.Close();
                }
                else
                {
                    MessageBoxAdv.Show("No tienes privilegios suficientes",
                     "Error al editar registro", MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void grdView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}
