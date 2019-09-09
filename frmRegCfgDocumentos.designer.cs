namespace GAFE
{
    partial class frmRegCfgDocumentos
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
            this.cboCfgCatFoliadores = new System.Windows.Forms.ComboBox();
            this.cboTipoMov = new System.Windows.Forms.ComboBox();
            this.optAbono = new System.Windows.Forms.RadioButton();
            this.optCargo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.chkEditaFecha = new System.Windows.Forms.CheckBox();
            this.chkUsaSerie = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveTipoMov = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.chkEsInterno = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoriza = new System.Windows.Forms.CheckBox();
            this.chkAfectaInventario = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optProveedor = new System.Windows.Forms.RadioButton();
            this.optCliente = new System.Windows.Forms.RadioButton();
            this.cboDocRel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBotonDocRel = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(438, 347);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 19;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click_1);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(333, 347);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 18;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cboCfgCatFoliadores
            // 
            this.cboCfgCatFoliadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboCfgCatFoliadores.FormattingEnabled = true;
            this.cboCfgCatFoliadores.Location = new System.Drawing.Point(138, 132);
            this.cboCfgCatFoliadores.Name = "cboCfgCatFoliadores";
            this.cboCfgCatFoliadores.Size = new System.Drawing.Size(336, 26);
            this.cboCfgCatFoliadores.TabIndex = 6;
            // 
            // cboTipoMov
            // 
            this.cboTipoMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboTipoMov.FormattingEnabled = true;
            this.cboTipoMov.Location = new System.Drawing.Point(138, 100);
            this.cboTipoMov.Name = "cboTipoMov";
            this.cboTipoMov.Size = new System.Drawing.Size(336, 26);
            this.cboTipoMov.TabIndex = 5;
            // 
            // optAbono
            // 
            this.optAbono.AutoSize = true;
            this.optAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optAbono.Location = new System.Drawing.Point(283, 72);
            this.optAbono.Name = "optAbono";
            this.optAbono.Size = new System.Drawing.Size(69, 22);
            this.optAbono.TabIndex = 4;
            this.optAbono.Text = "Abono";
            this.optAbono.UseVisualStyleBackColor = true;
            // 
            // optCargo
            // 
            this.optCargo.AutoSize = true;
            this.optCargo.Checked = true;
            this.optCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optCargo.Location = new System.Drawing.Point(138, 72);
            this.optCargo.Name = "optCargo";
            this.optCargo.Size = new System.Drawing.Size(67, 22);
            this.optCargo.TabIndex = 3;
            this.optCargo.TabStop = true;
            this.optCargo.Text = "Cargo";
            this.optCargo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(7, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Tipo movimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Foliador";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEstatus.Location = new System.Drawing.Point(369, 317);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(67, 22);
            this.chkEstatus.TabIndex = 17;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // chkEditaFecha
            // 
            this.chkEditaFecha.AutoSize = true;
            this.chkEditaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEditaFecha.Location = new System.Drawing.Point(191, 289);
            this.chkEditaFecha.Name = "chkEditaFecha";
            this.chkEditaFecha.Size = new System.Drawing.Size(100, 22);
            this.chkEditaFecha.TabIndex = 13;
            this.chkEditaFecha.Text = "Edita fecha";
            this.chkEditaFecha.UseVisualStyleBackColor = true;
            // 
            // chkUsaSerie
            // 
            this.chkUsaSerie.AutoSize = true;
            this.chkUsaSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkUsaSerie.Location = new System.Drawing.Point(11, 289);
            this.chkUsaSerie.Name = "chkUsaSerie";
            this.chkUsaSerie.Size = new System.Drawing.Size(90, 22);
            this.chkUsaSerie.TabIndex = 12;
            this.chkUsaSerie.Text = "Usa serie";
            this.chkUsaSerie.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(138, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(391, 24);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Descripción";
            // 
            // txtClaveTipoMov
            // 
            this.txtClaveTipoMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveTipoMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveTipoMov.Location = new System.Drawing.Point(138, 12);
            this.txtClaveTipoMov.MaxLength = 10;
            this.txtClaveTipoMov.Name = "txtClaveTipoMov";
            this.txtClaveTipoMov.Size = new System.Drawing.Size(183, 24);
            this.txtClaveTipoMov.TabIndex = 1;
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodEmpleado.Location = new System.Drawing.Point(7, 15);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(56, 18);
            this.lblCodEmpleado.TabIndex = 24;
            this.lblCodEmpleado.Text = "Código";
            // 
            // chkEsInterno
            // 
            this.chkEsInterno.AutoSize = true;
            this.chkEsInterno.Checked = true;
            this.chkEsInterno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEsInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEsInterno.Location = new System.Drawing.Point(191, 317);
            this.chkEsInterno.Name = "chkEsInterno";
            this.chkEsInterno.Size = new System.Drawing.Size(94, 22);
            this.chkEsInterno.TabIndex = 16;
            this.chkEsInterno.Text = "Es interno";
            this.chkEsInterno.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtEmail.Location = new System.Drawing.Point(138, 164);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 24);
            this.txtEmail.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(7, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Enviar correo";
            // 
            // chkAutoriza
            // 
            this.chkAutoriza.AutoSize = true;
            this.chkAutoriza.Checked = true;
            this.chkAutoriza.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkAutoriza.Location = new System.Drawing.Point(369, 289);
            this.chkAutoriza.Name = "chkAutoriza";
            this.chkAutoriza.Size = new System.Drawing.Size(160, 22);
            this.chkAutoriza.TabIndex = 14;
            this.chkAutoriza.Text = "Solicita autorización";
            this.chkAutoriza.UseVisualStyleBackColor = true;
            // 
            // chkAfectaInventario
            // 
            this.chkAfectaInventario.AutoSize = true;
            this.chkAfectaInventario.Checked = true;
            this.chkAfectaInventario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAfectaInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkAfectaInventario.Location = new System.Drawing.Point(11, 317);
            this.chkAfectaInventario.Name = "chkAfectaInventario";
            this.chkAfectaInventario.Size = new System.Drawing.Size(135, 22);
            this.chkAfectaInventario.TabIndex = 15;
            this.chkAfectaInventario.Text = "Afecta inventario";
            this.chkAfectaInventario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(7, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "Usa";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.optProveedor);
            this.groupBox1.Controls.Add(this.optCliente);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(104, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 32);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // optProveedor
            // 
            this.optProveedor.AutoSize = true;
            this.optProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optProveedor.Location = new System.Drawing.Point(172, 6);
            this.optProveedor.Name = "optProveedor";
            this.optProveedor.Size = new System.Drawing.Size(95, 22);
            this.optProveedor.TabIndex = 11;
            this.optProveedor.TabStop = true;
            this.optProveedor.Text = "Proveedor";
            this.optProveedor.UseVisualStyleBackColor = true;
            // 
            // optCliente
            // 
            this.optCliente.AutoSize = true;
            this.optCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optCliente.Location = new System.Drawing.Point(34, 6);
            this.optCliente.Name = "optCliente";
            this.optCliente.Size = new System.Drawing.Size(71, 22);
            this.optCliente.TabIndex = 10;
            this.optCliente.TabStop = true;
            this.optCliente.Text = "Cliente";
            this.optCliente.UseVisualStyleBackColor = true;
            // 
            // cboDocRel
            // 
            this.cboDocRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboDocRel.FormattingEnabled = true;
            this.cboDocRel.Location = new System.Drawing.Point(138, 194);
            this.cboDocRel.Name = "cboDocRel";
            this.cboDocRel.Size = new System.Drawing.Size(336, 26);
            this.cboDocRel.TabIndex = 8;
            this.cboDocRel.SelectedIndexChanged += new System.EventHandler(this.cboDocRel_SelectedIndexChanged);
            this.cboDocRel.SelectedValueChanged += new System.EventHandler(this.cboDocRel_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(7, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "Doc. Relacionado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(7, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 52;
            this.label7.Text = "Nombre botón";
            // 
            // txtBotonDocRel
            // 
            this.txtBotonDocRel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBotonDocRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtBotonDocRel.Location = new System.Drawing.Point(138, 226);
            this.txtBotonDocRel.MaxLength = 100;
            this.txtBotonDocRel.Name = "txtBotonDocRel";
            this.txtBotonDocRel.Size = new System.Drawing.Size(214, 24);
            this.txtBotonDocRel.TabIndex = 9;
            // 
            // frmRegCfgDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CancelButton = this.cmdAceptar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 391);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBotonDocRel);
            this.Controls.Add(this.cboDocRel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkAfectaInventario);
            this.Controls.Add(this.chkAutoriza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.chkEsInterno);
            this.Controls.Add(this.cboCfgCatFoliadores);
            this.Controls.Add(this.cboTipoMov);
            this.Controls.Add(this.optAbono);
            this.Controls.Add(this.optCargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkEstatus);
            this.Controls.Add(this.chkEditaFecha);
            this.Controls.Add(this.chkUsaSerie);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClaveTipoMov);
            this.Controls.Add(this.lblCodEmpleado);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCfgDocumentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de documentos";
            this.Load += new System.EventHandler(this.frmRegCfgDocumentos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegCfgDocumentos_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.ComboBox cboCfgCatFoliadores;
        private System.Windows.Forms.ComboBox cboTipoMov;
        private System.Windows.Forms.RadioButton optAbono;
        private System.Windows.Forms.RadioButton optCargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.CheckBox chkEditaFecha;
        private System.Windows.Forms.CheckBox chkUsaSerie;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveTipoMov;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.CheckBox chkEsInterno;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoriza;
        private System.Windows.Forms.CheckBox chkAfectaInventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optProveedor;
        private System.Windows.Forms.RadioButton optCliente;
        private System.Windows.Forms.ComboBox cboDocRel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBotonDocRel;
    }
}