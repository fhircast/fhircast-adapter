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
            this.unsubscribe = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnDeleteSubscriptions = new System.Windows.Forms.Button();
            this.autoSubscribe = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.topic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iSite = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.iSiteHostname = new System.Windows.Forms.TextBox();
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
            this.btnSubscribe.Location = new System.Drawing.Point(26, 96);
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
            this.secret.Location = new System.Drawing.Point(87, 45);
            this.secret.Name = "secret";
            this.secret.Size = new System.Drawing.Size(199, 20);
            this.secret.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 52);
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
            this.events.Location = new System.Drawing.Point(317, 22);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(139, 124);
            this.events.TabIndex = 7;
            // 
            // unsubscribe
            // 
            this.unsubscribe.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.unsubscribe.Location = new System.Drawing.Point(160, 97);
            this.unsubscribe.Name = "unsubscribe";
            this.unsubscribe.Size = new System.Drawing.Size(126, 23);
            this.unsubscribe.TabIndex = 8;
            this.unsubscribe.Text = "Unsubscribe";
            this.unsubscribe.UseVisualStyleBackColor = false;
            this.unsubscribe.Click += new System.EventHandler(this.btnUnSubscribe_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSaveSettings.Location = new System.Drawing.Point(486, 53);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(156, 23);
            this.btnSaveSettings.TabIndex = 9;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnDeleteSubscriptions
            // 
            this.btnDeleteSubscriptions.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDeleteSubscriptions.Location = new System.Drawing.Point(26, 125);
            this.btnDeleteSubscriptions.Name = "btnDeleteSubscriptions";
            this.btnDeleteSubscriptions.Size = new System.Drawing.Size(128, 23);
            this.btnDeleteSubscriptions.TabIndex = 11;
            this.btnDeleteSubscriptions.Text = "Delete all subscriptions";
            this.btnDeleteSubscriptions.UseVisualStyleBackColor = false;
            this.btnDeleteSubscriptions.Click += new System.EventHandler(this.btnDeleteSubscriptions_Click);
            // 
            // autoSubscribe
            // 
            this.autoSubscribe.AutoSize = true;
            this.autoSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSubscribe.Location = new System.Drawing.Point(162, 133);
            this.autoSubscribe.Name = "autoSubscribe";
            this.autoSubscribe.Size = new System.Drawing.Size(149, 17);
            this.autoSubscribe.TabIndex = 12;
            this.autoSubscribe.Text = "Auto-subscribe on start-up";
            this.autoSubscribe.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHelp.Location = new System.Drawing.Point(486, 81);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(156, 23);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Online Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // topic
            // 
            this.topic.Location = new System.Drawing.Point(87, 67);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(199, 20);
            this.topic.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Topic:";
            // 
            // iSite
            // 
            this.iSite.AutoSize = true;
            this.iSite.Location = new System.Drawing.Point(486, 107);
            this.iSite.Name = "iSite";
            this.iSite.Size = new System.Drawing.Size(81, 17);
            this.iSite.TabIndex = 16;
            this.iSite.Text = "iSite control";
            this.iSite.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(397, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "FHIRcast is a registered trademark of HL7.  iSite is a registered trademark of Ph" +
    "ilips.";
            // 
            // iSiteHostname
            // 
            this.iSiteHostname.Location = new System.Drawing.Point(486, 127);
            this.iSiteHostname.Name = "iSiteHostname";
            this.iSiteHostname.Size = new System.Drawing.Size(156, 20);
            this.iSiteHostname.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(670, 450);
            this.Controls.Add(this.iSiteHostname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.iSite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topic);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.autoSubscribe);
            this.Controls.Add(this.btnDeleteSubscriptions);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.unsubscribe);
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
        private System.Windows.Forms.Button unsubscribe;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnDeleteSubscriptions;
        private System.Windows.Forms.CheckBox autoSubscribe;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox topic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox iSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iSiteHostname;
    }
}

