namespace GAFE
{
    partial class frmRepProveedores
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
            this.rptProveedores = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptProveedores
            // 
            this.rptProveedores.AutoSize = true;
            this.rptProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptProveedores.Location = new System.Drawing.Point(0, 0);
            this.rptProveedores.Name = "rptProveedores";
            this.rptProveedores.ServerReport.BearerToken = null;
            this.rptProveedores.Size = new System.Drawing.Size(800, 450);
            this.rptProveedores.TabIndex = 0;
            // 
            // frmRepProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptProveedores);
            this.Name = "frmRepProveedores";
            this.Text = "frmRepProveedores";
            this.Load += new System.EventHandler(this.frmRepProveedores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRepProveedores_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptProveedores;
    }
}