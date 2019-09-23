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
    public partial class frmExistencias : MetroForm
    {

        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        private clsUtil uT;

        List<clsFillCbo> lp;
        List<clsFillCbo> ln;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;

        public frmExistencias()
        {
            InitializeComponent();
        }


        public frmExistencias(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmExistencias_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv013A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAsignaStock.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv013B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv013C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            string Sqlstr = " SELECT  ClaveAlmacen,Descripcion FROM Inv_CatAlmacenes WHERE Estatus = 'A'";
            SqlDataReader dr = db.SelectDR(Sqlstr);
            lp = new List<clsFillCbo>();

            clsFillCbo Prv1 = new clsFillCbo();
            Prv1.Id = "";
            Prv1.Descripcion = "";
            lp.Add(Prv1);

            while (dr.Read())
            {
                clsFillCbo Prv = new clsFillCbo();
                Prv.Id = Convert.ToString(dr["ClaveAlmacen"]);
                Prv.Descripcion = Convert.ToString(dr["Descripcion"]);
                lp.Add(Prv);
            }
            dr.Close();
            cboAlmacen.DataSource = lp;
            cboAlmacen.ValueMember = "Id";
            cboAlmacen.DisplayMember = "Descripcion";
            cboAlmacen.SelectedValue = user.AlmacenUsa;
            cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;

            string Sqlstr2 = " SELECT CveLinea,Descripcion FROM Inv_Lineas WHERE Estatus = 1";
            SqlDataReader dr2 = db.SelectDR(Sqlstr2);
            ln = new List<clsFillCbo>();

            clsFillCbo Rln = new clsFillCbo();
            Rln.Id = "";
            Rln.Descripcion = "";
            ln.Add(Rln);

            while (dr2.Read())
            {
                clsFillCbo Rlnc = new clsFillCbo();
                Rlnc.Id = Convert.ToString(dr2["CveLinea"]);
                Rlnc.Descripcion = Convert.ToString(dr2["Descripcion"]);
                ln.Add(Rlnc);
            }
            dr2.Close();
            cboLineas.DataSource = ln;
            cboLineas.ValueMember = "Id";
            cboLineas.DisplayMember = "Descripcion";
            
            LlenaGridView(0);
        }


        private void LlenaGridView(int tieneFiltro)
        {
            PuiExistencias pui = new PuiExistencias(db);
            DatosTbl = (tieneFiltro == 0) ? pui.ListarExistencias() : pui.BuscaExistencia(txtClaveArticulo.Text,cboAlmacen.SelectedValue.ToString(),
                                                                              cboLineas.SelectedValue.ToString(),txtBuscar.Text);
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

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos la = new frmLstArticulos(db, StiloColor, user.CodPerfil,3);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            txtClaveArticulo.Text = la.dv[0];
            txtDscArticulo.Text = la.dv[1];
            LlenaGridView(1);
        }

        private void cboLineas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdAsignaStock_Click(object sender, EventArgs e)
        {
            string ClaveArticulo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            string ClaveAlmacen = grdView[3, grdView.CurrentRow.Index].Value.ToString();
            string Descripcion = grdView[1, grdView.CurrentRow.Index].Value.ToString();
            string Ubicacion = grdView[12, grdView.CurrentRow.Index].Value.ToString(); ;
            string stockMin = grdView[7, grdView.CurrentRow.Index].Value.ToString();
            string stockMax = grdView[8, grdView.CurrentRow.Index].Value.ToString();

            AsignaPorAlmacen fas = new AsignaPorAlmacen(ClaveArticulo,ClaveAlmacen,Descripcion,Ubicacion,stockMin,stockMax,db);
            fas.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            fas.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            fas.ShowDialog();
            LlenaGridView(1);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            string Almacen = (cboAlmacen.SelectedValue == null) ? "" : cboAlmacen.SelectedValue.ToString();
            string Linea = (cboLineas.SelectedValue == null) ? "" : cboLineas.SelectedValue.ToString();
            string Articulo = txtClaveArticulo.Text;
            string Buscar = txtBuscar.Text;

            frmRepExistencia Rep = new frmRepExistencia(Articulo, Almacen, Linea, Buscar, db);
            Rep.Show();
            
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }

        private void frmExistencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
