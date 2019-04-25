namespace GAFE
{
    partial class frmRegInventarioMovtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInventarioMovtos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblTipoMovtos = new System.Windows.Forms.Label();
            this.lblAlmaDest = new System.Windows.Forms.Label();
            this.lblAlmaOri = new System.Windows.Forms.Label();
            this.lblClaseMov = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboClaseMov = new System.Windows.Forms.ComboBox();
            this.cboAlmaDest = new System.Windows.Forms.ComboBox();
            this.cboTipoMovtos = new System.Windows.Forms.ComboBox();
            this.cboAlmaOri = new System.Windows.Forms.ComboBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.CodEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPartida = new System.Windows.Forms.Button();
            this.btnEliminarPartida = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblProveedor);
            this.panel2.Controls.Add(this.lblTipoMovtos);
            this.panel2.Controls.Add(this.lblAlmaDest);
            this.panel2.Controls.Add(this.lblAlmaOri);
            this.panel2.Controls.Add(this.lblClaseMov);
            this.panel2.Controls.Add(this.cboProveedor);
            this.panel2.Controls.Add(this.cboClaseMov);
            this.panel2.Controls.Add(this.cboAlmaDest);
            this.panel2.Controls.Add(this.cboTipoMovtos);
            this.panel2.Controls.Add(this.cboAlmaOri);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 196);
            this.panel2.TabIndex = 13;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(405, 109);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(81, 20);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor";
            // 
            // lblTipoMovtos
            // 
            this.lblTipoMovtos.AutoSize = true;
            this.lblTipoMovtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMovtos.Location = new System.Drawing.Point(5, 110);
            this.lblTipoMovtos.Name = "lblTipoMovtos";
            this.lblTipoMovtos.Size = new System.Drawing.Size(123, 20);
            this.lblTipoMovtos.TabIndex = 2;
            this.lblTipoMovtos.Text = "Tipo Movimiento";
            // 
            // lblAlmaDest
            // 
            this.lblAlmaDest.AutoSize = true;
            this.lblAlmaDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmaDest.Location = new System.Drawing.Point(405, 65);
            this.lblAlmaDest.Name = "lblAlmaDest";
            this.lblAlmaDest.Size = new System.Drawing.Size(130, 20);
            this.lblAlmaDest.TabIndex = 2;
            this.lblAlmaDest.Text = "Almacén Destino";
            // 
            // lblAlmaOri
            // 
            this.lblAlmaOri.AutoSize = true;
            this.lblAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmaOri.Location = new System.Drawing.Point(5, 65);
            this.lblAlmaOri.Name = "lblAlmaOri";
            this.lblAlmaOri.Size = new System.Drawing.Size(122, 20);
            this.lblAlmaOri.TabIndex = 2;
            this.lblAlmaOri.Text = "Almacén Origen";
            // 
            // lblClaseMov
            // 
            this.lblClaseMov.AutoSize = true;
            this.lblClaseMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaseMov.Location = new System.Drawing.Point(5, 20);
            this.lblClaseMov.Name = "lblClaseMov";
            this.lblClaseMov.Size = new System.Drawing.Size(89, 20);
            this.lblClaseMov.TabIndex = 2;
            this.lblClaseMov.Text = "Movimiento";
            // 
            // cboProveedor
            // 
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(536, 106);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(256, 28);
            this.cboProveedor.TabIndex = 5;
            // 
            // cboClaseMov
            // 
            this.cboClaseMov.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClaseMov.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClaseMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboClaseMov.FormattingEnabled = true;
            this.cboClaseMov.Location = new System.Drawing.Point(129, 12);
            this.cboClaseMov.Name = "cboClaseMov";
            this.cboClaseMov.Size = new System.Drawing.Size(236, 28);
            this.cboClaseMov.TabIndex = 1;
            this.cboClaseMov.SelectedIndexChanged += new System.EventHandler(this.cboClaseMov_SelectedIndexChanged);
            // 
            // cboAlmaDest
            // 
            this.cboAlmaDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboAlmaDest.FormattingEnabled = true;
            this.cboAlmaDest.Location = new System.Drawing.Point(536, 59);
            this.cboAlmaDest.Name = "cboAlmaDest";
            this.cboAlmaDest.Size = new System.Drawing.Size(256, 28);
            this.cboAlmaDest.TabIndex = 4;
            // 
            // cboTipoMovtos
            // 
            this.cboTipoMovtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboTipoMovtos.FormattingEnabled = true;
            this.cboTipoMovtos.Location = new System.Drawing.Point(129, 106);
            this.cboTipoMovtos.Name = "cboTipoMovtos";
            this.cboTipoMovtos.Size = new System.Drawing.Size(264, 28);
            this.cboTipoMovtos.TabIndex = 3;
            this.cboTipoMovtos.SelectedValueChanged += new System.EventHandler(this.cboTipoMovtos_SelectedValueChanged);
            // 
            // cboAlmaOri
            // 
            this.cboAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboAlmaOri.FormattingEnabled = true;
            this.cboAlmaOri.Location = new System.Drawing.Point(129, 59);
            this.cboAlmaOri.Name = "cboAlmaOri";
            this.cboAlmaOri.Size = new System.Drawing.Size(264, 28);
            this.cboAlmaOri.TabIndex = 2;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(532, 501);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 19;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(427, 501);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 18;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
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
            this.grdView.Location = new System.Drawing.Point(12, 276);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(644, 150);
            this.grdView.TabIndex = 20;
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
            // btnAddPartida
            // 
            this.btnAddPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddPartida.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPartida.Image")));
            this.btnAddPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPartida.Location = new System.Drawing.Point(12, 234);
            this.btnAddPartida.Name = "btnAddPartida";
            this.btnAddPartida.Size = new System.Drawing.Size(94, 36);
            this.btnAddPartida.TabIndex = 21;
            this.btnAddPartida.Text = "Aceptar";
            this.btnAddPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPartida.UseVisualStyleBackColor = false;
            this.btnAddPartida.Click += new System.EventHandler(this.btnAddPartida_Click);
            // 
            // btnEliminarPartida
            // 
            this.btnEliminarPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPartida.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarPartida.Image")));
            this.btnEliminarPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPartida.Location = new System.Drawing.Point(112, 234);
            this.btnEliminarPartida.Name = "btnEliminarPartida";
            this.btnEliminarPartida.Size = new System.Drawing.Size(94, 36);
            this.btnEliminarPartida.TabIndex = 21;
            this.btnEliminarPartida.Text = "Aceptar";
            this.btnEliminarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarPartida.UseVisualStyleBackColor = false;
            // 
            // frmRegInventarioMovtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 549);
            this.Controls.Add(this.btnEliminarPartida);
            this.Controls.Add(this.btnAddPartida);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegInventarioMovtos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Tipo Movimientos";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Button btnAddPartida;
        private System.Windows.Forms.Button btnEliminarPartida;
        private System.Windows.Forms.ComboBox cboAlmaOri;
        private System.Windows.Forms.ComboBox cboClaseMov;
        private System.Windows.Forms.Label lblAlmaOri;
        private System.Windows.Forms.Label lblClaseMov;
        private System.Windows.Forms.Label lblTipoMovtos;
        private System.Windows.Forms.ComboBox cboTipoMovtos;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblAlmaDest;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.ComboBox cboAlmaDest;
    }
}