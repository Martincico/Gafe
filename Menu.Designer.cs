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
            this.catsAlmacenes = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.CatListaPrecios = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcInven = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuMovInventarios = new System.Windows.Forms.ToolStripDropDownButton();
            this.MnuKardexArt = new System.Windows.Forms.ToolStripDropDownButton();
            this.MnuExitenciaArt = new System.Windows.Forms.ToolStripDropDownButton();
            this.RepInven = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.ModProveedores = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatProvee = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsProveedores = new System.Windows.Forms.ToolStripDropDownButton();
            this.ContInvDocumentos = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuRequisición = new System.Windows.Forms.ToolStripButton();
            this.MnuCotizacion = new System.Windows.Forms.ToolStripButton();
            this.MnuOrdenCompra = new System.Windows.Forms.ToolStripButton();
            this.MnuCompras = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx2 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsClientes = new System.Windows.Forms.ToolStripDropDownButton();
            this.ModGeneral = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.catGeneral = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuGeografia = new System.Windows.Forms.ToolStripButton();
            this.ModSeguridad = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatSeguridad = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.CatsUsuarios = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatsPerfiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatsAsignaPer = new System.Windows.Forms.ToolStripDropDownButton();
            this.CatsUserCfg = new System.Windows.Forms.ToolStripDropDownButton();
            this.ModConfiguracion = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.CatConfig = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuFoliadores = new System.Windows.Forms.ToolStripButton();
            this.CatCfgProveedores = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.MnuDocProvee = new System.Windows.Forms.ToolStripButton();
            this.MnuDocSeries = new System.Windows.Forms.ToolStripButton();
            this.panelPie = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribMenu)).BeginInit();
            this.ribMenu.SuspendLayout();
            this.ModInventario.Panel.SuspendLayout();
            this.CatInven.SuspendLayout();
            this.ProcInven.SuspendLayout();
            this.ModProveedores.Panel.SuspendLayout();
            this.CatProvee.SuspendLayout();
            this.ContInvDocumentos.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.ModGeneral.Panel.SuspendLayout();
            this.catGeneral.SuspendLayout();
            this.ModSeguridad.Panel.SuspendLayout();
            this.CatSeguridad.SuspendLayout();
            this.ModConfiguracion.Panel.SuspendLayout();
            this.CatConfig.SuspendLayout();
            this.CatCfgProveedores.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribMenu
            // 
            this.ribMenu.BackStageNavigationButtonStyle = Syncfusion.Windows.Forms.Tools.BackStageNavigationButtonStyles.Office2013;
            this.ribMenu.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ribMenu.Header.AddMainItem(ModInventario);
            this.ribMenu.Header.AddMainItem(ModProveedores);
            this.ribMenu.Header.AddMainItem(ModGeneral);
            this.ribMenu.Header.AddMainItem(ModSeguridad);
            this.ribMenu.Header.AddMainItem(ModConfiguracion);
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
            this.ribMenu.SelectedTab = this.ModProveedores;
            this.ribMenu.ShowRibbonDisplayOptionButton = true;
            this.ribMenu.Size = new System.Drawing.Size(799, 170);
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
            this.CatInven.Size = new System.Drawing.Size(165, 101);
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
            this.CatClase});
            this.CatsArticulos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsArticulos.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.CatsArticulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CatsArticulos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CatsArticulos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsArticulos.Name = "CatsArticulos";
            this.CatsArticulos.Size = new System.Drawing.Size(65, 84);
            this.CatsArticulos.Text = "Artículos";
            this.CatsArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // CatArticulo
            // 
            this.CatArticulo.Name = "CatArticulo";
            this.CatArticulo.Size = new System.Drawing.Size(169, 22);
            this.CatArticulo.Text = "Artículos";
            this.CatArticulo.Click += new System.EventHandler(this.CatArticulo_Click);
            // 
            // CatUMedidas
            // 
            this.CatUMedidas.Name = "CatUMedidas";
            this.CatUMedidas.Size = new System.Drawing.Size(169, 22);
            this.CatUMedidas.Text = "Unidad de medida";
            this.CatUMedidas.Click += new System.EventHandler(this.CatUMedidas_Click);
            // 
            // CatLineas
            // 
            this.CatLineas.Name = "CatLineas";
            this.CatLineas.Size = new System.Drawing.Size(169, 22);
            this.CatLineas.Text = "Lineas";
            this.CatLineas.Click += new System.EventHandler(this.CatLineas_Click);
            // 
            // CatMarcas
            // 
            this.CatMarcas.Name = "CatMarcas";
            this.CatMarcas.Size = new System.Drawing.Size(169, 22);
            this.CatMarcas.Text = "Marcas";
            this.CatMarcas.Click += new System.EventHandler(this.CatMarcas_Click);
            // 
            // CatClase
            // 
            this.CatClase.Name = "CatClase";
            this.CatClase.Size = new System.Drawing.Size(169, 22);
            this.CatClase.Text = "Clases";
            this.CatClase.Click += new System.EventHandler(this.CatClase_Click);
            // 
            // catsAlmacenes
            // 
            this.catsAlmacenes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatAlmacen,
            this.CatListaPrecios});
            this.catsAlmacenes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.catsAlmacenes.Image = global::GAFE.Properties.Resources.MnuAlmacen;
            this.catsAlmacenes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.catsAlmacenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catsAlmacenes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.catsAlmacenes.Name = "catsAlmacenes";
            this.catsAlmacenes.Size = new System.Drawing.Size(74, 84);
            this.catsAlmacenes.Text = "Almacenes";
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
            this.MnuMovInventarios,
            this.MnuKardexArt,
            this.MnuExitenciaArt});
            this.ProcInven.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office2007;
            this.ProcInven.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.ProcInven.Location = new System.Drawing.Point(0, 1);
            this.ProcInven.Name = "ProcInven";
            this.ProcInven.Office12Mode = false;
            this.ProcInven.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ProcInven.Size = new System.Drawing.Size(131, 101);
            this.ProcInven.TabIndex = 4;
            this.ProcInven.Text = "Procesos";
            // 
            // MnuMovInventarios
            // 
            this.MnuMovInventarios.AutoSize = false;
            this.MnuMovInventarios.Image = global::GAFE.Properties.Resources.MnuInventario;
            this.MnuMovInventarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuMovInventarios.Name = "MnuMovInventarios";
            this.MnuMovInventarios.ShowDropDownArrow = false;
            this.MnuMovInventarios.Size = new System.Drawing.Size(120, 28);
            this.MnuMovInventarios.Text = "Mov. Inventarios";
            this.MnuMovInventarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuMovInventarios.Click += new System.EventHandler(this.MnuMovInventarios_Click);
            // 
            // MnuKardexArt
            // 
            this.MnuKardexArt.AutoSize = false;
            this.MnuKardexArt.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.MnuKardexArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuKardexArt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuKardexArt.Name = "MnuKardexArt";
            this.MnuKardexArt.ShowDropDownArrow = false;
            this.MnuKardexArt.Size = new System.Drawing.Size(120, 28);
            this.MnuKardexArt.Text = "Kardex";
            this.MnuKardexArt.Click += new System.EventHandler(this.MnuKardexArt_Click);
            // 
            // MnuExitenciaArt
            // 
            this.MnuExitenciaArt.AutoSize = false;
            this.MnuExitenciaArt.Image = global::GAFE.Properties.Resources.MnuProveedores;
            this.MnuExitenciaArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuExitenciaArt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuExitenciaArt.Name = "MnuExitenciaArt";
            this.MnuExitenciaArt.ShowDropDownArrow = false;
            this.MnuExitenciaArt.Size = new System.Drawing.Size(120, 28);
            this.MnuExitenciaArt.Text = "Existencias";
            this.MnuExitenciaArt.Click += new System.EventHandler(this.MnuExitenciaArt_Click);
            // 
            // RepInven
            // 
            this.RepInven.AutoSize = false;
            this.RepInven.Dock = System.Windows.Forms.DockStyle.None;
            this.RepInven.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.RepInven.ForeColor = System.Drawing.Color.Black;
            this.RepInven.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.RepInven.Image = null;
            this.RepInven.Location = new System.Drawing.Point(0, 1);
            this.RepInven.Name = "RepInven";
            this.RepInven.Office12Mode = false;
            this.RepInven.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RepInven.Size = new System.Drawing.Size(100, 101);
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
            this.ModProveedores.Panel.Controls.Add(this.ContInvDocumentos);
            this.ModProveedores.Panel.Controls.Add(this.toolStripEx2);
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
            this.CatProvee.Dock = System.Windows.Forms.DockStyle.None;
            this.CatProvee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatProvee.ForeColor = System.Drawing.Color.Black;
            this.CatProvee.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatProvee.Image = null;
            this.CatProvee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CatsProveedores});
            this.CatProvee.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.CatProvee.Location = new System.Drawing.Point(0, 1);
            this.CatProvee.Name = "CatProvee";
            this.CatProvee.Office12Mode = false;
            this.CatProvee.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatProvee.Size = new System.Drawing.Size(83, 101);
            this.CatProvee.TabIndex = 11;
            this.CatProvee.Text = "Catálogos";
            // 
            // CatsProveedores
            // 
            this.CatsProveedores.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsProveedores.Image = global::GAFE.Properties.Resources.MnuProveedores;
            this.CatsProveedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CatsProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CatsProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsProveedores.Name = "CatsProveedores";
            this.CatsProveedores.ShowDropDownArrow = false;
            this.CatsProveedores.Size = new System.Drawing.Size(74, 84);
            this.CatsProveedores.Text = "Proveedores";
            this.CatsProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsProveedores.Click += new System.EventHandler(this.CatsProveedores_Click);
            // 
            // ContInvDocumentos
            // 
            this.ContInvDocumentos.AutoSize = false;
            this.ContInvDocumentos.Dock = System.Windows.Forms.DockStyle.None;
            this.ContInvDocumentos.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ContInvDocumentos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ContInvDocumentos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ContInvDocumentos.Image = null;
            this.ContInvDocumentos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuRequisición,
            this.MnuCotizacion,
            this.MnuOrdenCompra,
            this.MnuCompras});
            this.ContInvDocumentos.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ContInvDocumentos.Location = new System.Drawing.Point(85, 1);
            this.ContInvDocumentos.Name = "ContInvDocumentos";
            this.ContInvDocumentos.Office12Mode = false;
            this.ContInvDocumentos.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ContInvDocumentos.Size = new System.Drawing.Size(226, 101);
            this.ContInvDocumentos.TabIndex = 10;
            this.ContInvDocumentos.Text = "Procesos";
            // 
            // MnuRequisición
            // 
            this.MnuRequisición.AutoSize = false;
            this.MnuRequisición.Image = global::GAFE.Properties.Resources.MnuAlmacen;
            this.MnuRequisición.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuRequisición.Name = "MnuRequisición";
            this.MnuRequisición.Size = new System.Drawing.Size(110, 42);
            this.MnuRequisición.Text = "Requisición";
            this.MnuRequisición.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuRequisición.Click += new System.EventHandler(this.MnuRequisición_Click);
            // 
            // MnuCotizacion
            // 
            this.MnuCotizacion.AutoSize = false;
            this.MnuCotizacion.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.MnuCotizacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuCotizacion.Name = "MnuCotizacion";
            this.MnuCotizacion.Size = new System.Drawing.Size(110, 42);
            this.MnuCotizacion.Text = "Cotización";
            this.MnuCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MnuCotizacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MnuCotizacion.Click += new System.EventHandler(this.MnuCotizacion_Click);
            // 
            // MnuOrdenCompra
            // 
            this.MnuOrdenCompra.AutoSize = false;
            this.MnuOrdenCompra.Image = global::GAFE.Properties.Resources.MnuInventario;
            this.MnuOrdenCompra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuOrdenCompra.Name = "MnuOrdenCompra";
            this.MnuOrdenCompra.Size = new System.Drawing.Size(110, 42);
            this.MnuOrdenCompra.Text = "Orden compra";
            this.MnuOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MnuOrdenCompra.Click += new System.EventHandler(this.MnuOrdenCompra_Click);
            // 
            // MnuCompras
            // 
            this.MnuCompras.AutoSize = false;
            this.MnuCompras.Image = global::GAFE.Properties.Resources.MnuProveedores;
            this.MnuCompras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuCompras.Name = "MnuCompras";
            this.MnuCompras.Size = new System.Drawing.Size(110, 42);
            this.MnuCompras.Text = "Compras";
            this.MnuCompras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MnuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MnuCompras.Click += new System.EventHandler(this.MnuCompras_Click);
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
            this.CatsClientes});
            this.toolStripEx2.Location = new System.Drawing.Point(313, 1);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Office12Mode = false;
            this.toolStripEx2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx2.Size = new System.Drawing.Size(145, 101);
            this.toolStripEx2.TabIndex = 9;
            this.toolStripEx2.Text = "Reportes";
            // 
            // CatsClientes
            // 
            this.CatsClientes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsClientes.Image = global::GAFE.Properties.Resources.MnuUsuarios;
            this.CatsClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CatsClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CatsClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsClientes.Name = "CatsClientes";
            this.CatsClientes.ShowDropDownArrow = false;
            this.CatsClientes.Size = new System.Drawing.Size(52, 84);
            this.CatsClientes.Text = "Clientes";
            this.CatsClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CatsClientes.Click += new System.EventHandler(this.CatsClientes_Click);
            // 
            // ModGeneral
            // 
            this.ModGeneral.Name = "ModGeneral";
            // 
            // ribMenu.ribbonPanel3
            // 
            this.ModGeneral.Panel.Controls.Add(this.catGeneral);
            this.ModGeneral.Panel.Name = "ribbonPanel3";
            this.ModGeneral.Panel.ScrollPosition = 0;
            this.ModGeneral.Panel.TabIndex = 5;
            this.ModGeneral.Panel.Text = "General";
            this.ModGeneral.Position = 2;
            this.ModGeneral.Size = new System.Drawing.Size(63, 30);
            this.ModGeneral.Tag = "1";
            this.ModGeneral.Text = "General";
            // 
            // catGeneral
            // 
            this.catGeneral.AutoSize = false;
            this.catGeneral.Dock = System.Windows.Forms.DockStyle.None;
            this.catGeneral.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.catGeneral.ForeColor = System.Drawing.Color.MidnightBlue;
            this.catGeneral.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.catGeneral.Image = null;
            this.catGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuGeografia});
            this.catGeneral.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.catGeneral.Location = new System.Drawing.Point(0, 1);
            this.catGeneral.Name = "catGeneral";
            this.catGeneral.Office12Mode = false;
            this.catGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.catGeneral.Size = new System.Drawing.Size(126, 101);
            this.catGeneral.TabIndex = 0;
            this.catGeneral.Text = "General";
            // 
            // MnuGeografia
            // 
            this.MnuGeografia.AutoSize = false;
            this.MnuGeografia.Image = global::GAFE.Properties.Resources.MnuColores;
            this.MnuGeografia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuGeografia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuGeografia.Name = "MnuGeografia";
            this.MnuGeografia.Size = new System.Drawing.Size(94, 28);
            this.MnuGeografia.Text = "Geografía";
            this.MnuGeografia.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.MnuGeografia.Click += new System.EventHandler(this.MnuGeografia_Click);
            // 
            // ModSeguridad
            // 
            this.ModSeguridad.Name = "ModSeguridad";
            // 
            // ribMenu.ribbonPanel4
            // 
            this.ModSeguridad.Panel.Controls.Add(this.CatSeguridad);
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
            this.CatsAsignaPer,
            this.CatsUserCfg});
            this.CatSeguridad.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.CatSeguridad.Location = new System.Drawing.Point(0, 1);
            this.CatSeguridad.Name = "CatSeguridad";
            this.CatSeguridad.Office12Mode = false;
            this.CatSeguridad.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatSeguridad.Size = new System.Drawing.Size(248, 101);
            this.CatSeguridad.TabIndex = 1;
            this.CatSeguridad.Text = "Usuarios";
            // 
            // CatsUsuarios
            // 
            this.CatsUsuarios.AutoSize = false;
            this.CatsUsuarios.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsUsuarios.Image = global::GAFE.Properties.Resources.MnuUsuarios;
            this.CatsUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CatsUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsUsuarios.Name = "CatsUsuarios";
            this.CatsUsuarios.ShowDropDownArrow = false;
            this.CatsUsuarios.Size = new System.Drawing.Size(120, 42);
            this.CatsUsuarios.Text = "Usuarios";
            this.CatsUsuarios.ToolTipText = "Usuarios";
            this.CatsUsuarios.Click += new System.EventHandler(this.CatsUsuarios_Click);
            // 
            // CatsPerfiles
            // 
            this.CatsPerfiles.AutoSize = false;
            this.CatsPerfiles.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsPerfiles.Image = global::GAFE.Properties.Resources.MnuColores;
            this.CatsPerfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CatsPerfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsPerfiles.Name = "CatsPerfiles";
            this.CatsPerfiles.ShowDropDownArrow = false;
            this.CatsPerfiles.Size = new System.Drawing.Size(120, 42);
            this.CatsPerfiles.Text = "Perfiles";
            this.CatsPerfiles.ToolTipText = "Perfiles";
            this.CatsPerfiles.Click += new System.EventHandler(this.CatsPerfiles_Click);
            // 
            // CatsAsignaPer
            // 
            this.CatsAsignaPer.AutoSize = false;
            this.CatsAsignaPer.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsAsignaPer.Image = global::GAFE.Properties.Resources.MnuAlmacen;
            this.CatsAsignaPer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CatsAsignaPer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsAsignaPer.Name = "CatsAsignaPer";
            this.CatsAsignaPer.ShowDropDownArrow = false;
            this.CatsAsignaPer.Size = new System.Drawing.Size(120, 42);
            this.CatsAsignaPer.Text = "Permisos";
            this.CatsAsignaPer.ToolTipText = "Permisos";
            this.CatsAsignaPer.Click += new System.EventHandler(this.CatsAsignaPer_Click);
            // 
            // CatsUserCfg
            // 
            this.CatsUserCfg.AutoSize = false;
            this.CatsUserCfg.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatsUserCfg.Image = global::GAFE.Properties.Resources.MnuTemas;
            this.CatsUserCfg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CatsUserCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CatsUserCfg.Name = "CatsUserCfg";
            this.CatsUserCfg.ShowDropDownArrow = false;
            this.CatsUserCfg.Size = new System.Drawing.Size(120, 42);
            this.CatsUserCfg.Text = "Configuración";
            this.CatsUserCfg.ToolTipText = "Configuración";
            this.CatsUserCfg.Click += new System.EventHandler(this.CatsUserCfg_Click);
            // 
            // ModConfiguracion
            // 
            this.ModConfiguracion.Name = "ModConfiguracion";
            // 
            // ribMenu.ribbonPanel5
            // 
            this.ModConfiguracion.Panel.Controls.Add(this.CatConfig);
            this.ModConfiguracion.Panel.Controls.Add(this.CatCfgProveedores);
            this.ModConfiguracion.Panel.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Office2007;
            this.ModConfiguracion.Panel.Name = "ribbonPanel5";
            this.ModConfiguracion.Panel.ScrollPosition = 0;
            this.ModConfiguracion.Panel.TabIndex = 6;
            this.ModConfiguracion.Panel.Text = "Configuración";
            this.ModConfiguracion.Position = 4;
            this.ModConfiguracion.Size = new System.Drawing.Size(97, 30);
            this.ModConfiguracion.Tag = "1";
            this.ModConfiguracion.Text = "Configuración";
            // 
            // CatConfig
            // 
            this.CatConfig.AutoSize = false;
            this.CatConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.CatConfig.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatConfig.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatConfig.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatConfig.Image = null;
            this.CatConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFoliadores});
            this.CatConfig.Location = new System.Drawing.Point(0, 1);
            this.CatConfig.Name = "CatConfig";
            this.CatConfig.Office12Mode = false;
            this.CatConfig.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatConfig.Size = new System.Drawing.Size(126, 101);
            this.CatConfig.TabIndex = 2;
            this.CatConfig.Text = "Documentos";
            // 
            // MnuFoliadores
            // 
            this.MnuFoliadores.AutoSize = false;
            this.MnuFoliadores.Image = global::GAFE.Properties.Resources.MnuTemas;
            this.MnuFoliadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuFoliadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuFoliadores.Name = "MnuFoliadores";
            this.MnuFoliadores.Size = new System.Drawing.Size(94, 28);
            this.MnuFoliadores.Text = "Foliadores";
            this.MnuFoliadores.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.MnuFoliadores.Click += new System.EventHandler(this.MnuFoliadores_Click);
            // 
            // CatCfgProveedores
            // 
            this.CatCfgProveedores.AutoSize = false;
            this.CatCfgProveedores.Dock = System.Windows.Forms.DockStyle.None;
            this.CatCfgProveedores.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CatCfgProveedores.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CatCfgProveedores.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CatCfgProveedores.Image = null;
            this.CatCfgProveedores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDocProvee,
            this.MnuDocSeries});
            this.CatCfgProveedores.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.CatCfgProveedores.Location = new System.Drawing.Point(128, 1);
            this.CatCfgProveedores.Name = "CatCfgProveedores";
            this.CatCfgProveedores.Office12Mode = false;
            this.CatCfgProveedores.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.CatCfgProveedores.Size = new System.Drawing.Size(130, 101);
            this.CatCfgProveedores.TabIndex = 3;
            this.CatCfgProveedores.Text = "Proveedores";
            // 
            // MnuDocProvee
            // 
            this.MnuDocProvee.AutoSize = false;
            this.MnuDocProvee.Image = global::GAFE.Properties.Resources.MnuProveedores;
            this.MnuDocProvee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuDocProvee.Name = "MnuDocProvee";
            this.MnuDocProvee.Size = new System.Drawing.Size(110, 42);
            this.MnuDocProvee.Text = "Documentos";
            this.MnuDocProvee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuDocProvee.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.MnuDocProvee.Click += new System.EventHandler(this.MnuDocProvee_Click);
            // 
            // MnuDocSeries
            // 
            this.MnuDocSeries.AutoSize = false;
            this.MnuDocSeries.Image = global::GAFE.Properties.Resources.MnuInventario;
            this.MnuDocSeries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuDocSeries.Name = "MnuDocSeries";
            this.MnuDocSeries.Size = new System.Drawing.Size(110, 42);
            this.MnuDocSeries.Text = "Serie Doc";
            this.MnuDocSeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnuDocSeries.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.MnuDocSeries.Click += new System.EventHandler(this.MnuDocSeries_Click);
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
            this.panelContenedor.Location = new System.Drawing.Point(1, 170);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(799, 224);
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
            this.ModProveedores.Panel.PerformLayout();
            this.CatProvee.ResumeLayout(false);
            this.CatProvee.PerformLayout();
            this.ContInvDocumentos.ResumeLayout(false);
            this.ContInvDocumentos.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.ModGeneral.Panel.ResumeLayout(false);
            this.catGeneral.ResumeLayout(false);
            this.catGeneral.PerformLayout();
            this.ModSeguridad.Panel.ResumeLayout(false);
            this.CatSeguridad.ResumeLayout(false);
            this.CatSeguridad.PerformLayout();
            this.ModConfiguracion.Panel.ResumeLayout(false);
            this.CatConfig.ResumeLayout(false);
            this.CatConfig.PerformLayout();
            this.CatCfgProveedores.ResumeLayout(false);
            this.CatCfgProveedores.PerformLayout();
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
        private System.Windows.Forms.ToolStripDropDownButton catsAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem CatAlmacen;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx ProcInven;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx RepInven;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripMenuItem CatListaPrecios;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModGeneral;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx catGeneral;
        private System.Windows.Forms.ToolStripButton MnuGeografia;
        private System.Windows.Forms.ToolStripDropDownButton MnuMovInventarios;
        private System.Windows.Forms.ToolStripDropDownButton MnuKardexArt;
        private System.Windows.Forms.ToolStripDropDownButton MnuExitenciaArt;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatProvee;
        private System.Windows.Forms.ToolStripDropDownButton CatsProveedores;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx ContInvDocumentos;
        private System.Windows.Forms.ToolStripButton MnuRequisición;
        private System.Windows.Forms.ToolStripButton MnuCotizacion;
        private System.Windows.Forms.ToolStripButton MnuOrdenCompra;
        private System.Windows.Forms.ToolStripButton MnuCompras;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx2;
        private System.Windows.Forms.ToolStripDropDownButton CatsUserCfg;
        private System.Windows.Forms.ToolStripDropDownButton CatsClientes;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem ModConfiguracion;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatConfig;
        private System.Windows.Forms.ToolStripButton MnuFoliadores;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx CatCfgProveedores;
        private System.Windows.Forms.ToolStripButton MnuDocProvee;
        private System.Windows.Forms.ToolStripButton MnuDocSeries;
    }
}

