namespace GAFE
{
    partial class DocLstRequisiciones
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
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmEditar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.grdViewReq = new System.Windows.Forms.DataGridView();
            this.idMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblAlmaOri = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRestablecer = new System.Windows.Forms.Button();
            this.cmdAutorizarTodo = new System.Windows.Forms.Button();
            this.btnGenerarDoc = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewReq)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.Image = global::GAFE.Properties.Resources.Consultar;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.Location = new System.Drawing.Point(732, 7);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(94, 36);
            this.cmdConsultar.TabIndex = 14;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEliminar.Image = global::GAFE.Properties.Resources.Eliminar;
            this.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminar.Location = new System.Drawing.Point(628, 7);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(94, 36);
            this.cmdEliminar.TabIndex = 17;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminar.UseVisualStyleBackColor = false;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmEditar
            // 
            this.cmEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmEditar.Image = global::GAFE.Properties.Resources.Editar;
            this.cmEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmEditar.Location = new System.Drawing.Point(524, 7);
            this.cmEditar.Name = "cmEditar";
            this.cmEditar.Size = new System.Drawing.Size(94, 36);
            this.cmEditar.TabIndex = 16;
            this.cmEditar.Text = "Editar";
            this.cmEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmEditar.UseVisualStyleBackColor = false;
            this.cmEditar.Click += new System.EventHandler(this.cmEditar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAgregar.Image = global::GAFE.Properties.Resources.Nuevo;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(420, 7);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(94, 36);
            this.cmdAgregar.TabIndex = 15;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.UseVisualStyleBackColor = false;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // grdViewReq
            // 
            this.grdViewReq.AllowUserToAddRows = false;
            this.grdViewReq.AllowUserToDeleteRows = false;
            this.grdViewReq.AllowUserToOrderColumns = true;
            this.grdViewReq.BackgroundColor = System.Drawing.Color.White;
            this.grdViewReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewReq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMov});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewReq.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewReq.Location = new System.Drawing.Point(0, 86);
            this.grdViewReq.Name = "grdViewReq";
            this.grdViewReq.ReadOnly = true;
            this.grdViewReq.RowTemplate.Height = 25;
            this.grdViewReq.Size = new System.Drawing.Size(840, 297);
            this.grdViewReq.TabIndex = 18;
            this.grdViewReq.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grdViewReq_RowPrePaint);
            this.grdViewReq.SelectionChanged += new System.EventHandler(this.grdViewReq_SelectionChanged);
            this.grdViewReq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdViewReq_MouseClick);
            // 
            // idMov
            // 
            this.idMov.HeaderText = "idMov";
            this.idMov.Name = "idMov";
            this.idMov.ReadOnly = true;
            this.idMov.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(229, 39);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 22);
            this.textBox1.TabIndex = 27;
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(66, 39);
            this.txtCodigo.MaxLength = 100;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(135, 22);
            this.txtCodigo.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Folio de";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(584, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "a";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(620, 11);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(104, 22);
            this.dtFechaFin.TabIndex = 22;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(460, 12);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(104, 22);
            this.dtFechaInicio.TabIndex = 21;
            this.dtFechaInicio.ValueChanged += new System.EventHandler(this.dtFechaInicio_ValueChanged);
            // 
            // lblAlmaOri
            // 
            this.lblAlmaOri.AutoSize = true;
            this.lblAlmaOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmaOri.Location = new System.Drawing.Point(3, 12);
            this.lblAlmaOri.Name = "lblAlmaOri";
            this.lblAlmaOri.Size = new System.Drawing.Size(61, 16);
            this.lblAlmaOri.TabIndex = 19;
            this.lblAlmaOri.Text = "Almacén";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(66, 9);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(300, 24);
            this.cboAlmacen.TabIndex = 20;
            this.cboAlmacen.SelectedValueChanged += new System.EventHandler(this.cboAlmaOri_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fecha";
            // 
            // cmdRestablecer
            // 
            this.cmdRestablecer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdRestablecer.Image = global::GAFE.Properties.Resources.Reiniciar;
            this.cmdRestablecer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRestablecer.Location = new System.Drawing.Point(755, 10);
            this.cmdRestablecer.Name = "cmdRestablecer";
            this.cmdRestablecer.Size = new System.Drawing.Size(76, 56);
            this.cmdRestablecer.TabIndex = 29;
            this.cmdRestablecer.Text = "Restablacer";
            this.cmdRestablecer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRestablecer.UseVisualStyleBackColor = false;
            this.cmdRestablecer.Click += new System.EventHandler(this.cmdRestablecer_Click);
            // 
            // cmdAutorizarTodo
            // 
            this.cmdAutorizarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cmdAutorizarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAutorizarTodo.Image = global::GAFE.Properties.Resources.Check;
            this.cmdAutorizarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAutorizarTodo.Location = new System.Drawing.Point(50, 7);
            this.cmdAutorizarTodo.Name = "cmdAutorizarTodo";
            this.cmdAutorizarTodo.Size = new System.Drawing.Size(38, 36);
            this.cmdAutorizarTodo.TabIndex = 30;
            this.cmdAutorizarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAutorizarTodo.UseVisualStyleBackColor = false;
            this.cmdAutorizarTodo.Visible = false;
            this.cmdAutorizarTodo.Click += new System.EventHandler(this.cmdAutorizarTodo_Click);
            // 
            // btnGenerarDoc
            // 
            this.btnGenerarDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnGenerarDoc.Enabled = false;
            this.btnGenerarDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarDoc.Image = global::GAFE.Properties.Resources.migrar_doc;
            this.btnGenerarDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarDoc.Location = new System.Drawing.Point(94, 8);
            this.btnGenerarDoc.Name = "btnGenerarDoc";
            this.btnGenerarDoc.Size = new System.Drawing.Size(181, 36);
            this.btnGenerarDoc.TabIndex = 31;
            this.btnGenerarDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarDoc.UseVisualStyleBackColor = false;
            this.btnGenerarDoc.Visible = false;
            this.btnGenerarDoc.Click += new System.EventHandler(this.btnGenerarDoc_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::GAFE.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(6, 7);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(38, 36);
            this.btnImprimir.TabIndex = 32;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboSucursal
            // 
            this.cboSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(460, 39);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(264, 24);
            this.cboSucursal.TabIndex = 33;
            this.cboSucursal.Visible = false;
            this.cboSucursal.SelectedValueChanged += new System.EventHandler(this.cboSucursal_SelectedValueChanged);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(388, 42);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(60, 16);
            this.lblSucursal.TabIndex = 34;
            this.lblSucursal.Text = "Sucursal";
            this.lblSucursal.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.cboAlmacen);
            this.panel1.Controls.Add(this.lblAlmaOri);
            this.panel1.Controls.Add(this.lblSucursal);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.cboSucursal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdRestablecer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtFechaFin);
            this.panel1.Controls.Add(this.dtFechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 80);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.cmdConsultar);
            this.panel2.Controls.Add(this.cmdEliminar);
            this.panel2.Controls.Add(this.btnGenerarDoc);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.cmdAutorizarTodo);
            this.panel2.Controls.Add(this.cmEditar);
            this.panel2.Controls.Add(this.cmdAgregar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 52);
            this.panel2.TabIndex = 36;
            // 
            // DocLstRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionButtonHoverColor = System.Drawing.Color.DimGray;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdViewReq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocLstRequisiciones";
            this.ShowIcon = false;
            this.Text = "DocLstRequisiciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocLstRequisiciones_FormClosing);
            this.Load += new System.EventHandler(this.DocLstRequisiciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewReq)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmEditar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdViewReq;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Label lblAlmaOri;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRestablecer;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMov;
        private System.Windows.Forms.Button cmdAutorizarTodo;
        private System.Windows.Forms.Button btnGenerarDoc;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}