namespace GAFE
{
    partial class frmExistencias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExistencias));
            this.grdView = new System.Windows.Forms.DataGridView();
            this.CodEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantApartada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUltimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLineas = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.txtDscArticulo = new System.Windows.Forms.TextBox();
            this.cmdArticulo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdAsignaStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodEmpleado,
            this.Nombre,
            this.Linea,
            this.ClaveAlmacen,
            this.Cantidad,
            this.CantApartada,
            this.Total,
            this.stockMin,
            this.stockMax,
            this.CostoPromedio,
            this.CostoUltimo,
            this.CostoActual,
            this.Ubicacion});
            this.grdView.Location = new System.Drawing.Point(11, 156);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(829, 265);
            this.grdView.TabIndex = 4;
            // 
            // CodEmpleado
            // 
            this.CodEmpleado.Frozen = true;
            this.CodEmpleado.HeaderText = "Código";
            this.CodEmpleado.Name = "CodEmpleado";
            this.CodEmpleado.ReadOnly = true;
            this.CodEmpleado.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 350;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Línea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // ClaveAlmacen
            // 
            this.ClaveAlmacen.HeaderText = "Almacén";
            this.ClaveAlmacen.Name = "ClaveAlmacen";
            this.ClaveAlmacen.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // CantApartada
            // 
            this.CantApartada.HeaderText = "Cant. Apartada";
            this.CantApartada.Name = "CantApartada";
            this.CantApartada.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Exitencia";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // stockMin
            // 
            this.stockMin.HeaderText = "Min";
            this.stockMin.Name = "stockMin";
            this.stockMin.ReadOnly = true;
            // 
            // stockMax
            // 
            this.stockMax.HeaderText = "Max";
            this.stockMax.Name = "stockMax";
            this.stockMax.ReadOnly = true;
            // 
            // CostoPromedio
            // 
            this.CostoPromedio.HeaderText = "Costo Prom";
            this.CostoPromedio.Name = "CostoPromedio";
            this.CostoPromedio.ReadOnly = true;
            // 
            // CostoUltimo
            // 
            this.CostoUltimo.HeaderText = "Costo. Ultimo";
            this.CostoUltimo.Name = "CostoUltimo";
            this.CostoUltimo.ReadOnly = true;
            // 
            // CostoActual
            // 
            this.CostoActual.HeaderText = "Costo Actual";
            this.CostoActual.Name = "CostoActual";
            this.CostoActual.ReadOnly = true;
            // 
            // Ubicacion
            // 
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboLineas);
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClaveArticulo);
            this.panel1.Controls.Add(this.txtDscArticulo);
            this.panel1.Controls.Add(this.cmdArticulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 149);
            this.panel1.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtBuscar.Location = new System.Drawing.Point(106, 115);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(421, 24);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Buscar";
            // 
            // cboLineas
            // 
            this.cboLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboLineas.FormattingEnabled = true;
            this.cboLineas.Location = new System.Drawing.Point(106, 83);
            this.cboLineas.Name = "cboLineas";
            this.cboLineas.Size = new System.Drawing.Size(417, 26);
            this.cboLineas.TabIndex = 5;
            this.cboLineas.SelectionChangeCommitted += new System.EventHandler(this.cboLineas_SelectionChangeCommitted);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(106, 51);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(417, 26);
            this.cboAlmacen.TabIndex = 4;
            this.cboAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboAlmacen_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 1004;
            this.label2.Text = "Almacén";
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveArticulo.Location = new System.Drawing.Point(106, 14);
            this.txtClaveArticulo.MaxLength = 20;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.ReadOnly = true;
            this.txtClaveArticulo.Size = new System.Drawing.Size(110, 24);
            this.txtClaveArticulo.TabIndex = 1003;
            this.txtClaveArticulo.TabStop = false;
            // 
            // txtDscArticulo
            // 
            this.txtDscArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDscArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDscArticulo.Location = new System.Drawing.Point(218, 14);
            this.txtDscArticulo.MaxLength = 20;
            this.txtDscArticulo.Name = "txtDscArticulo";
            this.txtDscArticulo.ReadOnly = true;
            this.txtDscArticulo.Size = new System.Drawing.Size(309, 24);
            this.txtDscArticulo.TabIndex = 1002;
            this.txtDscArticulo.TabStop = false;
            // 
            // cmdArticulo
            // 
            this.cmdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdArticulo.Image = ((System.Drawing.Image)(resources.GetObject("cmdArticulo.Image")));
            this.cmdArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArticulo.Location = new System.Drawing.Point(8, 9);
            this.cmdArticulo.Name = "cmdArticulo";
            this.cmdArticulo.Size = new System.Drawing.Size(94, 36);
            this.cmdArticulo.TabIndex = 3;
            this.cmdArticulo.Text = "Artículo...";
            this.cmdArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdArticulo.UseVisualStyleBackColor = false;
            this.cmdArticulo.Click += new System.EventHandler(this.cmdArticulo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(8, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Líneas";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdBuscar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscar.Image")));
            this.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscar.Location = new System.Drawing.Point(317, 427);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(94, 36);
            this.cmdBuscar.TabIndex = 2;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdImprimir.Image = global::GAFE.Properties.Resources.printer;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(15, 427);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(94, 36);
            this.cmdImprimir.TabIndex = 3;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = false;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // cmdAsignaStock
            // 
            this.cmdAsignaStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAsignaStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdAsignaStock.Image = global::GAFE.Properties.Resources.Seleccionar;
            this.cmdAsignaStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAsignaStock.Location = new System.Drawing.Point(131, 427);
            this.cmdAsignaStock.Name = "cmdAsignaStock";
            this.cmdAsignaStock.Size = new System.Drawing.Size(170, 36);
            this.cmdAsignaStock.TabIndex = 1;
            this.cmdAsignaStock.Text = "Asigna Stock por Almacén";
            this.cmdAsignaStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAsignaStock.UseVisualStyleBackColor = false;
            this.cmdAsignaStock.Click += new System.EventHandler(this.cmdAsignaStock_Click);
            // 
            // frmExistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 472);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.cmdAsignaStock);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExistencias";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existencia por Almacen";
            this.Load += new System.EventHandler(this.frmExistencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdAsignaStock;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.TextBox txtDscArticulo;
        private System.Windows.Forms.Button cmdArticulo;
        private System.Windows.Forms.ComboBox cboLineas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantApartada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUltimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
    }
}