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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNoFactura = new System.Windows.Forms.TextBox();
            this.lblNoFactura = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cboSerie = new System.Windows.Forms.ComboBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.FechaExpedicion = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.grdViewD = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSubTotalDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIeps = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdAutorizarTodo = new System.Windows.Forms.Button();
            this.DelPartida = new System.Windows.Forms.Button();
            this.EditPartida = new System.Windows.Forms.Button();
            this.AddPartida = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewD)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.txtNoFactura);
            this.panel1.Controls.Add(this.lblNoFactura);
            this.panel1.Controls.Add(this.cboSucursal);
            this.panel1.Controls.Add(this.lblSucursal);
            this.panel1.Controls.Add(this.cboProveedor);
            this.panel1.Controls.Add(this.lblProveedor);
            this.panel1.Controls.Add(this.cboSerie);
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.FechaExpedicion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNumDoc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDocumento);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // txtNoFactura
            // 
            resources.ApplyResources(this.txtNoFactura, "txtNoFactura");
            this.txtNoFactura.Name = "txtNoFactura";
            this.txtNoFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoFactura_KeyPress);
            // 
            // lblNoFactura
            // 
            resources.ApplyResources(this.lblNoFactura, "lblNoFactura");
            this.lblNoFactura.Name = "lblNoFactura";
            // 
            // cboSucursal
            // 
            resources.ApplyResources(this.cboSucursal, "cboSucursal");
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Name = "cboSucursal";
            // 
            // lblSucursal
            // 
            resources.ApplyResources(this.lblSucursal, "lblSucursal");
            this.lblSucursal.Name = "lblSucursal";
            // 
            // cboProveedor
            // 
            resources.ApplyResources(this.cboProveedor, "cboProveedor");
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Name = "cboProveedor";
            // 
            // lblProveedor
            // 
            resources.ApplyResources(this.lblProveedor, "lblProveedor");
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Click += new System.EventHandler(this.lblProveedor_Click);
            // 
            // cboSerie
            // 
            resources.ApplyResources(this.cboSerie, "cboSerie");
            this.cboSerie.FormattingEnabled = true;
            this.cboSerie.Name = "cboSerie";
            this.cboSerie.SelectedIndexChanged += new System.EventHandler(this.cboSerie_SelectedIndexChanged);
            // 
            // cboAlmacen
            // 
            resources.ApplyResources(this.cboAlmacen, "cboAlmacen");
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.SelectedIndexChanged += new System.EventHandler(this.cboAlmacen_SelectedIndexChanged);
            // 
            // FechaExpedicion
            // 
            resources.ApplyResources(this.FechaExpedicion, "FechaExpedicion");
            this.FechaExpedicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaExpedicion.Name = "FechaExpedicion";
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
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.TextChanged += new System.EventHandler(this.txtNumDoc_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            this.txtDocumento.ReadOnly = true;
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
            // grdViewD
            // 
            this.grdViewD.AllowUserToAddRows = false;
            this.grdViewD.AllowUserToDeleteRows = false;
            this.grdViewD.AllowUserToOrderColumns = true;
            this.grdViewD.BackgroundColor = System.Drawing.Color.White;
            this.grdViewD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewD.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.grdViewD, "grdViewD");
            this.grdViewD.Name = "grdViewD";
            this.grdViewD.ReadOnly = true;
            this.grdViewD.RowTemplate.Height = 25;
            this.grdViewD.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdViewD_CellMouseUp);
            this.grdViewD.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewD_CellValueChanged);
            this.grdViewD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdViewD_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtSubTotalDesc);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtIVA);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtIeps);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtDescuento);
            this.panel2.Controls.Add(this.cmdAceptar);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.txtObservaciones);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtSubTotal);
            this.panel2.Controls.Add(this.label8);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtSubTotalDesc
            // 
            resources.ApplyResources(this.txtSubTotalDesc, "txtSubTotalDesc");
            this.txtSubTotalDesc.Name = "txtSubTotalDesc";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtIVA
            // 
            resources.ApplyResources(this.txtIVA, "txtIVA");
            this.txtIVA.Name = "txtIVA";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtIeps
            // 
            resources.ApplyResources(this.txtIeps, "txtIeps");
            this.txtIeps.Name = "txtIeps";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtDescuento
            // 
            resources.ApplyResources(this.txtDescuento, "txtDescuento");
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.cmdAceptar, "cmdAceptar");
            this.cmdAceptar.Image = global::GAFE.Properties.Resources.Guardar;
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cmdCancelar, "cmdCancelar");
            this.cmdCancelar.Image = global::GAFE.Properties.Resources.Cancelar;
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
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
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtSubTotal
            // 
            resources.ApplyResources(this.txtSubTotal, "txtSubTotal");
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.TextChanged += new System.EventHandler(this.txtSubTotal_TextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cmdAutorizarTodo
            // 
            this.cmdAutorizarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.cmdAutorizarTodo, "cmdAutorizarTodo");
            this.cmdAutorizarTodo.Image = global::GAFE.Properties.Resources.Check;
            this.cmdAutorizarTodo.Name = "cmdAutorizarTodo";
            this.cmdAutorizarTodo.UseVisualStyleBackColor = false;
            this.cmdAutorizarTodo.Click += new System.EventHandler(this.cmdAutorizarTodo_Click);
            // 
            // DelPartida
            // 
            this.DelPartida.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.DelPartida, "DelPartida");
            this.DelPartida.Image = global::GAFE.Properties.Resources.Eliminar;
            this.DelPartida.Name = "DelPartida";
            this.DelPartida.UseVisualStyleBackColor = false;
            this.DelPartida.Click += new System.EventHandler(this.DelPartida_Click);
            // 
            // EditPartida
            // 
            this.EditPartida.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.EditPartida, "EditPartida");
            this.EditPartida.Image = global::GAFE.Properties.Resources.Editar;
            this.EditPartida.Name = "EditPartida";
            this.EditPartida.UseVisualStyleBackColor = false;
            this.EditPartida.Click += new System.EventHandler(this.EditPartida_Click);
            // 
            // AddPartida
            // 
            this.AddPartida.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.AddPartida, "AddPartida");
            this.AddPartida.Image = global::GAFE.Properties.Resources.Nuevo;
            this.AddPartida.Name = "AddPartida";
            this.AddPartida.UseVisualStyleBackColor = false;
            this.AddPartida.Click += new System.EventHandler(this.AddPartida_Click);
            // 
            // DocRegistroRequisicion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.BorderThickness = 2;
            this.CancelButton = this.cmdCancelar;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdAutorizarTodo);
            this.Controls.Add(this.AddPartida);
            this.Controls.Add(this.EditPartida);
            this.Controls.Add(this.DelPartida);
            this.Controls.Add(this.grdViewD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocRegistroRequisicion";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocRegistroRequisicion_FormClosing);
            this.Load += new System.EventHandler(this.DocRegistroRequisicion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocRegistroRequisicion_KeyDown);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaExpedicion;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DataGridView grdViewD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AddPartida;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Button DelPartida;
        private System.Windows.Forms.Button EditPartida;
        private System.Windows.Forms.ComboBox cboSerie;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button cmdAutorizarTodo;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNoFactura;
        private System.Windows.Forms.Label lblNoFactura;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIeps;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSubTotalDesc;
        private System.Windows.Forms.Label label6;
    }
}