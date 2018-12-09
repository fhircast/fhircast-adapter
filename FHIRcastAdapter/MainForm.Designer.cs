namespace FHIRcastAdapter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.hubURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hubURL
            // 
            this.hubURL.Location = new System.Drawing.Point(87, 22);
            this.hubURL.Name = "hubURL";
            this.hubURL.Size = new System.Drawing.Size(223, 20);
            this.hubURL.TabIndex = 0;
            this.hubURL.Text = "http://localhost:3000/api/hub/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HUB URL:";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSubscribe.Location = new System.Drawing.Point(357, 22);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 2;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = false;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hubURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FHIRcast Adapter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hubURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubscribe;
    }
}

