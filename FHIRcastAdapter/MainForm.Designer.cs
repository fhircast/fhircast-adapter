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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.hubURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnShutdown = new System.Windows.Forms.Button();
            this.logList = new System.Windows.Forms.ListBox();
            this.secret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.events = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hubURL
            // 
            this.hubURL.Location = new System.Drawing.Point(87, 22);
            this.hubURL.Name = "hubURL";
            this.hubURL.Size = new System.Drawing.Size(199, 20);
            this.hubURL.TabIndex = 0;
            this.hubURL.Text = "http://localhost:3000/api/hub/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hub URL:";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubscribe.Location = new System.Drawing.Point(26, 93);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(128, 23);
            this.btnSubscribe.TabIndex = 2;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = false;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Visit fhircast.org !";
            this.notifyIcon.BalloonTipTitle = "FHIRcast Adapter";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FHIRcast";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // btnShutdown
            // 
            this.btnShutdown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShutdown.Location = new System.Drawing.Point(486, 25);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(156, 23);
            this.btnShutdown.TabIndex = 3;
            this.btnShutdown.Text = "Shutdown Adapter";
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // logList
            // 
            this.logList.FormattingEnabled = true;
            this.logList.HorizontalScrollbar = true;
            this.logList.Location = new System.Drawing.Point(26, 162);
            this.logList.Name = "logList";
            this.logList.ScrollAlwaysVisible = true;
            this.logList.Size = new System.Drawing.Size(616, 264);
            this.logList.TabIndex = 4;
            // 
            // secret
            // 
            this.secret.Location = new System.Drawing.Point(87, 60);
            this.secret.Name = "secret";
            this.secret.Size = new System.Drawing.Size(199, 20);
            this.secret.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Secret:";
            // 
            // events
            // 
            this.events.CheckOnClick = true;
            this.events.FormattingEnabled = true;
            this.events.Items.AddRange(new object[] {
            "open-patient-chart",
            "switch-patient-chart",
            "close-patient-chart",
            "open-imaging-study",
            "switch-imaging-study",
            "close-imaging-study",
            "logout-user",
            "hibernate-user"});
            this.events.Location = new System.Drawing.Point(320, 22);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(139, 124);
            this.events.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(160, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Unsubscribe";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Location = new System.Drawing.Point(486, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Get Context";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Location = new System.Drawing.Point(160, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Select All Events";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Location = new System.Drawing.Point(26, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Delete all subscriptions";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(486, 129);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Auto-subscribe on start-up";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.Location = new System.Drawing.Point(486, 93);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Online Help";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(670, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.events);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secret);
            this.Controls.Add(this.logList);
            this.Controls.Add(this.btnShutdown);
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
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.TextBox secret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox events;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
    }
}

