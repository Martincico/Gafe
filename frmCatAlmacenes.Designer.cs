﻿namespace GAFE
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
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNumRojo = new System.Windows.Forms.CheckBox();
            this.chkEsDeConsigna = new System.Windows.Forms.CheckBox();
            this.chkEsDeVenta = new System.Windows.Forms.CheckBox();
            this.chkEsDeCompra = new System.Windows.Forms.CheckBox();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveAlmacen = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmEditar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.CodEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsultar.Location = new System.Drawing.Point(12, 221);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 36);
            this.cmdConsultar.TabIndex = 3;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkNumRojo);
            this.panel2.Controls.Add(this.chkEsDeConsigna);
            this.panel2.Controls.Add(this.chkEsDeVenta);
            this.panel2.Controls.Add(this.chkEsDeCompra);
            this.panel2.Controls.Add(this.cboEstatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.cmdAceptar);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtClaveAlmacen);
            this.panel2.Controls.Add(this.lblCodEmpleado);
            this.panel2.Location = new System.Drawing.Point(2, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 249);
            this.panel2.TabIndex = 12;
            // 
            // chkNumRojo
            // 
            this.chkNumRojo.AutoSize = true;
            this.chkNumRojo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNumRojo.Location = new System.Drawing.Point(95, 192);
            this.chkNumRojo.Name = "chkNumRojo";
            this.chkNumRojo.Size = new System.Drawing.Size(175, 22);
            this.chkNumRojo.TabIndex = 13;
            this.chkNumRojo.Text = "Trabaja con Negativos";
            this.chkNumRojo.UseVisualStyleBackColor = true;
            // 
            // chkEsDeConsigna
            // 
            this.chkEsDeConsigna.AutoSize = true;
            this.chkEsDeConsigna.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsDeConsigna.Location = new System.Drawing.Point(95, 164);
            this.chkEsDeConsigna.Name = "chkEsDeConsigna";
            this.chkEsDeConsigna.Size = new System.Drawing.Size(118, 22);
            this.chkEsDeConsigna.TabIndex = 12;
            this.chkEsDeConsigna.Text = "Consignacion";
            this.chkEsDeConsigna.UseVisualStyleBackColor = true;
            // 
            // chkEsDeVenta
            // 
            this.chkEsDeVenta.AutoSize = true;
            this.chkEsDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsDeVenta.Location = new System.Drawing.Point(95, 136);
            this.chkEsDeVenta.Name = "chkEsDeVenta";
            this.chkEsDeVenta.Size = new System.Drawing.Size(68, 22);
            this.chkEsDeVenta.TabIndex = 11;
            this.chkEsDeVenta.Text = "Vende";
            this.chkEsDeVenta.UseVisualStyleBackColor = true;
            // 
            // chkEsDeCompra
            // 
            this.chkEsDeCompra.AutoSize = true;
            this.chkEsDeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsDeCompra.Location = new System.Drawing.Point(95, 108);
            this.chkEsDeCompra.Name = "chkEsDeCompra";
            this.chkEsDeCompra.Size = new System.Drawing.Size(81, 22);
            this.chkEsDeCompra.TabIndex = 10;
            this.chkEsDeCompra.Text = "Compra";
            this.chkEsDeCompra.UseVisualStyleBackColor = true;
            // 
            // cboEstatus
            // 
            this.cboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstatus.Location = new System.Drawing.Point(95, 74);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(147, 28);
            this.cboEstatus.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Estatus";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Location = new System.Drawing.Point(402, 220);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 15;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Location = new System.Drawing.Point(321, 220);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 14;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(95, 42);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(392, 26);
            this.txtDescripcion.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // txtClaveAlmacen
            // 
            this.txtClaveAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveAlmacen.Location = new System.Drawing.Point(95, 10);
            this.txtClaveAlmacen.MaxLength = 10;
            this.txtClaveAlmacen.Name = "txtClaveAlmacen";
            this.txtClaveAlmacen.Size = new System.Drawing.Size(147, 26);
            this.txtClaveAlmacen.TabIndex = 7;
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodEmpleado.Location = new System.Drawing.Point(5, 13);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(59, 20);
            this.lblCodEmpleado.TabIndex = 1;
            this.lblCodEmpleado.Text = "Codigo";
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminar.Location = new System.Drawing.Point(402, 221);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminar.TabIndex = 6;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = false;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmEditar
            // 
            this.cmEditar.BackColor = System.Drawing.SystemColors.Control;
            this.cmEditar.Location = new System.Drawing.Point(321, 221);
            this.cmEditar.Name = "cmEditar";
            this.cmEditar.Size = new System.Drawing.Size(94, 36);
            this.cmEditar.TabIndex = 5;
            this.cmEditar.Text = "Editar";
            this.cmEditar.UseVisualStyleBackColor = false;
            this.cmEditar.Click += new System.EventHandler(this.cmEditar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregar.Location = new System.Drawing.Point(240, 221);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregar.TabIndex = 4;
            this.cmdAgregar.Text = "Agregar";
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
            this.grdView.Location = new System.Drawing.Point(11, 65);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(474, 150);
            this.grdView.TabIndex = 8;
            this.grdView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdView_RowHeaderMouseDoubleClick);
            this.grdView.DoubleClick += new System.EventHandler(this.grdView_DoubleClick);
            // 
            // CodEmpleado
            // 
            this.CodEmpleado.HeaderText = "Codigo";
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
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 58);
            this.panel1.TabIndex = 7;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdBuscar.Location = new System.Drawing.Point(389, 7);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(94, 36);
            this.cmdBuscar.TabIndex = 2;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(59, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(290, 26);
            this.txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // frmCatAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 515);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmEditar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 554);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 286);
            this.Name = "frmCatAlmacenes";
            this.Text = "Catálogo de almacenes";
            this.Load += new System.EventHandler(this.frmCatAlmacenes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveAlmacen;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmEditar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNumRojo;
        private System.Windows.Forms.CheckBox chkEsDeConsigna;
        private System.Windows.Forms.CheckBox chkEsDeVenta;
        private System.Windows.Forms.CheckBox chkEsDeCompra;
    }
}