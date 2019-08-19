namespace GAFE
{
    partial class frmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja));
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.cmdArticulo = new System.Windows.Forms.Button();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.grdViewD = new System.Windows.Forms.DataGridView();
            this.lblVender = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbArticulo = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTotalArticulos = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblDescArticulo = new System.Windows.Forms.Label();
            this.lblPrecioArt = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveArticulo.Location = new System.Drawing.Point(602, 85);
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.Size = new System.Drawing.Size(170, 22);
            this.txtClaveArticulo.TabIndex = 2;
            this.txtClaveArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveArticulo_KeyPress);
            // 
            // cmdArticulo
            // 
            this.cmdArticulo.BackColor = System.Drawing.Color.Snow;
            this.cmdArticulo.BackgroundImage = global::GAFE.Properties.Resources.MnuArticulos;
            this.cmdArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdArticulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cmdArticulo.Location = new System.Drawing.Point(539, 77);
            this.cmdArticulo.Name = "cmdArticulo";
            this.cmdArticulo.Size = new System.Drawing.Size(48, 34);
            this.cmdArticulo.TabIndex = 1;
            this.cmdArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdArticulo.UseVisualStyleBackColor = false;
            this.cmdArticulo.Click += new System.EventHandler(this.cmdArticulo_Click);
            // 
            // cboCliente
            // 
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(15, 38);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(268, 24);
            this.cboCliente.TabIndex = 27;
            this.cboCliente.SelectedValueChanged += new System.EventHandler(this.cboCliente_SelectedValueChanged);
            // 
            // grdViewD
            // 
            this.grdViewD.BackgroundColor = System.Drawing.Color.White;
            this.grdViewD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewD.Location = new System.Drawing.Point(12, 77);
            this.grdViewD.Name = "grdViewD";
            this.grdViewD.Size = new System.Drawing.Size(488, 386);
            this.grdViewD.TabIndex = 36;
            // 
            // lblVender
            // 
            this.lblVender.AutoSize = true;
            this.lblVender.BackColor = System.Drawing.Color.Transparent;
            this.lblVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVender.ForeColor = System.Drawing.Color.White;
            this.lblVender.Location = new System.Drawing.Point(24, 19);
            this.lblVender.Name = "lblVender";
            this.lblVender.Size = new System.Drawing.Size(56, 16);
            this.lblVender.TabIndex = 26;
            this.lblVender.Text = "Cliente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label10.Location = new System.Drawing.Point(676, 395);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 16);
            this.label10.TabIndex = 48;
            this.label10.Text = "%";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtDescuento.Location = new System.Drawing.Point(703, 393);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(70, 22);
            this.txtDescuento.TabIndex = 4;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label9.Location = new System.Drawing.Point(545, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 46;
            this.label9.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label6.Location = new System.Drawing.Point(545, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "SubTotal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label4.Location = new System.Drawing.Point(545, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Descuento";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtCantidad.Location = new System.Drawing.Point(710, 174);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(62, 22);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label3.Location = new System.Drawing.Point(561, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.label2.Location = new System.Drawing.Point(561, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(356, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Ticket";
            // 
            // pbArticulo
            // 
            this.pbArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbArticulo.Image = global::GAFE.Properties.Resources.Image;
            this.pbArticulo.Location = new System.Drawing.Point(548, 202);
            this.pbArticulo.Name = "pbArticulo";
            this.pbArticulo.Size = new System.Drawing.Size(205, 141);
            this.pbArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArticulo.TabIndex = 254;
            this.pbArticulo.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Snow;
            this.btnEditar.BackgroundImage = global::GAFE.Properties.Resources.Editar;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEditar.Location = new System.Drawing.Point(15, 469);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(33, 34);
            this.btnEditar.TabIndex = 255;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Snow;
            this.btnEliminar.BackgroundImage = global::GAFE.Properties.Resources.Eliminar;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEliminar.Location = new System.Drawing.Point(54, 469);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(31, 34);
            this.btnEliminar.TabIndex = 256;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblTotalArticulos
            // 
            this.lblTotalArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTotalArticulos.Location = new System.Drawing.Point(328, 479);
            this.lblTotalArticulos.Name = "lblTotalArticulos";
            this.lblTotalArticulos.Size = new System.Drawing.Size(172, 16);
            this.lblTotalArticulos.TabIndex = 257;
            this.lblTotalArticulos.Text = "Total artículos:";
            this.lblTotalArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTicket
            // 
            this.lblTicket.BackColor = System.Drawing.Color.White;
            this.lblTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTicket.Location = new System.Drawing.Point(356, 35);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(93, 26);
            this.lblTicket.TabIndex = 258;
            this.lblTicket.Text = "0";
            this.lblTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescArticulo
            // 
            this.lblDescArticulo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDescArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblDescArticulo.Location = new System.Drawing.Point(525, 112);
            this.lblDescArticulo.Name = "lblDescArticulo";
            this.lblDescArticulo.Size = new System.Drawing.Size(247, 20);
            this.lblDescArticulo.TabIndex = 259;
            this.lblDescArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioArt
            // 
            this.lblPrecioArt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblPrecioArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioArt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblPrecioArt.Location = new System.Drawing.Point(654, 141);
            this.lblPrecioArt.Name = "lblPrecioArt";
            this.lblPrecioArt.Size = new System.Drawing.Size(119, 20);
            this.lblPrecioArt.TabIndex = 260;
            this.lblPrecioArt.Text = "0";
            this.lblPrecioArt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblSubTotal.Location = new System.Drawing.Point(638, 362);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(134, 20);
            this.lblSubTotal.TabIndex = 261;
            this.lblSubTotal.Text = "0";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTotal.Location = new System.Drawing.Point(638, 425);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(134, 20);
            this.lblTotal.TabIndex = 262;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdAceptar.Location = new System.Drawing.Point(522, 552);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 263;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.BackgroundImage = global::GAFE.Properties.Resources.bg_cajas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblPrecioArt);
            this.Controls.Add(this.lblDescArticulo);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.lblTotalArticulos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.pbArticulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdViewD);
            this.Controls.Add(this.lblVender);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.txtClaveArticulo);
            this.Controls.Add(this.cmdArticulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaja";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo movimientos de inventarios";
            this.Load += new System.EventHandler(this.frmCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaja_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.Button cmdArticulo;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.DataGridView grdViewD;
        private System.Windows.Forms.Label lblVender;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbArticulo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTotalArticulos;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblDescArticulo;
        private System.Windows.Forms.Label lblPrecioArt;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button cmdAceptar;
    }
}