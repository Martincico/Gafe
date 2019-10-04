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
using System.Collections;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class MovtosInvLst : MetroForm
    {
        private String TipoDocProv = "MINV"; //MINV aun no sta registrado
        private SqlDataAdapter DatosTbl;

        private MsSql db = null;
        DataTable dt = null;
        DataRow row = null;

        public DatCfgUsuario user;
        private clsUtil uT;

        public clsStiloTemas StiloColor;

        public MovtosInvLst()
        {
            InitializeComponent();
        }


        public MovtosInvLst(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmCatInventarioMovtos_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv011A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdRestablecer.Enabled = (AcCOP == 1) ? true : false;

            LlecboProveedor();
            LlecboAlmaOri(user.AlmacenUsa);
            cboAlmaOri.Enabled =user.CambiaAlmacen == 1 ? true : false;

            LlecboTipoMovtos();
            
            LlenaGridView();

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            /*
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(5000, user.FecServer);
            //llamar la forma de regdoc
            if (movimiento.CompareTo("Error") != 0)
            {
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor,  1, ConfigDoc, movimiento, CveDoc, NameDoc);
                Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Rcap.ShowDialog();
                LlenaGridView();
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro", "ERROR "+ NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 



            */
            MovtosInvPui pui = new MovtosInvPui(db);
            String folMovto = pui.AgregarBlanco(1, user.FecServer);
            if (folMovto.CompareTo("Error") != 0)
            {
                MovtosInvRegistro Ventana = new MovtosInvRegistro(db, 1, TipoDocProv, user, StiloColor, folMovto);
                Ventana.ShowDialog();
            }
            else
            {
                MessageBoxAdv.Show("Movimiento Inventario: Ha ocurrido un error.", "InventarioMovimientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LlenaGridView();
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                MovtosInvRegistro Ventana = new MovtosInvRegistro(db, StiloColor, 3, TipoDocProv, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                Ventana.ShowDialog();
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro ",
                    "Error al consultar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void frmCatInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void LlenaGridView()
        {
            String CodProve = Convert.ToString(cboProveedor.SelectedValue);
            String AlmOri = Convert.ToString(cboAlmaOri.SelectedValue);
            String CodTipoMov = Convert.ToString(cboTipoMovtos.SelectedValue);
            String FIni = dtFechaInicio.Value.ToString("dd/MM/yyyy");
            String FFin = dtFechaFin.Value.ToString("dd/MM/yyyy");


            MovtosInvPui pui = new MovtosInvPui(db);
            DatosTbl = pui.ListarInventarioMovtos(CodProve, AlmOri, CodTipoMov, FIni, FFin);
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();
                grdView.DataSource = Ds.Tables[0];
                grdView.Columns["Documento"].Frozen = true;//Inmovilizar columna
                grdView.Columns["NoMovimiento"].Visible = false;
                grdView.Columns["Cancelado"].Visible = false;
                grdView.Columns["TotalDoc"].Visible = false;
                grdView.Columns["CveTipoMov"].Visible = false;
                grdView.Columns["NoMovtoTra"].Visible = false;
                grdView.Columns["DocTra"].Visible = false;
                grdView.Columns["DocOrigen"].Visible = false;


                for (int i = 0; i < grdView.Columns.Count; i++)
                {
                    grdView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdConsultar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmdConsultar_Click(sender, e);
        }
        

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                String NoMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                String NoDoc = grdView[1, grdView.CurrentRow.Index].Value.ToString();
                String IdTipMov = grdView[8, grdView.CurrentRow.Index].Value.ToString();
                String t = grdView[9, grdView.CurrentRow.Index].Value.ToString();
                if (t.Equals(""))
                {
                    t = grdView[11, grdView.CurrentRow.Index].Value.ToString();
                    if (t.Equals(""))
                    {
                        if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + NoDoc,
                         "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            db.IniciaTrans();
                            int Rsp = EliminarMov(NoMov, IdTipMov);
                            String err = "";
                            if (Rsp < 0)
                            {
                                db.CancelaTrans();
                                switch (Rsp)
                                {
                                    case -1: err = "Existe un error al eliminar registro"; break;
                                    case -2: err = "Existe un error al afectar existencias de relación"; break;
                                    case -3: err = "Existe un error al afectar existencias"; break;
                                }
                                MessageBoxAdv.Show(err, "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                db.TerminaTrans();
                                MessageBoxAdv.Show("Registro eliminado", "Confirmacion", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBoxAdv.Show("Se requiere eliminar el documento Compra No: " + t, "Acción no permitida", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    t = grdView[10, grdView.CurrentRow.Index].Value.ToString();
                    MessageBoxAdv.Show("Proviene de un traspaso No: " + t, "Acción no permitida", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }

                LlenaGridView();
            }
            catch (Exception ex)
            {
                db.CancelaTrans();
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }

        }

        private void LlecboProveedor()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            dt = lin.CboInv_CatAlmacenes();
            row = dt.NewRow();
            row["ClaveAlmacen"] = "0";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboProveedor.DataSource = dt;
            cboProveedor.ValueMember = "ClaveAlmacen";
            cboProveedor.DisplayMember = "Descripcion";

            cboProveedor.SelectedValue = "0";
        }
        private void LlecboAlmaOri(String CveUser)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            dt = lin.CboInv_CatAlmacenes();
            row = dt.NewRow();
            row["ClaveAlmacen"] = "0";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboAlmaOri.DataSource = dt;

            cboAlmaOri.ValueMember = "ClaveAlmacen";
            cboAlmaOri.DisplayMember = "Descripcion";

            cboAlmaOri.SelectedValue = CveUser;
        }

        private void LlecboTipoMovtos()
        {

            PuiCatTipoMovtos lin = new PuiCatTipoMovtos(db);

            dt = lin.CboInv_TipoMovtos();
            row = dt.NewRow();
            if (dt.Rows.Count > 1)
            {
                row["CveTipoMov"] = "0";
                row["Descripcion"] = "TODOS ";
            }
            else
            {
                row["CveTipoMov"] = "";
                row["Descripcion"] = "";

            }
            dt.Rows.Add(row);

            cboTipoMovtos.DataSource = dt;


            cboTipoMovtos.ValueMember = "CveTipoMov";
            cboTipoMovtos.DisplayMember = "Descripcion";

            cboTipoMovtos.SelectedValue = "0";

        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            /*
            DateTime date1 = dtFechaInicio.Value;
            DateTime date2 = dtFechaFin.Value;
            int result = DateTime.Compare(date1, date2);

            if (result < 0)//Date1 Menor que Date2
                LlenaGridView();
            else if (result == 0)//Iguales
                LlenaGridView();
            else//Date1 Mayor que Date2
            {
                dtFechaInicio.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             */


            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                dtFechaInicio.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                LlenaGridView();

        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                dtFechaFin.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                LlenaGridView();
        }

        private void cboProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboProveedor.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void cboAlmaOri_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmaOri.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void cboTipoMovtos_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboTipoMovtos.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void cmdRestablecer_Click(object sender, EventArgs e)
        {
            dtFechaFin.Value = dtFechaFin.MaxDate;
            dtFechaInicio.Value = DateTime.Now;
            cboTipoMovtos.SelectedValue = "0";
            cboAlmaOri.SelectedValue = user.AlmacenUsa;
            cboProveedor.SelectedValue = "0";
            dtFechaFin.Value =  DateTime.Now;

        }

        private void frmLstInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private int EliminarMov(String NoMov, String IdTipMov)
        {
            int Rsp = -4;
            MovtosInvPui pui = new MovtosInvPui(db);
            MovtosInvPui puiRel = new MovtosInvPui(db);

            pui.keyNoMovimiento = NoMov;
            pui.EditarInventarioMov();

            PuiCatTipoMovtos PuiTM = new PuiCatTipoMovtos(db);
            PuiTM.keyCveTipoMov = IdTipMov;
            PuiTM.EditarTipoMov();
            int rpp = 1;
            if (PuiTM.cmpAfectaCosto == 1)
            {
                rpp = pui.AfectaCostos(pui.cmpCveTipoMov, 0);
            }
            if (pui.AfectaExistencias(pui.cmpEntSal, 0) >= 1 && rpp >= 1)
            {
                if (PuiTM.cmpEsTraspaso == 1)
                {
                    

                    puiRel.keyNoMovimiento = NoMov;
                    puiRel.GetRegMovTraspaso();

                    puiRel.EditarInventarioMov();

                    PuiCatTipoMovtos PuiTMRel = new PuiCatTipoMovtos(db);
                    PuiTMRel.keyCveTipoMov = puiRel.cmpCveTipoMov;
                    PuiTMRel.EditarTipoMov();

                    rpp = 1;
                    if (PuiTMRel.cmpAfectaCosto == 1)
                    {
                        rpp = puiRel.AfectaCostos(puiRel.cmpCveTipoMov, 0);
                    }
                    if (puiRel.AfectaExistencias(puiRel.cmpEntSal, 0) >= 1 && rpp >= 1)
                        Rsp = 0;
                    else
                        Rsp = -2;
                }
                else
                    Rsp = 0;

            }
            else
                Rsp = -3;

            if (Rsp == 0)
            {
                Rsp = pui.DelRegCerosSql();
                if (PuiTM.cmpEsTraspaso == 1)
                    Rsp = puiRel.DelRegCerosSql();
            }

            return Rsp;
        }


        public int DelMigraMov(String DcOrigen)
        {
            int Rsp = -4;
            MovtosInvPui Del = new MovtosInvPui(db);
            Del.cmpDocOrigen = DcOrigen;
            Del.GetIdMov();
            Rsp = EliminarMov(Del.keyNoMovimiento, Del.cmpCveTipoMov);

            return Rsp;
        }
    }
}
