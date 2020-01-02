namespace GAFE
{
    partial class fmtoDocumentos
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
            this.rptDocumentos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosGafe = new GAFE.DatosGafe();
            ((System.ComponentModel.ISupportInitialize)(this.DatosGafe)).BeginInit();
            this.SuspendLayout();
            // 
            // rptDocumentos
            // 
            this.rptDocumentos.AutoSize = true;
            this.rptDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDocumentos.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoDocumentos.rdlc";
            this.rptDocumentos.Location = new System.Drawing.Point(0, 0);
            this.rptDocumentos.Name = "rptDocumentos";
            this.rptDocumentos.ServerReport.BearerToken = null;
            this.rptDocumentos.Size = new System.Drawing.Size(800, 450);
            this.rptDocumentos.TabIndex = 0;
            // 
            // DatosGafe
            // 
            this.DatosGafe.DataSetName = "DatosGafe";
            this.DatosGafe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fmtoDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptDocumentos);
            this.Name = "fmtoDocumentos";
            this.Text = "Vista previa";
            this.Load += new System.EventHandler(this.fmtoDocumentos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmtoDocumentos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DatosGafe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptDocumentos;
        private DatosGafe DatosGafe;
    }
}