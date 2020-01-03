namespace GAFE
{
    partial class frmRegTipoMovtos
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
            this.chkSolicitaSucursal = new System.Windows.Forms.CheckBox();
            this.chkInterno = new System.Windows.Forms.CheckBox();
            this.cboCfgCatFoliadores = new System.Windows.Forms.ComboBox();
            this.cboTipoMovRel = new System.Windows.Forms.ComboBox();
            this.rdbSalida = new System.Windows.Forms.RadioButton();
            this.rdbEntrada = new System.Windows.Forms.RadioButton();
            this.cboCveClsMov = new System.Windows.Forms.ComboBox();
            this.txtFmtoImpresion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSugiereCosto = new System.Windows.Forms.CheckBox();
            this.chkAfectaCosto = new System.Windows.Forms.CheckBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.chkCalculaIva = new System.Windows.Forms.CheckBox();
            this.chkSolicitaCosto = new System.Windows.Forms.CheckBox();
            this.chkEditaCosto = new System.Windows.Forms.CheckBox();
            this.chkMuestraCosto = new System.Windows.Forms.CheckBox();
            this.chkEstraspaso = new System.Windows.Forms.CheckBox();
            this.chkEditaFoli = new System.Windows.Forms.CheckBox();
            this.txtDescCorta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveTipoMov = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.tbConfiguracion = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.tbConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSolicitaSucursal
            // 
            this.chkSolicitaSucursal.AutoSize = true;
            this.chkSolicitaSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSolicitaSucursal.Location = new System.Drawing.Point(22, 188);
            this.chkSolicitaSucursal.Name = "chkSolicitaSucursal";
            this.chkSolicitaSucursal.Size = new System.Drawing.Size(129, 21);
            this.chkSolicitaSucursal.TabIndex = 24;
            this.chkSolicitaSucursal.Text = "Solicita sucursal";
            this.chkSolicitaSucursal.UseVisualStyleBackColor = true;
            this.chkSolicitaSucursal.Visible = false;
            // 
            // chkInterno
            // 
            this.chkInterno.AutoSize = true;
            this.chkInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkInterno.Location = new System.Drawing.Point(22, 149);
            this.chkInterno.Name = "chkInterno";
            this.chkInterno.Size = new System.Drawing.Size(91, 21);
            this.chkInterno.TabIndex = 23;
            this.chkInterno.Text = "Es interno";
            this.chkInterno.UseVisualStyleBackColor = true;
            // 
            // cboCfgCatFoliadores
            // 
            this.cboCfgCatFoliadores.Enabled = false;
            this.cboCfgCatFoliadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboCfgCatFoliadores.FormattingEnabled = true;
            this.cboCfgCatFoliadores.Location = new System.Drawing.Point(156, 210);
            this.cboCfgCatFoliadores.Name = "cboCfgCatFoliadores";
            this.cboCfgCatFoliadores.Size = new System.Drawing.Size(251, 24);
            this.cboCfgCatFoliadores.TabIndex = 22;
            // 
            // cboTipoMovRel
            // 
            this.cboTipoMovRel.Enabled = false;
            this.cboTipoMovRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboTipoMovRel.FormattingEnabled = true;
            this.cboTipoMovRel.Location = new System.Drawing.Point(156, 176);
            this.cboTipoMovRel.Name = "cboTipoMovRel";
            this.cboTipoMovRel.Size = new System.Drawing.Size(251, 24);
            this.cboTipoMovRel.TabIndex = 6;
            // 
            // rdbSalida
            // 
            this.rdbSalida.AutoSize = true;
            this.rdbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdbSalida.Location = new System.Drawing.Point(349, 112);
            this.rdbSalida.Name = "rdbSalida";
            this.rdbSalida.Size = new System.Drawing.Size(74, 21);
            this.rdbSalida.TabIndex = 4;
            this.rdbSalida.Text = "SALIDA";
            this.rdbSalida.UseVisualStyleBackColor = true;
            // 
            // rdbEntrada
            // 
            this.rdbEntrada.AutoSize = true;
            this.rdbEntrada.Checked = true;
            this.rdbEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdbEntrada.Location = new System.Drawing.Point(156, 112);
            this.rdbEntrada.Name = "rdbEntrada";
            this.rdbEntrada.Size = new System.Drawing.Size(92, 21);
            this.rdbEntrada.TabIndex = 4;
            this.rdbEntrada.TabStop = true;
            this.rdbEntrada.Text = "ENTRADA";
            this.rdbEntrada.UseVisualStyleBackColor = true;
            // 
            // cboCveClsMov
            // 
            this.cboCveClsMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboCveClsMov.FormattingEnabled = true;
            this.cboCveClsMov.Location = new System.Drawing.Point(156, 142);
            this.cboCveClsMov.Name = "cboCveClsMov";
            this.cboCveClsMov.Size = new System.Drawing.Size(203, 24);
            this.cboCveClsMov.TabIndex = 5;
            this.cboCveClsMov.SelectedValueChanged += new System.EventHandler(this.cboCveClsMov_SelectedValueChanged);
            // 
            // txtFmtoImpresion
            // 
            this.txtFmtoImpresion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFmtoImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFmtoImpresion.Location = new System.Drawing.Point(156, 242);
            this.txtFmtoImpresion.MaxLength = 80;
            this.txtFmtoImpresion.Name = "txtFmtoImpresion";
            this.txtFmtoImpresion.Size = new System.Drawing.Size(323, 23);
            this.txtFmtoImpresion.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(10, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fmto Impresión";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mov. Relacionado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(10, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Foliador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(8, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Clase Movimiento";
            // 
            // chkSugiereCosto
            // 
            this.chkSugiereCosto.AutoSize = true;
            this.chkSugiereCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSugiereCosto.Location = new System.Drawing.Point(22, 63);
            this.chkSugiereCosto.Name = "chkSugiereCosto";
            this.chkSugiereCosto.Size = new System.Drawing.Size(114, 21);
            this.chkSugiereCosto.TabIndex = 12;
            this.chkSugiereCosto.Text = "Sugiere costo";
            this.chkSugiereCosto.UseVisualStyleBackColor = true;
            // 
            // chkAfectaCosto
            // 
            this.chkAfectaCosto.AutoSize = true;
            this.chkAfectaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkAfectaCosto.Location = new System.Drawing.Point(423, 63);
            this.chkAfectaCosto.Name = "chkAfectaCosto";
            this.chkAfectaCosto.Size = new System.Drawing.Size(105, 21);
            this.chkAfectaCosto.TabIndex = 11;
            this.chkAfectaCosto.Text = "Afecta costo";
            this.chkAfectaCosto.UseVisualStyleBackColor = true;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEstatus.Location = new System.Drawing.Point(216, 149);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(65, 21);
            this.chkEstatus.TabIndex = 17;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // chkCalculaIva
            // 
            this.chkCalculaIva.AutoSize = true;
            this.chkCalculaIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkCalculaIva.Location = new System.Drawing.Point(423, 20);
            this.chkCalculaIva.Name = "chkCalculaIva";
            this.chkCalculaIva.Size = new System.Drawing.Size(98, 21);
            this.chkCalculaIva.TabIndex = 16;
            this.chkCalculaIva.Text = "Calcula IVA";
            this.chkCalculaIva.UseVisualStyleBackColor = true;
            // 
            // chkSolicitaCosto
            // 
            this.chkSolicitaCosto.AutoSize = true;
            this.chkSolicitaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSolicitaCosto.Location = new System.Drawing.Point(22, 106);
            this.chkSolicitaCosto.Name = "chkSolicitaCosto";
            this.chkSolicitaCosto.Size = new System.Drawing.Size(110, 21);
            this.chkSolicitaCosto.TabIndex = 15;
            this.chkSolicitaCosto.Text = "Solicita costo";
            this.chkSolicitaCosto.UseVisualStyleBackColor = true;
            // 
            // chkEditaCosto
            // 
            this.chkEditaCosto.AutoSize = true;
            this.chkEditaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditaCosto.Location = new System.Drawing.Point(216, 106);
            this.chkEditaCosto.Name = "chkEditaCosto";
            this.chkEditaCosto.Size = new System.Drawing.Size(97, 21);
            this.chkEditaCosto.TabIndex = 14;
            this.chkEditaCosto.Text = "Edita costo";
            this.chkEditaCosto.UseVisualStyleBackColor = true;
            // 
            // chkMuestraCosto
            // 
            this.chkMuestraCosto.AutoSize = true;
            this.chkMuestraCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkMuestraCosto.Location = new System.Drawing.Point(216, 63);
            this.chkMuestraCosto.Name = "chkMuestraCosto";
            this.chkMuestraCosto.Size = new System.Drawing.Size(116, 21);
            this.chkMuestraCosto.TabIndex = 13;
            this.chkMuestraCosto.Text = "Muestra costo";
            this.chkMuestraCosto.UseVisualStyleBackColor = true;
            // 
            // chkEstraspaso
            // 
            this.chkEstraspaso.AutoSize = true;
            this.chkEstraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEstraspaso.Location = new System.Drawing.Point(216, 20);
            this.chkEstraspaso.Name = "chkEstraspaso";
            this.chkEstraspaso.Size = new System.Drawing.Size(102, 21);
            this.chkEstraspaso.TabIndex = 10;
            this.chkEstraspaso.Text = "Es traspaso";
            this.chkEstraspaso.UseVisualStyleBackColor = true;
            // 
            // chkEditaFoli
            // 
            this.chkEditaFoli.AutoSize = true;
            this.chkEditaFoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditaFoli.Location = new System.Drawing.Point(22, 20);
            this.chkEditaFoli.Name = "chkEditaFoli";
            this.chkEditaFoli.Size = new System.Drawing.Size(89, 21);
            this.chkEditaFoli.TabIndex = 9;
            this.chkEditaFoli.Text = "Edita folio";
            this.chkEditaFoli.UseVisualStyleBackColor = true;
            // 
            // txtDescCorta
            // 
            this.txtDescCorta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescCorta.Location = new System.Drawing.Point(156, 74);
            this.txtDescCorta.MaxLength = 30;
            this.txtDescCorta.Name = "txtDescCorta";
            this.txtDescCorta.Size = new System.Drawing.Size(175, 23);
            this.txtDescCorta.TabIndex = 3;
            this.txtDescCorta.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción Corta";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(156, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(401, 23);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // txtClaveTipoMov
            // 
            this.txtClaveTipoMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveTipoMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtClaveTipoMov.Location = new System.Drawing.Point(156, 10);
            this.txtClaveTipoMov.MaxLength = 10;
            this.txtClaveTipoMov.Name = "txtClaveTipoMov";
            this.txtClaveTipoMov.Size = new System.Drawing.Size(147, 23);
            this.txtClaveTipoMov.TabIndex = 1;
            this.txtClaveTipoMov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveTipoMov_KeyPress);
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCodEmpleado.Location = new System.Drawing.Point(10, 13);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(52, 17);
            this.lblCodEmpleado.TabIndex = 1;
            this.lblCodEmpleado.Text = "Código";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(480, 302);
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
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(375, 302);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 18;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbGeneral);
            this.tabControl1.Controls.Add(this.tbConfiguracion);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 300);
            this.tabControl1.TabIndex = 20;
            // 
            // tbGeneral
            // 
            this.tbGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbGeneral.Controls.Add(this.label4);
            this.tbGeneral.Controls.Add(this.lblCodEmpleado);
            this.tbGeneral.Controls.Add(this.cboCfgCatFoliadores);
            this.tbGeneral.Controls.Add(this.txtClaveTipoMov);
            this.tbGeneral.Controls.Add(this.cboTipoMovRel);
            this.tbGeneral.Controls.Add(this.label2);
            this.tbGeneral.Controls.Add(this.rdbSalida);
            this.tbGeneral.Controls.Add(this.txtDescripcion);
            this.tbGeneral.Controls.Add(this.rdbEntrada);
            this.tbGeneral.Controls.Add(this.label3);
            this.tbGeneral.Controls.Add(this.cboCveClsMov);
            this.tbGeneral.Controls.Add(this.txtDescCorta);
            this.tbGeneral.Controls.Add(this.txtFmtoImpresion);
            this.tbGeneral.Controls.Add(this.label5);
            this.tbGeneral.Controls.Add(this.label7);
            this.tbGeneral.Controls.Add(this.label6);
            this.tbGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneral.Size = new System.Drawing.Size(570, 274);
            this.tbGeneral.TabIndex = 0;
            this.tbGeneral.Text = "General";
            // 
            // tbConfiguracion
            // 
            this.tbConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbConfiguracion.Controls.Add(this.chkSolicitaSucursal);
            this.tbConfiguracion.Controls.Add(this.chkAfectaCosto);
            this.tbConfiguracion.Controls.Add(this.chkInterno);
            this.tbConfiguracion.Controls.Add(this.chkEditaFoli);
            this.tbConfiguracion.Controls.Add(this.chkSugiereCosto);
            this.tbConfiguracion.Controls.Add(this.chkEstraspaso);
            this.tbConfiguracion.Controls.Add(this.chkMuestraCosto);
            this.tbConfiguracion.Controls.Add(this.chkEstatus);
            this.tbConfiguracion.Controls.Add(this.chkEditaCosto);
            this.tbConfiguracion.Controls.Add(this.chkCalculaIva);
            this.tbConfiguracion.Controls.Add(this.chkSolicitaCosto);
            this.tbConfiguracion.Location = new System.Drawing.Point(4, 22);
            this.tbConfiguracion.Name = "tbConfiguracion";
            this.tbConfiguracion.Padding = new System.Windows.Forms.Padding(3);
            this.tbConfiguracion.Size = new System.Drawing.Size(570, 274);
            this.tbConfiguracion.TabIndex = 1;
            this.tbConfiguracion.Text = "Configuración";
            // 
            // frmRegTipoMovtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 339);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegTipoMovtos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de tipo movimientos";
            this.tabControl1.ResumeLayout(false);
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            this.tbConfiguracion.ResumeLayout(false);
            this.tbConfiguracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkSugiereCosto;
        private System.Windows.Forms.CheckBox chkAfectaCosto;
        private System.Windows.Forms.CheckBox chkCalculaIva;
        private System.Windows.Forms.CheckBox chkSolicitaCosto;
        private System.Windows.Forms.CheckBox chkEditaCosto;
        private System.Windows.Forms.CheckBox chkMuestraCosto;
        private System.Windows.Forms.CheckBox chkEstraspaso;
        private System.Windows.Forms.CheckBox chkEditaFoli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFmtoImpresion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescCorta;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtClaveTipoMov;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.ComboBox cboCveClsMov;
        private System.Windows.Forms.RadioButton rdbSalida;
        private System.Windows.Forms.RadioButton rdbEntrada;
        private System.Windows.Forms.ComboBox cboTipoMovRel;
        private System.Windows.Forms.ComboBox cboCfgCatFoliadores;
        private System.Windows.Forms.CheckBox chkInterno;
        private System.Windows.Forms.CheckBox chkSolicitaSucursal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.TabPage tbConfiguracion;
    }
}