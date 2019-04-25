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
    public partial class AddPartidaInvMovtos : Form
    {
        private int opcion;
        private MsSql db = null;


        public AddPartidaInvMovtos()
        {
            InitializeComponent();
        }

        public AddPartidaInvMovtos(MsSql Odat, int Op, String Cod="")
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            
            LimpiarControles();
            OpcionControles(true);
            
            switch (opcion)
            {
                case 1://Nuevo
                    OpcionControles(true);
                break;
                case 2://Edita
                    get_Campos(Cod);
            
                break;
                case 3://Consulta
                    get_Campos(Cod);
                    OpcionControles(false);
            
                break;

            }
            
        }

        private void get_Campos(String Cod)
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            pui.keyCveTipoMov = Cod;
            pui.EditarTipoMov();


        }


        private void AddPartidaInvMovtos_KeyDown(object sender, KeyEventArgs e)
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
                    MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
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
                        MessageBox.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        public int set_Campos()
        {


            return 1;
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            


            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
           

        }

        private void LimpiarControles()
        {

        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void cboCveClsMov_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /*Recorre un cbo y retorna el index
         * 
        private static int GetCboSelectIndex(ComboBox combobx, string value)
        {
            for (int i = 0; i <= combobx.Items.Count - 1; i++)
            {
                DataRowView cb = (DataRowView)combobx.Items[i];
                MessageBox.Show("Registro " + cb.Row.ItemArray[0].ToString(), "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                if (cb.Row.ItemArray[0].ToString() == value)
                    return i;
            }
            return -1;
        }
        */
    }
}
