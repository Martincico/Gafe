namespace GAFE
{
    partial class DocRegistroRequisicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocRegistroRequisicion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.FechaExpedicion = new System.Windows.Forms.DateTimePicker();
            this.Descuento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grdViewD = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DelPartida = new System.Windows.Forms.Button();
            this.EditPartida = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIeps = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddPartida = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewD)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.txtDescuento);
            this.panel1.Controls.Add(this.FechaExpedicion);
            this.panel1.Controls.Add(this.Descuento);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNumDoc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSerie);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDocumento);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cboAlmacen
            // 
            resources.ApplyResources(this.cboAlmacen, "cboAlmacen");
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Name = "cboAlmacen";
            // 
            // txtDescuento
            // 
            resources.ApplyResources(this.txtDescuento, "txtDescuento");
            this.txtDescuento.Name = "txtDescuento";
            // 
            // FechaExpedicion
            // 
            resources.ApplyResources(this.FechaExpedicion, "FechaExpedicion");
            this.FechaExpedicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaExpedicion.Name = "FechaExpedicion";
            // 
            // Descuento
            // 
            resources.ApplyResources(this.Descuento, "Descuento");
            this.Descuento.Name = "Descuento";
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
            // txtNumDoc
            // 
            resources.ApplyResources(this.txtNumDoc, "txtNumDoc");
            this.txtNumDoc.Name = "txtNumDoc";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtSerie
            // 
            resources.ApplyResources(this.txtSerie, "txtSerie");
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.TextChanged += new System.EventHandler(this.txtSerie_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDocumento
            // 
            resources.ApplyResources(this.txtDocumento, "txtDocumento");
            this.txtDocumento.Name = "txtDocumento";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtObservaciones
            // 
            resources.ApplyResources(this.txtObservaciones, "txtObservaciones");
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // grdViewD
            // 
            this.grdViewD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.grdViewD, "grdViewD");
            this.grdViewD.Name = "grdViewD";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DelPartida);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtObservaciones);
            this.panel2.Controls.Add(this.EditPartida);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtIva);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtIeps);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtSubTotal);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.AddPartida);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.grdViewD);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // DelPartida
            // 
            resources.ApplyResources(this.DelPartida, "DelPartida");
            this.DelPartida.Image = global::GAFE.Properties.Resources.Eliminar;
            this.DelPartida.Name = "DelPartida";
            this.DelPartida.UseVisualStyleBackColor = false;
            this.DelPartida.Click += new System.EventHandler(this.DelPartida_Click);
            // 
            // EditPartida
            // 
            resources.ApplyResources(this.EditPartida, "EditPartida");
            this.EditPartida.Image = global::GAFE.Properties.Resources.Editar;
            this.EditPartida.Name = "EditPartida";
            this.EditPartida.UseVisualStyleBackColor = false;
            this.EditPartida.Click += new System.EventHandler(this.EditPartida_Click);
            // 
            // txtTotal
            // 
            resources.ApplyResources(this.txtTotal, "txtTotal");
            this.txtTotal.Name = "txtTotal";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtIva
            // 
            resources.ApplyResources(this.txtIva, "txtIva");
            this.txtIva.Name = "txtIva";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtIeps
            // 
            resources.ApplyResources(this.txtIeps, "txtIeps");
            this.txtIeps.Name = "txtIeps";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtSubTotal
            // 
            resources.ApplyResources(this.txtSubTotal, "txtSubTotal");
            this.txtSubTotal.Name = "txtSubTotal";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // AddPartida
            // 
            resources.ApplyResources(this.AddPartida, "AddPartida");
            this.AddPartida.Image = global::GAFE.Properties.Resources.Nuevo;
            this.AddPartida.Name = "AddPartida";
            this.AddPartida.UseVisualStyleBackColor = false;
            this.AddPartida.Click += new System.EventHandler(this.AddPartida_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Name = "label6";
            // 
            // cmdAceptar
            // 
            resources.ApplyResources(this.cmdAceptar, "cmdAceptar");
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cmdCancelar, "cmdCancelar");
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // DocRegistroRequisicion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocRegistroRequisicion";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocRegistroRequisicion_FormClosing);
            this.Load += new System.EventHandler(this.DocRegistroRequisicion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaExpedicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label Descuento;
        private System.Windows.Forms.DataGridView grdViewD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AddPartida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIeps;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Button DelPartida;
        private System.Windows.Forms.Button EditPartida;
    }
}