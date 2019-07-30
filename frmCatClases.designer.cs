namespace GAFE
{
    partial class frmCatClases
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveClase = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
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
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboEstatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.cmdAceptar);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtClaveClase);
            this.panel2.Controls.Add(this.lblCodEmpleado);
            this.panel2.Location = new System.Drawing.Point(1, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 135);
            this.panel2.TabIndex = 12;
            // 
            // cboEstatus
            // 
            this.cboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstatus.Location = new System.Drawing.Point(95, 74);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(147, 26);
            this.cboEstatus.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.Location = new System.Drawing.Point(5, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Estatus";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(390, 92);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 11;
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
            this.cmdAceptar.Location = new System.Drawing.Point(290, 92);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(95, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(392, 24);
            this.txtDescripcion.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // txtClaveClase
            // 
            this.txtClaveClase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveClase.Location = new System.Drawing.Point(95, 10);
            this.txtClaveClase.MaxLength = 10;
            this.txtClaveClase.Name = "txtClaveClase";
            this.txtClaveClase.Size = new System.Drawing.Size(147, 24);
            this.txtClaveClase.TabIndex = 7;
            this.txtClaveClase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveClase_KeyPress);
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodEmpleado.Location = new System.Drawing.Point(5, 13);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(56, 18);
            this.lblCodEmpleado.TabIndex = 1;
            this.lblCodEmpleado.Text = "Código";
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
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
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
            this.grdView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellContentClick);
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
            this.cmdBuscar.Image = global::GAFE.Properties.Resources.Buscar;
            this.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscar.Location = new System.Drawing.Point(389, 5);
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
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdConsultar.Image = global::GAFE.Properties.Resources.Consultar;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.Location = new System.Drawing.Point(403, 223);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 36);
            this.cmdConsultar.TabIndex = 13;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdSeleccionar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmdSeleccionar.Image = global::GAFE.Properties.Resources.Seleccionar;
            this.cmdSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeleccionar.Location = new System.Drawing.Point(10, 223);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(36, 36);
            this.cmdSeleccionar.TabIndex = 16;
            this.cmdSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSeleccionar.UseVisualStyleBackColor = false;
            this.cmdSeleccionar.Visible = false;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // frmCatClases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 403);
            this.Controls.Add(this.cmdSeleccionar);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 439);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 300);
            this.Name = "frmCatClases";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de clases";
            this.Load += new System.EventHandler(this.frmCatClases_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveClase;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmdSeleccionar;
    }
}