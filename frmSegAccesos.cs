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
    public partial class frmSegAccesos : MetroForm
    {
        private MsSql db = null;
        private SqlDataAdapter dtA = null;
        DataSet Ds;

        //private SqlDataAdapter DatosTbl;

        List<clsFillCbo> LstPrv;
        private int Esnuevo;

        public frmSegAccesos(MsSql Odat)
        {
            InitializeComponent();
            db = Odat;
        }




        private void frmSegAccesos_Load(object sender, EventArgs e)
        {
            string Sqlstr = "Select CodPerfil,Descripcion from SPerfiles ";
            SqlDataReader dr = db.SelectDR(Sqlstr);

            LstPrv = new List<clsFillCbo>();
            while (dr.Read())
            {
                clsFillCbo Prv = new clsFillCbo();
                Prv.Id = Convert.ToString(dr["CodPerfil"]);
                Prv.Descripcion = Convert.ToString(dr["Descripcion"]);
                LstPrv.Add(Prv);
            }
            dr.Close();
            cboPerfiles.DataSource = LstPrv;
            cboPerfiles.ValueMember = "Id";
            cboPerfiles.DisplayMember = "Descripcion";
            btnActualizaSeg.Enabled = false;
        }


        private void btnAsignaSeg_Click(object sender, EventArgs e)
        {
            CargarRegistrosDB();
            PuiSegAccesos Ac = new PuiSegAccesos(db);
            Ac.keySAcceso = cboPerfiles.SelectedValue.ToString();
           
            if (Ac.EsAccesoNuevo() == 1)
            {
                CrearArbol("0", null);
                tSeg.ExpandAll();
                tSeg.Nodes[0].Checked = true;
                Esnuevo = 1;
            }
            else
            {
                Esnuevo = 0;
                CrearArbol("0", null);
                tSeg.ExpandAll();
                //Recorrer el arbol y marcar el check conlos Accesos del perfil
                this.tSeg.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tSeg_AfterCheck);
                  MarcaRecursivo2(tSeg.Nodes[0],true);
                this.tSeg.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tSeg_AfterCheck);
            }
          btnActualizaSeg.Enabled = true;
        }


        private void CargarRegistrosDB()
        {
            string sql = "exec GetArbolDeSeguridad";
            dtA = db.SelectDA(sql);
            Ds = new DataSet();
            dtA.Fill(Ds);

            DataTable tablaArbol = Ds.Tables.Add("TablaArbol");
            tablaArbol.Columns.Add("Modulo", typeof(string));
            tablaArbol.Columns.Add("Nombre", typeof(string));
            tablaArbol.Columns.Add("Tipo", typeof(string));
            tablaArbol.Columns.Add("idNodo", typeof(string));
            tablaArbol.Columns.Add("idPadre", typeof(string));

            for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                tablaArbol.Rows.Add(tmp);
            }
        }


        private void CrearArbol(string indicePadre, TreeNode nodePadre)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            DataView dataViewHijos = new DataView(Ds.Tables["TablaArbol"]);

            dataViewHijos.RowFilter = Ds.Tables["TablaArbol"].Columns["idPadre"].ColumnName + " = '" + indicePadre + "'";


            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["Nombre"].ToString().Trim();
                nuevoNodo.ForeColor = Color.Red;
                nuevoNodo.Name = dataRowCurrent["idNodo"].ToString().Trim();



                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    tSeg.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                CrearArbol(dataRowCurrent["idNodo"].ToString(), nuevoNodo);
            }

        }

        private void tSeg_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tSeg.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tSeg_AfterCheck);
            MarcaRecursivo(e.Node, e.Node.Checked);
            e.Node.ForeColor = (e.Node.Checked == true) ? Color.Green : Color.Red;

            this.tSeg.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tSeg_AfterCheck);
        }

        private void MarcaRecursivo(TreeNode n, bool chk)
        {

            n.Checked = chk;
            n.ForeColor = (n.Checked == true) ? Color.Green : Color.Red;

            foreach (TreeNode tn in n.Nodes)
            {
                MarcaRecursivo(tn, chk);
            }
        }


        private void MarcaRecursivo2(TreeNode n, bool chk)
        {
            //Preguntar el valor de acceso
            PuiSegAccesos ac = new PuiSegAccesos(db);
            ac.keySAcceso = cboPerfiles.SelectedValue.ToString();
            ac.cmpIdNodo = n.Name;
            ac.cmpIdPadre = (n.Parent == null) ? "0" : n.Parent.Name;
            int Vacceso = ac.ValorDeAcceso();

            //MessageBoxAdv.Show("Nodo " + ac.cmpIdNodo + " padre " + ac.cmpIdPadre + " Acceso " + Vacceso.ToString());

            chk = (Vacceso == 1) ? true : false;


            n.Checked = chk;
            n.ForeColor = (n.Checked == true) ? Color.Green : Color.Red;

            foreach (TreeNode tn in n.Nodes)
            {
                MarcaRecursivo2(tn, chk);
            }
        }



        private void btnActualizaSeg_Click(object sender, EventArgs e)
        {
          //  if (Esnuevo == 1)
         //   {
                TreeNodeCollection nodes = tSeg.Nodes;
                foreach (TreeNode n in nodes)
                {
                    RecorrerRecursivo(n);
                }
                MessageBoxAdv.Show("Accesos Asignados al Perfil " + cboPerfiles.SelectedValue.ToString(),"Cinfirmacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                tSeg.Nodes.Clear();
                btnActualizaSeg.Enabled = false;

           // }

        }

        private void RecorrerRecursivo(TreeNode treeNode)
        {
            // Print the node.             
            /*MessageBoxAdv.Show(treeNode.Text+" Nombre = "+treeNode.Name +
                    " Padre = "+ ((treeNode.Parent == null)?"Raiz": treeNode.Parent.Name) );*/
            PuiSegAccesos ac = new PuiSegAccesos(db);
            ac.keySAcceso = cboPerfiles.SelectedValue.ToString();
            ac.cmpIdNodo = treeNode.Name;
            ac.cmpIdPadre = (treeNode.Parent == null) ? "0" : treeNode.Parent.Name;
            ac.cmpAcceso = (treeNode.Checked == true) ? 1 : 0;

            if (Esnuevo == 1)
                ac.AgregarAcceso();
            else
            {
                if (ac.ElRegistroEsNuevo() == 1)
                    ac.AgregarAcceso();
                else
                    ac.ActualizaAcceso();                  
            }

            // Print each node recursively.  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                RecorrerRecursivo(tn);
            }
        }

        private void cboPerfiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tSeg.Nodes.Clear();
            btnActualizaSeg.Enabled = false;
        }
    }
}
