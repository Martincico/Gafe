﻿namespace GAFE
{
    partial class frmSegAccesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegAccesos));
            this.label1 = new System.Windows.Forms.Label();
            this.cboPerfiles = new System.Windows.Forms.ComboBox();
            this.btnAsignaSeg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizaSeg = new System.Windows.Forms.Button();
            this.tSeg = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecciona Perfil";
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPerfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(165, 24);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(409, 24);
            this.cboPerfiles.TabIndex = 2;
            this.cboPerfiles.SelectionChangeCommitted += new System.EventHandler(this.cboPerfiles_SelectionChangeCommitted);
            // 
            // btnAsignaSeg
            // 
            this.btnAsignaSeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignaSeg.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAsignaSeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignaSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignaSeg.Location = new System.Drawing.Point(598, 12);
            this.btnAsignaSeg.Name = "btnAsignaSeg";
            this.btnAsignaSeg.Size = new System.Drawing.Size(143, 47);
            this.btnAsignaSeg.TabIndex = 3;
            this.btnAsignaSeg.Text = "Asigna / Modifica Accesos";
            this.btnAsignaSeg.UseVisualStyleBackColor = false;
            this.btnAsignaSeg.Click += new System.EventHandler(this.btnAsignaSeg_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAsignaSeg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPerfiles);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 74);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnActualizaSeg);
            this.panel2.Controls.Add(this.tSeg);
            this.panel2.Location = new System.Drawing.Point(16, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 481);
            this.panel2.TabIndex = 5;
            // 
            // btnActualizaSeg
            // 
            this.btnActualizaSeg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizaSeg.BackgroundImage")));
            this.btnActualizaSeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizaSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizaSeg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizaSeg.Location = new System.Drawing.Point(515, 13);
            this.btnActualizaSeg.Name = "btnActualizaSeg";
            this.btnActualizaSeg.Size = new System.Drawing.Size(239, 144);
            this.btnActualizaSeg.TabIndex = 1;
            this.btnActualizaSeg.Text = "Actualizar";
            this.btnActualizaSeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizaSeg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizaSeg.UseVisualStyleBackColor = true;
            this.btnActualizaSeg.Click += new System.EventHandler(this.btnActualizaSeg_Click);
            // 
            // tSeg
            // 
            this.tSeg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSeg.CheckBoxes = true;
            this.tSeg.Location = new System.Drawing.Point(109, 13);
            this.tSeg.Name = "tSeg";
            this.tSeg.Size = new System.Drawing.Size(381, 457);
            this.tSeg.TabIndex = 0;
            this.tSeg.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tSeg_AfterCheck);
            // 
            // frmSegAccesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(817, 615);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(817, 615);
            this.Name = "frmSegAccesos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configurando Accesos al sistema";
            this.Load += new System.EventHandler(this.frmSegAccesos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPerfiles;
        private System.Windows.Forms.Button btnAsignaSeg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tSeg;
        private System.Windows.Forms.Button btnActualizaSeg;
    }
}