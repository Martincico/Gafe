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
            this.grdViewPart = new System.Windows.Forms.DataGridView();
            this.btnAddPartida = new System.Windows.Forms.Button();
            this.btnEliminarPartida = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtTotDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditaPartida = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTitDocumento = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblTitFolio = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTitFecha = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewPart)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(12, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 67);
            this.panel2.TabIndex = 13;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(395, 38);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(63, 15);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor";
            // 
            // lblTipoMovtos
            // 
            this.lblTipoMovtos.AutoSize = true;
            this.lblTipoMovtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMovtos.Location = new System.Drawing.Point(5, 38);
            this.lblTipoMovtos.Name = "lblTipoMovtos";
            this.lblTipoMovtos.Size = new System.Drawing.Size(98, 15);
            this.lblTipoMovtos.TabIndex = 2;
            this.lblTipoMovtos.Text = "Tipo Movimiento";
            // 
            // lblAlmaDest
            // 
            this.lblAlmaDest.AutoSize = true;
            this.lblAlmaDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmaDest.Location = new System.Drawing.Point(395, 38);
            this.lblAlmaDest.Name = "lblAlmaDest";
            this.lblAlmaDest.Size = new System.Drawing.Size(112, 15);
            this.lblAlmaDest.TabIndex = 2;
            this.lblAlmaDest.Text = "Almacén     Destino";
            // 
            // lblAlmaOri
            // 
            this.lblAlmaOri.AutoSize = true;
            this.lblAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmaOri.Location = new System.Drawing.Point(395, 9);
            this.lblAlmaOri.Name = "lblAlmaOri";
            this.lblAlmaOri.Size = new System.Drawing.Size(95, 15);
            this.lblAlmaOri.TabIndex = 2;
            this.lblAlmaOri.Text = "Almacén Origen";
            // 
            // lblClaseMov
            // 
            this.lblClaseMov.AutoSize = true;
            this.lblClaseMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaseMov.Location = new System.Drawing.Point(5, 9);
            this.lblClaseMov.Name = "lblClaseMov";
            this.lblClaseMov.Size = new System.Drawing.Size(71, 15);
            this.lblClaseMov.TabIndex = 2;
            this.lblClaseMov.Text = "Movimiento";
            // 
            // cboProveedor
            // 
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(527, 35);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(264, 23);
            this.cboProveedor.TabIndex = 5;
            // 
            // cboClaseMov
            // 
            this.cboClaseMov.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClaseMov.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClaseMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClaseMov.FormattingEnabled = true;
            this.cboClaseMov.Location = new System.Drawing.Point(117, 6);
            this.cboClaseMov.Name = "cboClaseMov";
            this.cboClaseMov.Size = new System.Drawing.Size(264, 23);
            this.cboClaseMov.TabIndex = 1;
            this.cboClaseMov.SelectedIndexChanged += new System.EventHandler(this.cboClaseMov_SelectedIndexChanged);
            // 
            // cboAlmaDest
            // 
            this.cboAlmaDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmaDest.FormattingEnabled = true;
            this.cboAlmaDest.Location = new System.Drawing.Point(527, 35);
            this.cboAlmaDest.Name = "cboAlmaDest";
            this.cboAlmaDest.Size = new System.Drawing.Size(264, 23);
            this.cboAlmaDest.TabIndex = 4;
            this.cboAlmaDest.SelectedIndexChanged += new System.EventHandler(this.cboAlmaDest_SelectedIndexChanged);
            // 
            // cboTipoMovtos
            // 
            this.cboTipoMovtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovtos.FormattingEnabled = true;
            this.cboTipoMovtos.Location = new System.Drawing.Point(117, 35);
            this.cboTipoMovtos.Name = "cboTipoMovtos";
            this.cboTipoMovtos.Size = new System.Drawing.Size(264, 23);
            this.cboTipoMovtos.TabIndex = 3;
            this.cboTipoMovtos.SelectedValueChanged += new System.EventHandler(this.cboTipoMovtos_SelectedValueChanged);
            // 
            // cboAlmaOri
            // 
            this.cboAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmaOri.FormattingEnabled = true;
            this.cboAlmaOri.Location = new System.Drawing.Point(527, 6);
            this.cboAlmaOri.Name = "cboAlmaOri";
            this.cboAlmaOri.Size = new System.Drawing.Size(264, 23);
            this.cboAlmaOri.TabIndex = 2;
            this.cboAlmaOri.SelectedValueChanged += new System.EventHandler(this.cboAlmaOri_SelectedValueChanged);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(729, 383);
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
            this.cmdAceptar.Location = new System.Drawing.Point(633, 383);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 18;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // grdViewPart
            // 
            this.grdViewPart.AllowUserToAddRows = false;
            this.grdViewPart.AllowUserToDeleteRows = false;
            this.grdViewPart.AllowUserToOrderColumns = true;
            this.grdViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewPart.Location = new System.Drawing.Point(12, 154);
            this.grdViewPart.Name = "grdViewPart";
            this.grdViewPart.ReadOnly = true;
            this.grdViewPart.Size = new System.Drawing.Size(615, 280);
            this.grdViewPart.TabIndex = 20;
            // 
            // btnAddPartida
            // 
            this.btnAddPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddPartida.Image = global::GAFE.Properties.Resources.Nuevo;
            this.btnAddPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPartida.Location = new System.Drawing.Point(107, 112);
            this.btnAddPartida.Name = "btnAddPartida";
            this.btnAddPartida.Size = new System.Drawing.Size(94, 36);
            this.btnAddPartida.TabIndex = 21;
            this.btnAddPartida.Text = "Articulo";
            this.btnAddPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPartida.UseVisualStyleBackColor = false;
            this.btnAddPartida.Click += new System.EventHandler(this.btnAddPartida_Click);
            // 
            // btnEliminarPartida
            // 
            this.btnEliminarPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPartida.Image = global::GAFE.Properties.Resources.Eliminar;
            this.btnEliminarPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPartida.Location = new System.Drawing.Point(363, 112);
            this.btnEliminarPartida.Name = "btnEliminarPartida";
            this.btnEliminarPartida.Size = new System.Drawing.Size(94, 36);
            this.btnEliminarPartida.TabIndex = 21;
            this.btnEliminarPartida.Text = "Eliminar";
            this.btnEliminarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarPartida.UseVisualStyleBackColor = false;
            this.btnEliminarPartida.Click += new System.EventHandler(this.btnEliminarPartida_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(719, 298);
            this.txtTotal.MaxLength = 100;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(99, 21);
            this.txtTotal.TabIndex = 75;
            this.txtTotal.Text = "0";
            // 
            // txtIva
            // 
            this.txtIva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIva.Enabled = false;
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(719, 262);
            this.txtIva.MaxLength = 100;
            this.txtIva.Name = "txtIva";
            this.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIva.Size = new System.Drawing.Size(99, 21);
            this.txtIva.TabIndex = 74;
            this.txtIva.Text = "0";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(719, 226);
            this.txtSubTotal.MaxLength = 100;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubTotal.Size = new System.Drawing.Size(99, 21);
            this.txtSubTotal.TabIndex = 73;
            this.txtSubTotal.Text = "0";
            // 
            // txtTotDesc
            // 
            this.txtTotDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotDesc.Enabled = false;
            this.txtTotDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDesc.Location = new System.Drawing.Point(719, 190);
            this.txtTotDesc.MaxLength = 100;
            this.txtTotDesc.Name = "txtTotDesc";
            this.txtTotDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotDesc.Size = new System.Drawing.Size(99, 21);
            this.txtTotDesc.TabIndex = 72;
            this.txtTotDesc.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(632, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(632, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 77;
            this.label6.Text = "Iva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(632, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 78;
            this.label5.Text = "Sub. Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(632, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "Total Desc.";
            // 
            // txtDescuento
            // 
            this.txtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(719, 154);
            this.txtDescuento.MaxLength = 100;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescuento.Size = new System.Drawing.Size(99, 21);
            this.txtDescuento.TabIndex = 80;
            this.txtDescuento.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(632, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 81;
            this.label1.Text = "Descuento";
            // 
            // btnEditaPartida
            // 
            this.btnEditaPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditaPartida.Image = global::GAFE.Properties.Resources.Editar;
            this.btnEditaPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditaPartida.Location = new System.Drawing.Point(235, 112);
            this.btnEditaPartida.Name = "btnEditaPartida";
            this.btnEditaPartida.Size = new System.Drawing.Size(94, 36);
            this.btnEditaPartida.TabIndex = 83;
            this.btnEditaPartida.Text = "Editar";
            this.btnEditaPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditaPartida.UseVisualStyleBackColor = false;
            this.btnEditaPartida.Click += new System.EventHandler(this.btnEditaPartida_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblDocumento);
            this.panel1.Controls.Add(this.lblTitDocumento);
            this.panel1.Controls.Add(this.lblFolio);
            this.panel1.Controls.Add(this.lblTitFolio);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblTitFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 33);
            this.panel1.TabIndex = 84;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocumento.Location = new System.Drawing.Point(665, 8);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(80, 15);
            this.lblDocumento.TabIndex = 88;
            this.lblDocumento.Text = "Documento";
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitDocumento
            // 
            this.lblTitDocumento.AutoSize = true;
            this.lblTitDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitDocumento.Location = new System.Drawing.Point(593, 8);
            this.lblTitDocumento.Name = "lblTitDocumento";
            this.lblTitDocumento.Size = new System.Drawing.Size(71, 15);
            this.lblTitDocumento.TabIndex = 85;
            this.lblTitDocumento.Text = "Documento";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFolio.Location = new System.Drawing.Point(505, 8);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(39, 15);
            this.lblFolio.TabIndex = 89;
            this.lblFolio.Text = "Folio";
            this.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitFolio
            // 
            this.lblTitFolio.AutoSize = true;
            this.lblTitFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitFolio.Location = new System.Drawing.Point(470, 8);
            this.lblTitFolio.Name = "lblTitFolio";
            this.lblTitFolio.Size = new System.Drawing.Size(34, 15);
            this.lblTitFolio.TabIndex = 86;
            this.lblTitFolio.Text = "Folio";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(75, 8);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 15);
            this.lblFecha.TabIndex = 90;
            this.lblFecha.Text = "Fecha";
            // 
            // lblTitFecha
            // 
            this.lblTitFecha.AutoSize = true;
            this.lblTitFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitFecha.Location = new System.Drawing.Point(27, 8);
            this.lblTitFecha.Name = "lblTitFecha";
            this.lblTitFecha.Size = new System.Drawing.Size(41, 15);
            this.lblTitFecha.TabIndex = 87;
            this.lblTitFecha.Text = "Fecha";
            // 
            // frmRegInventarioMovtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 446);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditaPartida);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtTotDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEliminarPartida);
            this.Controls.Add(this.btnAddPartida);
            this.Controls.Add(this.grdViewPart);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegInventarioMovtos_FormClosing);
            this.Load += new System.EventHandler(this.frmRegInventarioMovtos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegInventarioMovtos_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewPart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.DataGridView grdViewPart;
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
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtTotDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditaPartida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTitDocumento;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblTitFolio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTitFecha;
    }
}