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
using System.Globalization;

namespace GAFE
{
    public partial class DocLstRequisiciones : MetroForm
    {
        clsCfgDocumento ConfigDoc;
        DatCfgUsuario user;
        DatCfgParamSystem ParamSystem;
        DatCfgSystem CfgSystem;
        ClsUtilerias Util;
        DataTable dt = null;
        DataRow row = null;
        MsSql db;
        private SqlDataAdapter DatosTbl;
        
        public clsStiloTemas StiloColor;
        private String CveDoc;
        private String NameDoc;
        private clsUtil uT;
        private int AcCOPEdit, AcCOPMigra;



        public DocLstRequisiciones(MsSql Odat, DatCfgSystem CfgSys,  DatCfgParamSystem ParaSystem, 
            DatCfgUsuario DatUsr,  clsStiloTemas NewColor, String CveDc, String _NameDoc)
        {
            
            InitializeComponent();
            //LocalizationProvider.Provider = new localizer();
            db = Odat;
            user = DatUsr;
            ParamSystem = ParaSystem;
            CfgSystem = CfgSys;
            StiloColor = NewColor;
            CveDoc = CveDc;
            clsCfgDocumento cd = new clsCfgDocumento(CveDoc, db);
            ConfigDoc = cd.ConfigDoc();
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
            NameDoc = _NameDoc;

            this.Text = "LISTADO DE " + NameDoc;
            Util = new ClsUtilerias(ParamSystem.NumDec);


        }

        private void DocLstRequisiciones_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();
            String st = "";
            switch (NameDoc)
            {
                case "REQUISICIÓN": st = "R"; break;
                case "COTIZACIÓN": st = "C"; break;
                case "ORDEN DE COMPRA": st = "O"; break;
                case "COMPRAS": st = "CO"; break;
                case "ORDEN DE SALIDA": st = "OS"; break;
                case "ORDEN DE ENTRADA": st = "OE"; break;
            }

            clsUsPerfil up = uT.BuscarIdNodo("1Prov" + st + "AG");
            int AcCOP = ConfigDoc.DeshabilitaBotones == 1 ? 0 : ((up != null) ? up.Acceso : 0);
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "ED");
            AcCOPEdit = ConfigDoc.DeshabilitaBotones == 1 ? 0 : ((up != null) ? up.Acceso : 0);
            cmEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "EL");
            AcCOP = ConfigDoc.DeshabilitaBotones == 1 ? 0 : ((up != null) ? up.Acceso : 0);
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "CO");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "MI");
            AcCOPMigra = (up != null) ? up.Acceso : 0;
            btnGenerarDoc.Enabled = (AcCOPMigra == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "IM");
            AcCOP = (up != null) ? up.Acceso : 0;
            btnImprimir.Enabled = (AcCOP == 1) ? true : false;
            
            cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;
            cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;

            LlecboAlmaOri(user.AlmacenUsa);

            if (ConfigDoc.UsaAlmDestino == 1)
            {
                lblSucursal.Visible = true;
                cboSucursal.Visible = true;
                LlecboSucursales(user.SucursalUsa);
            }

            if (ConfigDoc.DeshabilitaBotones == 1)
            {
                cboAlmacen.Enabled = false;
                LlecboAlmaOri("999");
                cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;

            }


            /*
            if (ConfigDoc.UsaAlmTmp == 1)
            {
                cboAlmacen.Enabled = false;
                LlecboAlmaOri("999");
                cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;

            }
            */

            /*
            
            up = uT.BuscarIdNodo("1Prov" + st + "BU");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;
            */

            LlenaGridView();

            cmdAutorizarTodo.Visible = ConfigDoc.SolicitaAutorizar == 1 ? true : false;

            if (ConfigDoc.AfectaInventario == 1)
            {
                if (ParamSystem.AfectaExistAuto == 0)
                    btnGenerarDoc.Visible = true;
            }
            else
            {
                btnGenerarDoc.Visible = true;
            }
            btnGenerarDoc.Text = ConfigDoc.txtBotonDocRel;
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(5000, user.FecServer, user.Usuario);
            //llamar la forma de regdoc
            if (movimiento.CompareTo("Error") != 0)
            {
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, CfgSystem, ParamSystem, user, StiloColor, 1, ConfigDoc, movimiento, CveDoc, NameDoc);
                Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Rcap.ShowDialog();
                LlenaGridView();

            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro", "ERROR " + NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyDocumento = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
                if (rq.keyDocumento.Length == 0)
                {
                    MessageBoxAdv.Show("Documento en uso por otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, CfgSystem,ParamSystem, user, StiloColor, 2, ConfigDoc, rq.keyDocumento, CveDoc, NameDoc);
                        Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                        Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                        Rcap.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBoxAdv.Show("Error:" + ex.Message, "Alerta", MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation);
                    }
                    LlenaGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            int iii = 0;
            
            try
            {
                /*
                                     0.- M.idMov
                     1.- M.Documento
                     2.- M.Serie
                     3.- M.NumDoc
                     4.- M.ClaveAlmacen
                     5.- Alm.Descripcion 'Almacén'
                     6.- M.FechaExpedicion as 'Fec Exp'
                     7.- M.Impuesto
                     8.- M.Descuento
                     9.- M.SubTotal
                     10.- M.Total
                     11.- M.CveProveedor
                     12.- M.EsperaAceptacion
                     13.- M.DocOrigen
                     14.- M.CveSucursal
                     15.- S.Nombre as Sucursal
                     16.- Proveedor
                     17.- M.NoFactura

                */
                String idMov = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
                String Doc = grdViewReq[1, grdViewReq.CurrentRow.Index].Value.ToString();//Documento
                if (MessageBoxAdv.Show("Está seguro de eliminar el documento: " + Doc,
                     "Confirme operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    db.IniciaTrans();
                    iii = 1;
                    int EspAcept = Convert.ToInt32(grdViewReq[12, grdViewReq.CurrentRow.Index].Value.ToString());

                    int Rsp = 0;
                    DialogResult rspw = DialogResult.Yes;
                    if (ConfigDoc.AfectaInventario == 1)
                    {
                        DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                        rq.cmpDocOrigen = idMov;
                        rq.GetDoc_PorDocOrigen();

                        if (!string.IsNullOrEmpty(rq.keyidMov))
                        {
                            rspw = MessageBoxAdv.Show("Tiene un documento relacionado. Documento:  " + rq.keyDocumento + ((rq.cmpEsperaAceptacion == 1) ? ", por confirmar" : ", confirmado"),
                         "Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rspw == DialogResult.Yes)
                            {
                                Rsp = RecursividadEliminar(rq.keyidMov, rq.cmpEsperaAceptacion, 0);
                            }
                        }
                    }

                    if(rspw == DialogResult.Yes)
                    {
                        if (Rsp >= 0)
                            Rsp = RecursividadEliminar(idMov, EspAcept, 1);
                    }
                    else
                        db.CancelaTrans();


                }
                LlenaGridView();
            }
            catch (Exception ex)
            {
                if (iii == 1)//Si el error viene con Transacción
                    db.CancelaTrans();

                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }

        }

        private int RecursividadEliminar(String _idM, int EspAcept, int OpeFin)
        {
            int Rsp = 0;
            DocPuiRequisiciones RqMast = new DocPuiRequisiciones(db);
            RqMast.keyidMov = _idM;
            RqMast.cmpUsuarioModi = user.Usuario;
            if (EspAcept == 0)
            {
                if (ConfigDoc.AfectaInventario == 1)
                {
                    MovtosInvLst Ventana = new MovtosInvLst(db, ParamSystem, user, StiloColor);
                    Rsp = Ventana.DelMigraMov(_idM);
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
                }
            }
            if (Rsp >= 0)
            {
                if (RqMast.DelCeroDocumento() >= 1)
                {
                    if (OpeFin == 1)//Cuando ya se elimina la Orden de salida
                    {
                        db.TerminaTrans();
                        MessageBoxAdv.Show("Registro eliminado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Rsp = -4;
                    MessageBoxAdv.Show("Existe un error al eliminar", "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.CancelaTrans();
                }
            }


            return Rsp;
        }


        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyDocumento = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
                if (rq.keyDocumento.Length == 0)
                {
                    MessageBoxAdv.Show("Documento en uso por otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, CfgSystem, ParamSystem, user, StiloColor, 3, ConfigDoc, rq.keyDocumento, CveDoc, NameDoc);
                    Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                    Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                    Rcap.ShowDialog();
                    LlenaGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void LlenaGridView()
        {
            String AlmOri = Convert.ToString(cboAlmacen.SelectedValue);
            String FIni = dtFechaInicio.Value.ToString("yyyy/MM/dd");
            String FFin = dtFechaFin.Value.ToString("yyyy/MM/dd");
            String CvS = ConfigDoc.UsaAlmDestino == 0 ? "" : Convert.ToString(cboSucursal.SelectedValue);


            DocPuiRequisiciones pui = new DocPuiRequisiciones(db);
            DatosTbl = pui.ListarDocumentos(AlmOri, FIni, FFin, CveDoc, CvS);
            DataSet Ds = new DataSet();

            try
            {
                /*
                     0.- M.idMov
                     1.- M.Documento
                     2.- M.Serie
                     3.- M.NumDoc
                     4.- M.ClaveAlmacen
                     5.- Alm.Descripcion 'Almacén'
                     6.- M.FechaExpedicion as 'Fec Exp'
                     7.- M.Impuesto
                     8.- M.Descuento
                     9.- M.SubTotal
                     10.- M.Total
                     11.- M.CveProveedor
                     12.- M.EsperaAceptacion
                     13.- M.DocOrigen
                     14.- M.CveSucursal
                     15.- S.Nombre as Sucursal
                     16.- Proveedor
                     17.- M.NoFactura
                     */

                DatosTbl.Fill(Ds);
                grdViewReq.Columns.Clear();
                grdViewReq.DataSource = Ds.Tables[0];

                grdViewReq.Columns["IdMov"].Visible = false;
                grdViewReq.Columns["ClaveAlmacen"].Visible = false;
                grdViewReq.Columns["CveProveedor"].Visible = false;
                grdViewReq.Columns["EsperaAceptacion"].Visible = false;
                grdViewReq.Columns["DocOrigen"].Visible = false;
                grdViewReq.Columns["CveSucursal"].Visible = false;


                grdViewReq.Columns["Total"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewReq.Columns["Descuento"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewReq.Columns["SubTotal"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewReq.Columns["Impuesto"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
                grdViewReq.Columns["Impuesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewReq.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewReq.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdViewReq.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                if(ConfigDoc.UsaFactura!=1)
                    grdViewReq.Columns["NoFactura"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlecboAlmaOri(String CveUser)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            dt = lin.CboCatAlmacenes( (ConfigDoc.DeshabilitaBotones == 1)?0:1 );
            row = dt.NewRow();
            row["ClaveAlmacen"] = "0";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboAlmacen.DataSource = dt;

            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";

            cboAlmacen.SelectedValue = CveUser;
        }

        private void LlecboSucursales(String CveSc = "")
        {
            PuiCatSucursales lin = new PuiCatSucursales(db);
            dt = lin.LLenaCboSucursales();
            row = dt.NewRow();
            row["Clave"] = "0";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboSucursal.DataSource = dt;

            cboSucursal.ValueMember = "Clave";
            cboSucursal.DisplayMember = "Descripcion";

            cboSucursal.SelectedValue = CveSc == null ? "0" : CveSc;
        }



        private void DocLstRequisiciones_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cmdRestablecer_Click(object sender, EventArgs e)
        {
            dtFechaFin.Value = dtFechaFin.MaxDate;

            dtFechaInicio.Value = DateTime.Now;
            cboAlmacen.SelectedValue = user.AlmacenUsa;
            dtFechaFin.Value = DateTime.Now;
        }

        private void cboAlmaOri_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmacen.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
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

        private void cmdAutorizarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarDoc_Click(object sender, EventArgs e)
        {
            String StrNM = "";
            try
            {
                if (ConfigDoc.AfectaInventario == 1)
                {
                    string IdDocOrg = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
                    string strprov = grdViewReq[11, grdViewReq.CurrentRow.Index].Value.ToString();
                    MovtosInvRegistro Ventana = new MovtosInvRegistro(db, ParamSystem, StiloColor, "MINV", user);
                    String cboalm = Convert.ToString(cboAlmacen.SelectedValue);
                    if (!cboalm.Equals(""))
                    {
                        if (!cboalm.Equals("0"))
                        {
                            if (ConfigDoc.UsaAlmTmp == 1)
                            {
                                StrNM = funcParaMigrarDoc(1);
                            }

                            if (!StrNM.Equals("Error"))
                            {

                                String CvSuc = (ConfigDoc.UsaAlmDestino == 1) ? grdViewReq[14, grdViewReq.CurrentRow.Index].Value.ToString() : "";
                                String AlmDst = (ConfigDoc.UsaAlmTmp == 1) ? "999" : (ConfigDoc.DeshabilitaBotones==1 ? CvSuc :"");

                                int rsp = Ventana.MigrarDocDetToMovDet(ConfigDoc.CveTipoMov, strprov, IdDocOrg, cboalm, AlmDst, CvSuc);
                                if (rsp != 0)
                                {
                                    string msj = "";
                                    switch (rsp)
                                    {
                                        case 1: msj = "Al guardar cabecero"; break;
                                        case 2: msj = "Al guardar detalle partidas"; break;
                                        case 3: msj = "Al afectar existencias"; break;
                                        case 13: msj = "Al afectar costos"; break;
                                        case 4: msj = "Traspaso: Registro en blanco"; break;
                                        case 5: msj = "Traspaso: Al guardar cabecero"; break;
                                        case 6: msj = "Traspaso: Al guardar detalle partidas"; break;
                                        case 7: msj = "Traspaso: Al afectar existencias"; break;
                                        case 17: msj = "Traspaso: Al afectar costos"; break;
                                        case 8: msj = "Traspaso: Al actualizar detalle partidas"; break;
                                        case 9: msj = "El registro ya ha sido migrado"; break;
                                        default: msj = "Error desconocido"; break;
                                    }
                                    if (ConfigDoc.DeshabilitaBotones == 1)
                                    {
                                        DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                                        rq.keyidMov = StrNM;
                                        rq.EliminaDocumento();
                                    }
                                    MessageBoxAdv.Show(msj, "Error al guardar el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBoxAdv.Show("No se puede aplicar para el almacén TODOS", "Error al migrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBoxAdv.Show("Debe seleccionar almacén correcto", "Error al migrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    funcParaMigrarDoc();

                LlenaGridView();
            }
            catch (Exception ex)
            {
                if (ConfigDoc.DeshabilitaBotones == 1)
                {
                    DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                    rq.keyidMov = StrNM;
                    rq.EliminaDocumento();
                }
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private String funcParaMigrarDoc(int SperAcep = 0)
        {
            clsCfgDocumento Ccd = new clsCfgDocumento(ConfigDoc.DocRel, db);
            clsCfgDocumento CfgDocTrans = Ccd.ConfigDoc();
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(5000, user.FecServer, user.Usuario);
            rq.keyidMov = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
            if (movimiento.CompareTo("Error") != 0)
            {
                rq.keyidMovNew = movimiento;
                rq.cmpCveDoc = ConfigDoc.DocRel;
                rq.cmpDocOrigen = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();


                if (ConfigDoc.UsaAlmTmp == 1)
                    rq.cmpClaveAlmacen = "999";
                else
                    rq.cmpClaveAlmacen = Convert.ToString(cboAlmacen.SelectedValue);

                if (ConfigDoc.UsaAlmDestino == 1)
                    rq.cmpCveSucursal = grdViewReq[14, grdViewReq.CurrentRow.Index].Value.ToString();



                int _fol = int.Parse(CfgDocTrans.Foliador); //5000; // 
                string _alm = "";// "5000";
                string _ser = "";
                rq.cmpSerie = _ser;
                if (CfgDocTrans.UsaSerie == 1)
                {
                    //MOSTRAR EL LISTADO DE SERIE
                    _alm = Convert.ToString(cboAlmacen.SelectedValue);
                    _ser = "SERIE";//Poner serie seleccionada
                    clsCfgDocSeries cds = new clsCfgDocSeries(_alm, ConfigDoc.DocRel, _ser, db);
                    clsCfgDocSeries CfgDocSerie = cds.ConfigDocSerie();

                    _fol = int.Parse(CfgDocSerie.CodFoliador);

                    rq.cmpSerie = _ser;
                }

                if (rq.GuardarDocTransf(_fol, _alm, CfgDocTrans.CveDoc, _ser, SperAcep) == 1)
                {
                    if (SperAcep == 0)
                        MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rq.keyidMov = movimiento;
                    rq.EliminaDocumento();
                    MessageBoxAdv.Show("Existe un error insertar registro", "ERROR " + NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    movimiento = "Error";
                }
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro en blanco", "ERROR " + NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return movimiento;
        }

        private void MnuDel_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            /*
            switch (e.ClickedItem.Name.ToString())
            {
                case "EsperaAceptacion":
                    MessageBoxAdv.Show(e.ClickedItem.Name.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            */
        }

        private void grdView_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void grdViewReq_MouseClick(object sender, MouseEventArgs e)
        {
            /*
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip MnuDer = new ContextMenuStrip();
                    int position_xy_mouse_row = grdView.HitTest(e.X, e.Y).RowIndex;

                    //MessageBox.Show(position_xy_mouse_row.ToString());

                    if (position_xy_mouse_row >= 0)
                    {
                        MnuDer.Items.Add("Espera aceptación").Name = "EsperaAceptacion";
                    }

                    MnuDer.Show(grdView, new Point(e.X, e.Y));

                    MnuDer.ItemClicked += new ToolStripItemClickedEventHandler(MnuDel_Click);
                }
                */
        }

        private void grdViewReq_SelectionChanged(object sender, EventArgs e)
        {
            if (grdViewReq.SelectedCells.Count > 0)
            {
                int EspAcept = Convert.ToInt32(grdViewReq[12, grdViewReq.CurrentRow.Index].Value.ToString());
                Boolean rspAcep = EspAcept == 1 ? true : false;

                if (AcCOPMigra == 1)
                        btnGenerarDoc.Enabled = rspAcep;
                
                if (AcCOPEdit == 1)
                    cmEditar.Enabled = rspAcep;



            }
            //Do_Something_With_It(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboSucursal.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                String cv = grdViewReq[0, grdViewReq.CurrentRow.Index].Value.ToString();
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyidMov = cv;
                DataTable dt = rq.DocCabPrint();
                fmtoDocumentos print = new fmtoDocumentos();
                //this.Cursor = Cursors.AppStarting;
                String pict = Convert.ToString(GAFE.Properties.Resources.Editar);


                print.DoctosCab(db, dt, cv, "Farmacias Salinas G", pict, NameDoc);
                //this.Cursor = Cursors.Default;
                print.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }

        }

        private void grdViewReq_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            FormatRow(grdViewReq.Rows[e.RowIndex]);
        }

        private void FormatRow(DataGridViewRow myrow)
        {
            try
            {
                if (Convert.ToInt32(myrow.Cells["EsperaAceptacion"].Value) == 0)
                    myrow.DefaultCellStyle.BackColor = Color.FromArgb(147, 201, 255); //ColorTranslator.FromHtml(StiloColor.HoverEncabezado);
                else
                    myrow.DefaultCellStyle.BackColor = Color.White; //ColorTranslator.FromHtml(StiloColor.HoverEncabezado);
            }
            catch (Exception exception)
            {
                MessageBoxAdv.Show(exception.Message, "RowPrePaint", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
