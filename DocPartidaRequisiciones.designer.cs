namespace GAFE
{
    partial class DocPartidaRequisiciones
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
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmdArticulo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.txtPrecioNeto = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtUmedida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCveIESP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCveIVA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCalculaPorcentaje = new System.Windows.Forms.CheckBox();
            this.txtImpIEPS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClaveArticulo.Location = new System.Drawing.Point(101, 6);
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.Size = new System.Drawing.Size(208, 22);
            this.txtClaveArticulo.TabIndex = 2;
            this.txtClaveArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveArticulo_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(101, 33);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(468, 45);
            this.txtDescripcion.TabIndex = 20;
            // 
            // cmdArticulo
            // 
            this.cmdArticulo.BackColor = System.Drawing.Color.White;
            this.cmdArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmdArticulo.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.cmdArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArticulo.Location = new System.Drawing.Point(1, 6);
            this.cmdArticulo.Name = "cmdArticulo";
            this.cmdArticulo.Size = new System.Drawing.Size(94, 72);
            this.cmdArticulo.TabIndex = 1;
            this.cmdArticulo.Text = "Artículo";
            this.cmdArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdArticulo.UseVisualStyleBackColor = false;
            this.cmdArticulo.Click += new System.EventHandler(this.cmdArticulo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPrecio.Location = new System.Drawing.Point(101, 84);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(99, 22);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.Text = "0";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCantidad.Location = new System.Drawing.Point(101, 110);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(99, 22);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(13, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Descuento";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpuesto.Location = new System.Drawing.Point(423, 134);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(146, 22);
            this.txtImpuesto.TabIndex = 13;
            this.txtImpuesto.Text = "0";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpuesto.TextChanged += new System.EventHandler(this.txtImpuesto_TextChanged);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSubtotal.Location = new System.Drawing.Point(423, 84);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(146, 22);
            this.txtSubtotal.TabIndex = 15;
            this.txtSubtotal.Text = "0";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(320, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "SubTotal";
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
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(476, 188);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 17;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // txtPrecioNeto
            // 
            this.txtPrecioNeto.Enabled = false;
            this.txtPrecioNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtPrecioNeto.Location = new System.Drawing.Point(128, 167);
            this.txtPrecioNeto.Name = "txtPrecioNeto";
            this.txtPrecioNeto.Size = new System.Drawing.Size(22, 24);
            this.txtPrecioNeto.TabIndex = 19;
            this.txtPrecioNeto.Text = "0";
            this.txtPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioNeto.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(423, 159);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(146, 22);
            this.txtTotal.TabIndex = 22;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(319, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescuento.Location = new System.Drawing.Point(101, 136);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(99, 22);
            this.txtDescuento.TabIndex = 5;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // txtUmedida
            // 
            this.txtUmedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUmedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUmedida.Location = new System.Drawing.Point(489, 6);
            this.txtUmedida.MaxLength = 100;
            this.txtUmedida.Name = "txtUmedida";
            this.txtUmedida.ReadOnly = true;
            this.txtUmedida.Size = new System.Drawing.Size(80, 22);
            this.txtUmedida.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(429, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 93;
            this.label8.Text = "U. Med.";
            // 
            // txtCveIESP
            // 
            this.txtCveIESP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCveIESP.Location = new System.Drawing.Point(364, 109);
            this.txtCveIESP.Name = "txtCveIESP";
            this.txtCveIESP.ReadOnly = true;
            this.txtCveIESP.Size = new System.Drawing.Size(57, 22);
            this.txtCveIESP.TabIndex = 103;
            this.txtCveIESP.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(320, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 102;
            this.label1.Text = "IEPS";
            // 
            // txtCveIVA
            // 
            this.txtCveIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCveIVA.Location = new System.Drawing.Point(364, 134);
            this.txtCveIVA.Name = "txtCveIVA";
            this.txtCveIVA.ReadOnly = true;
            this.txtCveIVA.Size = new System.Drawing.Size(57, 22);
            this.txtCveIVA.TabIndex = 101;
            this.txtCveIVA.Text = "0";
            this.txtCveIVA.TextChanged += new System.EventHandler(this.txtCveIVA_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(320, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 16);
            this.label7.TabIndex = 100;
            this.label7.Text = "IVA";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // chkCalculaPorcentaje
            // 
            this.chkCalculaPorcentaje.AutoSize = true;
            this.chkCalculaPorcentaje.Location = new System.Drawing.Point(206, 140);
            this.chkCalculaPorcentaje.Name = "chkCalculaPorcentaje";
            this.chkCalculaPorcentaje.Size = new System.Drawing.Size(75, 17);
            this.chkCalculaPorcentaje.TabIndex = 104;
            this.chkCalculaPorcentaje.Text = "calc. en %";
            this.chkCalculaPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculaPorcentaje.UseVisualStyleBackColor = true;
            this.chkCalculaPorcentaje.CheckedChanged += new System.EventHandler(this.chkCalculaPorcentaje_CheckedChanged);
            // 
            // txtImpIEPS
            // 
            this.txtImpIEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpIEPS.Location = new System.Drawing.Point(423, 109);
            this.txtImpIEPS.Name = "txtImpIEPS";
            this.txtImpIEPS.ReadOnly = true;
            this.txtImpIEPS.Size = new System.Drawing.Size(146, 22);
            this.txtImpIEPS.TabIndex = 105;
            this.txtImpIEPS.Text = "0";
            this.txtImpIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DocPartidaRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.BorderThickness = 3;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 225);
            this.Controls.Add(this.txtImpIEPS);
            this.Controls.Add(this.chkCalculaPorcentaje);
            this.Controls.Add(this.txtCveIESP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCveIVA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUmedida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrecioNeto);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdArticulo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtClaveArticulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocPartidaRequisiciones";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de partidas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocPartidaRequisiciones_FormClosed);
            this.Load += new System.EventHandler(this.DocPartidaRequisiciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button cmdArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.TextBox txtPrecioNeto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtUmedida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCveIESP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCveIVA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCalculaPorcentaje;
        private System.Windows.Forms.TextBox txtImpIEPS;
    }
}