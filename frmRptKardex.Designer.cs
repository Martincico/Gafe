namespace GAFE
{
    partial class frmRptKardex
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
            this.rptKardex = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptKardex
            // 
            this.rptKardex.AutoSize = true;
            this.rptKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptKardex.Location = new System.Drawing.Point(0, 0);
            this.rptKardex.Name = "rptKardex";
            this.rptKardex.ServerReport.BearerToken = null;
            this.rptKardex.Size = new System.Drawing.Size(800, 450);
            this.rptKardex.TabIndex = 0;
            // 
            // frmRptKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptKardex);
            this.Name = "frmRptKardex";
            this.Text = "frmRptKardex";
            this.Load += new System.EventHandler(this.frmRptKardex_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRptKardex_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptKardex;
    }
}