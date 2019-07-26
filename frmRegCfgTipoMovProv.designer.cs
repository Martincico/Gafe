namespace GAFE
{
    partial class frmRegCfgTipoMovProv
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
            this.chkUsaCliente = new System.Windows.Forms.CheckBox();
            this.chkUsaProvee = new System.Windows.Forms.CheckBox();
            this.chkAutoriza = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(438, 256);
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
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(333, 256);
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
            this.cboCfgCatFoliadores.Location = new System.Drawing.Point(131, 132);
            this.cboCfgCatFoliadores.Name = "cboCfgCatFoliadores";
            this.cboCfgCatFoliadores.Size = new System.Drawing.Size(336, 26);
            this.cboCfgCatFoliadores.TabIndex = 37;
            // 
            // cboTipoMov
            // 
            this.cboTipoMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboTipoMov.FormattingEnabled = true;
            this.cboTipoMov.Location = new System.Drawing.Point(131, 100);
            this.cboTipoMov.Name = "cboTipoMov";
            this.cboTipoMov.Size = new System.Drawing.Size(336, 26);
            this.cboTipoMov.TabIndex = 29;
            // 
            // optAbono
            // 
            this.optAbono.AutoSize = true;
            this.optAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optAbono.Location = new System.Drawing.Point(276, 72);
            this.optAbono.Name = "optAbono";
            this.optAbono.Size = new System.Drawing.Size(69, 22);
            this.optAbono.TabIndex = 27;
            this.optAbono.Text = "Abono";
            this.optAbono.UseVisualStyleBackColor = true;
            // 
            // optCargo
            // 
            this.optCargo.AutoSize = true;
            this.optCargo.Checked = true;
            this.optCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.optCargo.Location = new System.Drawing.Point(131, 72);
            this.optCargo.Name = "optCargo";
            this.optCargo.Size = new System.Drawing.Size(67, 22);
            this.optCargo.TabIndex = 28;
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
            this.chkEstatus.Location = new System.Drawing.Point(10, 262);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(67, 22);
            this.chkEstatus.TabIndex = 33;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // chkEditaFecha
            // 
            this.chkEditaFecha.AutoSize = true;
            this.chkEditaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkEditaFecha.Location = new System.Drawing.Point(131, 206);
            this.chkEditaFecha.Name = "chkEditaFecha";
            this.chkEditaFecha.Size = new System.Drawing.Size(100, 22);
            this.chkEditaFecha.TabIndex = 32;
            this.chkEditaFecha.Text = "Edita fecha";
            this.chkEditaFecha.UseVisualStyleBackColor = true;
            // 
            // chkUsaSerie
            // 
            this.chkUsaSerie.AutoSize = true;
            this.chkUsaSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkUsaSerie.Location = new System.Drawing.Point(10, 206);
            this.chkUsaSerie.Name = "chkUsaSerie";
            this.chkUsaSerie.Size = new System.Drawing.Size(90, 22);
            this.chkUsaSerie.TabIndex = 31;
            this.chkUsaSerie.Text = "Usa serie";
            this.chkUsaSerie.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(131, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(401, 24);
            this.txtDescripcion.TabIndex = 25;
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
            this.txtClaveTipoMov.Location = new System.Drawing.Point(131, 12);
            this.txtClaveTipoMov.MaxLength = 10;
            this.txtClaveTipoMov.Name = "txtClaveTipoMov";
            this.txtClaveTipoMov.Size = new System.Drawing.Size(147, 24);
            this.txtClaveTipoMov.TabIndex = 23;
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
            this.chkEsInterno.Location = new System.Drawing.Point(10, 234);
            this.chkEsInterno.Name = "chkEsInterno";
            this.chkEsInterno.Size = new System.Drawing.Size(94, 22);
            this.chkEsInterno.TabIndex = 38;
            this.chkEsInterno.Text = "Es interno";
            this.chkEsInterno.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtEmail.Location = new System.Drawing.Point(131, 164);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 24);
            this.txtEmail.TabIndex = 39;
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
            // chkUsaCliente
            // 
            this.chkUsaCliente.AutoSize = true;
            this.chkUsaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkUsaCliente.Location = new System.Drawing.Point(272, 206);
            this.chkUsaCliente.Name = "chkUsaCliente";
            this.chkUsaCliente.Size = new System.Drawing.Size(100, 22);
            this.chkUsaCliente.TabIndex = 41;
            this.chkUsaCliente.Text = "Usa cliente";
            this.chkUsaCliente.UseVisualStyleBackColor = true;
            // 
            // chkUsaProvee
            // 
            this.chkUsaProvee.AutoSize = true;
            this.chkUsaProvee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkUsaProvee.Location = new System.Drawing.Point(407, 206);
            this.chkUsaProvee.Name = "chkUsaProvee";
            this.chkUsaProvee.Size = new System.Drawing.Size(125, 22);
            this.chkUsaProvee.TabIndex = 42;
            this.chkUsaProvee.Text = "Usa proveedor";
            this.chkUsaProvee.UseVisualStyleBackColor = true;
            // 
            // chkAutoriza
            // 
            this.chkAutoriza.AutoSize = true;
            this.chkAutoriza.Checked = true;
            this.chkAutoriza.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkAutoriza.Location = new System.Drawing.Point(131, 234);
            this.chkAutoriza.Name = "chkAutoriza";
            this.chkAutoriza.Size = new System.Drawing.Size(160, 22);
            this.chkAutoriza.TabIndex = 43;
            this.chkAutoriza.Text = "Solicita autorización";
            this.chkAutoriza.UseVisualStyleBackColor = true;
            // 
            // frmRegCfgTipoMovProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 299);
            this.Controls.Add(this.chkAutoriza);
            this.Controls.Add(this.chkUsaProvee);
            this.Controls.Add(this.chkUsaCliente);
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
            this.Name = "frmRegCfgTipoMovProv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de documentos";
            this.Load += new System.EventHandler(this.frmRegCfgTipoMovProv_Load);
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
        private System.Windows.Forms.CheckBox chkUsaCliente;
        private System.Windows.Forms.CheckBox chkUsaProvee;
        private System.Windows.Forms.CheckBox chkAutoriza;
    }
}