namespace ClipboardCleaner
{
    partial class SettingsForm
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
            this.autorunCheckBox = new System.Windows.Forms.CheckBox();
            this.timeToClearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.clipboardGroupBox = new System.Windows.Forms.GroupBox();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.clearAfterLabel = new System.Windows.Forms.Label();
            this.notificationGroupBox = new System.Windows.Forms.GroupBox();
            this.showNotificationProgressCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.automaticClearingCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeToClearNumericUpDown)).BeginInit();
            this.generalGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.clipboardGroupBox.SuspendLayout();
            this.notificationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // autorunCheckBox
            // 
            this.autorunCheckBox.AutoSize = true;
            this.autorunCheckBox.Location = new System.Drawing.Point(6, 43);
            this.autorunCheckBox.Name = "autorunCheckBox";
            this.autorunCheckBox.Size = new System.Drawing.Size(70, 19);
            this.autorunCheckBox.TabIndex = 1;
            this.autorunCheckBox.Text = "Autorun";
            this.autorunCheckBox.UseVisualStyleBackColor = true;
            // 
            // timeToClearNumericUpDown
            // 
            this.timeToClearNumericUpDown.Location = new System.Drawing.Point(138, 42);
            this.timeToClearNumericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.timeToClearNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timeToClearNumericUpDown.Name = "timeToClearNumericUpDown";
            this.timeToClearNumericUpDown.Size = new System.Drawing.Size(51, 23);
            this.timeToClearNumericUpDown.TabIndex = 3;
            this.timeToClearNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generalGroupBox.Controls.Add(this.languageComboBox);
            this.generalGroupBox.Controls.Add(this.languageLabel);
            this.generalGroupBox.Controls.Add(this.autorunCheckBox);
            this.generalGroupBox.Location = new System.Drawing.Point(3, 3);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(297, 74);
            this.generalGroupBox.TabIndex = 3;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General";
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(142, 16);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(149, 23);
            this.languageComboBox.TabIndex = 0;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(6, 19);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(59, 15);
            this.languageLabel.TabIndex = 5;
            this.languageLabel.Text = "Language";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.generalGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clipboardGroupBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.notificationGroupBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 163);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // clipboardGroupBox
            // 
            this.clipboardGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardGroupBox.Controls.Add(this.automaticClearingCheckBox);
            this.clipboardGroupBox.Controls.Add(this.secondsLabel);
            this.clipboardGroupBox.Controls.Add(this.clearAfterLabel);
            this.clipboardGroupBox.Controls.Add(this.timeToClearNumericUpDown);
            this.clipboardGroupBox.Location = new System.Drawing.Point(306, 3);
            this.clipboardGroupBox.Name = "clipboardGroupBox";
            this.clipboardGroupBox.Size = new System.Drawing.Size(298, 74);
            this.clipboardGroupBox.TabIndex = 4;
            this.clipboardGroupBox.TabStop = false;
            this.clipboardGroupBox.Text = "Clipboard";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(195, 44);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(50, 15);
            this.secondsLabel.TabIndex = 4;
            this.secondsLabel.Text = "seconds";
            // 
            // clearAfterLabel
            // 
            this.clearAfterLabel.AutoSize = true;
            this.clearAfterLabel.Location = new System.Drawing.Point(8, 44);
            this.clearAfterLabel.Name = "clearAfterLabel";
            this.clearAfterLabel.Size = new System.Drawing.Size(61, 15);
            this.clearAfterLabel.TabIndex = 3;
            this.clearAfterLabel.Text = "Clear after";
            // 
            // notificationGroupBox
            // 
            this.notificationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.notificationGroupBox, 2);
            this.notificationGroupBox.Controls.Add(this.showNotificationProgressCheckBox);
            this.notificationGroupBox.Controls.Add(this.showNotificationCheckBox);
            this.notificationGroupBox.Location = new System.Drawing.Point(3, 85);
            this.notificationGroupBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.notificationGroupBox.Name = "notificationGroupBox";
            this.notificationGroupBox.Size = new System.Drawing.Size(601, 75);
            this.notificationGroupBox.TabIndex = 5;
            this.notificationGroupBox.TabStop = false;
            this.notificationGroupBox.Text = "Notification";
            // 
            // showNotificationProgressCheckBox
            // 
            this.showNotificationProgressCheckBox.AutoSize = true;
            this.showNotificationProgressCheckBox.Location = new System.Drawing.Point(6, 47);
            this.showNotificationProgressCheckBox.Name = "showNotificationProgressCheckBox";
            this.showNotificationProgressCheckBox.Size = new System.Drawing.Size(172, 19);
            this.showNotificationProgressCheckBox.TabIndex = 5;
            this.showNotificationProgressCheckBox.Text = "Progress bar on notification";
            this.showNotificationProgressCheckBox.UseVisualStyleBackColor = true;
            // 
            // showNotificationCheckBox
            // 
            this.showNotificationCheckBox.AutoSize = true;
            this.showNotificationCheckBox.Location = new System.Drawing.Point(6, 22);
            this.showNotificationCheckBox.Name = "showNotificationCheckBox";
            this.showNotificationCheckBox.Size = new System.Drawing.Size(124, 19);
            this.showNotificationCheckBox.TabIndex = 4;
            this.showNotificationCheckBox.Text = "Show notifications";
            this.showNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(206, 194);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 98;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClickHandler);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(324, 194);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 99;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // automaticClearingCheckBox
            // 
            this.automaticClearingCheckBox.AutoSize = true;
            this.automaticClearingCheckBox.Location = new System.Drawing.Point(8, 18);
            this.automaticClearingCheckBox.Name = "automaticClearingCheckBox";
            this.automaticClearingCheckBox.Size = new System.Drawing.Size(129, 19);
            this.automaticClearingCheckBox.TabIndex = 2;
            this.automaticClearingCheckBox.Text = "Automatic Clearing";
            this.automaticClearingCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 233);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.timeToClearNumericUpDown)).EndInit();
            this.generalGroupBox.ResumeLayout(false);
            this.generalGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.clipboardGroupBox.ResumeLayout(false);
            this.clipboardGroupBox.PerformLayout();
            this.notificationGroupBox.ResumeLayout(false);
            this.notificationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox autorunCheckBox;
        private NumericUpDown timeToClearNumericUpDown;
        private GroupBox generalGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox clipboardGroupBox;
        private Label clearAfterLabel;
        private GroupBox notificationGroupBox;
        private CheckBox showNotificationCheckBox;
        private Label secondsLabel;
        private ComboBox languageComboBox;
        private Label languageLabel;
        private Button saveButton;
        private Button cancelButton;
        private CheckBox showNotificationProgressCheckBox;
        private CheckBox automaticClearingCheckBox;
    }
}