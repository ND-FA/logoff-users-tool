namespace LogoffUsersTool.UI
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serverComboBox = new System.Windows.Forms.ComboBox();
            this.searchServersButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.searchServersButton);
            this.settingsGroupBox.Controls.Add(this.serverLabel);
            this.settingsGroupBox.Controls.Add(this.serverComboBox);
            this.settingsGroupBox.Controls.Add(this.timerLabel);
            this.settingsGroupBox.Controls.Add(this.timerNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.intervalLabel);
            this.settingsGroupBox.Controls.Add(this.intervalNumericUpDown);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(460, 120);
            this.settingsGroupBox.TabIndex = 0;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Настройки по умолчанию";
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(6, 25);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(47, 15);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Сервер:";
            // 
            // serverComboBox
            // 
            this.serverComboBox.Location = new System.Drawing.Point(180, 22);
            this.serverComboBox.Name = "serverComboBox";
            this.serverComboBox.Size = new System.Drawing.Size(200, 23);
            this.serverComboBox.TabIndex = 1;
            // 
            // searchServersButton
            // 
            this.searchServersButton.Location = new System.Drawing.Point(386, 21);
            this.searchServersButton.Name = "searchServersButton";
            this.searchServersButton.Size = new System.Drawing.Size(68, 25);
            this.searchServersButton.TabIndex = 9;
            this.searchServersButton.Text = "Поиск";
            this.searchServersButton.UseVisualStyleBackColor = true;
            this.searchServersButton.Click += new System.EventHandler(this.searchServersButton_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(6, 55);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(121, 15);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Таймер (секунды):";
            // 
            // timerNumericUpDown
            // 
            this.timerNumericUpDown.Location = new System.Drawing.Point(180, 53);
            this.timerNumericUpDown.Maximum = new decimal(new int[] { 86400, 0, 0, 0 });
            this.timerNumericUpDown.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            this.timerNumericUpDown.Name = "timerNumericUpDown";
            this.timerNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.timerNumericUpDown.TabIndex = 3;
            this.timerNumericUpDown.Value = new decimal(new int[] { 900, 0, 0, 0 });
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(6, 85);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(168, 15);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал уведомлений (сек):";
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(180, 83);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            this.intervalNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.intervalNumericUpDown.TabIndex = 5;
            this.intervalNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(266, 138);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(372, 138);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 180);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Name = "SettingsForm";
            this.Text = "Настройки по умолчанию";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.ComboBox serverComboBox;
        private System.Windows.Forms.Button searchServersButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.NumericUpDown timerNumericUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
