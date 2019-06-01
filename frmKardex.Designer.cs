namespace GAFE
{
    partial class frmKardex
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
            this.grdView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboAlmacenes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.txtDscArticulo = new System.Windows.Forms.TextBox();
            this.cmdArticulo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AllowUserToOrderColumns = true;
            this.grdView.BackgroundColor = System.Drawing.Color.White;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Location = new System.Drawing.Point(10, 117);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(1039, 374);
            this.grdView.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdConsultar);
            this.panel1.Controls.Add(this.dtFechaFin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdImprimir);
            this.panel1.Controls.Add(this.dtFechaInicio);
            this.panel1.Controls.Add(this.cboAlmacenes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtClaveArticulo);
            this.panel1.Controls.Add(this.txtDscArticulo);
            this.panel1.Controls.Add(this.cmdArticulo);
            this.panel1.Location = new System.Drawing.Point(3, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 97);
            this.panel1.TabIndex = 26;
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsultar.Image = global::GAFE.Properties.Resources.Consultar;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.Location = new System.Drawing.Point(716, 37);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 53);
            this.cmdConsultar.TabIndex = 27;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(853, 5);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(150, 26);
            this.dtFechaFin.TabIndex = 1009;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(823, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 1008;
            this.label4.Text = "al:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(573, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 1007;
            this.label3.Text = "Periodo del:";
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImprimir.Image = global::GAFE.Properties.Resources.printer;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(839, 37);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(94, 53);
            this.cmdImprimir.TabIndex = 28;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = false;
            this.cmdImprimir.Visible = false;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(670, 5);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(150, 26);
            this.dtFechaInicio.TabIndex = 1006;
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.DisplayMember = "Descripcion";
            this.cboAlmacenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacenes.FormattingEnabled = true;
            this.cboAlmacenes.Location = new System.Drawing.Point(104, 33);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(421, 28);
            this.cboAlmacenes.TabIndex = 1005;
            this.cboAlmacenes.ValueMember = "ClaveAlmacen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 1004;
            this.label2.Text = "Almacén";
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveArticulo.Location = new System.Drawing.Point(104, 5);
            this.txtClaveArticulo.MaxLength = 20;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.ReadOnly = true;
            this.txtClaveArticulo.Size = new System.Drawing.Size(110, 24);
            this.txtClaveArticulo.TabIndex = 1003;
            // 
            // txtDscArticulo
            // 
            this.txtDscArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDscArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDscArticulo.Location = new System.Drawing.Point(216, 5);
            this.txtDscArticulo.MaxLength = 20;
            this.txtDscArticulo.Name = "txtDscArticulo";
            this.txtDscArticulo.ReadOnly = true;
            this.txtDscArticulo.Size = new System.Drawing.Size(309, 24);
            this.txtDscArticulo.TabIndex = 1002;
            // 
            // cmdArticulo
            // 
            this.cmdArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArticulo.Location = new System.Drawing.Point(5, 3);
            this.cmdArticulo.Name = "cmdArticulo";
            this.cmdArticulo.Size = new System.Drawing.Size(94, 28);
            this.cmdArticulo.TabIndex = 1001;
            this.cmdArticulo.Text = "Artículo...";
            this.cmdArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArticulo.UseVisualStyleBackColor = false;
            this.cmdArticulo.Click += new System.EventHandler(this.cmdArticulo_Click);
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 503);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel1);
            this.Name = "frmKardex";
            this.ShowIcon = false;
            this.Text = "Kardex de Artículos";
            this.Load += new System.EventHandler(this.frmKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboAlmacenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.TextBox txtDscArticulo;
        private System.Windows.Forms.Button cmdArticulo;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
    }
}