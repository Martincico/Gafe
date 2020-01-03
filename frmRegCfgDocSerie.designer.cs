namespace GAFE
{
    partial class frmRegCfgDocSerie
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
            this.lblAlmaOri = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.lblTipoMovtos = new System.Windows.Forms.Label();
            this.cboTMovtoProv = new System.Windows.Forms.ComboBox();
            this.cboCfgCatFoliadores = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEditaFoli = new System.Windows.Forms.CheckBox();
            this.txtFmtoImpresion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreImpresora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPregImpresion = new System.Windows.Forms.CheckBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(459, 278);
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
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(354, 278);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 18;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // lblAlmaOri
            // 
            this.lblAlmaOri.AutoSize = true;
            this.lblAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAlmaOri.Location = new System.Drawing.Point(10, 15);
            this.lblAlmaOri.Name = "lblAlmaOri";
            this.lblAlmaOri.Size = new System.Drawing.Size(109, 17);
            this.lblAlmaOri.TabIndex = 20;
            this.lblAlmaOri.Text = "Almacén Origen";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(152, 12);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(264, 24);
            this.cboAlmacen.TabIndex = 21;
            // 
            // lblTipoMovtos
            // 
            this.lblTipoMovtos.AutoSize = true;
            this.lblTipoMovtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTipoMovtos.Location = new System.Drawing.Point(10, 47);
            this.lblTipoMovtos.Name = "lblTipoMovtos";
            this.lblTipoMovtos.Size = new System.Drawing.Size(112, 17);
            this.lblTipoMovtos.TabIndex = 22;
            this.lblTipoMovtos.Text = "Movimiento Prov";
            // 
            // cboTMovtoProv
            // 
            this.cboTMovtoProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboTMovtoProv.FormattingEnabled = true;
            this.cboTMovtoProv.Location = new System.Drawing.Point(152, 44);
            this.cboTMovtoProv.Name = "cboTMovtoProv";
            this.cboTMovtoProv.Size = new System.Drawing.Size(264, 24);
            this.cboTMovtoProv.TabIndex = 23;
            // 
            // cboCfgCatFoliadores
            // 
            this.cboCfgCatFoliadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboCfgCatFoliadores.FormattingEnabled = true;
            this.cboCfgCatFoliadores.Location = new System.Drawing.Point(152, 136);
            this.cboCfgCatFoliadores.Name = "cboCfgCatFoliadores";
            this.cboCfgCatFoliadores.Size = new System.Drawing.Size(336, 24);
            this.cboCfgCatFoliadores.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(10, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Foliador";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSerie.Location = new System.Drawing.Point(152, 76);
            this.txtSerie.MaxLength = 100;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(134, 23);
            this.txtSerie.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Serie";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(152, 106);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(401, 23);
            this.txtDescripcion.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(10, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Descripción";
            // 
            // chkEditaFoli
            // 
            this.chkEditaFoli.AutoSize = true;
            this.chkEditaFoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditaFoli.Location = new System.Drawing.Point(13, 238);
            this.chkEditaFoli.Name = "chkEditaFoli";
            this.chkEditaFoli.Size = new System.Drawing.Size(89, 21);
            this.chkEditaFoli.TabIndex = 44;
            this.chkEditaFoli.Text = "Edita folio";
            this.chkEditaFoli.UseVisualStyleBackColor = true;
            // 
            // txtFmtoImpresion
            // 
            this.txtFmtoImpresion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFmtoImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFmtoImpresion.Location = new System.Drawing.Point(152, 168);
            this.txtFmtoImpresion.MaxLength = 80;
            this.txtFmtoImpresion.Name = "txtFmtoImpresion";
            this.txtFmtoImpresion.Size = new System.Drawing.Size(192, 23);
            this.txtFmtoImpresion.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(10, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Fmto Impresión";
            // 
            // txtNombreImpresora
            // 
            this.txtNombreImpresora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreImpresora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNombreImpresora.Location = new System.Drawing.Point(152, 198);
            this.txtNombreImpresora.MaxLength = 80;
            this.txtNombreImpresora.Name = "txtNombreImpresora";
            this.txtNombreImpresora.Size = new System.Drawing.Size(323, 23);
            this.txtNombreImpresora.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(10, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nombre Impresora";
            // 
            // chkPregImpresion
            // 
            this.chkPregImpresion.AutoSize = true;
            this.chkPregImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkPregImpresion.Location = new System.Drawing.Point(152, 238);
            this.chkPregImpresion.Name = "chkPregImpresion";
            this.chkPregImpresion.Size = new System.Drawing.Size(138, 21);
            this.chkPregImpresion.TabIndex = 49;
            this.chkPregImpresion.Text = "Pregunta imprimir";
            this.chkPregImpresion.UseVisualStyleBackColor = true;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEstatus.Location = new System.Drawing.Point(354, 238);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(65, 21);
            this.chkEstatus.TabIndex = 50;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // frmRegCfgDocSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 323);
            this.Controls.Add(this.chkEstatus);
            this.Controls.Add(this.chkPregImpresion);
            this.Controls.Add(this.txtNombreImpresora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFmtoImpresion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkEditaFoli);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCfgCatFoliadores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTipoMovtos);
            this.Controls.Add(this.cboTMovtoProv);
            this.Controls.Add(this.lblAlmaOri);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCfgDocSerie";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro tipo de documentos";
            this.Load += new System.EventHandler(this.frmRegCfgDocSerie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Label lblAlmaOri;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label lblTipoMovtos;
        private System.Windows.Forms.ComboBox cboTMovtoProv;
        private System.Windows.Forms.ComboBox cboCfgCatFoliadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEditaFoli;
        private System.Windows.Forms.TextBox txtFmtoImpresion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreImpresora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPregImpresion;
        private System.Windows.Forms.CheckBox chkEstatus;
    }
}