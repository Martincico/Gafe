namespace GAFE
{
    partial class frmExistencias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOmitir0 = new System.Windows.Forms.CheckBox();
            this.cmdArticulo = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLineas = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.txtDscArticulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAsignaStock = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.BackgroundColor = System.Drawing.Color.White;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdView.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdView.Location = new System.Drawing.Point(0, 102);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.RowTemplate.Height = 29;
            this.grdView.Size = new System.Drawing.Size(852, 312);
            this.grdView.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOmitir0);
            this.panel1.Controls.Add(this.cmdArticulo);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboLineas);
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClaveArticulo);
            this.panel1.Controls.Add(this.txtDscArticulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 96);
            this.panel1.TabIndex = 0;
            // 
            // chkOmitir0
            // 
            this.chkOmitir0.AutoSize = true;
            this.chkOmitir0.Checked = true;
            this.chkOmitir0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOmitir0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkOmitir0.Location = new System.Drawing.Point(106, 69);
            this.chkOmitir0.Name = "chkOmitir0";
            this.chkOmitir0.Size = new System.Drawing.Size(159, 20);
            this.chkOmitir0.TabIndex = 1006;
            this.chkOmitir0.Text = "Omitir existencias en 0";
            this.chkOmitir0.UseVisualStyleBackColor = true;
            this.chkOmitir0.CheckedChanged += new System.EventHandler(this.chkOmitir0_CheckedChanged);
            // 
            // cmdArticulo
            // 
            this.cmdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmdArticulo.Image = global::GAFE.Properties.Resources.MnuArticulos;
            this.cmdArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArticulo.Location = new System.Drawing.Point(11, 2);
            this.cmdArticulo.Name = "cmdArticulo";
            this.cmdArticulo.Size = new System.Drawing.Size(85, 36);
            this.cmdArticulo.TabIndex = 1005;
            this.cmdArticulo.Text = "Artículo";
            this.cmdArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdArticulo.UseVisualStyleBackColor = false;
            this.cmdArticulo.Click += new System.EventHandler(this.cmdArticulo_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(529, 41);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(309, 22);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(443, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Buscar";
            // 
            // cboLineas
            // 
            this.cboLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboLineas.FormattingEnabled = true;
            this.cboLineas.Location = new System.Drawing.Point(529, 11);
            this.cboLineas.Name = "cboLineas";
            this.cboLineas.Size = new System.Drawing.Size(309, 24);
            this.cboLineas.TabIndex = 5;
            this.cboLineas.SelectionChangeCommitted += new System.EventHandler(this.cboLineas_SelectionChangeCommitted);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(106, 39);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(309, 24);
            this.cboAlmacen.TabIndex = 4;
            this.cboAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboAlmacen_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1004;
            this.label2.Text = "Almacén";
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClaveArticulo.Location = new System.Drawing.Point(421, 10);
            this.txtClaveArticulo.MaxLength = 20;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.ReadOnly = true;
            this.txtClaveArticulo.Size = new System.Drawing.Size(10, 22);
            this.txtClaveArticulo.TabIndex = 1003;
            this.txtClaveArticulo.TabStop = false;
            this.txtClaveArticulo.Visible = false;
            // 
            // txtDscArticulo
            // 
            this.txtDscArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDscArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDscArticulo.Location = new System.Drawing.Point(106, 10);
            this.txtDscArticulo.MaxLength = 20;
            this.txtDscArticulo.Name = "txtDscArticulo";
            this.txtDscArticulo.ReadOnly = true;
            this.txtDscArticulo.Size = new System.Drawing.Size(309, 22);
            this.txtDscArticulo.TabIndex = 1002;
            this.txtDscArticulo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(443, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Líneas";
            // 
            // cmdAsignaStock
            // 
            this.cmdAsignaStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAsignaStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdAsignaStock.Image = global::GAFE.Properties.Resources.MnuAlmacen;
            this.cmdAsignaStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAsignaStock.Location = new System.Drawing.Point(557, 9);
            this.cmdAsignaStock.Name = "cmdAsignaStock";
            this.cmdAsignaStock.Size = new System.Drawing.Size(183, 36);
            this.cmdAsignaStock.TabIndex = 1;
            this.cmdAsignaStock.Text = "Asigna Stock por Almacén";
            this.cmdAsignaStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAsignaStock.UseVisualStyleBackColor = false;
            this.cmdAsignaStock.Click += new System.EventHandler(this.cmdAsignaStock_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdImprimir.Image = global::GAFE.Properties.Resources.printer;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(746, 9);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(94, 36);
            this.cmdImprimir.TabIndex = 3;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = false;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.lblTotalRegistros);
            this.panel2.Controls.Add(this.cmdImprimir);
            this.panel2.Controls.Add(this.cmdAsignaStock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 52);
            this.panel2.TabIndex = 8;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(12, 9);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(15, 16);
            this.lblTotalRegistros.TabIndex = 1005;
            this.lblTotalRegistros.Text = "0";
            this.lblTotalRegistros.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmExistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExistencias";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existencia por Almacen";
            this.Load += new System.EventHandler(this.frmExistencias_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExistencias_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdAsignaStock;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.TextBox txtDscArticulo;
        private System.Windows.Forms.ComboBox cboLineas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdArticulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkOmitir0;
        private System.Windows.Forms.Label lblTotalRegistros;
    }
}