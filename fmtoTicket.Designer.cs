namespace GAFE
{
    partial class fmtoTicket
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
            this.rptTicket = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosGafe = new GAFE.DatosGafe();
            ((System.ComponentModel.ISupportInitialize)(this.DatosGafe)).BeginInit();
            this.SuspendLayout();
            // 
            // rptTicket
            // 
            this.rptTicket.AutoSize = true;
            this.rptTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptTicket.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoTicket.rdlc";
            this.rptTicket.Location = new System.Drawing.Point(0, 0);
            this.rptTicket.Name = "rptTicket";
            this.rptTicket.ServerReport.BearerToken = null;
            this.rptTicket.Size = new System.Drawing.Size(351, 450);
            this.rptTicket.TabIndex = 0;
            // 
            // DatosGafe
            // 
            this.DatosGafe.DataSetName = "DatosGafe";
            this.DatosGafe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fmtoTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 450);
            this.Controls.Add(this.rptTicket);
            this.Name = "fmtoTicket";
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.fmtoTicket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmtoTicket_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DatosGafe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptTicket;
        private DatosGafe DatosGafe;
    }
}