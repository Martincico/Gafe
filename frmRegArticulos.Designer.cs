namespace GAFE
{
    partial class frmRegArticulos
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
            this.opfFoto = new System.Windows.Forms.OpenFileDialog();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtUMed2 = new System.Windows.Forms.TextBox();
            this.cmdUMed2 = new System.Windows.Forms.Button();
            this.txtUMed3 = new System.Windows.Forms.TextBox();
            this.cmdUMed3 = new System.Windows.Forms.Button();
            this.txtUMed1 = new System.Windows.Forms.TextBox();
            this.cmdUMed1 = new System.Windows.Forms.Button();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.cmdLinea = new System.Windows.Forms.Button();
            this.txtClase3 = new System.Windows.Forms.TextBox();
            this.cmdClase3 = new System.Windows.Forms.Button();
            this.txtClase2 = new System.Windows.Forms.TextBox();
            this.cmdClase2 = new System.Windows.Forms.Button();
            this.txtClase1 = new System.Windows.Forms.TextBox();
            this.cmdClase1 = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.cmdMarca = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblUMed = new System.Windows.Forms.Label();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.lblDescArt = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblClase = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoSAT = new System.Windows.Forms.TextBox();
            this.lblCodB = new System.Windows.Forms.Label();
            this.txtCodigoAlterno = new System.Windows.Forms.TextBox();
            this.lblCveInterna = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.tabImpuestos = new System.Windows.Forms.TabPage();
            this.cmdLimpiarRetISR = new System.Windows.Forms.Button();
            this.cmdLimpiarRetIVA = new System.Windows.Forms.Button();
            this.cmdBorrarIEPS = new System.Windows.Forms.Button();
            this.chkEsServicio = new System.Windows.Forms.CheckBox();
            this.txtRetISR = new System.Windows.Forms.TextBox();
            this.cmdRetISR = new System.Windows.Forms.Button();
            this.lblRetISR = new System.Windows.Forms.Label();
            this.txtRetIVA = new System.Windows.Forms.TextBox();
            this.cmdRetIVA = new System.Windows.Forms.Button();
            this.lblRetIVA = new System.Windows.Forms.Label();
            this.txtImpIESP = new System.Windows.Forms.TextBox();
            this.cmdImpIESP = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.cmdImpuesto = new System.Windows.Forms.Button();
            this.lblImp = new System.Windows.Forms.Label();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.pbArticulo = new System.Windows.Forms.PictureBox();
            this.cmdFoto = new System.Windows.Forms.Button();
            this.chkRequiereReceta = new System.Windows.Forms.CheckBox();
            this.chkDispVenta = new System.Windows.Forms.CheckBox();
            this.chkDispKit = new System.Windows.Forms.CheckBox();
            this.chkEsKit = new System.Windows.Forms.CheckBox();
            this.chkEsInventa = new System.Windows.Forms.CheckBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.tabOtros = new System.Windows.Forms.TabPage();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtultimoProveedor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUltimaCompra = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdLstPrecio = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabImpuestos.SuspendLayout();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).BeginInit();
            this.tabOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // opfFoto
            // 
            this.opfFoto.Filter = "Imagenes | *.JPG;*.PNG;*.BMP";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(634, 299);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 16;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Aceptar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(518, 299);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 15;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabImpuestos);
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabOtros);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 294);
            this.tabControl1.TabIndex = 1332;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabGeneral.Controls.Add(this.txtUMed2);
            this.tabGeneral.Controls.Add(this.cmdUMed2);
            this.tabGeneral.Controls.Add(this.txtUMed3);
            this.tabGeneral.Controls.Add(this.cmdUMed3);
            this.tabGeneral.Controls.Add(this.txtUMed1);
            this.tabGeneral.Controls.Add(this.cmdUMed1);
            this.tabGeneral.Controls.Add(this.txtLinea);
            this.tabGeneral.Controls.Add(this.cmdLinea);
            this.tabGeneral.Controls.Add(this.txtClase3);
            this.tabGeneral.Controls.Add(this.cmdClase3);
            this.tabGeneral.Controls.Add(this.txtClase2);
            this.tabGeneral.Controls.Add(this.cmdClase2);
            this.tabGeneral.Controls.Add(this.txtClase1);
            this.tabGeneral.Controls.Add(this.cmdClase1);
            this.tabGeneral.Controls.Add(this.txtMarca);
            this.tabGeneral.Controls.Add(this.cmdMarca);
            this.tabGeneral.Controls.Add(this.label7);
            this.tabGeneral.Controls.Add(this.label14);
            this.tabGeneral.Controls.Add(this.lblMarca);
            this.tabGeneral.Controls.Add(this.lblUMed);
            this.tabGeneral.Controls.Add(this.txtClaveArticulo);
            this.tabGeneral.Controls.Add(this.lblDescArt);
            this.tabGeneral.Controls.Add(this.txtDescripcion);
            this.tabGeneral.Controls.Add(this.label9);
            this.tabGeneral.Controls.Add(this.label10);
            this.tabGeneral.Controls.Add(this.lblClase);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtCodigoSAT);
            this.tabGeneral.Controls.Add(this.lblCodB);
            this.tabGeneral.Controls.Add(this.txtCodigoAlterno);
            this.tabGeneral.Controls.Add(this.lblCveInterna);
            this.tabGeneral.Controls.Add(this.lblLinea);
            this.tabGeneral.Controls.Add(this.txtCodigoBarras);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(726, 268);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // txtUMed2
            // 
            this.txtUMed2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUMed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUMed2.Location = new System.Drawing.Point(142, 230);
            this.txtUMed2.MaxLength = 20;
            this.txtUMed2.Name = "txtUMed2";
            this.txtUMed2.ReadOnly = true;
            this.txtUMed2.Size = new System.Drawing.Size(135, 22);
            this.txtUMed2.TabIndex = 1364;
            this.txtUMed2.TabStop = false;
            // 
            // cmdUMed2
            // 
            this.cmdUMed2.BackColor = System.Drawing.Color.White;
            this.cmdUMed2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUMed2.Location = new System.Drawing.Point(105, 231);
            this.cmdUMed2.Name = "cmdUMed2";
            this.cmdUMed2.Size = new System.Drawing.Size(31, 22);
            this.cmdUMed2.TabIndex = 1363;
            this.cmdUMed2.Text = "...";
            this.cmdUMed2.UseVisualStyleBackColor = false;
            this.cmdUMed2.Click += new System.EventHandler(this.cmdUMed2_Click);
            // 
            // txtUMed3
            // 
            this.txtUMed3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUMed3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUMed3.Location = new System.Drawing.Point(485, 208);
            this.txtUMed3.MaxLength = 20;
            this.txtUMed3.Name = "txtUMed3";
            this.txtUMed3.ReadOnly = true;
            this.txtUMed3.Size = new System.Drawing.Size(135, 22);
            this.txtUMed3.TabIndex = 1362;
            this.txtUMed3.TabStop = false;
            // 
            // cmdUMed3
            // 
            this.cmdUMed3.BackColor = System.Drawing.Color.White;
            this.cmdUMed3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUMed3.Location = new System.Drawing.Point(448, 209);
            this.cmdUMed3.Name = "cmdUMed3";
            this.cmdUMed3.Size = new System.Drawing.Size(31, 22);
            this.cmdUMed3.TabIndex = 1361;
            this.cmdUMed3.Text = "...";
            this.cmdUMed3.UseVisualStyleBackColor = false;
            this.cmdUMed3.Click += new System.EventHandler(this.cmdUMed3_Click);
            // 
            // txtUMed1
            // 
            this.txtUMed1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUMed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUMed1.Location = new System.Drawing.Point(142, 202);
            this.txtUMed1.MaxLength = 20;
            this.txtUMed1.Name = "txtUMed1";
            this.txtUMed1.ReadOnly = true;
            this.txtUMed1.Size = new System.Drawing.Size(135, 22);
            this.txtUMed1.TabIndex = 1360;
            this.txtUMed1.TabStop = false;
            // 
            // cmdUMed1
            // 
            this.cmdUMed1.BackColor = System.Drawing.Color.White;
            this.cmdUMed1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUMed1.Location = new System.Drawing.Point(105, 203);
            this.cmdUMed1.Name = "cmdUMed1";
            this.cmdUMed1.Size = new System.Drawing.Size(31, 22);
            this.cmdUMed1.TabIndex = 1359;
            this.cmdUMed1.Text = "...";
            this.cmdUMed1.UseVisualStyleBackColor = false;
            this.cmdUMed1.Click += new System.EventHandler(this.cmdUMed1_Click);
            // 
            // txtLinea
            // 
            this.txtLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtLinea.Location = new System.Drawing.Point(142, 174);
            this.txtLinea.MaxLength = 20;
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.ReadOnly = true;
            this.txtLinea.Size = new System.Drawing.Size(309, 22);
            this.txtLinea.TabIndex = 1358;
            this.txtLinea.TabStop = false;
            // 
            // cmdLinea
            // 
            this.cmdLinea.BackColor = System.Drawing.Color.White;
            this.cmdLinea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLinea.Location = new System.Drawing.Point(105, 174);
            this.cmdLinea.Name = "cmdLinea";
            this.cmdLinea.Size = new System.Drawing.Size(31, 22);
            this.cmdLinea.TabIndex = 1357;
            this.cmdLinea.Text = "...";
            this.cmdLinea.UseVisualStyleBackColor = false;
            this.cmdLinea.Click += new System.EventHandler(this.cmdLinea_Click);
            // 
            // txtClase3
            // 
            this.txtClase3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClase3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClase3.Location = new System.Drawing.Point(142, 146);
            this.txtClase3.MaxLength = 20;
            this.txtClase3.Name = "txtClase3";
            this.txtClase3.ReadOnly = true;
            this.txtClase3.Size = new System.Drawing.Size(226, 22);
            this.txtClase3.TabIndex = 1356;
            this.txtClase3.TabStop = false;
            // 
            // cmdClase3
            // 
            this.cmdClase3.BackColor = System.Drawing.Color.White;
            this.cmdClase3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClase3.Location = new System.Drawing.Point(105, 147);
            this.cmdClase3.Name = "cmdClase3";
            this.cmdClase3.Size = new System.Drawing.Size(31, 22);
            this.cmdClase3.TabIndex = 1355;
            this.cmdClase3.Text = "...";
            this.cmdClase3.UseVisualStyleBackColor = false;
            this.cmdClase3.Click += new System.EventHandler(this.cmdClase3_Click);
            // 
            // txtClase2
            // 
            this.txtClase2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClase2.Location = new System.Drawing.Point(485, 115);
            this.txtClase2.MaxLength = 20;
            this.txtClase2.Name = "txtClase2";
            this.txtClase2.ReadOnly = true;
            this.txtClase2.Size = new System.Drawing.Size(226, 22);
            this.txtClase2.TabIndex = 1354;
            this.txtClase2.TabStop = false;
            // 
            // cmdClase2
            // 
            this.cmdClase2.BackColor = System.Drawing.Color.White;
            this.cmdClase2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClase2.Location = new System.Drawing.Point(448, 116);
            this.cmdClase2.Name = "cmdClase2";
            this.cmdClase2.Size = new System.Drawing.Size(31, 22);
            this.cmdClase2.TabIndex = 1353;
            this.cmdClase2.Text = "...";
            this.cmdClase2.UseVisualStyleBackColor = false;
            this.cmdClase2.Click += new System.EventHandler(this.cmdClase2_Click);
            // 
            // txtClase1
            // 
            this.txtClase1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClase1.Location = new System.Drawing.Point(142, 118);
            this.txtClase1.MaxLength = 20;
            this.txtClase1.Name = "txtClase1";
            this.txtClase1.ReadOnly = true;
            this.txtClase1.Size = new System.Drawing.Size(226, 22);
            this.txtClase1.TabIndex = 1352;
            this.txtClase1.TabStop = false;
            // 
            // cmdClase1
            // 
            this.cmdClase1.BackColor = System.Drawing.Color.White;
            this.cmdClase1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClase1.Location = new System.Drawing.Point(105, 119);
            this.cmdClase1.Name = "cmdClase1";
            this.cmdClase1.Size = new System.Drawing.Size(31, 22);
            this.cmdClase1.TabIndex = 1351;
            this.cmdClase1.Text = "...";
            this.cmdClase1.UseVisualStyleBackColor = false;
            this.cmdClase1.Click += new System.EventHandler(this.cmdClase1_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMarca.Location = new System.Drawing.Point(142, 90);
            this.txtMarca.MaxLength = 20;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(199, 22);
            this.txtMarca.TabIndex = 1349;
            this.txtMarca.TabStop = false;
            // 
            // cmdMarca
            // 
            this.cmdMarca.BackColor = System.Drawing.Color.White;
            this.cmdMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMarca.Location = new System.Drawing.Point(105, 89);
            this.cmdMarca.Name = "cmdMarca";
            this.cmdMarca.Size = new System.Drawing.Size(31, 22);
            this.cmdMarca.TabIndex = 1348;
            this.cmdMarca.Text = "...";
            this.cmdMarca.UseVisualStyleBackColor = false;
            this.cmdMarca.Click += new System.EventHandler(this.cmdMarca_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(10, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 1338;
            this.label7.Text = "U Medida 2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label14.Location = new System.Drawing.Point(335, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 1339;
            this.label14.Text = "U Med equival";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(10, 93);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(46, 16);
            this.lblMarca.TabIndex = 1347;
            this.lblMarca.Text = "Marca";
            // 
            // lblUMed
            // 
            this.lblUMed.AutoSize = true;
            this.lblUMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUMed.Location = new System.Drawing.Point(10, 205);
            this.lblUMed.Name = "lblUMed";
            this.lblUMed.Size = new System.Drawing.Size(67, 16);
            this.lblUMed.TabIndex = 1337;
            this.lblUMed.Text = "U Medida";
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClaveArticulo.Location = new System.Drawing.Point(105, 6);
            this.txtClaveArticulo.MaxLength = 10;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.Size = new System.Drawing.Size(147, 22);
            this.txtClaveArticulo.TabIndex = 1;
            this.txtClaveArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveArticulo_KeyPress);
            // 
            // lblDescArt
            // 
            this.lblDescArt.AutoSize = true;
            this.lblDescArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescArt.ForeColor = System.Drawing.Color.Black;
            this.lblDescArt.Location = new System.Drawing.Point(10, 65);
            this.lblDescArt.Name = "lblDescArt";
            this.lblDescArt.Size = new System.Drawing.Size(80, 16);
            this.lblDescArt.TabIndex = 1324;
            this.lblDescArt.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(105, 62);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(606, 22);
            this.txtDescripcion.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(377, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 1333;
            this.label9.Text = "Clase 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(10, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 1334;
            this.label10.Text = "Clase 3";
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblClase.Location = new System.Drawing.Point(10, 121);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(43, 16);
            this.lblClase.TabIndex = 1335;
            this.lblClase.Text = "Clase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(371, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 1328;
            this.label4.Text = "Codigo SAT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(371, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 1327;
            this.label3.Text = "Código Alterno";
            // 
            // txtCodigoSAT
            // 
            this.txtCodigoSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSAT.Enabled = false;
            this.txtCodigoSAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoSAT.Location = new System.Drawing.Point(479, 34);
            this.txtCodigoSAT.MaxLength = 50;
            this.txtCodigoSAT.Name = "txtCodigoSAT";
            this.txtCodigoSAT.Size = new System.Drawing.Size(232, 22);
            this.txtCodigoSAT.TabIndex = 4;
            this.txtCodigoSAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSAT_KeyPress);
            // 
            // lblCodB
            // 
            this.lblCodB.AutoSize = true;
            this.lblCodB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodB.Location = new System.Drawing.Point(10, 37);
            this.lblCodB.Name = "lblCodB";
            this.lblCodB.Size = new System.Drawing.Size(95, 16);
            this.lblCodB.TabIndex = 1326;
            this.lblCodB.Text = "Código Barras";
            // 
            // txtCodigoAlterno
            // 
            this.txtCodigoAlterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoAlterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoAlterno.Location = new System.Drawing.Point(479, 7);
            this.txtCodigoAlterno.MaxLength = 10;
            this.txtCodigoAlterno.Name = "txtCodigoAlterno";
            this.txtCodigoAlterno.Size = new System.Drawing.Size(232, 22);
            this.txtCodigoAlterno.TabIndex = 2;
            this.txtCodigoAlterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoAlterno_KeyPress);
            // 
            // lblCveInterna
            // 
            this.lblCveInterna.AutoSize = true;
            this.lblCveInterna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCveInterna.Location = new System.Drawing.Point(10, 10);
            this.lblCveInterna.Name = "lblCveInterna";
            this.lblCveInterna.Size = new System.Drawing.Size(86, 16);
            this.lblCveInterna.TabIndex = 1323;
            this.lblCveInterna.Text = "Clave interna";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblLinea.Location = new System.Drawing.Point(10, 177);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(41, 16);
            this.lblLinea.TabIndex = 1329;
            this.lblLinea.Text = "Línea";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarras.Location = new System.Drawing.Point(105, 34);
            this.txtCodigoBarras.MaxLength = 20;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(222, 22);
            this.txtCodigoBarras.TabIndex = 3;
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            // 
            // tabImpuestos
            // 
            this.tabImpuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabImpuestos.Controls.Add(this.cmdLimpiarRetISR);
            this.tabImpuestos.Controls.Add(this.cmdLimpiarRetIVA);
            this.tabImpuestos.Controls.Add(this.cmdBorrarIEPS);
            this.tabImpuestos.Controls.Add(this.chkEsServicio);
            this.tabImpuestos.Controls.Add(this.txtRetISR);
            this.tabImpuestos.Controls.Add(this.cmdRetISR);
            this.tabImpuestos.Controls.Add(this.lblRetISR);
            this.tabImpuestos.Controls.Add(this.txtRetIVA);
            this.tabImpuestos.Controls.Add(this.cmdRetIVA);
            this.tabImpuestos.Controls.Add(this.lblRetIVA);
            this.tabImpuestos.Controls.Add(this.txtImpIESP);
            this.tabImpuestos.Controls.Add(this.cmdImpIESP);
            this.tabImpuestos.Controls.Add(this.label18);
            this.tabImpuestos.Controls.Add(this.txtImpuesto);
            this.tabImpuestos.Controls.Add(this.cmdImpuesto);
            this.tabImpuestos.Controls.Add(this.lblImp);
            this.tabImpuestos.Location = new System.Drawing.Point(4, 22);
            this.tabImpuestos.Name = "tabImpuestos";
            this.tabImpuestos.Padding = new System.Windows.Forms.Padding(3);
            this.tabImpuestos.Size = new System.Drawing.Size(726, 268);
            this.tabImpuestos.TabIndex = 9;
            this.tabImpuestos.Text = "Impuestos";
            // 
            // cmdLimpiarRetISR
            // 
            this.cmdLimpiarRetISR.BackColor = System.Drawing.Color.White;
            this.cmdLimpiarRetISR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLimpiarRetISR.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdLimpiarRetISR.Location = new System.Drawing.Point(310, 202);
            this.cmdLimpiarRetISR.Name = "cmdLimpiarRetISR";
            this.cmdLimpiarRetISR.Size = new System.Drawing.Size(26, 22);
            this.cmdLimpiarRetISR.TabIndex = 1385;
            this.cmdLimpiarRetISR.UseVisualStyleBackColor = false;
            this.cmdLimpiarRetISR.Click += new System.EventHandler(this.cmdLimpiarRetISR_Click);
            // 
            // cmdLimpiarRetIVA
            // 
            this.cmdLimpiarRetIVA.BackColor = System.Drawing.Color.White;
            this.cmdLimpiarRetIVA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLimpiarRetIVA.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdLimpiarRetIVA.Location = new System.Drawing.Point(310, 156);
            this.cmdLimpiarRetIVA.Name = "cmdLimpiarRetIVA";
            this.cmdLimpiarRetIVA.Size = new System.Drawing.Size(26, 22);
            this.cmdLimpiarRetIVA.TabIndex = 1384;
            this.cmdLimpiarRetIVA.UseVisualStyleBackColor = false;
            this.cmdLimpiarRetIVA.Click += new System.EventHandler(this.cmdLimpiarRetIVA_Click);
            // 
            // cmdBorrarIEPS
            // 
            this.cmdBorrarIEPS.BackColor = System.Drawing.Color.White;
            this.cmdBorrarIEPS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarIEPS.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdBorrarIEPS.Location = new System.Drawing.Point(310, 66);
            this.cmdBorrarIEPS.Name = "cmdBorrarIEPS";
            this.cmdBorrarIEPS.Size = new System.Drawing.Size(26, 22);
            this.cmdBorrarIEPS.TabIndex = 1383;
            this.cmdBorrarIEPS.UseVisualStyleBackColor = false;
            this.cmdBorrarIEPS.Click += new System.EventHandler(this.cmdBorrarIEPS_Click);
            // 
            // chkEsServicio
            // 
            this.chkEsServicio.AutoSize = true;
            this.chkEsServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsServicio.Location = new System.Drawing.Point(104, 112);
            this.chkEsServicio.Name = "chkEsServicio";
            this.chkEsServicio.Size = new System.Drawing.Size(95, 20);
            this.chkEsServicio.TabIndex = 1382;
            this.chkEsServicio.Text = "Es Servicio";
            this.chkEsServicio.UseVisualStyleBackColor = true;
            this.chkEsServicio.CheckedChanged += new System.EventHandler(this.chkEsServicio_CheckedChanged);
            // 
            // txtRetISR
            // 
            this.txtRetISR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRetISR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtRetISR.Location = new System.Drawing.Point(141, 202);
            this.txtRetISR.MaxLength = 20;
            this.txtRetISR.Name = "txtRetISR";
            this.txtRetISR.ReadOnly = true;
            this.txtRetISR.Size = new System.Drawing.Size(163, 22);
            this.txtRetISR.TabIndex = 1381;
            this.txtRetISR.TabStop = false;
            // 
            // cmdRetISR
            // 
            this.cmdRetISR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdRetISR.Enabled = false;
            this.cmdRetISR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRetISR.Location = new System.Drawing.Point(104, 202);
            this.cmdRetISR.Name = "cmdRetISR";
            this.cmdRetISR.Size = new System.Drawing.Size(31, 22);
            this.cmdRetISR.TabIndex = 1380;
            this.cmdRetISR.Text = "...";
            this.cmdRetISR.UseVisualStyleBackColor = false;
            this.cmdRetISR.Click += new System.EventHandler(this.cmdRetISR_Click);
            // 
            // lblRetISR
            // 
            this.lblRetISR.AutoSize = true;
            this.lblRetISR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRetISR.Location = new System.Drawing.Point(26, 208);
            this.lblRetISR.Name = "lblRetISR";
            this.lblRetISR.Size = new System.Drawing.Size(57, 16);
            this.lblRetISR.TabIndex = 1379;
            this.lblRetISR.Text = "Ret. ISR";
            // 
            // txtRetIVA
            // 
            this.txtRetIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRetIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtRetIVA.Location = new System.Drawing.Point(141, 156);
            this.txtRetIVA.MaxLength = 20;
            this.txtRetIVA.Name = "txtRetIVA";
            this.txtRetIVA.ReadOnly = true;
            this.txtRetIVA.Size = new System.Drawing.Size(163, 22);
            this.txtRetIVA.TabIndex = 1378;
            this.txtRetIVA.TabStop = false;
            // 
            // cmdRetIVA
            // 
            this.cmdRetIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdRetIVA.Enabled = false;
            this.cmdRetIVA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRetIVA.Location = new System.Drawing.Point(104, 156);
            this.cmdRetIVA.Name = "cmdRetIVA";
            this.cmdRetIVA.Size = new System.Drawing.Size(31, 22);
            this.cmdRetIVA.TabIndex = 1377;
            this.cmdRetIVA.Text = "...";
            this.cmdRetIVA.UseVisualStyleBackColor = false;
            this.cmdRetIVA.Click += new System.EventHandler(this.cmdRetIVA_Click);
            // 
            // lblRetIVA
            // 
            this.lblRetIVA.AutoSize = true;
            this.lblRetIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRetIVA.Location = new System.Drawing.Point(26, 159);
            this.lblRetIVA.Name = "lblRetIVA";
            this.lblRetIVA.Size = new System.Drawing.Size(56, 16);
            this.lblRetIVA.TabIndex = 1376;
            this.lblRetIVA.Text = "Ret. IVA";
            // 
            // txtImpIESP
            // 
            this.txtImpIESP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImpIESP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpIESP.Location = new System.Drawing.Point(141, 66);
            this.txtImpIESP.MaxLength = 20;
            this.txtImpIESP.Name = "txtImpIESP";
            this.txtImpIESP.ReadOnly = true;
            this.txtImpIESP.Size = new System.Drawing.Size(163, 22);
            this.txtImpIESP.TabIndex = 1375;
            this.txtImpIESP.TabStop = false;
            // 
            // cmdImpIESP
            // 
            this.cmdImpIESP.BackColor = System.Drawing.Color.White;
            this.cmdImpIESP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImpIESP.Location = new System.Drawing.Point(104, 66);
            this.cmdImpIESP.Name = "cmdImpIESP";
            this.cmdImpIESP.Size = new System.Drawing.Size(31, 22);
            this.cmdImpIESP.TabIndex = 1374;
            this.cmdImpIESP.Text = "...";
            this.cmdImpIESP.UseVisualStyleBackColor = false;
            this.cmdImpIESP.Click += new System.EventHandler(this.cmdImpIESP_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label18.Location = new System.Drawing.Point(26, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 16);
            this.label18.TabIndex = 1373;
            this.label18.Text = "IESP";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtImpuesto.Location = new System.Drawing.Point(141, 19);
            this.txtImpuesto.MaxLength = 20;
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(163, 22);
            this.txtImpuesto.TabIndex = 1372;
            this.txtImpuesto.TabStop = false;
            // 
            // cmdImpuesto
            // 
            this.cmdImpuesto.BackColor = System.Drawing.Color.White;
            this.cmdImpuesto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImpuesto.Location = new System.Drawing.Point(104, 20);
            this.cmdImpuesto.Name = "cmdImpuesto";
            this.cmdImpuesto.Size = new System.Drawing.Size(31, 22);
            this.cmdImpuesto.TabIndex = 1371;
            this.cmdImpuesto.Text = "...";
            this.cmdImpuesto.UseVisualStyleBackColor = false;
            this.cmdImpuesto.Click += new System.EventHandler(this.cmdImpuesto_Click);
            // 
            // lblImp
            // 
            this.lblImp.AutoSize = true;
            this.lblImp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblImp.Location = new System.Drawing.Point(26, 22);
            this.lblImp.Name = "lblImp";
            this.lblImp.Size = new System.Drawing.Size(29, 16);
            this.lblImp.TabIndex = 1370;
            this.lblImp.Text = "IVA";
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabConfig.Controls.Add(this.pbArticulo);
            this.tabConfig.Controls.Add(this.cmdFoto);
            this.tabConfig.Controls.Add(this.chkRequiereReceta);
            this.tabConfig.Controls.Add(this.chkDispVenta);
            this.tabConfig.Controls.Add(this.chkDispKit);
            this.tabConfig.Controls.Add(this.chkEsKit);
            this.tabConfig.Controls.Add(this.chkEsInventa);
            this.tabConfig.Controls.Add(this.chkEstatus);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(726, 268);
            this.tabConfig.TabIndex = 8;
            this.tabConfig.Text = "Configuración";
            // 
            // pbArticulo
            // 
            this.pbArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbArticulo.Image = global::GAFE.Properties.Resources.Image;
            this.pbArticulo.Location = new System.Drawing.Point(458, 11);
            this.pbArticulo.Name = "pbArticulo";
            this.pbArticulo.Size = new System.Drawing.Size(265, 240);
            this.pbArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArticulo.TabIndex = 1363;
            this.pbArticulo.TabStop = false;
            // 
            // cmdFoto
            // 
            this.cmdFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdFoto.Image = global::GAFE.Properties.Resources.Seleccionar;
            this.cmdFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFoto.Location = new System.Drawing.Point(345, 11);
            this.cmdFoto.Name = "cmdFoto";
            this.cmdFoto.Size = new System.Drawing.Size(107, 39);
            this.cmdFoto.TabIndex = 1364;
            this.cmdFoto.Text = "Seleccionar";
            this.cmdFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFoto.UseVisualStyleBackColor = false;
            this.cmdFoto.Click += new System.EventHandler(this.cmdFoto_Click);
            // 
            // chkRequiereReceta
            // 
            this.chkRequiereReceta.AutoSize = true;
            this.chkRequiereReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkRequiereReceta.Location = new System.Drawing.Point(14, 146);
            this.chkRequiereReceta.Name = "chkRequiereReceta";
            this.chkRequiereReceta.Size = new System.Drawing.Size(172, 20);
            this.chkRequiereReceta.TabIndex = 1362;
            this.chkRequiereReceta.Text = "Requiere receta médica";
            this.chkRequiereReceta.UseVisualStyleBackColor = true;
            // 
            // chkDispVenta
            // 
            this.chkDispVenta.AutoSize = true;
            this.chkDispVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDispVenta.Location = new System.Drawing.Point(14, 101);
            this.chkDispVenta.Name = "chkDispVenta";
            this.chkDispVenta.Size = new System.Drawing.Size(159, 20);
            this.chkDispVenta.TabIndex = 1358;
            this.chkDispVenta.Text = "Disponible para venta";
            this.chkDispVenta.UseVisualStyleBackColor = true;
            // 
            // chkDispKit
            // 
            this.chkDispKit.AutoSize = true;
            this.chkDispKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDispKit.Location = new System.Drawing.Point(14, 191);
            this.chkDispKit.Name = "chkDispKit";
            this.chkDispKit.Size = new System.Drawing.Size(109, 20);
            this.chkDispKit.TabIndex = 1360;
            this.chkDispKit.Text = "Disponible Kit";
            this.chkDispKit.UseVisualStyleBackColor = true;
            this.chkDispKit.Visible = false;
            // 
            // chkEsKit
            // 
            this.chkEsKit.AutoSize = true;
            this.chkEsKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsKit.Location = new System.Drawing.Point(14, 236);
            this.chkEsKit.Name = "chkEsKit";
            this.chkEsKit.Size = new System.Drawing.Size(60, 20);
            this.chkEsKit.TabIndex = 1361;
            this.chkEsKit.Text = "Es Kit";
            this.chkEsKit.UseVisualStyleBackColor = true;
            this.chkEsKit.Visible = false;
            // 
            // chkEsInventa
            // 
            this.chkEsInventa.AutoSize = true;
            this.chkEsInventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsInventa.Location = new System.Drawing.Point(14, 56);
            this.chkEsInventa.Name = "chkEsInventa";
            this.chkEsInventa.Size = new System.Drawing.Size(104, 20);
            this.chkEsInventa.TabIndex = 1357;
            this.chkEsInventa.Text = "Inventariable";
            this.chkEsInventa.UseVisualStyleBackColor = true;
            this.chkEsInventa.CheckedChanged += new System.EventHandler(this.chkEsInventa_CheckedChanged);
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEstatus.Location = new System.Drawing.Point(14, 11);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(64, 20);
            this.chkEstatus.TabIndex = 1356;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // tabOtros
            // 
            this.tabOtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabOtros.Controls.Add(this.txtObservaciones);
            this.tabOtros.Controls.Add(this.label17);
            this.tabOtros.Controls.Add(this.dtFechaAlta);
            this.tabOtros.Controls.Add(this.label5);
            this.tabOtros.Controls.Add(this.txtultimoProveedor);
            this.tabOtros.Controls.Add(this.label16);
            this.tabOtros.Controls.Add(this.txtUltimaCompra);
            this.tabOtros.Controls.Add(this.label15);
            this.tabOtros.Location = new System.Drawing.Point(4, 22);
            this.tabOtros.Name = "tabOtros";
            this.tabOtros.Size = new System.Drawing.Size(726, 268);
            this.tabOtros.TabIndex = 7;
            this.tabOtros.Text = "Otros";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtObservaciones.Location = new System.Drawing.Point(149, 112);
            this.txtObservaciones.MaxLength = 200;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(566, 102);
            this.txtObservaciones.TabIndex = 1334;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label17.Location = new System.Drawing.Point(10, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 16);
            this.label17.TabIndex = 1333;
            this.label17.Text = "Observaciones";
            // 
            // dtFechaAlta
            // 
            this.dtFechaAlta.CustomFormat = "yyyyyy/MM/dd hh:mm:ss";
            this.dtFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtFechaAlta.Location = new System.Drawing.Point(149, 77);
            this.dtFechaAlta.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtFechaAlta.Name = "dtFechaAlta";
            this.dtFechaAlta.Size = new System.Drawing.Size(257, 22);
            this.dtFechaAlta.TabIndex = 1332;
            this.dtFechaAlta.Value = new System.DateTime(2019, 4, 24, 23, 59, 59, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(10, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 1331;
            this.label5.Text = "Fecha Alta";
            // 
            // txtultimoProveedor
            // 
            this.txtultimoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtultimoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtultimoProveedor.Location = new System.Drawing.Point(149, 42);
            this.txtultimoProveedor.MaxLength = 20;
            this.txtultimoProveedor.Name = "txtultimoProveedor";
            this.txtultimoProveedor.ReadOnly = true;
            this.txtultimoProveedor.Size = new System.Drawing.Size(222, 22);
            this.txtultimoProveedor.TabIndex = 1308;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label16.Location = new System.Drawing.Point(10, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 16);
            this.label16.TabIndex = 1306;
            this.label16.Text = "Ultimo Proveedor";
            // 
            // txtUltimaCompra
            // 
            this.txtUltimaCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUltimaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUltimaCompra.Location = new System.Drawing.Point(149, 7);
            this.txtUltimaCompra.MaxLength = 20;
            this.txtUltimaCompra.Name = "txtUltimaCompra";
            this.txtUltimaCompra.ReadOnly = true;
            this.txtUltimaCompra.Size = new System.Drawing.Size(222, 22);
            this.txtUltimaCompra.TabIndex = 1307;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label15.Location = new System.Drawing.Point(10, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 16);
            this.label15.TabIndex = 1305;
            this.label15.Text = "Última Compra";
            // 
            // cmdLstPrecio
            // 
            this.cmdLstPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdLstPrecio.Image = global::GAFE.Properties.Resources.UnCheck;
            this.cmdLstPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLstPrecio.Location = new System.Drawing.Point(2, 299);
            this.cmdLstPrecio.Name = "cmdLstPrecio";
            this.cmdLstPrecio.Size = new System.Drawing.Size(111, 36);
            this.cmdLstPrecio.TabIndex = 1333;
            this.cmdLstPrecio.Text = "Listas precio";
            this.cmdLstPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLstPrecio.UseVisualStyleBackColor = false;
            this.cmdLstPrecio.Visible = false;
            this.cmdLstPrecio.Click += new System.EventHandler(this.cmdLstPrecio_Click);
            // 
            // frmRegArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 339);
            this.Controls.Add(this.cmdLstPrecio);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegArticulos";
            this.ShowIcon = false;
            this.Text = "Artículos";
            this.Load += new System.EventHandler(this.frmCatArticulos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabImpuestos.ResumeLayout(false);
            this.tabImpuestos.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticulo)).EndInit();
            this.tabOtros.ResumeLayout(false);
            this.tabOtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.OpenFileDialog opfFoto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblUMed;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.Label lblDescArt;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoSAT;
        private System.Windows.Forms.Label lblCodB;
        private System.Windows.Forms.TextBox txtCodigoAlterno;
        private System.Windows.Forms.Label lblCveInterna;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.TabPage tabOtros;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtFechaAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtultimoProveedor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtUltimaCompra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.CheckBox chkRequiereReceta;
        private System.Windows.Forms.CheckBox chkDispVenta;
        private System.Windows.Forms.CheckBox chkDispKit;
        private System.Windows.Forms.CheckBox chkEsKit;
        private System.Windows.Forms.CheckBox chkEsInventa;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.Button cmdMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtClase1;
        private System.Windows.Forms.Button cmdClase1;
        private System.Windows.Forms.TextBox txtClase2;
        private System.Windows.Forms.Button cmdClase2;
        private System.Windows.Forms.TextBox txtUMed2;
        private System.Windows.Forms.Button cmdUMed2;
        private System.Windows.Forms.TextBox txtUMed3;
        private System.Windows.Forms.Button cmdUMed3;
        private System.Windows.Forms.TextBox txtUMed1;
        private System.Windows.Forms.Button cmdUMed1;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.Button cmdLinea;
        private System.Windows.Forms.TextBox txtClase3;
        private System.Windows.Forms.Button cmdClase3;
        private System.Windows.Forms.PictureBox pbArticulo;
        private System.Windows.Forms.Button cmdFoto;
        private System.Windows.Forms.Button cmdLstPrecio;
        private System.Windows.Forms.TabPage tabImpuestos;
        private System.Windows.Forms.TextBox txtImpIESP;
        private System.Windows.Forms.Button cmdImpIESP;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.Button cmdImpuesto;
        private System.Windows.Forms.Label lblImp;
        private System.Windows.Forms.TextBox txtRetISR;
        private System.Windows.Forms.Button cmdRetISR;
        private System.Windows.Forms.Label lblRetISR;
        private System.Windows.Forms.TextBox txtRetIVA;
        private System.Windows.Forms.Button cmdRetIVA;
        private System.Windows.Forms.Label lblRetIVA;
        private System.Windows.Forms.CheckBox chkEsServicio;
        private System.Windows.Forms.Button cmdBorrarIEPS;
        private System.Windows.Forms.Button cmdLimpiarRetISR;
        private System.Windows.Forms.Button cmdLimpiarRetIVA;
    }
}