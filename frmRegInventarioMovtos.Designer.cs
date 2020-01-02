namespace GAFE
{
    partial class frmRegInventarioMovtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInventarioMovtos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblTipoMovtos = new System.Windows.Forms.Label();
            this.lblAlmaDest = new System.Windows.Forms.Label();
            this.lblAlmaOri = new System.Windows.Forms.Label();
            this.lblClaseMov = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboClaseMov = new System.Windows.Forms.ComboBox();
            this.cboAlmaDest = new System.Windows.Forms.ComboBox();
            this.cboTipoMovtos = new System.Windows.Forms.ComboBox();
            this.cboAlmaOri = new System.Windows.Forms.ComboBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.grdViewPart = new System.Windows.Forms.DataGridView();
            this.btnAddPartida = new System.Windows.Forms.Button();
            this.btnEliminarPartida = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtTotDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditaPartida = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTitDocumento = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblTitFolio = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTitFecha = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewPart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblProveedor);
            this.panel2.Controls.Add(this.lblTipoMovtos);
            this.panel2.Controls.Add(this.lblAlmaDest);
            this.panel2.Controls.Add(this.lblAlmaOri);
            this.panel2.Controls.Add(this.lblClaseMov);
            this.panel2.Controls.Add(this.cboProveedor);
            this.panel2.Controls.Add(this.cboClaseMov);
            this.panel2.Controls.Add(this.cboAlmaDest);
            this.panel2.Controls.Add(this.cboTipoMovtos);
            this.panel2.Controls.Add(this.cboAlmaOri);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblProveedor
            // 
            resources.ApplyResources(this.lblProveedor, "lblProveedor");
            this.lblProveedor.Name = "lblProveedor";
            // 
            // lblTipoMovtos
            // 
            resources.ApplyResources(this.lblTipoMovtos, "lblTipoMovtos");
            this.lblTipoMovtos.Name = "lblTipoMovtos";
            // 
            // lblAlmaDest
            // 
            resources.ApplyResources(this.lblAlmaDest, "lblAlmaDest");
            this.lblAlmaDest.Name = "lblAlmaDest";
            // 
            // lblAlmaOri
            // 
            resources.ApplyResources(this.lblAlmaOri, "lblAlmaOri");
            this.lblAlmaOri.Name = "lblAlmaOri";
            // 
            // lblClaseMov
            // 
            resources.ApplyResources(this.lblClaseMov, "lblClaseMov");
            this.lblClaseMov.Name = "lblClaseMov";
            // 
            // cboProveedor
            // 
            resources.ApplyResources(this.cboProveedor, "cboProveedor");
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Name = "cboProveedor";
            // 
            // cboClaseMov
            // 
            this.cboClaseMov.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClaseMov.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cboClaseMov, "cboClaseMov");
            this.cboClaseMov.FormattingEnabled = true;
            this.cboClaseMov.Name = "cboClaseMov";
            this.cboClaseMov.SelectedIndexChanged += new System.EventHandler(this.cboClaseMov_SelectedIndexChanged);
            // 
            // cboAlmaDest
            // 
            resources.ApplyResources(this.cboAlmaDest, "cboAlmaDest");
            this.cboAlmaDest.FormattingEnabled = true;
            this.cboAlmaDest.Name = "cboAlmaDest";
            this.cboAlmaDest.SelectedIndexChanged += new System.EventHandler(this.cboAlmaDest_SelectedIndexChanged);
            // 
            // cboTipoMovtos
            // 
            resources.ApplyResources(this.cboTipoMovtos, "cboTipoMovtos");
            this.cboTipoMovtos.FormattingEnabled = true;
            this.cboTipoMovtos.Name = "cboTipoMovtos";
            this.cboTipoMovtos.SelectedValueChanged += new System.EventHandler(this.cboTipoMovtos_SelectedValueChanged);
            // 
            // cboAlmaOri
            // 
            resources.ApplyResources(this.cboAlmaOri, "cboAlmaOri");
            this.cboAlmaOri.FormattingEnabled = true;
            this.cboAlmaOri.Name = "cboAlmaOri";
            this.cboAlmaOri.SelectedValueChanged += new System.EventHandler(this.cboAlmaOri_SelectedValueChanged);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cmdCancelar, "cmdCancelar");
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cmdAceptar, "cmdAceptar");
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // grdViewPart
            // 
            this.grdViewPart.AllowUserToAddRows = false;
            this.grdViewPart.AllowUserToDeleteRows = false;
            this.grdViewPart.AllowUserToOrderColumns = true;
            this.grdViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.grdViewPart, "grdViewPart");
            this.grdViewPart.Name = "grdViewPart";
            this.grdViewPart.ReadOnly = true;
            // 
            // btnAddPartida
            // 
            this.btnAddPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddPartida.Image = global::GAFE.Properties.Resources.Nuevo;
            resources.ApplyResources(this.btnAddPartida, "btnAddPartida");
            this.btnAddPartida.Name = "btnAddPartida";
            this.btnAddPartida.UseVisualStyleBackColor = false;
            this.btnAddPartida.Click += new System.EventHandler(this.btnAddPartida_Click);
            // 
            // btnEliminarPartida
            // 
            this.btnEliminarPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPartida.Image = global::GAFE.Properties.Resources.Eliminar;
            resources.ApplyResources(this.btnEliminarPartida, "btnEliminarPartida");
            this.btnEliminarPartida.Name = "btnEliminarPartida";
            this.btnEliminarPartida.UseVisualStyleBackColor = false;
            this.btnEliminarPartida.Click += new System.EventHandler(this.btnEliminarPartida_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtTotal, "txtTotal");
            this.txtTotal.Name = "txtTotal";
            // 
            // txtIva
            // 
            this.txtIva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtIva, "txtIva");
            this.txtIva.Name = "txtIva";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtSubTotal, "txtSubTotal");
            this.txtSubTotal.Name = "txtSubTotal";
            // 
            // txtTotDesc
            // 
            this.txtTotDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtTotDesc, "txtTotDesc");
            this.txtTotDesc.Name = "txtTotDesc";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtDescuento
            // 
            this.txtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtDescuento, "txtDescuento");
            this.txtDescuento.Name = "txtDescuento";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnEditaPartida
            // 
            this.btnEditaPartida.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditaPartida.Image = global::GAFE.Properties.Resources.Editar;
            resources.ApplyResources(this.btnEditaPartida, "btnEditaPartida");
            this.btnEditaPartida.Name = "btnEditaPartida";
            this.btnEditaPartida.UseVisualStyleBackColor = false;
            this.btnEditaPartida.Click += new System.EventHandler(this.btnEditaPartida_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblDocumento);
            this.panel1.Controls.Add(this.lblTitDocumento);
            this.panel1.Controls.Add(this.lblFolio);
            this.panel1.Controls.Add(this.lblTitFolio);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblTitFecha);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lblDocumento
            // 
            resources.ApplyResources(this.lblDocumento, "lblDocumento");
            this.lblDocumento.Name = "lblDocumento";
            // 
            // lblTitDocumento
            // 
            resources.ApplyResources(this.lblTitDocumento, "lblTitDocumento");
            this.lblTitDocumento.Name = "lblTitDocumento";
            // 
            // lblFolio
            // 
            resources.ApplyResources(this.lblFolio, "lblFolio");
            this.lblFolio.Name = "lblFolio";
            // 
            // lblTitFolio
            // 
            resources.ApplyResources(this.lblTitFolio, "lblTitFolio");
            this.lblTitFolio.Name = "lblTitFolio";
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.lblFecha.Name = "lblFecha";
            // 
            // lblTitFecha
            // 
            resources.ApplyResources(this.lblTitFecha, "lblTitFecha");
            this.lblTitFecha.Name = "lblTitFecha";
            // 
            // frmRegInventarioMovtos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditaPartida);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtTotDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEliminarPartida);
            this.Controls.Add(this.btnAddPartida);
            this.Controls.Add(this.grdViewPart);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegInventarioMovtos";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegInventarioMovtos_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewPart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.DataGridView grdViewPart;
        private System.Windows.Forms.Button btnAddPartida;
        private System.Windows.Forms.Button btnEliminarPartida;
        private System.Windows.Forms.ComboBox cboAlmaOri;
        private System.Windows.Forms.ComboBox cboClaseMov;
        private System.Windows.Forms.Label lblAlmaOri;
        private System.Windows.Forms.Label lblClaseMov;
        private System.Windows.Forms.Label lblTipoMovtos;
        private System.Windows.Forms.ComboBox cboTipoMovtos;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblAlmaDest;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.ComboBox cboAlmaDest;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtTotDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditaPartida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTitDocumento;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblTitFolio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTitFecha;
    }
}