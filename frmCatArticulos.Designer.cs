namespace GAFE
{
    partial class frmCatArticulos
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
            this.chkDispVenta = new System.Windows.Forms.CheckBox();
            this.chkEsServicio = new System.Windows.Forms.CheckBox();
            this.chkDispKit = new System.Windows.Forms.CheckBox();
            this.chkEsKit = new System.Windows.Forms.CheckBox();
            this.chkEsInventa = new System.Windows.Forms.CheckBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboImpuesto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUMedida2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboUMedidaEquival = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUMedida1 = new System.Windows.Forms.ComboBox();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboClase3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboClase2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboClase1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoSAT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoAlterno = new System.Windows.Forms.TextBox();
            this.lblCodEmpleado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLinea = new System.Windows.Forms.ComboBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.grdViewUbicacion = new System.Windows.Forms.DataGridView();
            this.tabFoto = new System.Windows.Forms.TabPage();
            this.pbArticulo = new System.Windows.Forms.PictureBox();
            this.cmdFoto = new System.Windows.Forms.Button();
            this.tabOtros = new System.Windows.Forms.TabPage();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtultimoProveedor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUltimaCompra = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabUbicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewUbicacion)).BeginInit();
            this.tabFoto.SuspendLayout();
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
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(617, 395);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 36);
            this.cmdCancelar.TabIndex = 270;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Aceptar;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(501, 395);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 36);
            this.cmdAceptar.TabIndex = 260;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabUbicacion);
            this.tabControl1.Controls.Add(this.tabFoto);
            this.tabControl1.Controls.Add(this.tabOtros);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 390);
            this.tabControl1.TabIndex = 1332;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tabGeneral.Controls.Add(this.chkDispVenta);
            this.tabGeneral.Controls.Add(this.chkEsServicio);
            this.tabGeneral.Controls.Add(this.chkDispKit);
            this.tabGeneral.Controls.Add(this.chkEsKit);
            this.tabGeneral.Controls.Add(this.chkEsInventa);
            this.tabGeneral.Controls.Add(this.chkEstatus);
            this.tabGeneral.Controls.Add(this.label12);
            this.tabGeneral.Controls.Add(this.cboImpuesto);
            this.tabGeneral.Controls.Add(this.label7);
            this.tabGeneral.Controls.Add(this.cboUMedida2);
            this.tabGeneral.Controls.Add(this.label14);
            this.tabGeneral.Controls.Add(this.cboUMedidaEquival);
            this.tabGeneral.Controls.Add(this.label13);
            this.tabGeneral.Controls.Add(this.cboMarca);
            this.tabGeneral.Controls.Add(this.label8);
            this.tabGeneral.Controls.Add(this.cboUMedida1);
            this.tabGeneral.Controls.Add(this.txtClaveArticulo);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.txtDescripcion);
            this.tabGeneral.Controls.Add(this.label9);
            this.tabGeneral.Controls.Add(this.cboClase3);
            this.tabGeneral.Controls.Add(this.label10);
            this.tabGeneral.Controls.Add(this.cboClase2);
            this.tabGeneral.Controls.Add(this.label11);
            this.tabGeneral.Controls.Add(this.cboClase1);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtCodigoSAT);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.txtCodigoAlterno);
            this.tabGeneral.Controls.Add(this.lblCodEmpleado);
            this.tabGeneral.Controls.Add(this.label6);
            this.tabGeneral.Controls.Add(this.cboLinea);
            this.tabGeneral.Controls.Add(this.txtCodigoBarras);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(726, 364);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // chkDispVenta
            // 
            this.chkDispVenta.AutoSize = true;
            this.chkDispVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDispVenta.Location = new System.Drawing.Point(549, 326);
            this.chkDispVenta.Name = "chkDispVenta";
            this.chkDispVenta.Size = new System.Drawing.Size(159, 20);
            this.chkDispVenta.TabIndex = 1351;
            this.chkDispVenta.Text = "Disponible para venta";
            this.chkDispVenta.UseVisualStyleBackColor = true;
            // 
            // chkEsServicio
            // 
            this.chkEsServicio.AutoSize = true;
            this.chkEsServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsServicio.Location = new System.Drawing.Point(337, 326);
            this.chkEsServicio.Name = "chkEsServicio";
            this.chkEsServicio.Size = new System.Drawing.Size(95, 20);
            this.chkEsServicio.TabIndex = 1352;
            this.chkEsServicio.Text = "Es Servicio";
            this.chkEsServicio.UseVisualStyleBackColor = true;
            // 
            // chkDispKit
            // 
            this.chkDispKit.AutoSize = true;
            this.chkDispKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDispKit.Location = new System.Drawing.Point(549, 300);
            this.chkDispKit.Name = "chkDispKit";
            this.chkDispKit.Size = new System.Drawing.Size(109, 20);
            this.chkDispKit.TabIndex = 1353;
            this.chkDispKit.Text = "Disponible Kit";
            this.chkDispKit.UseVisualStyleBackColor = true;
            // 
            // chkEsKit
            // 
            this.chkEsKit.AutoSize = true;
            this.chkEsKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsKit.Location = new System.Drawing.Point(126, 326);
            this.chkEsKit.Name = "chkEsKit";
            this.chkEsKit.Size = new System.Drawing.Size(60, 20);
            this.chkEsKit.TabIndex = 1354;
            this.chkEsKit.Text = "Es Kit";
            this.chkEsKit.UseVisualStyleBackColor = true;
            // 
            // chkEsInventa
            // 
            this.chkEsInventa.AutoSize = true;
            this.chkEsInventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEsInventa.Location = new System.Drawing.Point(337, 300);
            this.chkEsInventa.Name = "chkEsInventa";
            this.chkEsInventa.Size = new System.Drawing.Size(104, 20);
            this.chkEsInventa.TabIndex = 1350;
            this.chkEsInventa.Text = "Inventariable";
            this.chkEsInventa.UseVisualStyleBackColor = true;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEstatus.Location = new System.Drawing.Point(126, 300);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(64, 20);
            this.chkEstatus.TabIndex = 1349;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label12.Location = new System.Drawing.Point(10, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 1336;
            this.label12.Text = "Impuesto";
            // 
            // cboImpuesto
            // 
            this.cboImpuesto.DisplayMember = "Descripcion";
            this.cboImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboImpuesto.FormattingEnabled = true;
            this.cboImpuesto.Location = new System.Drawing.Point(126, 270);
            this.cboImpuesto.Name = "cboImpuesto";
            this.cboImpuesto.Size = new System.Drawing.Size(222, 24);
            this.cboImpuesto.TabIndex = 1346;
            this.cboImpuesto.ValueMember = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(370, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 1338;
            this.label7.Text = "U Med 2";
            // 
            // cboUMedida2
            // 
            this.cboUMedida2.DisplayMember = "Descripcion";
            this.cboUMedida2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUMedida2.FormattingEnabled = true;
            this.cboUMedida2.Location = new System.Drawing.Point(486, 210);
            this.cboUMedida2.Name = "cboUMedida2";
            this.cboUMedida2.Size = new System.Drawing.Size(222, 24);
            this.cboUMedida2.TabIndex = 1344;
            this.cboUMedida2.ValueMember = "Clave";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label14.Location = new System.Drawing.Point(10, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 1339;
            this.label14.Text = "U Med equival";
            // 
            // cboUMedidaEquival
            // 
            this.cboUMedidaEquival.DisplayMember = "Descripcion";
            this.cboUMedidaEquival.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUMedidaEquival.FormattingEnabled = true;
            this.cboUMedidaEquival.Location = new System.Drawing.Point(126, 240);
            this.cboUMedidaEquival.Name = "cboUMedidaEquival";
            this.cboUMedidaEquival.Size = new System.Drawing.Size(147, 24);
            this.cboUMedidaEquival.TabIndex = 1345;
            this.cboUMedidaEquival.ValueMember = "Clave";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 16);
            this.label13.TabIndex = 1347;
            this.label13.Text = "Marca";
            // 
            // cboMarca
            // 
            this.cboMarca.DisplayMember = "Descripcion";
            this.cboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(126, 90);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(222, 24);
            this.cboMarca.TabIndex = 1348;
            this.cboMarca.ValueMember = "Clave";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(10, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 1337;
            this.label8.Text = "U Medida 1";
            // 
            // cboUMedida1
            // 
            this.cboUMedida1.DisplayMember = "Descripcion";
            this.cboUMedida1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUMedida1.FormattingEnabled = true;
            this.cboUMedida1.Location = new System.Drawing.Point(126, 210);
            this.cboUMedida1.Name = "cboUMedida1";
            this.cboUMedida1.Size = new System.Drawing.Size(222, 24);
            this.cboUMedida1.TabIndex = 1343;
            this.cboUMedida1.ValueMember = "Clave";
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClaveArticulo.Location = new System.Drawing.Point(126, 6);
            this.txtClaveArticulo.MaxLength = 10;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.Size = new System.Drawing.Size(147, 22);
            this.txtClaveArticulo.TabIndex = 1321;
            this.txtClaveArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveArticulo_KeyPress_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1324;
            this.label2.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(126, 62);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(582, 22);
            this.txtDescripcion.TabIndex = 1332;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(10, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 1333;
            this.label9.Text = "Clase 3";
            // 
            // cboClase3
            // 
            this.cboClase3.DisplayMember = "Descripcion";
            this.cboClase3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboClase3.FormattingEnabled = true;
            this.cboClase3.Location = new System.Drawing.Point(126, 180);
            this.cboClase3.Name = "cboClase3";
            this.cboClase3.Size = new System.Drawing.Size(222, 24);
            this.cboClase3.TabIndex = 1342;
            this.cboClase3.ValueMember = "Clave";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(370, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 1334;
            this.label10.Text = "Clase 2";
            // 
            // cboClase2
            // 
            this.cboClase2.DisplayMember = "Descripcion";
            this.cboClase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboClase2.FormattingEnabled = true;
            this.cboClase2.Location = new System.Drawing.Point(486, 150);
            this.cboClase2.Name = "cboClase2";
            this.cboClase2.Size = new System.Drawing.Size(222, 24);
            this.cboClase2.TabIndex = 1341;
            this.cboClase2.ValueMember = "Clave";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.Location = new System.Drawing.Point(10, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 1335;
            this.label11.Text = "Clase 1";
            // 
            // cboClase1
            // 
            this.cboClase1.DisplayMember = "Descripcion";
            this.cboClase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboClase1.FormattingEnabled = true;
            this.cboClase1.Location = new System.Drawing.Point(126, 150);
            this.cboClase1.Name = "cboClase1";
            this.cboClase1.Size = new System.Drawing.Size(222, 24);
            this.cboClase1.TabIndex = 1340;
            this.cboClase1.ValueMember = "Clave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 1328;
            this.label4.Text = "Codigo SAT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 1327;
            this.label3.Text = "Código Alterno";
            // 
            // txtCodigoSAT
            // 
            this.txtCodigoSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoSAT.Location = new System.Drawing.Point(486, 34);
            this.txtCodigoSAT.MaxLength = 50;
            this.txtCodigoSAT.Name = "txtCodigoSAT";
            this.txtCodigoSAT.Size = new System.Drawing.Size(222, 22);
            this.txtCodigoSAT.TabIndex = 1330;
            this.txtCodigoSAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSAT_KeyPress_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 1326;
            this.label1.Text = "Código Barras";
            // 
            // txtCodigoAlterno
            // 
            this.txtCodigoAlterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoAlterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoAlterno.Location = new System.Drawing.Point(486, 7);
            this.txtCodigoAlterno.MaxLength = 10;
            this.txtCodigoAlterno.Name = "txtCodigoAlterno";
            this.txtCodigoAlterno.Size = new System.Drawing.Size(222, 22);
            this.txtCodigoAlterno.TabIndex = 1325;
            this.txtCodigoAlterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoAlterno_KeyPress_1);
            // 
            // lblCodEmpleado
            // 
            this.lblCodEmpleado.AutoSize = true;
            this.lblCodEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodEmpleado.Location = new System.Drawing.Point(10, 10);
            this.lblCodEmpleado.Name = "lblCodEmpleado";
            this.lblCodEmpleado.Size = new System.Drawing.Size(43, 16);
            this.lblCodEmpleado.TabIndex = 1323;
            this.lblCodEmpleado.Text = "Clave";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(10, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 1329;
            this.label6.Text = "Línea";
            // 
            // cboLinea
            // 
            this.cboLinea.DisplayMember = "Descripcion";
            this.cboLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboLinea.FormattingEnabled = true;
            this.cboLinea.Location = new System.Drawing.Point(126, 120);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Size = new System.Drawing.Size(222, 24);
            this.cboLinea.TabIndex = 1331;
            this.cboLinea.ValueMember = "Clave";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarras.Location = new System.Drawing.Point(126, 34);
            this.txtCodigoBarras.MaxLength = 20;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(222, 22);
            this.txtCodigoBarras.TabIndex = 1322;
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress_1);
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tabUbicacion.Controls.Add(this.grdViewUbicacion);
            this.tabUbicacion.Location = new System.Drawing.Point(4, 22);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Size = new System.Drawing.Size(726, 364);
            this.tabUbicacion.TabIndex = 5;
            this.tabUbicacion.Text = "Ubicacion";
            // 
            // grdViewUbicacion
            // 
            this.grdViewUbicacion.AllowUserToAddRows = false;
            this.grdViewUbicacion.AllowUserToDeleteRows = false;
            this.grdViewUbicacion.AllowUserToOrderColumns = true;
            this.grdViewUbicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewUbicacion.Location = new System.Drawing.Point(11, 8);
            this.grdViewUbicacion.Name = "grdViewUbicacion";
            this.grdViewUbicacion.ReadOnly = true;
            this.grdViewUbicacion.Size = new System.Drawing.Size(705, 279);
            this.grdViewUbicacion.TabIndex = 9;
            // 
            // tabFoto
            // 
            this.tabFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tabFoto.Controls.Add(this.pbArticulo);
            this.tabFoto.Controls.Add(this.cmdFoto);
            this.tabFoto.Location = new System.Drawing.Point(4, 22);
            this.tabFoto.Name = "tabFoto";
            this.tabFoto.Size = new System.Drawing.Size(726, 364);
            this.tabFoto.TabIndex = 6;
            this.tabFoto.Text = "Foto";
            // 
            // pbArticulo
            // 
            this.pbArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbArticulo.Image = global::GAFE.Properties.Resources.Image;
            this.pbArticulo.Location = new System.Drawing.Point(194, 3);
            this.pbArticulo.Name = "pbArticulo";
            this.pbArticulo.Size = new System.Drawing.Size(398, 316);
            this.pbArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArticulo.TabIndex = 253;
            this.pbArticulo.TabStop = false;
            // 
            // cmdFoto
            // 
            this.cmdFoto.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFoto.Location = new System.Drawing.Point(345, 325);
            this.cmdFoto.Name = "cmdFoto";
            this.cmdFoto.Size = new System.Drawing.Size(100, 28);
            this.cmdFoto.TabIndex = 254;
            this.cmdFoto.Text = "Seleccionar";
            this.cmdFoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFoto.UseVisualStyleBackColor = false;
            // 
            // tabOtros
            // 
            this.tabOtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
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
            this.tabOtros.Size = new System.Drawing.Size(726, 364);
            this.tabOtros.TabIndex = 7;
            this.tabOtros.Text = "Otros";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtObservaciones.Location = new System.Drawing.Point(149, 91);
            this.txtObservaciones.MaxLength = 200;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(566, 22);
            this.txtObservaciones.TabIndex = 1334;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label17.Location = new System.Drawing.Point(10, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 16);
            this.label17.TabIndex = 1333;
            this.label17.Text = "Observaciones";
            // 
            // dtFechaAlta
            // 
            this.dtFechaAlta.CustomFormat = "yyyyyy/MM/dd hh:mm:ss";
            this.dtFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtFechaAlta.Location = new System.Drawing.Point(149, 63);
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
            this.label5.Location = new System.Drawing.Point(10, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 1331;
            this.label5.Text = "Fecha Alta";
            // 
            // txtultimoProveedor
            // 
            this.txtultimoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtultimoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtultimoProveedor.Location = new System.Drawing.Point(149, 35);
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
            this.label16.Location = new System.Drawing.Point(10, 38);
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
            // frmCatArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 435);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCatArticulos";
            this.ShowIcon = false;
            this.Text = "Artículos";
            this.Load += new System.EventHandler(this.frmCatArticulos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabUbicacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewUbicacion)).EndInit();
            this.tabFoto.ResumeLayout(false);
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboImpuesto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUMedida2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboUMedidaEquival;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUMedida1;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboClase3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboClase2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboClase1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoSAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoAlterno;
        private System.Windows.Forms.Label lblCodEmpleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLinea;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.TabPage tabUbicacion;
        private System.Windows.Forms.DataGridView grdViewUbicacion;
        private System.Windows.Forms.TabPage tabFoto;
        private System.Windows.Forms.PictureBox pbArticulo;
        private System.Windows.Forms.Button cmdFoto;
        private System.Windows.Forms.CheckBox chkDispVenta;
        private System.Windows.Forms.CheckBox chkEsServicio;
        private System.Windows.Forms.CheckBox chkDispKit;
        private System.Windows.Forms.CheckBox chkEsKit;
        private System.Windows.Forms.CheckBox chkEsInventa;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.TabPage tabOtros;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtFechaAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtultimoProveedor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtUltimaCompra;
        private System.Windows.Forms.Label label15;
    }
}