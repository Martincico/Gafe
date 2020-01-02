namespace GAFE
{
    partial class frmCatAlmacenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatAlmacenes));
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.chkNumRojo = new System.Windows.Forms.CheckBox();
            this.chkEsDeConsigna = new System.Windows.Forms.CheckBox();
            this.chkEsDeVenta = new System.Windows.Forms.CheckBox();
            this.chkEsDeCompra = new System.Windows.Forms.CheckBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.CodEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAlmacen = new System.Windows.Forms.TabControl();
            this.tbDatGen = new System.Windows.Forms.TabPage();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLstPrecio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveAlmacen = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.tbConfg = new System.Windows.Forms.TabPage();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabAlmacen.SuspendLayout();
            this.tbDatGen.SuspendLayout();
            this.tbConfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdConsultar.Image = global::GAFE.Properties.Resources.Consultar;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.Location = new System.Drawing.Point(403, 223);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 36);
            this.cmdConsultar.TabIndex = 3;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // chkNumRojo
            // 
            this.chkNumRojo.AutoSize = true;
            this.chkNumRojo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkNumRojo.Location = new System.Drawing.Point(13, 16);
            this.chkNumRojo.Name = "chkNumRojo";
            this.chkNumRojo.Size = new System.Drawing.Size(175, 22);
            this.chkNumRojo.TabIndex = 13;
            this.chkNumRojo.Text = "Trabaja con Negativos";
            this.chkNumRojo.UseVisualStyleBackColor = true;
            // 
            // chkEsDeConsigna
            // 
            this.chkEsDeConsigna.AutoSize = true;
            this.chkEsDeConsigna.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEsDeConsigna.Location = new System.Drawing.Point(13, 49);
            this.chkEsDeConsigna.Name = "chkEsDeConsigna";
            this.chkEsDeConsigna.Size = new System.Drawing.Size(118, 22);
            this.chkEsDeConsigna.TabIndex = 12;
            this.chkEsDeConsigna.Text = "Consignación";
            this.chkEsDeConsigna.UseVisualStyleBackColor = true;
            // 
            // chkEsDeVenta
            // 
            this.chkEsDeVenta.AutoSize = true;
            this.chkEsDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEsDeVenta.Location = new System.Drawing.Point(309, 49);
            this.chkEsDeVenta.Name = "chkEsDeVenta";
            this.chkEsDeVenta.Size = new System.Drawing.Size(68, 22);
            this.chkEsDeVenta.TabIndex = 11;
            this.chkEsDeVenta.Text = "Vende";
            this.chkEsDeVenta.UseVisualStyleBackColor = true;
            // 
            // chkEsDeCompra
            // 
            this.chkEsDeCompra.AutoSize = true;
            this.chkEsDeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEsDeCompra.Location = new System.Drawing.Point(309, 16);
            this.chkEsDeCompra.Name = "chkEsDeCompra";
            this.chkEsDeCompra.Size = new System.Drawing.Size(81, 22);
            this.chkEsDeCompra.TabIndex = 10;
            this.chkEsDeCompra.Text = "Compra";
            this.chkEsDeCompra.UseVisualStyleBackColor = true;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(399, 442);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 15;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(293, 442);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 14;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminar.Image = global::GAFE.Properties.Resources.Eliminar;
            this.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminar.Location = new System.Drawing.Point(303, 223);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminar.TabIndex = 6;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminar.UseVisualStyleBackColor = false;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEditar.Image = global::GAFE.Properties.Resources.Editar;
            this.cmdEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditar.Location = new System.Drawing.Point(203, 223);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(94, 36);
            this.cmdEditar.TabIndex = 5;
            this.cmdEditar.Text = "Editar";
            this.cmdEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditar.UseVisualStyleBackColor = false;
            this.cmdEditar.Click += new System.EventHandler(this.cmEditar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregar.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(103, 223);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregar.TabIndex = 4;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.UseVisualStyleBackColor = false;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodEmpleado,
            this.Nombre});
            this.grdView.Location = new System.Drawing.Point(12, 62);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(474, 154);
            this.grdView.TabIndex = 8;
            this.grdView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdView_RowHeaderMouseDoubleClick);
            this.grdView.DoubleClick += new System.EventHandler(this.grdView_DoubleClick);
            // 
            // CodEmpleado
            // 
            this.CodEmpleado.HeaderText = "Código";
            this.CodEmpleado.Name = "CodEmpleado";
            this.CodEmpleado.ReadOnly = true;
            this.CodEmpleado.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 350;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 55);
            this.panel1.TabIndex = 7;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdBuscar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscar.Image")));
            this.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscar.Location = new System.Drawing.Point(390, 7);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(94, 36);
            this.cmdBuscar.TabIndex = 2;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtBuscar.Location = new System.Drawing.Point(59, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(325, 24);
            this.txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // tabAlmacen
            // 
            this.tabAlmacen.Controls.Add(this.tbDatGen);
            this.tabAlmacen.Controls.Add(this.tbConfg);
            this.tabAlmacen.Location = new System.Drawing.Point(-2, 265);
            this.tabAlmacen.Name = "tabAlmacen";
            this.tabAlmacen.SelectedIndex = 0;
            this.tabAlmacen.Size = new System.Drawing.Size(499, 175);
            this.tabAlmacen.TabIndex = 13;
            // 
            // tbDatGen
            // 
            this.tbDatGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbDatGen.Controls.Add(this.cboSucursal);
            this.tbDatGen.Controls.Add(this.label4);
            this.tbDatGen.Controls.Add(this.cboLstPrecio);
            this.tbDatGen.Controls.Add(this.label3);
            this.tbDatGen.Controls.Add(this.txtDescripcion);
            this.tbDatGen.Controls.Add(this.label2);
            this.tbDatGen.Controls.Add(this.txtClaveAlmacen);
            this.tbDatGen.Controls.Add(this.lblCodEmpleado);
            this.tbDatGen.Location = new System.Drawing.Point(4, 22);
            this.tbDatGen.Name = "tbDatGen";
            this.tbDatGen.Padding = new System.Windows.Forms.Padding(3);
            this.tbDatGen.Size = new System.Drawing.Size(491, 149);
            this.tbDatGen.TabIndex = 0;
            this.tbDatGen.Text = "Datos generales";
            // 
            // cboSucursal
            // 
            this.cboSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(95, 108);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(246, 26);
            this.cboSucursal.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(7, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Sucursal";
            // 
            // cboLstPrecio
            // 
            this.cboLstPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboLstPrecio.FormattingEnabled = true;
            this.cboLstPrecio.Location = new System.Drawing.Point(95, 76);
            this.cboLstPrecio.Name = "cboLstPrecio";
            this.cboLstPrecio.Size = new System.Drawing.Size(246, 26);
            this.cboLstPrecio.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Lista Precio";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(95, 46);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(392, 24);
            this.txtDescripcion.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descripción";
            // 
            // txtClaveAlmacen
            // 
            this.txtClaveAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveAlmacen.Location = new System.Drawing.Point(95, 13);
            this.txtClaveAlmacen.MaxLength = 10;
            this.txtClaveAlmacen.Name = "txtClaveAlmacen";
            this.txtClaveAlmacen.Size = new System.Drawing.Size(147, 24);
            this.txtClaveAlmacen.TabIndex = 24;
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodEmpleado.Location = new System.Drawing.Point(5, 17);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(56, 18);
            this.lblCodEmpleado.TabIndex = 22;
            this.lblCodEmpleado.Text = "Código";
            // 
            // tbConfg
            // 
            this.tbConfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbConfg.Controls.Add(this.chkEstatus);
            this.tbConfg.Controls.Add(this.chkEsDeCompra);
            this.tbConfg.Controls.Add(this.chkNumRojo);
            this.tbConfg.Controls.Add(this.chkEsDeConsigna);
            this.tbConfg.Controls.Add(this.chkEsDeVenta);
            this.tbConfg.Location = new System.Drawing.Point(4, 22);
            this.tbConfg.Name = "tbConfg";
            this.tbConfg.Padding = new System.Windows.Forms.Padding(3);
            this.tbConfg.Size = new System.Drawing.Size(491, 149);
            this.tbConfg.TabIndex = 1;
            this.tbConfg.Text = "Configuración";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEstatus.Location = new System.Drawing.Point(13, 86);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(67, 22);
            this.chkEstatus.TabIndex = 14;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // frmCatAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 484);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.tabAlmacen);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 520);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 297);
            this.Name = "frmCatAlmacenes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Catálogo de almacenes";
            this.Load += new System.EventHandler(this.frmCatAlmacenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabAlmacen.ResumeLayout(false);
            this.tbDatGen.ResumeLayout(false);
            this.tbDatGen.PerformLayout();
            this.tbConfg.ResumeLayout(false);
            this.tbConfg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNumRojo;
        private System.Windows.Forms.CheckBox chkEsDeConsigna;
        private System.Windows.Forms.CheckBox chkEsDeVenta;
        private System.Windows.Forms.CheckBox chkEsDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.TabControl tabAlmacen;
        private System.Windows.Forms.TabPage tbDatGen;
        private System.Windows.Forms.ComboBox cboLstPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveAlmacen;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.TabPage tbConfg;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEstatus;
    }
}