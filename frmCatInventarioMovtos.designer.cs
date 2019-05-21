namespace GAFE
{
    partial class frmCatInventarioMovtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatInventarioMovtos));
            this.cmEliminar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdResetear = new System.Windows.Forms.Button();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmEliminar
            // 
            this.cmEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.cmEliminar.Image = global::GAFE.Properties.Resources.Eliminar;
            this.cmEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmEliminar.Location = new System.Drawing.Point(358, 420);
            this.cmEliminar.Name = "cmEliminar";
            this.cmEliminar.Size = new System.Drawing.Size(94, 36);
            this.cmEliminar.TabIndex = 5;
            this.cmEliminar.Text = "Eliminar";
            this.cmEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmEliminar.UseVisualStyleBackColor = false;
            this.cmEliminar.Click += new System.EventHandler(this.cmEliminar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(578, 420);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregar.TabIndex = 4;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.UseVisualStyleBackColor = false;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Location = new System.Drawing.Point(9, 78);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(673, 322);
            this.grdView.TabIndex = 8;
            this.grdView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellContentClick);
            this.grdView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdView_RowHeaderMouseDoubleClick);
            this.grdView.DoubleClick += new System.EventHandler(this.grdView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdResetear);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 71);
            this.panel1.TabIndex = 7;
            // 
            // cmdResetear
            // 
            this.cmdResetear.BackColor = System.Drawing.SystemColors.Control;
            this.cmdResetear.Image = ((System.Drawing.Image)(resources.GetObject("cmdResetear.Image")));
            this.cmdResetear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdResetear.Location = new System.Drawing.Point(576, 9);
            this.cmdResetear.Name = "cmdResetear";
            this.cmdResetear.Size = new System.Drawing.Size(94, 36);
            this.cmdResetear.TabIndex = 2;
            this.cmdResetear.Text = "Buscar";
            this.cmdResetear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdResetear.UseVisualStyleBackColor = false;
            this.cmdResetear.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsultar.Image = ((System.Drawing.Image)(resources.GetObject("cmdConsultar.Image")));
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.Location = new System.Drawing.Point(178, 420);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 36);
            this.cmdConsultar.TabIndex = 3;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(9, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Imprimir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCatInventarioMovtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.cmEliminar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(710, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(710, 500);
            this.Name = "frmCatInventarioMovtos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo movimientos de inventarios";
            this.Load += new System.EventHandler(this.frmCatInventarioMovtos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmEliminar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdResetear;
        private System.Windows.Forms.Button button1;
    }
}