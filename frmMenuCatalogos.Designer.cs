namespace GAFE
{
    partial class frmMenuCatalogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuCatalogos));
            this.PanCabeza = new System.Windows.Forms.Panel();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.lblCabeza = new System.Windows.Forms.Label();
            this.PanPíe = new System.Windows.Forms.Panel();
            this.txtError = new System.Windows.Forms.TextBox();
            this.PanMenu = new System.Windows.Forms.Panel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BarraSidePanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmdClases = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PanContenido = new System.Windows.Forms.Panel();
            this.PanCabeza.SuspendLayout();
            this.PanPíe.SuspendLayout();
            this.PanMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanCabeza
            // 
            this.PanCabeza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.PanCabeza.Controls.Add(this.cmdCerrar);
            this.PanCabeza.Controls.Add(this.lblCabeza);
            this.PanCabeza.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanCabeza.Location = new System.Drawing.Point(0, 0);
            this.PanCabeza.Name = "PanCabeza";
            this.PanCabeza.Size = new System.Drawing.Size(990, 33);
            this.PanCabeza.TabIndex = 3;
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.FlatAppearance.BorderSize = 0;
            this.cmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCerrar.ForeColor = System.Drawing.Color.White;
            this.cmdCerrar.Location = new System.Drawing.Point(691, 2);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(30, 31);
            this.cmdCerrar.TabIndex = 4;
            this.cmdCerrar.Text = "X";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // lblCabeza
            // 
            this.lblCabeza.AutoSize = true;
            this.lblCabeza.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabeza.ForeColor = System.Drawing.Color.White;
            this.lblCabeza.Location = new System.Drawing.Point(6, 7);
            this.lblCabeza.Name = "lblCabeza";
            this.lblCabeza.Size = new System.Drawing.Size(0, 16);
            this.lblCabeza.TabIndex = 0;
            // 
            // PanPíe
            // 
            this.PanPíe.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PanPíe.Controls.Add(this.txtError);
            this.PanPíe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanPíe.Location = new System.Drawing.Point(0, 494);
            this.PanPíe.Name = "PanPíe";
            this.PanPíe.Size = new System.Drawing.Size(990, 74);
            this.PanPíe.TabIndex = 4;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(9, 6);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(969, 56);
            this.txtError.TabIndex = 2;
            // 
            // PanMenu
            // 
            this.PanMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanMenu.Controls.Add(this.ribbon1);
            this.PanMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanMenu.Location = new System.Drawing.Point(0, 33);
            this.PanMenu.Name = "PanMenu";
            this.PanMenu.Size = new System.Drawing.Size(990, 118);
            this.PanMenu.TabIndex = 6;
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(990, 117);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.BarraSidePanel);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cmdClases);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 343);
            this.panel1.TabIndex = 7;
            // 
            // BarraSidePanel
            // 
            this.BarraSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.BarraSidePanel.Location = new System.Drawing.Point(2, 47);
            this.BarraSidePanel.Name = "BarraSidePanel";
            this.BarraSidePanel.Size = new System.Drawing.Size(8, 46);
            this.BarraSidePanel.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(12, 228);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(214, 46);
            this.button5.TabIndex = 4;
            this.button5.Text = "     Marcas";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(12, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(214, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "  Unidad de Medida";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(12, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "   Lineas";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // cmdClases
            // 
            this.cmdClases.FlatAppearance.BorderSize = 0;
            this.cmdClases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClases.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClases.ForeColor = System.Drawing.Color.White;
            this.cmdClases.Image = ((System.Drawing.Image)(resources.GetObject("cmdClases.Image")));
            this.cmdClases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClases.Location = new System.Drawing.Point(12, 93);
            this.cmdClases.Name = "cmdClases";
            this.cmdClases.Size = new System.Drawing.Size(214, 46);
            this.cmdClases.TabIndex = 1;
            this.cmdClases.Text = "   Clases";
            this.cmdClases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClases.UseVisualStyleBackColor = true;
            this.cmdClases.Click += new System.EventHandler(this.cmdClases_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "   Inicio";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PanContenido
            // 
            this.PanContenido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanContenido.Location = new System.Drawing.Point(246, 151);
            this.PanContenido.Name = "PanContenido";
            this.PanContenido.Size = new System.Drawing.Size(744, 343);
            this.PanContenido.TabIndex = 8;
            // 
            // frmMenuCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(990, 568);
            this.Controls.Add(this.PanContenido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanMenu);
            this.Controls.Add(this.PanPíe);
            this.Controls.Add(this.PanCabeza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmMenuCatalogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenuCatalogos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanCabeza.ResumeLayout(false);
            this.PanCabeza.PerformLayout();
            this.PanPíe.ResumeLayout(false);
            this.PanPíe.PerformLayout();
            this.PanMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanCabeza;
        private System.Windows.Forms.Label lblCabeza;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Panel PanPíe;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Panel PanMenu;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel BarraSidePanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cmdClases;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PanContenido;
    }
}