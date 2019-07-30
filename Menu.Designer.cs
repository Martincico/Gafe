namespace GAFE
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribMenu = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.ModInventario = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatInven = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsArticulos = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatArticulo = new System.Windows.Forms.ToolStripMenuItem();
            this.CatUMedidas = new System.Windows.Forms.ToolStripMenuItem();
            this.CatLineas = new System.Windows.Forms.ToolStripMenuItem();
            this.CatMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.CatClase = new System.Windows.Forms.ToolStripMenuItem();
            this.CatGeografia = new System.Windows.Forms.ToolStripMenuItem();
            this.catsAlmacenes = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.CatListaPrecios = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcInven = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.OpInventarios = new System.Windows.Forms.ToolStripDropDownButton();
            this.OpMovInv = new System.Windows.Forms.ToolStripMenuItem();
            this.OpKardex = new System.Windows.Forms.ToolStripMenuItem();
            this.OpExistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.InvMenDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.OpInvFisicos = new System.Windows.Forms.ToolStripDropDownButton();
            this.RepInven = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.ModProveedores = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatProvee = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsProveedores = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.ModConfiguración = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.toolStripEx4 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuCfgFoliadores = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripEx2 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CfgMnuProveedores = new System.Windows.Forms.ToolStripDropDownButton();
            this.Prov_TipoMov = new System.Windows.Forms.ToolStripMenuItem();
            this.Prov_SereDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEx3 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CfgMnuInventarios = new System.Windows.Forms.ToolStripDropDownButton();
            this.Inv_TipoMov = new System.Windows.Forms.ToolStripMenuItem();
            this.ModSeguridad = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatSeguridad = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsUsuarios = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatsPerfiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatsAsignaPer = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatPersonalizar = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsTemas = new System.Windows.Forms.ToolStripDropDownButton();
            this.stilDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.stilClaro = new System.Windows.Forms.ToolStripMenuItem();
            this.stilVerde = new System.Windows.Forms.ToolStripMenuItem();
            this.stilNegro = new System.Windows.Forms.ToolStripMenuItem();
            this.stilAzul = new System.Windows.Forms.ToolStripMenuItem();
            this.stilRosado = new System.Windows.Forms.ToolStripMenuItem();
            this.CatsFondos = new System.Windows.Forms.ToolStripDropDownButton();
            this.PerFondo1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PerFondo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PerFondo3 = new System.Windows.Forms.ToolStripMenuItem();
            this.PerFondo4 = new System.Windows.Forms.ToolStripMenuItem();
            this.PerFondoNone = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPie = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribMenu)).BeginInit();
            this.ribMenu.SuspendLayout();
            this.ModInventario.Panel.SuspendLayout();
            this.CatInven.SuspendLayout();
            this.ProcInven.SuspendLayout();
            this.ModProveedores.Panel.SuspendLayout();
            this.CatProvee.SuspendLayout();
            this.ModConfiguración.Panel.SuspendLayout();
            this.toolStripEx4.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.toolStripEx3.SuspendLayout();
            this.ModSeguridad.Panel.SuspendLayout();
            this.CatSeguridad.SuspendLayout();
            this.CatPersonalizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribMenu
            // 
            this.ribMenu.BackStageNavigationButtonStyle = Syncfusion.Windows.Forms.Tools.BackStageNavigationButtonStyles.Office2013;
            this.ribMenu.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ribMenu.Header.AddMainItem(ModInventario);
            this.ribMenu.Header.AddMainItem(ModProveedores);
            this.ribMenu.Header.AddMainItem(ModConfiguración);
            this.ribMenu.Header.AddMainItem(ModSeguridad);
            this.ribMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ribMenu.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office12;
            this.ribMenu.Location = new System.Drawing.Point(1, 0);
            this.ribMenu.MenuButtonFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ribMenu.MenuButtonImage = global::GAFE.Properties.Resources.Logotipo;
            this.ribMenu.MenuButtonText = "GAFE";
            this.ribMenu.MenuButtonWidth = 56;
            this.ribMenu.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.ribMenu.Name = "ribMenu";
            this.ribMenu.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            // 
            // ribMenu.OfficeMenu
            // 
            this.ribMenu.OfficeMenu.Name = "OfficeMenu";
            this.ribMenu.OfficeMenu.ShowItemToolTips = true;
            this.ribMenu.OfficeMenu.Size = new System.Drawing.Size(12, 65);
            this.ribMenu.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ribMenu.QuickPanelVisible = false;
            this.ribMenu.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            this.ribMenu.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2016;
            this.ribMenu.SelectedTab = this.ModInventario;
            this.ribMenu.ShowRibbonDisplayOptionButton = true;
            this.ribMenu.Size = new System.Drawing.Size(799, 149);
            this.ribMenu.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.ribMenu.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.ribMenu.TabIndex = 0;
            this.ribMenu.Text = "ribbonControlAdv1";
            this.ribMenu.ThemeName = "Office2016";
            this.ribMenu.ThemeStyle.CloseButtonBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.ribMenu.ThemeStyle.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.ribMenu.ThemeStyle.MoreCommandsStyle.PropertyGridViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ribMenu.ThemeStyle.QuickDropDownPressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.ribMenu.ThemeStyle.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ribMenu.ThemeStyle.TabGroupColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(158)))));
            this.ribMenu.TitleColor = System.Drawing.Color.White;
            this.ribMenu.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribMenu.Click += new System.EventHandler(this.ribMenu_Click);
            // 
            // ModInventario
            // 
            this.ModInventario.Name = "ModInventario";
            // 
            // ribMenu.ribbonPanel1
            // 
            this.ModInventario.Panel.Controls.Add(this.CatInven);
            this.ModInventario.Panel.Controls.Add(this.ProcInven);
            this.ModInventario.Panel.Controls.Add(this.RepInven);
            this.ModInventario.Panel.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office2007;
            this.ModInventario.Panel.Name = "ribbonPanel1";
            this.ModInventario.Panel.ScrollPosition = 0;
            this.ModInventario.Panel.TabIndex = 2;
            this.ModInventario.Panel.Text = "Inventarios";
            this.ModInventario.Position = 0;
            this.ModInventario.Size = new System.Drawing.Size(80, 30);
            this.ModInventario.Tag = "1";
            this.ModInventario.Text = "Inventarios";
            // 
            // CatInven
            // 
            this.CatInven.AutoSize = false;
            this.CatInven.Dock = System.Windows.Forms.DockStyle.None;
            this.CatInven.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatInven.ForeColor = System.Drawing.Color.Black;
            this.CatInven.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatInven.Image = null;
            this.CatInven.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatsArticulos,
            this.catsAlmacenes});
            this.CatInven.Location = new System.Drawing.Point(0, 1);
            this.CatInven.Name = "CatInven";
            this.CatInven.Office12Mode = false;
            this.CatInven.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatInven.Size = new System.Drawing.Size(165, 80);
            this.CatInven.TabIndex = 0;
            this.CatInven.Text = "Catálgos";
            // 
            // CatsArticulos
            // 
            this.CatsArticulos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatArticulo,
            this.CatUMedidas,
            this.CatLineas,
            this.CatMarcas,
            this.CatClase,
            this.CatGeografia});
            this.CatsArticulos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsArticulos.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.CatsArticulos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsArticulos.Name = "CatsArticulos";
            this.CatsArticulos.Size = new System.Drawing.Size(65, 63);
            this.CatsArticulos.Text = "Artículos";
            this.CatsArticulos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // CatArticulo
            // 
            this.CatArticulo.Name = "CatArticulo";
            this.CatArticulo.Size = new System.Drawing.Size(180, 22);
            this.CatArticulo.Text = "Artículos";
            this.CatArticulo.Click += new System.EventHandler(this.CatArticulo_Click);
            // 
            // CatUMedidas
            // 
            this.CatUMedidas.Name = "CatUMedidas";
            this.CatUMedidas.Size = new System.Drawing.Size(180, 22);
            this.CatUMedidas.Text = "Unidad de medida";
            this.CatUMedidas.Click += new System.EventHandler(this.CatUMedidas_Click);
            // 
            // CatLineas
            // 
            this.CatLineas.Name = "CatLineas";
            this.CatLineas.Size = new System.Drawing.Size(180, 22);
            this.CatLineas.Text = "Lineas";
            this.CatLineas.Click += new System.EventHandler(this.CatLineas_Click);
            // 
            // CatMarcas
            // 
            this.CatMarcas.Name = "CatMarcas";
            this.CatMarcas.Size = new System.Drawing.Size(180, 22);
            this.CatMarcas.Text = "Marcas";
            this.CatMarcas.Click += new System.EventHandler(this.CatMarcas_Click);
            // 
            // CatClase
            // 
            this.CatClase.Name = "CatClase";
            this.CatClase.Size = new System.Drawing.Size(180, 22);
            this.CatClase.Text = "Clases";
            this.CatClase.Click += new System.EventHandler(this.CatClase_Click);
            // 
            // CatGeografia
            // 
            this.CatGeografia.Name = "CatGeografia";
            this.CatGeografia.Size = new System.Drawing.Size(180, 22);
            this.CatGeografia.Text = "Geografía";
            this.CatGeografia.Click += new System.EventHandler(this.CatGeografia_Click);
            // 
            // catsAlmacenes
            // 
            this.catsAlmacenes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatAlmacen,
            this.CatListaPrecios});
            this.catsAlmacenes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.catsAlmacenes.Image = global::GAFE.Properties.Resources.MnuAlmacen;
            this.catsAlmacenes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.catsAlmacenes.Name = "catsAlmacenes";
            this.catsAlmacenes.Size = new System.Drawing.Size(74, 63);
            this.catsAlmacenes.Text = "Almacenes";
            this.catsAlmacenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.catsAlmacenes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.catsAlmacenes.ToolTipText = "Almacenes";
            // 
            // CatAlmacen
            // 
            this.CatAlmacen.Name = "CatAlmacen";
            this.CatAlmacen.Size = new System.Drawing.Size(152, 22);
            this.CatAlmacen.Text = "Almacén";
            this.CatAlmacen.ToolTipText = "Almacén";
            this.CatAlmacen.Click += new System.EventHandler(this.CatAlmacen_Click);
            // 
            // CatListaPrecios
            // 
            this.CatListaPrecios.Name = "CatListaPrecios";
            this.CatListaPrecios.Size = new System.Drawing.Size(152, 22);
            this.CatListaPrecios.Text = "Lista de Precios";
            this.CatListaPrecios.Click += new System.EventHandler(this.CatListaPrecios_Click);
            // 
            // ProcInven
            // 
            this.ProcInven.AutoSize = false;
            this.ProcInven.Dock = System.Windows.Forms.DockStyle.None;
            this.ProcInven.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ProcInven.ForeColor = System.Drawing.Color.Black;
            this.ProcInven.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ProcInven.Image = null;
            this.ProcInven.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpInventarios,
            this.OpInvFisicos});
            this.ProcInven.Location = new System.Drawing.Point(167, 1);
            this.ProcInven.Name = "ProcInven";
            this.ProcInven.Office12Mode = false;
            this.ProcInven.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ProcInven.Size = new System.Drawing.Size(177, 80);
            this.ProcInven.TabIndex = 4;
            this.ProcInven.Text = "Procesos";
            // 
            // OpInventarios
            // 
            this.OpInventarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpMovInv,
            this.OpKardex,
            this.OpExistencia,
            this.InvMenDocumentos});
            this.OpInventarios.ForeColor = System.Drawing.Color.MidnightBlue;
            this.OpInventarios.Image = global::GAFE.Properties.Resources.MnuInventario;
            this.OpInventarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpInventarios.Name = "OpInventarios";
            this.OpInventarios.Size = new System.Drawing.Size(77, 63);
            this.OpInventarios.Text = "Inventarios";
            this.OpInventarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpInventarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.OpInventarios.ToolTipText = "Inventarios";
            // 
            // OpMovInv
            // 
            this.OpMovInv.Name = "OpMovInv";
            this.OpMovInv.Size = new System.Drawing.Size(216, 22);
            this.OpMovInv.Text = "Movimientos de inventarios";
            this.OpMovInv.Click += new System.EventHandler(this.OpMovInv_Click);
            // 
            // OpKardex
            // 
            this.OpKardex.Name = "OpKardex";
            this.OpKardex.Size = new System.Drawing.Size(216, 22);
            this.OpKardex.Text = "Kardex por artículo";
            this.OpKardex.Click += new System.EventHandler(this.OpKardex_Click);
            // 
            // OpExistencia
            // 
            this.OpExistencia.Name = "OpExistencia";
            this.OpExistencia.Size = new System.Drawing.Size(216, 22);
            this.OpExistencia.Text = "Existencia Art - Almacén";
            this.OpExistencia.Click += new System.EventHandler(this.OpExistencia_Click);
            // 
            // InvMenDocumentos
            // 
            this.InvMenDocumentos.Name = "InvMenDocumentos";
            this.InvMenDocumentos.Size = new System.Drawing.Size(216, 22);
            this.InvMenDocumentos.Text = "Documentos";
            this.InvMenDocumentos.Click += new System.EventHandler(this.InvMenDocumentos_Click);
            // 
            // OpInvFisicos
            // 
            this.OpInvFisicos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.OpInvFisicos.Image = global::GAFE.Properties.Resources.Cancelar;
            this.OpInvFisicos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpInvFisicos.Name = "OpInvFisicos";
            this.OpInvFisicos.Size = new System.Drawing.Size(73, 63);
            this.OpInvFisicos.Text = "Inv. físicos";
            this.OpInvFisicos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpInvFisicos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.OpInvFisicos.ToolTipText = "Inv. físicos";
            // 
            // RepInven
            // 
            this.RepInven.AutoSize = false;
            this.RepInven.Dock = System.Windows.Forms.DockStyle.None;
            this.RepInven.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.RepInven.ForeColor = System.Drawing.Color.Black;
            this.RepInven.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.RepInven.Image = null;
            this.RepInven.Location = new System.Drawing.Point(346, 1);
            this.RepInven.Name = "RepInven";
            this.RepInven.Office12Mode = false;
            this.RepInven.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RepInven.Size = new System.Drawing.Size(100, 80);
            this.RepInven.TabIndex = 5;
            this.RepInven.Text = "Reportes";
            // 
            // ModProveedores
            // 
            this.ModProveedores.Name = "ModProveedores";
            // 
            // ribMenu.ribbonPanel2
            // 
            this.ModProveedores.Panel.Controls.Add(this.CatProvee);
            this.ModProveedores.Panel.Name = "ribbonPanel2";
            this.ModProveedores.Panel.ScrollPosition = 0;
            this.ModProveedores.Panel.TabIndex = 3;
            this.ModProveedores.Panel.Text = "Proveedores";
            this.ModProveedores.Position = 1;
            this.ModProveedores.Size = new System.Drawing.Size(86, 30);
            this.ModProveedores.Tag = "2";
            this.ModProveedores.Text = "Proveedores";
            // 
            // CatProvee
            // 
            this.CatProvee.AutoSize = false;
            this.CatProvee.Dock = System.Windows.Forms.DockStyle.None;
            this.CatProvee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatProvee.ForeColor = System.Drawing.Color.Black;
            this.CatProvee.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatProvee.Image = null;
            this.CatProvee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatsProveedores});
            this.CatProvee.Location = new System.Drawing.Point(0, 1);
            this.CatProvee.Name = "CatProvee";
            this.CatProvee.Office12Mode = false;
            this.CatProvee.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatProvee.Size = new System.Drawing.Size(121, 80);
            this.CatProvee.TabIndex = 1;
            this.CatProvee.Text = "Catálgos";
            // 
            // CatsProveedores
            // 
            this.CatsProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatProveedores});
            this.CatsProveedores.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsProveedores.Image = global::GAFE.Properties.Resources.MnuProveedores;
            this.CatsProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsProveedores.Name = "CatsProveedores";
            this.CatsProveedores.Size = new System.Drawing.Size(83, 63);
            this.CatsProveedores.Text = "Proveedores";
            this.CatsProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // CatProveedores
            // 
            this.CatProveedores.Name = "CatProveedores";
            this.CatProveedores.Size = new System.Drawing.Size(126, 22);
            this.CatProveedores.Text = "Proveedor";
            this.CatProveedores.ToolTipText = "Proveedor";
            this.CatProveedores.Click += new System.EventHandler(this.CatProveedores_Click);
            // 
            // ModConfiguración
            // 
            this.ModConfiguración.Name = "ModConfiguración";
            // 
            // ribMenu.ribbonPanel3
            // 
            this.ModConfiguración.Panel.Controls.Add(this.toolStripEx4);
            this.ModConfiguración.Panel.Controls.Add(this.toolStripEx2);
            this.ModConfiguración.Panel.Controls.Add(this.toolStripEx3);
            this.ModConfiguración.Panel.Name = "ribbonPanel3";
            this.ModConfiguración.Panel.ScrollPosition = 0;
            this.ModConfiguración.Panel.TabIndex = 5;
            this.ModConfiguración.Panel.Text = "Configuración";
            this.ModConfiguración.Position = 2;
            this.ModConfiguración.Size = new System.Drawing.Size(97, 30);
            this.ModConfiguración.Tag = "1";
            this.ModConfiguración.Text = "Configuración";
            // 
            // toolStripEx4
            // 
            this.toolStripEx4.AutoSize = false;
            this.toolStripEx4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripEx4.ForeColor = System.Drawing.Color.Black;
            this.toolStripEx4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx4.Image = null;
            this.toolStripEx4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCfgFoliadores});
            this.toolStripEx4.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx4.Name = "toolStripEx4";
            this.toolStripEx4.Office12Mode = false;
            this.toolStripEx4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx4.Size = new System.Drawing.Size(100, 80);
            this.toolStripEx4.TabIndex = 8;
            this.toolStripEx4.Text = "Reportes";
            // 
            // MnuCfgFoliadores
            // 
            this.MnuCfgFoliadores.ForeColor = System.Drawing.Color.MidnightBlue;
            this.MnuCfgFoliadores.Image = global::GAFE.Properties.Resources.Cancelar;
            this.MnuCfgFoliadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuCfgFoliadores.Name = "MnuCfgFoliadores";
            this.MnuCfgFoliadores.Size = new System.Drawing.Size(74, 63);
            this.MnuCfgFoliadores.Text = "Foliadores";
            this.MnuCfgFoliadores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MnuCfgFoliadores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.MnuCfgFoliadores.ToolTipText = "Inv. físicos";
            this.MnuCfgFoliadores.Click += new System.EventHandler(this.MnuCfgFoliadores_Click);
            // 
            // toolStripEx2
            // 
            this.toolStripEx2.AutoSize = false;
            this.toolStripEx2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripEx2.ForeColor = System.Drawing.Color.Black;
            this.toolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx2.Image = null;
            this.toolStripEx2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CfgMnuProveedores});
            this.toolStripEx2.Location = new System.Drawing.Point(102, 1);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Office12Mode = false;
            this.toolStripEx2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx2.Size = new System.Drawing.Size(110, 80);
            this.toolStripEx2.TabIndex = 7;
            this.toolStripEx2.Text = "Reportes";
            // 
            // CfgMnuProveedores
            // 
            this.CfgMnuProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Prov_TipoMov,
            this.Prov_SereDoc});
            this.CfgMnuProveedores.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CfgMnuProveedores.Image = global::GAFE.Properties.Resources.Cancelar;
            this.CfgMnuProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CfgMnuProveedores.Name = "CfgMnuProveedores";
            this.CfgMnuProveedores.Size = new System.Drawing.Size(83, 63);
            this.CfgMnuProveedores.Text = "Proveedores";
            this.CfgMnuProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CfgMnuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CfgMnuProveedores.ToolTipText = "Inv. físicos";
            // 
            // Prov_TipoMov
            // 
            this.Prov_TipoMov.Name = "Prov_TipoMov";
            this.Prov_TipoMov.Size = new System.Drawing.Size(166, 22);
            this.Prov_TipoMov.Text = "Tipo Movimientos";
            this.Prov_TipoMov.Click += new System.EventHandler(this.Prov_TipoMov_Click);
            // 
            // Prov_SereDoc
            // 
            this.Prov_SereDoc.Name = "Prov_SereDoc";
            this.Prov_SereDoc.Size = new System.Drawing.Size(166, 22);
            this.Prov_SereDoc.Text = "Serie documentos";
            this.Prov_SereDoc.Click += new System.EventHandler(this.Prov_SereDoc_Click);
            // 
            // toolStripEx3
            // 
            this.toolStripEx3.AutoSize = false;
            this.toolStripEx3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripEx3.ForeColor = System.Drawing.Color.Black;
            this.toolStripEx3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx3.Image = null;
            this.toolStripEx3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CfgMnuInventarios});
            this.toolStripEx3.Location = new System.Drawing.Point(214, 1);
            this.toolStripEx3.Name = "toolStripEx3";
            this.toolStripEx3.Office12Mode = false;
            this.toolStripEx3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx3.Size = new System.Drawing.Size(100, 80);
            this.toolStripEx3.TabIndex = 6;
            this.toolStripEx3.Text = "Reportes";
            // 
            // CfgMnuInventarios
            // 
            this.CfgMnuInventarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Inv_TipoMov});
            this.CfgMnuInventarios.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CfgMnuInventarios.Image = global::GAFE.Properties.Resources.Cancelar;
            this.CfgMnuInventarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CfgMnuInventarios.Name = "CfgMnuInventarios";
            this.CfgMnuInventarios.Size = new System.Drawing.Size(77, 63);
            this.CfgMnuInventarios.Text = "Inventarios";
            this.CfgMnuInventarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CfgMnuInventarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CfgMnuInventarios.ToolTipText = "Inv. físicos";
            // 
            // Inv_TipoMov
            // 
            this.Inv_TipoMov.Name = "Inv_TipoMov";
            this.Inv_TipoMov.Size = new System.Drawing.Size(165, 22);
            this.Inv_TipoMov.Text = "Tipo Movimientos";
            this.Inv_TipoMov.Click += new System.EventHandler(this.Inv_TipoMov_Click);
            // 
            // ModSeguridad
            // 
            this.ModSeguridad.Name = "ModSeguridad";
            // 
            // ribMenu.ribbonPanel4
            // 
            this.ModSeguridad.Panel.Controls.Add(this.CatSeguridad);
            this.ModSeguridad.Panel.Controls.Add(this.CatPersonalizar);
            this.ModSeguridad.Panel.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office12;
            this.ModSeguridad.Panel.Name = "ribbonPanel4";
            this.ModSeguridad.Panel.ScrollPosition = 0;
            this.ModSeguridad.Panel.TabIndex = 4;
            this.ModSeguridad.Panel.Text = "Seguridad";
            this.ModSeguridad.Position = 3;
            this.ModSeguridad.Size = new System.Drawing.Size(76, 30);
            this.ModSeguridad.Tag = "3";
            this.ModSeguridad.Text = "Seguridad";
            // 
            // CatSeguridad
            // 
            this.CatSeguridad.AutoSize = false;
            this.CatSeguridad.Dock = System.Windows.Forms.DockStyle.None;
            this.CatSeguridad.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatSeguridad.ForeColor = System.Drawing.Color.Black;
            this.CatSeguridad.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatSeguridad.Image = null;
            this.CatSeguridad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatsUsuarios,
            this.CatsPerfiles,
            this.CatsAsignaPer});
            this.CatSeguridad.Location = new System.Drawing.Point(0, 1);
            this.CatSeguridad.Name = "CatSeguridad";
            this.CatSeguridad.Office12Mode = false;
            this.CatSeguridad.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatSeguridad.Size = new System.Drawing.Size(251, 80);
            this.CatSeguridad.TabIndex = 1;
            this.CatSeguridad.Text = "Usuarios";
            // 
            // CatsUsuarios
            // 
            this.CatsUsuarios.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsUsuarios.Image = global::GAFE.Properties.Resources.MnuUsuarios;
            this.CatsUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsUsuarios.Name = "CatsUsuarios";
            this.CatsUsuarios.Size = new System.Drawing.Size(65, 63);
            this.CatsUsuarios.Text = "Usuarios";
            this.CatsUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsUsuarios.ToolTipText = "Usuarios";
            // 
            // CatsPerfiles
            // 
            this.CatsPerfiles.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsPerfiles.Image = global::GAFE.Properties.Resources.Cancelar;
            this.CatsPerfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsPerfiles.Name = "CatsPerfiles";
            this.CatsPerfiles.Size = new System.Drawing.Size(57, 63);
            this.CatsPerfiles.Text = "Perfiles";
            this.CatsPerfiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsPerfiles.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsPerfiles.ToolTipText = "Perfiles";
            // 
            // CatsAsignaPer
            // 
            this.CatsAsignaPer.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsAsignaPer.Image = global::GAFE.Properties.Resources.Cancelar;
            this.CatsAsignaPer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsAsignaPer.Name = "CatsAsignaPer";
            this.CatsAsignaPer.Size = new System.Drawing.Size(104, 63);
            this.CatsAsignaPer.Text = "Asigna permisos";
            this.CatsAsignaPer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsAsignaPer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsAsignaPer.ToolTipText = "Asigna permisos";
            this.CatsAsignaPer.Click += new System.EventHandler(this.CatsAsignaPer_Click);
            // 
            // CatPersonalizar
            // 
            this.CatPersonalizar.AutoSize = false;
            this.CatPersonalizar.Dock = System.Windows.Forms.DockStyle.None;
            this.CatPersonalizar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatPersonalizar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatPersonalizar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatPersonalizar.Image = null;
            this.CatPersonalizar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatsTemas,
            this.CatsFondos});
            this.CatPersonalizar.Location = new System.Drawing.Point(253, 1);
            this.CatPersonalizar.Name = "CatPersonalizar";
            this.CatPersonalizar.Office12Mode = false;
            this.CatPersonalizar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatPersonalizar.Size = new System.Drawing.Size(141, 80);
            this.CatPersonalizar.TabIndex = 2;
            this.CatPersonalizar.Text = "Personalizar";
            // 
            // CatsTemas
            // 
            this.CatsTemas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stilDefault,
            this.stilClaro,
            this.stilVerde,
            this.stilNegro,
            this.stilAzul,
            this.stilRosado});
            this.CatsTemas.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsTemas.Image = global::GAFE.Properties.Resources.MnuColores;
            this.CatsTemas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsTemas.Name = "CatsTemas";
            this.CatsTemas.Size = new System.Drawing.Size(50, 63);
            this.CatsTemas.Text = "Temas";
            this.CatsTemas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsTemas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsTemas.ToolTipText = "Temas";
            // 
            // stilDefault
            // 
            this.stilDefault.Name = "stilDefault";
            this.stilDefault.Size = new System.Drawing.Size(112, 22);
            this.stilDefault.Text = "Default";
            this.stilDefault.Click += new System.EventHandler(this.stilDefault_Click);
            // 
            // stilClaro
            // 
            this.stilClaro.Name = "stilClaro";
            this.stilClaro.Size = new System.Drawing.Size(112, 22);
            this.stilClaro.Text = "Claro";
            this.stilClaro.Click += new System.EventHandler(this.stilClaro_Click);
            // 
            // stilVerde
            // 
            this.stilVerde.Name = "stilVerde";
            this.stilVerde.Size = new System.Drawing.Size(112, 22);
            this.stilVerde.Text = "Verde";
            this.stilVerde.Click += new System.EventHandler(this.stilVerde_Click);
            // 
            // stilNegro
            // 
            this.stilNegro.Name = "stilNegro";
            this.stilNegro.Size = new System.Drawing.Size(112, 22);
            this.stilNegro.Text = "Negro";
            this.stilNegro.Click += new System.EventHandler(this.stilNegro_Click);
            // 
            // stilAzul
            // 
            this.stilAzul.Name = "stilAzul";
            this.stilAzul.Size = new System.Drawing.Size(112, 22);
            this.stilAzul.Text = "Azul";
            this.stilAzul.Click += new System.EventHandler(this.stilAzul_Click);
            // 
            // stilRosado
            // 
            this.stilRosado.Name = "stilRosado";
            this.stilRosado.Size = new System.Drawing.Size(112, 22);
            this.stilRosado.Text = "Rosa";
            this.stilRosado.Click += new System.EventHandler(this.stilRosado_Click);
            // 
            // CatsFondos
            // 
            this.CatsFondos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PerFondo1,
            this.PerFondo2,
            this.PerFondo3,
            this.PerFondo4,
            this.PerFondoNone});
            this.CatsFondos.Image = global::GAFE.Properties.Resources.MnuTemas;
            this.CatsFondos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsFondos.Name = "CatsFondos";
            this.CatsFondos.Size = new System.Drawing.Size(59, 63);
            this.CatsFondos.Text = "Fondos";
            this.CatsFondos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CatsFondos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // PerFondo1
            // 
            this.PerFondo1.Name = "PerFondo1";
            this.PerFondo1.Size = new System.Drawing.Size(120, 22);
            this.PerFondo1.Text = "Fondo1";
            this.PerFondo1.Click += new System.EventHandler(this.PerFondo1_Click);
            // 
            // PerFondo2
            // 
            this.PerFondo2.Name = "PerFondo2";
            this.PerFondo2.Size = new System.Drawing.Size(120, 22);
            this.PerFondo2.Text = "Fondo2";
            this.PerFondo2.Click += new System.EventHandler(this.PerFondo2_Click);
            // 
            // PerFondo3
            // 
            this.PerFondo3.Name = "PerFondo3";
            this.PerFondo3.Size = new System.Drawing.Size(120, 22);
            this.PerFondo3.Text = "Fondo3";
            this.PerFondo3.Click += new System.EventHandler(this.PerFondo3_Click);
            // 
            // PerFondo4
            // 
            this.PerFondo4.Name = "PerFondo4";
            this.PerFondo4.Size = new System.Drawing.Size(120, 22);
            this.PerFondo4.Text = "Fondo4";
            this.PerFondo4.Click += new System.EventHandler(this.PerFondo4_Click);
            // 
            // PerFondoNone
            // 
            this.PerFondoNone.Name = "PerFondoNone";
            this.PerFondoNone.Size = new System.Drawing.Size(120, 22);
            this.PerFondoNone.Text = "Ninguno";
            this.PerFondoNone.Click += new System.EventHandler(this.PerFondoNone_Click);
            // 
            // panelPie
            // 
            this.panelPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPie.Location = new System.Drawing.Point(1, 394);
            this.panelPie.Name = "panelPie";
            this.panelPie.Size = new System.Drawing.Size(799, 30);
            this.panelPie.TabIndex = 2;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panelContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(1, 149);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(799, 245);
            this.panelContenedor.TabIndex = 4;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 425);
            this.Controls.Add(this.ribMenu);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelPie);
            this.KeyPreview = true;
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.ShowApplicationIcon = false;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribMenu)).EndInit();
            this.ribMenu.ResumeLayout(false);
            this.ribMenu.PerformLayout();
            this.ModInventario.Panel.ResumeLayout(false);
            this.CatInven.ResumeLayout(false);
            this.CatInven.PerformLayout();
            this.ProcInven.ResumeLayout(false);
            this.ProcInven.PerformLayout();
            this.ModProveedores.Panel.ResumeLayout(false);
            this.CatProvee.ResumeLayout(false);
            this.CatProvee.PerformLayout();
            this.ModConfiguración.Panel.ResumeLayout(false);
            this.toolStripEx4.ResumeLayout(false);
            this.toolStripEx4.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.toolStripEx3.ResumeLayout(false);
            this.toolStripEx3.PerformLayout();
            this.ModSeguridad.Panel.ResumeLayout(false);
            this.CatSeguridad.ResumeLayout(false);
            this.CatSeguridad.PerformLayout();
            this.CatPersonalizar.ResumeLayout(false);
            this.CatPersonalizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv ribMenu;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModInventario;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModProveedores;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModSeguridad;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatSeguridad;
        private System.Windows.Forms.ToolStripDropDownButton CatsUsuarios;
        private System.Windows.Forms.ToolStripDropDownButton CatsPerfiles;
        private System.Windows.Forms.ToolStripDropDownButton CatsAsignaPer;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatInven;
        private System.Windows.Forms.ToolStripDropDownButton CatsArticulos;
        private System.Windows.Forms.ToolStripMenuItem CatArticulo;
        private System.Windows.Forms.ToolStripMenuItem CatUMedidas;
        private System.Windows.Forms.ToolStripMenuItem CatLineas;
        private System.Windows.Forms.ToolStripMenuItem CatMarcas;
        private System.Windows.Forms.ToolStripMenuItem CatClase;
        private System.Windows.Forms.ToolStripMenuItem CatGeografia;
        private System.Windows.Forms.ToolStripDropDownButton catsAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem CatAlmacen;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx ProcInven;
        private System.Windows.Forms.ToolStripDropDownButton OpInventarios;
        private System.Windows.Forms.ToolStripMenuItem OpMovInv;
        private System.Windows.Forms.ToolStripMenuItem OpKardex;
        private System.Windows.Forms.ToolStripMenuItem OpExistencia;
        private System.Windows.Forms.ToolStripDropDownButton OpInvFisicos;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx RepInven;
        private System.Windows.Forms.ToolStripDropDownButton CatsTemas;
        private System.Windows.Forms.ToolStripMenuItem stilDefault;
        private System.Windows.Forms.ToolStripMenuItem stilClaro;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.ToolStripMenuItem stilVerde;
        private System.Windows.Forms.ToolStripMenuItem stilNegro;
        private System.Windows.Forms.ToolStripMenuItem stilAzul;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripMenuItem stilRosado;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatPersonalizar;
        private System.Windows.Forms.ToolStripDropDownButton CatsFondos;
        private System.Windows.Forms.ToolStripMenuItem PerFondo1;
        private System.Windows.Forms.ToolStripMenuItem PerFondo2;
        private System.Windows.Forms.ToolStripMenuItem PerFondo3;
        private System.Windows.Forms.ToolStripMenuItem PerFondo4;
        private System.Windows.Forms.ToolStripMenuItem PerFondoNone;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatProvee;
        private System.Windows.Forms.ToolStripDropDownButton CatsProveedores;
        private System.Windows.Forms.ToolStripMenuItem CatProveedores;
        private System.Windows.Forms.ToolStripMenuItem CatListaPrecios;
        private System.Windows.Forms.ToolStripMenuItem InvMenDocumentos;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModConfiguración;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx3;
        private System.Windows.Forms.ToolStripDropDownButton CfgMnuInventarios;
        private System.Windows.Forms.ToolStripMenuItem Inv_TipoMov;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx2;
        private System.Windows.Forms.ToolStripDropDownButton CfgMnuProveedores;
        private System.Windows.Forms.ToolStripMenuItem Prov_TipoMov;
        private System.Windows.Forms.ToolStripMenuItem Prov_SereDoc;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx4;
        private System.Windows.Forms.ToolStripDropDownButton MnuCfgFoliadores;
    }
}

