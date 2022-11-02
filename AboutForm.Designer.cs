namespace ClipboardCleaner
{
    partial class AboutForm
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
            this.appNameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.websiteLabel = new System.Windows.Forms.Label();
            this.iconsByLabel = new System.Windows.Forms.Label();
            this.iconsByLinkLabel = new System.Windows.Forms.LinkLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appNameLabel
            // 
            this.appNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.appNameLabel.Location = new System.Drawing.Point(12, 9);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(485, 21);
            this.appNameLabel.TabIndex = 0;
            this.appNameLabel.Text = "ClipboardCleaner";
            this.appNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Location = new System.Drawing.Point(12, 38);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(485, 23);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Version";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(40, 61);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(86, 15);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "copyrightLabel";
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.Location = new System.Drawing.Point(98, 76);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(247, 15);
            this.websiteLinkLabel.TabIndex = 3;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "https://github.com/Qwox/ClipboardCleaner/";
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebsiteLinkClickedHandler);
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Location = new System.Drawing.Point(40, 76);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(52, 15);
            this.websiteLabel.TabIndex = 4;
            this.websiteLabel.Text = "Website:";
            // 
            // iconsByLabel
            // 
            this.iconsByLabel.AutoSize = true;
            this.iconsByLabel.Location = new System.Drawing.Point(40, 106);
            this.iconsByLabel.Name = "iconsByLabel";
            this.iconsByLabel.Size = new System.Drawing.Size(54, 15);
            this.iconsByLabel.TabIndex = 5;
            this.iconsByLabel.Text = "Icons by:";
            // 
            // iconsByLinkLabel
            // 
            this.iconsByLinkLabel.AutoSize = true;
            this.iconsByLinkLabel.Location = new System.Drawing.Point(98, 106);
            this.iconsByLinkLabel.Name = "iconsByLinkLabel";
            this.iconsByLinkLabel.Size = new System.Drawing.Size(113, 15);
            this.iconsByLinkLabel.TabIndex = 6;
            this.iconsByLinkLabel.TabStop = true;
            this.iconsByLinkLabel.Text = "https://icons8.com/";
            this.iconsByLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IconsLinkClickedHandler);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(217, 153);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "OK";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 188);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.iconsByLinkLabel);
            this.Controls.Add(this.iconsByLabel);
            this.Controls.Add(this.websiteLabel);
            this.Controls.Add(this.websiteLinkLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.appNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label appNameLabel;
        private Label versionLabel;
        private Label copyrightLabel;
        private LinkLabel websiteLinkLabel;
        private Label websiteLabel;
        private Label iconsByLabel;
        private LinkLabel iconsByLinkLabel;
        private Button closeButton;
    }
}