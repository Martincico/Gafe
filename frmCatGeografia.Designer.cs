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
            this.cmdEditarLocalidad = new System.Windows.Forms.Button();
            this.cmdEditarMunicipio = new System.Windows.Forms.Button();
            this.cmdEditarEstado = new System.Windows.Forms.Button();
            this.cmdEditarPais = new System.Windows.Forms.Button();
            this.cmdEliminarLocalidad = new System.Windows.Forms.Button();
            this.cmdEliminarMunicipio = new System.Windows.Forms.Button();
            this.cmdAgregarLocalidad = new System.Windows.Forms.Button();
            this.cmdAgregarMunicipio = new System.Windows.Forms.Button();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboMunicipios = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdEliminarEstado = new System.Windows.Forms.Button();
            this.cmdAgregarEstado = new System.Windows.Forms.Button();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEliminarPais = new System.Windows.Forms.Button();
            this.cmdAgregarPais = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEstatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAgregar = new System.Windows.Forms.Label();
            this.cboSyncPaises = new Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSyncPaises.AutoCompleteControl)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPaises
            // 
            this.cboPaises.DisplayMember = "Descripcion";
            this.cboPaises.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboPaises.FormattingEnabled = true;
            this.cboPaises.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboPaises.Location = new System.Drawing.Point(97, 8);
            this.cboPaises.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboPaises.Name = "cboPaises";
            this.cboPaises.Size = new System.Drawing.Size(291, 26);
            this.cboPaises.TabIndex = 20;
            this.cboPaises.Text = "Selecione un Pais";
            this.cboPaises.ValueMember = "Clave";
            this.cboPaises.SelectedIndexChanged += new System.EventHandler(this.cboPaises_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Pais";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdEditarLocalidad);
            this.panel1.Controls.Add(this.cmdEditarMunicipio);
            this.panel1.Controls.Add(this.cmdEditarEstado);
            this.panel1.Controls.Add(this.cmdEditarPais);
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
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 401);
            this.panel1.TabIndex = 22;
            // 
            // cmdEditarLocalidad
            // 
            this.cmdEditarLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEditarLocalidad.Enabled = false;
            this.cmdEditarLocalidad.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditarLocalidad.Image")));
            this.cmdEditarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditarLocalidad.Location = new System.Drawing.Point(295, 348);
            this.cmdEditarLocalidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEditarLocalidad.Name = "cmdEditarLocalidad";
            this.cmdEditarLocalidad.Size = new System.Drawing.Size(94, 36);
            this.cmdEditarLocalidad.TabIndex = 37;
            this.cmdEditarLocalidad.Text = "Localidad";
            this.cmdEditarLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditarLocalidad.UseVisualStyleBackColor = false;
            this.cmdEditarLocalidad.Visible = false;
            this.cmdEditarLocalidad.Click += new System.EventHandler(this.cmdEditarLocalidad_Click);
            // 
            // cmdEditarMunicipio
            // 
            this.cmdEditarMunicipio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEditarMunicipio.Enabled = false;
            this.cmdEditarMunicipio.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditarMunicipio.Image")));
            this.cmdEditarMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditarMunicipio.Location = new System.Drawing.Point(295, 252);
            this.cmdEditarMunicipio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEditarMunicipio.Name = "cmdEditarMunicipio";
            this.cmdEditarMunicipio.Size = new System.Drawing.Size(94, 36);
            this.cmdEditarMunicipio.TabIndex = 39;
            this.cmdEditarMunicipio.Text = "Minicipio";
            this.cmdEditarMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditarMunicipio.UseVisualStyleBackColor = false;
            this.cmdEditarMunicipio.Visible = false;
            this.cmdEditarMunicipio.Click += new System.EventHandler(this.cmdEditarMunicipio_Click);
            // 
            // cmdEditarEstado
            // 
            this.cmdEditarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEditarEstado.Enabled = false;
            this.cmdEditarEstado.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditarEstado.Image")));
            this.cmdEditarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditarEstado.Location = new System.Drawing.Point(295, 139);
            this.cmdEditarEstado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEditarEstado.Name = "cmdEditarEstado";
            this.cmdEditarEstado.Size = new System.Drawing.Size(94, 36);
            this.cmdEditarEstado.TabIndex = 38;
            this.cmdEditarEstado.Text = "Estado";
            this.cmdEditarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditarEstado.UseVisualStyleBackColor = false;
            this.cmdEditarEstado.Visible = false;
            this.cmdEditarEstado.Click += new System.EventHandler(this.cmdEditarEstado_Click);
            // 
            // cmdEditarPais
            // 
            this.cmdEditarPais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEditarPais.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditarPais.Image")));
            this.cmdEditarPais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditarPais.Location = new System.Drawing.Point(295, 40);
            this.cmdEditarPais.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEditarPais.Name = "cmdEditarPais";
            this.cmdEditarPais.Size = new System.Drawing.Size(94, 36);
            this.cmdEditarPais.TabIndex = 36;
            this.cmdEditarPais.Text = "Pais";
            this.cmdEditarPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditarPais.UseVisualStyleBackColor = false;
            this.cmdEditarPais.Visible = false;
            this.cmdEditarPais.Click += new System.EventHandler(this.cmdEditarPais_Click);
            // 
            // cmdEliminarLocalidad
            // 
            this.cmdEliminarLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminarLocalidad.Enabled = false;
            this.cmdEliminarLocalidad.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarLocalidad.Image")));
            this.cmdEliminarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarLocalidad.Location = new System.Drawing.Point(97, 347);
            this.cmdEliminarLocalidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEliminarLocalidad.Name = "cmdEliminarLocalidad";
            this.cmdEliminarLocalidad.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarLocalidad.TabIndex = 35;
            this.cmdEliminarLocalidad.Text = "Localidad";
            this.cmdEliminarLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarLocalidad.UseVisualStyleBackColor = false;
            this.cmdEliminarLocalidad.Visible = false;
            this.cmdEliminarLocalidad.Click += new System.EventHandler(this.cmdEliminarLocalidad_Click);
            // 
            // cmdEliminarMunicipio
            // 
            this.cmdEliminarMunicipio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminarMunicipio.Enabled = false;
            this.cmdEliminarMunicipio.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarMunicipio.Image")));
            this.cmdEliminarMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarMunicipio.Location = new System.Drawing.Point(97, 251);
            this.cmdEliminarMunicipio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEliminarMunicipio.Name = "cmdEliminarMunicipio";
            this.cmdEliminarMunicipio.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarMunicipio.TabIndex = 34;
            this.cmdEliminarMunicipio.Text = "Municipio";
            this.cmdEliminarMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarMunicipio.UseVisualStyleBackColor = false;
            this.cmdEliminarMunicipio.Visible = false;
            this.cmdEliminarMunicipio.Click += new System.EventHandler(this.cmdEliminarMunicipio_Click);
            // 
            // cmdAgregarLocalidad
            // 
            this.cmdAgregarLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregarLocalidad.Enabled = false;
            this.cmdAgregarLocalidad.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarLocalidad.Location = new System.Drawing.Point(197, 347);
            this.cmdAgregarLocalidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdAgregarLocalidad.Name = "cmdAgregarLocalidad";
            this.cmdAgregarLocalidad.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarLocalidad.TabIndex = 25;
            this.cmdAgregarLocalidad.Text = "Localidad";
            this.cmdAgregarLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarLocalidad.UseVisualStyleBackColor = false;
            this.cmdAgregarLocalidad.Visible = false;
            this.cmdAgregarLocalidad.Click += new System.EventHandler(this.cmdAgregarLocalidad_Click);
            // 
            // cmdAgregarMunicipio
            // 
            this.cmdAgregarMunicipio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregarMunicipio.Enabled = false;
            this.cmdAgregarMunicipio.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarMunicipio.Location = new System.Drawing.Point(197, 251);
            this.cmdAgregarMunicipio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdAgregarMunicipio.Name = "cmdAgregarMunicipio";
            this.cmdAgregarMunicipio.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarMunicipio.TabIndex = 31;
            this.cmdAgregarMunicipio.Text = "Minicipio";
            this.cmdAgregarMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarMunicipio.UseVisualStyleBackColor = false;
            this.cmdAgregarMunicipio.Visible = false;
            this.cmdAgregarMunicipio.Click += new System.EventHandler(this.cmdAgregarMunicipio_Click);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.DisplayMember = "Descripcion";
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboLocalidad.Location = new System.Drawing.Point(97, 318);
            this.cboLocalidad.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(291, 26);
            this.cboLocalidad.TabIndex = 26;
            this.cboLocalidad.ValueMember = "Clave";
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboPaises_SelectedIndexChanged);
            // 
            // cboMunicipios
            // 
            this.cboMunicipios.DisplayMember = "Descripcion";
            this.cboMunicipios.Enabled = false;
            this.cboMunicipios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboMunicipios.FormattingEnabled = true;
            this.cboMunicipios.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboMunicipios.Location = new System.Drawing.Point(97, 220);
            this.cboMunicipios.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboMunicipios.Name = "cboMunicipios";
            this.cboMunicipios.Size = new System.Drawing.Size(291, 26);
            this.cboMunicipios.TabIndex = 32;
            this.cboMunicipios.ValueMember = "Clave";
            this.cboMunicipios.SelectedIndexChanged += new System.EventHandler(this.cboPaises_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(6, 319);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(1, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Municipio";
            // 
            // cmdEliminarEstado
            // 
            this.cmdEliminarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminarEstado.Enabled = false;
            this.cmdEliminarEstado.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarEstado.Image")));
            this.cmdEliminarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarEstado.Location = new System.Drawing.Point(97, 138);
            this.cmdEliminarEstado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEliminarEstado.Name = "cmdEliminarEstado";
            this.cmdEliminarEstado.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarEstado.TabIndex = 28;
            this.cmdEliminarEstado.Text = "Estado";
            this.cmdEliminarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarEstado.UseVisualStyleBackColor = false;
            this.cmdEliminarEstado.Visible = false;
            this.cmdEliminarEstado.Click += new System.EventHandler(this.cmdEliminarEstado_Click);
            // 
            // cmdAgregarEstado
            // 
            this.cmdAgregarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregarEstado.Enabled = false;
            this.cmdAgregarEstado.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarEstado.Location = new System.Drawing.Point(197, 138);
            this.cmdAgregarEstado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdAgregarEstado.Name = "cmdAgregarEstado";
            this.cmdAgregarEstado.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarEstado.TabIndex = 25;
            this.cmdAgregarEstado.Text = "Estado";
            this.cmdAgregarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarEstado.UseVisualStyleBackColor = false;
            this.cmdAgregarEstado.Visible = false;
            this.cmdAgregarEstado.Click += new System.EventHandler(this.cmdAgregarEstado_Click);
            // 
            // cboEstados
            // 
            this.cboEstados.DisplayMember = "Descripcion";
            this.cboEstados.Enabled = false;
            this.cboEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstados.Location = new System.Drawing.Point(97, 106);
            this.cboEstados.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(291, 26);
            this.cboEstados.TabIndex = 26;
            this.cboEstados.ValueMember = "Clave";
            this.cboEstados.SelectedIndexChanged += new System.EventHandler(this.cboPaises_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Estado";
            // 
            // cmdEliminarPais
            // 
            this.cmdEliminarPais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminarPais.Enabled = false;
            this.cmdEliminarPais.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminarPais.Image")));
            this.cmdEliminarPais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminarPais.Location = new System.Drawing.Point(97, 39);
            this.cmdEliminarPais.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdEliminarPais.Name = "cmdEliminarPais";
            this.cmdEliminarPais.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminarPais.TabIndex = 22;
            this.cmdEliminarPais.Text = "Pais";
            this.cmdEliminarPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminarPais.UseVisualStyleBackColor = false;
            this.cmdEliminarPais.Visible = false;
            this.cmdEliminarPais.Click += new System.EventHandler(this.cmdEliminarPais_Click);
            // 
            // cmdAgregarPais
            // 
            this.cmdAgregarPais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregarPais.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregarPais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregarPais.Location = new System.Drawing.Point(197, 39);
            this.cmdAgregarPais.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdAgregarPais.Name = "cmdAgregarPais";
            this.cmdAgregarPais.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregarPais.TabIndex = 2;
            this.cmdAgregarPais.Text = "Pais";
            this.cmdAgregarPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregarPais.UseVisualStyleBackColor = false;
            this.cmdAgregarPais.Visible = false;
            this.cmdAgregarPais.Click += new System.EventHandler(this.cmdAgregarPais_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdSeleccionar.Image = global::GAFE.Properties.Resources.Seleccionar;
            this.cmdSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeleccionar.Location = new System.Drawing.Point(212, 407);
            this.cmdSeleccionar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(94, 36);
            this.cmdSeleccionar.TabIndex = 26;
            this.cmdSeleccionar.Text = "Seleccionar";
            this.cmdSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSeleccionar.UseVisualStyleBackColor = false;
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
            this.panel2.Location = new System.Drawing.Point(429, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 176);
            this.panel2.TabIndex = 23;
            // 
            // cboEstatus
            // 
            this.cboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboEstatus.FormattingEnabled = true;
            this.cboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Baja"});
            this.cboEstatus.Location = new System.Drawing.Point(95, 74);
            this.cboEstatus.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboEstatus.Name = "cboEstatus";
            this.cboEstatus.Size = new System.Drawing.Size(147, 26);
            this.cboEstatus.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(5, 77);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "Estatus";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(216, 108);
            this.cmdCancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 11;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(111, 108);
            this.cmdAceptar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(95, 43);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(276, 24);
            this.txtDescripcion.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.Location = new System.Drawing.Point(5, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "Descripción";
            // 
            // lblAgregar
            // 
            this.lblAgregar.AutoSize = true;
            this.lblAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblAgregar.Location = new System.Drawing.Point(442, 5);
            this.lblAgregar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAgregar.Name = "lblAgregar";
            this.lblAgregar.Size = new System.Drawing.Size(75, 18);
            this.lblAgregar.TabIndex = 20;
            this.lblAgregar.Text = "Agregar a:";
            // 
            // cboSyncPaises
            // 
            // 
            // 
            // 
            this.cboSyncPaises.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.cboSyncPaises.AutoCompleteControl.HeaderFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cboSyncPaises.AutoCompleteControl.ItemFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cboSyncPaises.AutoCompleteControl.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.cboSyncPaises.AutoCompleteControl.OverrideCombo = true;
            this.cboSyncPaises.AutoCompleteControl.ParentForm = this;
            this.cboSyncPaises.AutoCompleteControl.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.Default;
            this.cboSyncPaises.AutoCompleteControl.ThemeName = "Default";
            this.cboSyncPaises.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.cboSyncPaises.DataBindings.Add(new System.Windows.Forms.Binding("DisplayMember", global::GAFE.Properties.Settings.Default, "Descripcion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboSyncPaises.DataBindings.Add(new System.Windows.Forms.Binding("ValueMember", global::GAFE.Properties.Settings.Default, "Clave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboSyncPaises.DisplayMember = global::GAFE.Properties.Settings.Default.Descripcion;
            this.cboSyncPaises.DropDownWidth = 121;
            this.cboSyncPaises.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboSyncPaises.Location = new System.Drawing.Point(449, 201);
            this.cboSyncPaises.Name = "cboSyncPaises";
            this.cboSyncPaises.ParentForm = this;
            this.cboSyncPaises.Size = new System.Drawing.Size(352, 26);
            this.cboSyncPaises.TabIndex = 24;
            this.cboSyncPaises.Text = "Seleccione Pais...";
            this.cboSyncPaises.ValueMember = global::GAFE.Properties.Settings.Default.Clave;
            // 
            // frmCatGeografia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(816, 444);
            this.Controls.Add(this.cmdSeleccionar);
            this.Controls.Add(this.cboSyncPaises);
            this.Controls.Add(this.lblAgregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(828, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 480);
            this.Name = "frmCatGeografia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Catálogo de Geografia";
            this.Load += new System.EventHandler(this.frmCatGeografia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSyncPaises.AutoCompleteControl)).EndInit();
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
        private System.Windows.Forms.Button cmdSeleccionar;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete cboSyncPaises;
        private System.Windows.Forms.Button cmdEditarLocalidad;
        private System.Windows.Forms.Button cmdEditarMunicipio;
        private System.Windows.Forms.Button cmdEditarEstado;
        private System.Windows.Forms.Button cmdEditarPais;
    }
}