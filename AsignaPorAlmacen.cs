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
    public partial class AsignaPorAlmacen : MetroForm
    {
        private MsSql db = null;

        public AsignaPorAlmacen()
        {
            InitializeComponent();
        }

        public AsignaPorAlmacen(string claveArticulo,string Almacen, string descripcion, string ubicacion, string stockMin,
                                string stockMax,MsSql odb)
        {
            InitializeComponent();
            txtClaveArticulo.Text = claveArticulo;
            txtDescripcion.Text = descripcion;
            txtClaveAlmacen.Text = Almacen;
            txtUbicacion.Text = ubicacion;
            txtStockMin.Text = stockMin;
            txtStockMax.Text = stockMax;
            db = odb;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            PuiExistencias Apa = new PuiExistencias(db);
            Apa.keyClaveAlmacen = txtClaveAlmacen.Text;
            Apa.keyClaveArticulo = txtClaveArticulo.Text;
            Apa.cmpUbicacion = txtUbicacion.Text;
            Apa.cmpstockMin = Convert.ToDouble(txtStockMin.Text);
            Apa.cmpstockMax = Convert.ToDouble(txtStockMax.Text);
            if (Apa.AsignaPorAlmacen() >= 1)
                this.Close();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
