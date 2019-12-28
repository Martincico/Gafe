namespace GAFE
{
    partial class MovtosInvPart
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
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtMuesCosto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblMuesCosto = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtPrecioNeto = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtUmedida = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnBuscarArt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCalculaPorcentaje = new System.Windows.Forms.CheckBox();
            this.txtImpIEPS = new System.Windows.Forms.TextBox();
            this.txtCveIESP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCveIVA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(476, 188);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 7;
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
            this.cmdAceptar.Location = new System.Drawing.Point(376, 188);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 6;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtMuesCosto
            // 
            this.txtMuesCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuesCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMuesCosto.Location = new System.Drawing.Point(214, 106);
            this.txtMuesCosto.MaxLength = 100;
            this.txtMuesCosto.Name = "txtMuesCosto";
            this.txtMuesCosto.ReadOnly = true;
            this.txtMuesCosto.Size = new System.Drawing.Size(80, 22);
            this.txtMuesCosto.TabIndex = 80;
            this.txtMuesCosto.TextChanged += new System.EventHandler(this.txtMuesCosto_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(320, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 92;
            this.label5.Text = "SubTotal";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSubTotal.Location = new System.Drawing.Point(423, 84);
            this.txtSubTotal.MaxLength = 100;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(146, 22);
            this.txtSubTotal.TabIndex = 85;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextChanged += new System.EventHandler(this.txtSubTotal_TextChanged);
            // 
            // lblMuesCosto
            // 
            this.lblMuesCosto.AutoSize = true;
            this.lblMuesCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMuesCosto.Location = new System.Drawing.Point(211, 84);
            this.lblMuesCosto.Name = "lblMuesCosto";
            this.lblMuesCosto.Size = new System.Drawing.Size(43, 16);
            this.lblMuesCosto.TabIndex = 95;
            this.lblMuesCosto.Text = "Costo";
            this.lblMuesCosto.Click += new System.EventHandler(this.lblMuesCosto_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(423, 159);
            this.txtTotal.MaxLength = 100;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(146, 22);
            this.txtTotal.TabIndex = 87;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // txtPrecioNeto
            // 
            this.txtPrecioNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecioNeto.Enabled = false;
            this.txtPrecioNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPrecioNeto.Location = new System.Drawing.Point(245, 197);
            this.txtPrecioNeto.MaxLength = 100;
            this.txtPrecioNeto.Name = "txtPrecioNeto";
            this.txtPrecioNeto.Size = new System.Drawing.Size(40, 22);
            this.txtPrecioNeto.TabIndex = 84;
            this.txtPrecioNeto.Text = "0";
            this.txtPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioNeto.Visible = false;
            this.txtPrecioNeto.TextChanged += new System.EventHandler(this.txtPrecioNeto_TextChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescuento.Location = new System.Drawing.Point(101, 136);
            this.txtDescuento.MaxLength = 100;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(99, 22);
            this.txtDescuento.TabIndex = 5;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPrecio.Location = new System.Drawing.Point(101, 84);
            this.txtPrecio.MaxLength = 100;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(99, 22);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.Text = "0";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(319, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "Total";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCantidad.Location = new System.Drawing.Point(101, 110);
            this.txtCantidad.MaxLength = 100;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(99, 22);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtUmedida
            // 
            this.txtUmedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUmedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUmedida.Location = new System.Drawing.Point(490, 6);
            this.txtUmedida.MaxLength = 100;
            this.txtUmedida.Name = "txtUmedida";
            this.txtUmedida.ReadOnly = true;
            this.txtUmedida.Size = new System.Drawing.Size(80, 22);
            this.txtUmedida.TabIndex = 79;
            this.txtUmedida.TextChanged += new System.EventHandler(this.txtUmedida_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(101, 33);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(468, 45);
            this.txtDescripcion.TabIndex = 78;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // btnBuscarArt
            // 
            this.btnBuscarArt.BackColor = System.Drawing.Color.White;
            this.btnBuscarArt.FlatAppearance.BorderSize = 0;
            this.btnBuscarArt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnBuscarArt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscarArt.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.btnBuscarArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarArt.Location = new System.Drawing.Point(1, 6);
            this.btnBuscarArt.Name = "btnBuscarArt";
            this.btnBuscarArt.Size = new System.Drawing.Size(94, 72);
            this.btnBuscarArt.TabIndex = 1;
            this.btnBuscarArt.Text = "Artículo";
            this.btnBuscarArt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarArt.UseVisualStyleBackColor = false;
            this.btnBuscarArt.Click += new System.EventHandler(this.btnBuscarArt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Descuento";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 88;
            this.label1.Text = "Precio";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCodigo.Location = new System.Drawing.Point(101, 6);
            this.txtCodigo.MaxLength = 100;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(214, 22);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(415, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 91;
            this.label8.Text = "U. Med.";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "Cantidad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkCalculaPorcentaje
            // 
            this.chkCalculaPorcentaje.AutoSize = true;
            this.chkCalculaPorcentaje.Location = new System.Drawing.Point(206, 141);
            this.chkCalculaPorcentaje.Name = "chkCalculaPorcentaje";
            this.chkCalculaPorcentaje.Size = new System.Drawing.Size(75, 17);
            this.chkCalculaPorcentaje.TabIndex = 100;
            this.chkCalculaPorcentaje.Text = "calc. en %";
            this.chkCalculaPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculaPorcentaje.UseVisualStyleBackColor = true;
            this.chkCalculaPorcentaje.CheckedChanged += new System.EventHandler(this.chkCalculaPorcentaje_CheckedChanged);
            // 
            // txtImpIEPS
            // 
            this.txtImpIEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpIEPS.Location = new System.Drawing.Point(423, 107);
            this.txtImpIEPS.Name = "txtImpIEPS";
            this.txtImpIEPS.ReadOnly = true;
            this.txtImpIEPS.Size = new System.Drawing.Size(146, 22);
            this.txtImpIEPS.TabIndex = 111;
            this.txtImpIEPS.Text = "0";
            this.txtImpIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCveIESP
            // 
            this.txtCveIESP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCveIESP.Location = new System.Drawing.Point(376, 106);
            this.txtCveIESP.Name = "txtCveIESP";
            this.txtCveIESP.ReadOnly = true;
            this.txtCveIESP.Size = new System.Drawing.Size(45, 22);
            this.txtCveIESP.TabIndex = 110;
            this.txtCveIESP.Text = "0";
            this.txtCveIESP.TextChanged += new System.EventHandler(this.txtCveIESP_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(320, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 109;
            this.label4.Text = "IEPS";
            // 
            // txtCveIVA
            // 
            this.txtCveIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCveIVA.Location = new System.Drawing.Point(376, 133);
            this.txtCveIVA.Name = "txtCveIVA";
            this.txtCveIVA.ReadOnly = true;
            this.txtCveIVA.Size = new System.Drawing.Size(45, 22);
            this.txtCveIVA.TabIndex = 108;
            this.txtCveIVA.Text = "0";
            this.txtCveIVA.TextChanged += new System.EventHandler(this.txtCveIVA_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(321, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 107;
            this.label6.Text = "IVA";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpuesto.Location = new System.Drawing.Point(423, 133);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(146, 22);
            this.txtImpuesto.TabIndex = 106;
            this.txtImpuesto.Text = "0";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpuesto.TextChanged += new System.EventHandler(this.txtImpuesto_TextChanged_1);
            // 
            // MovtosInvPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 225);
            this.Controls.Add(this.txtImpIEPS);
            this.Controls.Add(this.txtCveIESP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCveIVA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.chkCalculaPorcentaje);
            this.Controls.Add(this.txtMuesCosto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblMuesCosto);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtPrecioNeto);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtUmedida);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnBuscarArt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovtosInvPart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de partidas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtMuesCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblMuesCosto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtPrecioNeto;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtUmedida;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnBuscarArt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCalculaPorcentaje;
        private System.Windows.Forms.TextBox txtImpIEPS;
        private System.Windows.Forms.TextBox txtCveIESP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCveIVA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImpuesto;
    }
}