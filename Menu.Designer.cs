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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.Clientes = new System.Windows.Forms.RibbonTab();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ModInventario = new System.Windows.Forms.RibbonTab();
            this.CatInven = new System.Windows.Forms.RibbonPanel();
            this.ProcInven = new System.Windows.Forms.RibbonPanel();
            this.RepInven = new System.Windows.Forms.RibbonPanel();
            this.ModProveedores = new System.Windows.Forms.RibbonTab();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.sUsuarios = new System.Windows.Forms.RibbonOrbMenuItem();
            this.sPerfiles = new System.Windows.Forms.RibbonOrbMenuItem();
            this.sAsignaPermisos = new System.Windows.Forms.RibbonOrbMenuItem();
            this.CatsArticulos = new System.Windows.Forms.RibbonButton();
            this.cmdAlmacenes = new System.Windows.Forms.RibbonButton();
            this.CatArticulo = new System.Windows.Forms.RibbonButton();
            this.CatUMedidas = new System.Windows.Forms.RibbonButton();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.CatLineas = new System.Windows.Forms.RibbonButton();
            this.CatMarcas = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // Clientes
            // 
            this.Clientes.Name = "Clientes";
            this.Clientes.Text = "Clientes";
            this.Clientes.Visible = false;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "Inventarios";
            this.ribbonTab1.Visible = false;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Catalogos";
            this.ribbonPanel1.Visible = false;
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.CheckOnClick = true;
            this.ribbonButton2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Right;
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Almacenes";
            this.ribbonButton2.Visible = false;
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Procesos";
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Reportes";
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Proveedores";
            this.ribbonTab2.Visible = false;
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = null;
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.ForeColor = System.Drawing.SystemColors.Window;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.sUsuarios);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.sPerfiles);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.sAsignaPermisos);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 224);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(800, 157);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ModInventario);
            this.ribbon1.Tabs.Add(this.ModProveedores);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.JellyBelly;
            // 
            // ModInventario
            // 
            this.ModInventario.Name = "ModInventario";
            this.ModInventario.Panels.Add(this.CatInven);
            this.ModInventario.Panels.Add(this.ProcInven);
            this.ModInventario.Panels.Add(this.RepInven);
            this.ModInventario.Text = "Inventarios";
            // 
            // CatInven
            // 
            this.CatInven.Items.Add(this.CatsArticulos);
            this.CatInven.Items.Add(this.cmdAlmacenes);
            this.CatInven.Name = "CatInven";
            this.CatInven.Text = "Catalogos";
            // 
            // ProcInven
            // 
            this.ProcInven.Name = "ProcInven";
            this.ProcInven.Text = "Procesos";
            // 
            // RepInven
            // 
            this.RepInven.Name = "RepInven";
            this.RepInven.Text = "Reportes";
            // 
            // ModProveedores
            // 
            this.ModProveedores.Name = "ModProveedores";
            this.ModProveedores.Text = "Proveedores";
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            this.ribbonSeparator1.Text = "Seguridad";
            // 
            // sUsuarios
            // 
            this.sUsuarios.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.sUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("sUsuarios.Image")));
            this.sUsuarios.LargeImage = ((System.Drawing.Image)(resources.GetObject("sUsuarios.LargeImage")));
            this.sUsuarios.Name = "sUsuarios";
            this.sUsuarios.SmallImage = ((System.Drawing.Image)(resources.GetObject("sUsuarios.SmallImage")));
            this.sUsuarios.Text = "Usuarios";
            // 
            // sPerfiles
            // 
            this.sPerfiles.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.sPerfiles.Image = ((System.Drawing.Image)(resources.GetObject("sPerfiles.Image")));
            this.sPerfiles.LargeImage = ((System.Drawing.Image)(resources.GetObject("sPerfiles.LargeImage")));
            this.sPerfiles.Name = "sPerfiles";
            this.sPerfiles.SmallImage = ((System.Drawing.Image)(resources.GetObject("sPerfiles.SmallImage")));
            this.sPerfiles.Text = "Perfiles";
            // 
            // sAsignaPermisos
            // 
            this.sAsignaPermisos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.sAsignaPermisos.Image = ((System.Drawing.Image)(resources.GetObject("sAsignaPermisos.Image")));
            this.sAsignaPermisos.LargeImage = ((System.Drawing.Image)(resources.GetObject("sAsignaPermisos.LargeImage")));
            this.sAsignaPermisos.Name = "sAsignaPermisos";
            this.sAsignaPermisos.SmallImage = ((System.Drawing.Image)(resources.GetObject("sAsignaPermisos.SmallImage")));
            this.sAsignaPermisos.Text = "Asignar Permisos";
            // 
            // CatsArticulos
            // 
            this.CatsArticulos.DropDownItems.Add(this.CatArticulo);
            this.CatsArticulos.DropDownItems.Add(this.CatUMedidas);
            this.CatsArticulos.DropDownItems.Add(this.CatLineas);
            this.CatsArticulos.DropDownItems.Add(this.CatMarcas);
            this.CatsArticulos.DropDownItems.Add(this.ribbonButton5);
            this.CatsArticulos.Image = global::GAFE.Properties.Resources.Cancelar;
            this.CatsArticulos.LargeImage = global::GAFE.Properties.Resources.Cancelar;
            this.CatsArticulos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown;
            this.CatsArticulos.Name = "CatsArticulos";
            this.CatsArticulos.SmallImage = global::GAFE.Properties.Resources.Cancelar;
            this.CatsArticulos.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.CatsArticulos.Text = "Articulos";
            // 
            // cmdAlmacenes
            // 
            this.cmdAlmacenes.DropDownItems.Add(this.ribbonButton7);
            this.cmdAlmacenes.DropDownItems.Add(this.ribbonButton8);
            this.cmdAlmacenes.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdAlmacenes.LargeImage = global::GAFE.Properties.Resources.Cancelar;
            this.cmdAlmacenes.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.cmdAlmacenes.Name = "cmdAlmacenes";
            this.cmdAlmacenes.SmallImage = global::GAFE.Properties.Resources.Cancelar;
            this.cmdAlmacenes.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.cmdAlmacenes.Text = "Almacenes";
            // 
            // CatArticulo
            // 
            this.CatArticulo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CatArticulo.Image = ((System.Drawing.Image)(resources.GetObject("CatArticulo.Image")));
            this.CatArticulo.LargeImage = ((System.Drawing.Image)(resources.GetObject("CatArticulo.LargeImage")));
            this.CatArticulo.Name = "CatArticulo";
            this.CatArticulo.SmallImage = ((System.Drawing.Image)(resources.GetObject("CatArticulo.SmallImage")));
            this.CatArticulo.Text = "Articulos";
            // 
            // CatUMedidas
            // 
            this.CatUMedidas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CatUMedidas.DropDownItems.Add(this.ribbonButton3);
            this.CatUMedidas.Image = ((System.Drawing.Image)(resources.GetObject("CatUMedidas.Image")));
            this.CatUMedidas.LargeImage = ((System.Drawing.Image)(resources.GetObject("CatUMedidas.LargeImage")));
            this.CatUMedidas.Name = "CatUMedidas";
            this.CatUMedidas.SmallImage = ((System.Drawing.Image)(resources.GetObject("CatUMedidas.SmallImage")));
            this.CatUMedidas.Text = "Unidades de medida";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.LargeImage")));
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "ribbonButton7";
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.LargeImage")));
            this.ribbonButton8.Name = "ribbonButton8";
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            this.ribbonButton8.Text = "ribbonButton8";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "ribbonButton3";
            // 
            // CatLineas
            // 
            this.CatLineas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CatLineas.Image = ((System.Drawing.Image)(resources.GetObject("CatLineas.Image")));
            this.CatLineas.LargeImage = ((System.Drawing.Image)(resources.GetObject("CatLineas.LargeImage")));
            this.CatLineas.Name = "CatLineas";
            this.CatLineas.SmallImage = ((System.Drawing.Image)(resources.GetObject("CatLineas.SmallImage")));
            this.CatLineas.Text = "Lineas";
            // 
            // CatMarcas
            // 
            this.CatMarcas.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CatMarcas.Image = ((System.Drawing.Image)(resources.GetObject("CatMarcas.Image")));
            this.CatMarcas.LargeImage = ((System.Drawing.Image)(resources.GetObject("CatMarcas.LargeImage")));
            this.CatMarcas.Name = "CatMarcas";
            this.CatMarcas.SmallImage = ((System.Drawing.Image)(resources.GetObject("CatMarcas.SmallImage")));
            this.CatMarcas.Text = "Marcas";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RibbonTab Clientes;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ModInventario;
        private System.Windows.Forms.RibbonPanel ProcInven;
        private System.Windows.Forms.RibbonPanel RepInven;
        private System.Windows.Forms.RibbonTab ModProveedores;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem sUsuarios;
        private System.Windows.Forms.RibbonOrbMenuItem sPerfiles;
        private System.Windows.Forms.RibbonOrbMenuItem sAsignaPermisos;
        public System.Windows.Forms.RibbonPanel CatInven;
        private System.Windows.Forms.RibbonButton CatsArticulos;
        private System.Windows.Forms.RibbonButton CatArticulo;
        private System.Windows.Forms.RibbonButton CatUMedidas;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton CatLineas;
        private System.Windows.Forms.RibbonButton CatMarcas;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton cmdAlmacenes;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonButton ribbonButton8;
    }
}

