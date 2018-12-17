namespace FHIRcastAdapter
{
    partial class IntelliSpaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntelliSpaceForm));
            this.axRadiology1 = new AxISRCONTROLLib.AxRadiology();
            ((System.ComponentModel.ISupportInitialize)(this.axRadiology1)).BeginInit();
            this.SuspendLayout();
            // 
            // axRadiology1
            // 
            this.axRadiology1.Enabled = true;
            this.axRadiology1.Location = new System.Drawing.Point(0, -2);
            this.axRadiology1.Name = "axRadiology1";
            this.axRadiology1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRadiology1.OcxState")));
            this.axRadiology1.Size = new System.Drawing.Size(801, 639);
            this.axRadiology1.TabIndex = 0;
            // 
            // IntelliSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 633);
            this.Controls.Add(this.axRadiology1);
            this.Name = "IntelliSpaceForm";
            this.Text = "IntelliSpaceForm";
            ((System.ComponentModel.ISupportInitialize)(this.axRadiology1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxISRCONTROLLib.AxRadiology axRadiology1;
    }
}