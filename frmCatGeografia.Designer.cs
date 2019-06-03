namespace GAFE
{
    partial class frmCatGeografia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatGeografia));
            this.cboPaises = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdEliminarPais = new System.Windows.Forms.Button();
            this.cmdEliminarEstado = new System.Windows.Forms.Button();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEliminarMunicipio = new System.Windows.Forms.Button();
            this.cboMunicipios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdEliminarLocalidad = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAgregar = new System.Windows.Forms.Label();
            this.cmdAgregarLocalidad = new System.Windows.Forms.Button();
            this.cmdAgregarMunicipio = new System.Windows.Forms.Button();
            this.cmdAgregarEstado = new System.Windows.Forms.Button();
            this.cmdAgregarPais = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPaises
            // 
            this.cboPaises.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaises.FormattingEnabled = true;
            this.cboPaises.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboPaises.Location = new System.Drawing.Point(97, 4);
            this.cboPaises.Name = "cboPaises";
            this.cboPaises.Size = new System.Drawing.Size(291, 28);
            this.cboPaises.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Paises";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdEliminarLocalidad);
            this.panel1.Controls.Add(this.cmdEliminarMunicipio);
            this.panel1.Controls.Add(this.cmdAgregarLocalidad);
            this.panel1.Controls.Add(this.cmdAgregarMunicipio);
            this.panel1.Controls.Add(this.cboLocalidad);
            this.panel1.Controls.Add(this.cboMunicipios);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmdEliminarEstado);
            this.panel1.Controls.Add(this.cmdAgregarEstado);
            this.panel1.Controls.Add(this.cboEstados);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdEliminarPais);
            this.panel1.Controls.Add(this.cmdAgregarPais);
            this.panel1.Controls.Add(this.cboPaises);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 401);
            this.panel1.TabIndex = 22;
            // 
            // cmdEliminarPais
            // 
            this.cmdEliminarPais.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminarPais.Enabled = false;
            this.cmdEliminarPais.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarPais.Image")));
            this.cmdEliminarPais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarPais.Location = new System.Drawing.Point(172, 41);
            this.cmdEliminarPais.Name = "cmdEliminarPais";
            this.cmdEliminarPais.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarPais.TabIndex = 22;
            this.cmdEliminarPais.Text = "Pais";
            this.cmdEliminarPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarPais.UseVisualStyleBackColor = false;
            // 
            // cmdEliminarEstado
            // 
            this.cmdEliminarEstado.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminarEstado.Enabled = false;
            this.cmdEliminarEstado.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarEstado.Image")));
            this.cmdEliminarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarEstado.Location = new System.Drawing.Point(172, 145);
            this.cmdEliminarEstado.Name = "cmdEliminarEstado";
            this.cmdEliminarEstado.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarEstado.TabIndex = 28;
            this.cmdEliminarEstado.Text = "Estado";
            this.cmdEliminarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarEstado.UseVisualStyleBackColor = false;
            // 
            // cboEstados
            // 
            this.cboEstados.Enabled = false;
            this.cboEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstados.Location = new System.Drawing.Point(97, 102);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(291, 28);
            this.cboEstados.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Estados";
            // 
            // cmdEliminarMunicipio
            // 
            this.cmdEliminarMunicipio.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminarMunicipio.Enabled = false;
            this.cmdEliminarMunicipio.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarMunicipio.Image")));
            this.cmdEliminarMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarMunicipio.Location = new System.Drawing.Point(172, 250);
            this.cmdEliminarMunicipio.Name = "cmdEliminarMunicipio";
            this.cmdEliminarMunicipio.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarMunicipio.TabIndex = 34;
            this.cmdEliminarMunicipio.Text = "Municipio";
            this.cmdEliminarMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarMunicipio.UseVisualStyleBackColor = false;
            // 
            // cboMunicipios
            // 
            this.cboMunicipios.Enabled = false;
            this.cboMunicipios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMunicipios.FormattingEnabled = true;
            this.cboMunicipios.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboMunicipios.Location = new System.Drawing.Point(97, 216);
            this.cboMunicipios.Name = "cboMunicipios";
            this.cboMunicipios.Size = new System.Drawing.Size(291, 28);
            this.cboMunicipios.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Municipios";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboLocalidad.Location = new System.Drawing.Point(97, 314);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(291, 28);
            this.cboLocalidad.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Localidades";
            // 
            // cmdEliminarLocalidad
            // 
            this.cmdEliminarLocalidad.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminarLocalidad.Enabled = false;
            this.cmdEliminarLocalidad.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarLocalidad.Image")));
            this.cmdEliminarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarLocalidad.Location = new System.Drawing.Point(172, 348);
            this.cmdEliminarLocalidad.Name = "cmdEliminarLocalidad";
            this.cmdEliminarLocalidad.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarLocalidad.TabIndex = 35;
            this.cmdEliminarLocalidad.Text = "Localidad";
            this.cmdEliminarLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarLocalidad.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboEstatus);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.cmdAceptar);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(430, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 169);
            this.panel2.TabIndex = 23;
            // 
            // cboEstatus
            // 
            this.cboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstatus.Location = new System.Drawing.Point(95, 74);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(147, 28);
            this.cboEstatus.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Estatus";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(148, 118);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 11;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(43, 118);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(95, 42);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(276, 26);
            this.txtDescripcion.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Descripción";
            // 
            // lblAgregar
            // 
            this.lblAgregar.AutoSize = true;
            this.lblAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregar.Location = new System.Drawing.Point(443, 67);
            this.lblAgregar.Name = "lblAgregar";
            this.lblAgregar.Size = new System.Drawing.Size(83, 20);
            this.lblAgregar.TabIndex = 20;
            this.lblAgregar.Text = "Agregar a:";
            // 
            // cmdAgregarLocalidad
            // 
            this.cmdAgregarLocalidad.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregarLocalidad.Enabled = false;
            this.cmdAgregarLocalidad.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarLocalidad.Location = new System.Drawing.Point(272, 348);
            this.cmdAgregarLocalidad.Name = "cmdAgregarLocalidad";
            this.cmdAgregarLocalidad.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarLocalidad.TabIndex = 25;
            this.cmdAgregarLocalidad.Text = "Localidad";
            this.cmdAgregarLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarLocalidad.UseVisualStyleBackColor = false;
            // 
            // cmdAgregarMunicipio
            // 
            this.cmdAgregarMunicipio.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregarMunicipio.Enabled = false;
            this.cmdAgregarMunicipio.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarMunicipio.Location = new System.Drawing.Point(272, 250);
            this.cmdAgregarMunicipio.Name = "cmdAgregarMunicipio";
            this.cmdAgregarMunicipio.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarMunicipio.TabIndex = 31;
            this.cmdAgregarMunicipio.Text = "Minicipio";
            this.cmdAgregarMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarMunicipio.UseVisualStyleBackColor = false;
            // 
            // cmdAgregarEstado
            // 
            this.cmdAgregarEstado.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregarEstado.Enabled = false;
            this.cmdAgregarEstado.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarEstado.Location = new System.Drawing.Point(272, 141);
            this.cmdAgregarEstado.Name = "cmdAgregarEstado";
            this.cmdAgregarEstado.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarEstado.TabIndex = 25;
            this.cmdAgregarEstado.Text = "Estado";
            this.cmdAgregarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarEstado.UseVisualStyleBackColor = false;
            // 
            // cmdAgregarPais
            // 
            this.cmdAgregarPais.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregarPais.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarPais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarPais.Location = new System.Drawing.Point(272, 41);
            this.cmdAgregarPais.Name = "cmdAgregarPais";
            this.cmdAgregarPais.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarPais.TabIndex = 2;
            this.cmdAgregarPais.Text = "Pais";
            this.cmdAgregarPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarPais.UseVisualStyleBackColor = false;
            // 
            // frmCatGeografia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 416);
            this.Controls.Add(this.lblAgregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 455);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 455);
            this.Name = "frmCatGeografia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Geografia";
            this.Load += new System.EventHandler(this.frmCatGeografia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPaises;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdEliminarMunicipio;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboMunicipios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdEliminarEstado;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEliminarPais;
        private System.Windows.Forms.Button cmdEliminarLocalidad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEstatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAgregar;
        private System.Windows.Forms.Button cmdAgregarLocalidad;
        private System.Windows.Forms.Button cmdAgregarMunicipio;
        private System.Windows.Forms.Button cmdAgregarEstado;
        private System.Windows.Forms.Button cmdAgregarPais;
    }
}