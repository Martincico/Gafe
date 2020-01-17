namespace GAFE
{
    partial class DcPtoVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DcPtoVenta));
            this.grdViewVenta = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVerVentas = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblTotalArticulos = new System.Windows.Forms.Label();
            this.lblTitTotal = new System.Windows.Forms.Label();
            this.lblTitDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblTitCantidad = new System.Windows.Forms.Label();
            this.lblTitSubTotal = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblTitleCliente = new System.Windows.Forms.Label();
            this.lblTitEfectivo = new System.Windows.Forms.Label();
            this.lblTitCambio = new System.Windows.Forms.Label();
            this.txtClaveArticulo = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.grdViewArticulo = new System.Windows.Forms.DataGridView();
            this.lblTitBusqueda = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.panelLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewArticulo)).BeginInit();
            this.panelLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdViewVenta
            // 
            this.grdViewVenta.AllowUserToAddRows = false;
            this.grdViewVenta.AllowUserToDeleteRows = false;
            this.grdViewVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdViewVenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdViewVenta.BackgroundColor = System.Drawing.Color.White;
            this.grdViewVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewVenta.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewVenta.EnableHeadersVisualStyles = false;
            this.grdViewVenta.Location = new System.Drawing.Point(51, 40);
            this.grdViewVenta.Name = "grdViewVenta";
            this.grdViewVenta.ReadOnly = true;
            this.grdViewVenta.Size = new System.Drawing.Size(486, 279);
            this.grdViewVenta.TabIndex = 271;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Snow;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEliminar.Image = global::GAFE.Properties.Resources.Eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(3, 94);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(43, 43);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVerVentas
            // 
            this.btnVerVentas.BackColor = System.Drawing.Color.Snow;
            this.btnVerVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnVerVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnVerVentas.Image = global::GAFE.Properties.Resources.Check;
            this.btnVerVentas.Location = new System.Drawing.Point(3, 276);
            this.btnVerVentas.Name = "btnVerVentas";
            this.btnVerVentas.Size = new System.Drawing.Size(43, 43);
            this.btnVerVentas.TabIndex = 7;
            this.btnVerVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerVentas.UseVisualStyleBackColor = false;
            this.btnVerVentas.Click += new System.EventHandler(this.btnVerVentas_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Snow;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnEditar.Image = global::GAFE.Properties.Resources.Editar;
            this.btnEditar.Location = new System.Drawing.Point(3, 42);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(43, 43);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblTotalArticulos
            // 
            this.lblTotalArticulos.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTotalArticulos.Location = new System.Drawing.Point(396, 7);
            this.lblTotalArticulos.Name = "lblTotalArticulos";
            this.lblTotalArticulos.Size = new System.Drawing.Size(141, 31);
            this.lblTotalArticulos.TabIndex = 284;
            this.lblTotalArticulos.Text = "Artículos: 000";
            this.lblTotalArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitTotal
            // 
            this.lblTitTotal.AutoSize = true;
            this.lblTitTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTitTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTitTotal.Location = new System.Drawing.Point(545, 162);
            this.lblTitTotal.Name = "lblTitTotal";
            this.lblTitTotal.Size = new System.Drawing.Size(51, 22);
            this.lblTitTotal.TabIndex = 266;
            this.lblTitTotal.Text = "Total";
            this.lblTitTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitDescuento
            // 
            this.lblTitDescuento.AutoSize = true;
            this.lblTitDescuento.BackColor = System.Drawing.Color.Transparent;
            this.lblTitDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitDescuento.ForeColor = System.Drawing.Color.Blue;
            this.lblTitDescuento.Location = new System.Drawing.Point(545, 110);
            this.lblTitDescuento.Name = "lblTitDescuento";
            this.lblTitDescuento.Size = new System.Drawing.Size(56, 22);
            this.lblTitDescuento.TabIndex = 264;
            this.lblTitDescuento.Text = "Desc.";
            this.lblTitDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtDescuento.Location = new System.Drawing.Point(622, 102);
            this.txtDescuento.MaxLength = 13;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescuento.Size = new System.Drawing.Size(158, 35);
            this.txtDescuento.TabIndex = 3;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtCantidad.Location = new System.Drawing.Point(143, 3);
            this.txtCantidad.MaxLength = 15;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(117, 35);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblTitCantidad
            // 
            this.lblTitCantidad.AutoSize = true;
            this.lblTitCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblTitCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitCantidad.ForeColor = System.Drawing.Color.Blue;
            this.lblTitCantidad.Location = new System.Drawing.Point(55, 11);
            this.lblTitCantidad.Name = "lblTitCantidad";
            this.lblTitCantidad.Size = new System.Drawing.Size(82, 22);
            this.lblTitCantidad.TabIndex = 273;
            this.lblTitCantidad.Text = "Cantidad";
            this.lblTitCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitSubTotal
            // 
            this.lblTitSubTotal.AutoSize = true;
            this.lblTitSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTitSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitSubTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTitSubTotal.Location = new System.Drawing.Point(543, 58);
            this.lblTitSubTotal.Name = "lblTitSubTotal";
            this.lblTitSubTotal.Size = new System.Drawing.Size(83, 22);
            this.lblTitSubTotal.TabIndex = 265;
            this.lblTitSubTotal.Text = "SubTotal";
            this.lblTitSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCliente
            // 
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(641, 8);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(147, 24);
            this.cboCliente.TabIndex = 8;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            this.cboCliente.SelectedValueChanged += new System.EventHandler(this.cboCliente_SelectedValueChanged);
            // 
            // lblTitleCliente
            // 
            this.lblTitleCliente.AutoSize = true;
            this.lblTitleCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCliente.ForeColor = System.Drawing.Color.Blue;
            this.lblTitleCliente.Location = new System.Drawing.Point(579, 11);
            this.lblTitleCliente.Name = "lblTitleCliente";
            this.lblTitleCliente.Size = new System.Drawing.Size(56, 16);
            this.lblTitleCliente.TabIndex = 285;
            this.lblTitleCliente.Text = "Cliente";
            this.lblTitleCliente.Click += new System.EventHandler(this.lblTitleCliente_Click);
            // 
            // lblTitEfectivo
            // 
            this.lblTitEfectivo.AutoSize = true;
            this.lblTitEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTitEfectivo.Location = new System.Drawing.Point(545, 219);
            this.lblTitEfectivo.Name = "lblTitEfectivo";
            this.lblTitEfectivo.Size = new System.Drawing.Size(74, 22);
            this.lblTitEfectivo.TabIndex = 289;
            this.lblTitEfectivo.Text = "Efectivo";
            this.lblTitEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitEfectivo.Click += new System.EventHandler(this.lblTitEfectivo_Click);
            // 
            // lblTitCambio
            // 
            this.lblTitCambio.AutoSize = true;
            this.lblTitCambio.BackColor = System.Drawing.Color.Transparent;
            this.lblTitCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.lblTitCambio.Location = new System.Drawing.Point(545, 270);
            this.lblTitCambio.Name = "lblTitCambio";
            this.lblTitCambio.Size = new System.Drawing.Size(71, 22);
            this.lblTitCambio.TabIndex = 290;
            this.lblTitCambio.Text = "Cambio";
            this.lblTitCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtClaveArticulo
            // 
            this.txtClaveArticulo.BackColor = System.Drawing.SystemColors.Window;
            this.txtClaveArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtClaveArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtClaveArticulo.Location = new System.Drawing.Point(91, 3);
            this.txtClaveArticulo.MaxLength = 15;
            this.txtClaveArticulo.Name = "txtClaveArticulo";
            this.txtClaveArticulo.Size = new System.Drawing.Size(236, 32);
            this.txtClaveArticulo.TabIndex = 292;
            this.txtClaveArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveArticulo_KeyPress);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.SystemColors.Window;
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtEfectivo.Location = new System.Drawing.Point(622, 260);
            this.txtEfectivo.MaxLength = 15;
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(158, 35);
            this.txtEfectivo.TabIndex = 293;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            // 
            // grdViewArticulo
            // 
            this.grdViewArticulo.AllowUserToAddRows = false;
            this.grdViewArticulo.AllowUserToDeleteRows = false;
            this.grdViewArticulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdViewArticulo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewArticulo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdViewArticulo.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewArticulo.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdViewArticulo.Location = new System.Drawing.Point(2, 40);
            this.grdViewArticulo.Name = "grdViewArticulo";
            this.grdViewArticulo.ReadOnly = true;
            this.grdViewArticulo.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewArticulo.RowTemplate.Height = 80;
            this.grdViewArticulo.Size = new System.Drawing.Size(784, 193);
            this.grdViewArticulo.TabIndex = 294;
            // 
            // lblTitBusqueda
            // 
            this.lblTitBusqueda.AutoSize = true;
            this.lblTitBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.lblTitBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitBusqueda.ForeColor = System.Drawing.Color.Blue;
            this.lblTitBusqueda.Location = new System.Drawing.Point(5, 8);
            this.lblTitBusqueda.Name = "lblTitBusqueda";
            this.lblTitBusqueda.Size = new System.Drawing.Size(91, 22);
            this.lblTitBusqueda.TabIndex = 295;
            this.lblTitBusqueda.Text = "Busqueda";
            this.lblTitBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtSubTotal.Location = new System.Drawing.Point(622, 50);
            this.txtSubTotal.MaxLength = 13;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubTotal.Size = new System.Drawing.Size(158, 35);
            this.txtSubTotal.TabIndex = 296;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtTotal.Location = new System.Drawing.Point(622, 154);
            this.txtTotal.MaxLength = 13;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(158, 35);
            this.txtTotal.TabIndex = 297;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCambio
            // 
            this.txtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(171)))));
            this.txtCambio.Location = new System.Drawing.Point(622, 206);
            this.txtCambio.MaxLength = 13;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCambio.Size = new System.Drawing.Size(158, 35);
            this.txtCambio.TabIndex = 298;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelLine
            // 
            this.panelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLine.Controls.Add(this.grdViewVenta);
            this.panelLine.Controls.Add(this.txtCambio);
            this.panelLine.Controls.Add(this.btnVerVentas);
            this.panelLine.Controls.Add(this.txtTotal);
            this.panelLine.Controls.Add(this.txtEfectivo);
            this.panelLine.Controls.Add(this.btnEditar);
            this.panelLine.Controls.Add(this.lblTotalArticulos);
            this.panelLine.Controls.Add(this.txtSubTotal);
            this.panelLine.Controls.Add(this.lblTitCambio);
            this.panelLine.Controls.Add(this.btnEliminar);
            this.panelLine.Controls.Add(this.lblTitEfectivo);
            this.panelLine.Controls.Add(this.txtCantidad);
            this.panelLine.Controls.Add(this.lblTitCantidad);
            this.panelLine.Controls.Add(this.lblTitSubTotal);
            this.panelLine.Controls.Add(this.lblTitTotal);
            this.panelLine.Controls.Add(this.lblTitDescuento);
            this.panelLine.Controls.Add(this.txtDescuento);
            this.panelLine.Location = new System.Drawing.Point(0, 239);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(788, 326);
            this.panelLine.TabIndex = 299;
            // 
            // DcPtoVenta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(788, 564);
            this.Controls.Add(this.txtClaveArticulo);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.lblTitBusqueda);
            this.Controls.Add(this.grdViewArticulo);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblTitleCliente);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DcPtoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de venta";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DcPtoVenta_FormClosed);
            this.Load += new System.EventHandler(this.DcPtoVenta_Load);
            this.Resize += new System.EventHandler(this.DcPtoVenta_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewArticulo)).EndInit();
            this.panelLine.ResumeLayout(false);
            this.panelLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdViewVenta;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVerVentas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblTotalArticulos;
        private System.Windows.Forms.Label lblTitTotal;
        private System.Windows.Forms.Label lblTitDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblTitSubTotal;
        private System.Windows.Forms.Label lblTitCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblTitleCliente;
        private System.Windows.Forms.Label lblTitEfectivo;
        private System.Windows.Forms.Label lblTitCambio;
        private System.Windows.Forms.TextBox txtClaveArticulo;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.DataGridView grdViewArticulo;
        private System.Windows.Forms.Label lblTitBusqueda;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Panel panelLine;
    }
}