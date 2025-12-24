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
            this.serversCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.emptyServersListLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.toggleSelectAllCheckBox = new System.Windows.Forms.CheckBox();
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
            this.settingsGroupBox.Controls.Add(this.serversCheckedListBox);
            this.settingsGroupBox.Controls.Add(this.emptyServersListLabel);
            this.settingsGroupBox.Controls.Add(this.serverLabel);
            this.settingsGroupBox.Controls.Add(this.toggleSelectAllCheckBox);
            this.settingsGroupBox.Controls.Add(this.timerLabel);
            this.settingsGroupBox.Controls.Add(this.timerNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.intervalLabel);
            this.settingsGroupBox.Controls.Add(this.intervalNumericUpDown);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(460, 220);
            this.settingsGroupBox.TabIndex = 0;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Настройки по умолчанию";
            // 
            // serversCheckedListBox
            // 
            this.serversCheckedListBox.FormattingEnabled = true;
            this.serversCheckedListBox.Location = new System.Drawing.Point(180, 22);
            this.serversCheckedListBox.Name = "serversCheckedListBox";
            this.serversCheckedListBox.Size = new System.Drawing.Size(274, 112);
            this.serversCheckedListBox.TabIndex = 1;
            // 
            // emptyServersListLabel
            // 
            this.emptyServersListLabel.BackColor = System.Drawing.SystemColors.Window;
            this.emptyServersListLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emptyServersListLabel.Location = new System.Drawing.Point(180, 22);
            this.emptyServersListLabel.Name = "emptyServersListLabel";
            this.emptyServersListLabel.Size = new System.Drawing.Size(274, 112);
            this.emptyServersListLabel.TabIndex = 15;
            this.emptyServersListLabel.Text = "Список пуст. Добавьте сервер!";
            this.emptyServersListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(6, 25);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(113, 15);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Серверы по умолчанию:";
            //
            // toggleSelectAllCheckBox
            //
            this.toggleSelectAllCheckBox.AutoSize = true;
            this.toggleSelectAllCheckBox.Location = new System.Drawing.Point(180, 137);
            this.toggleSelectAllCheckBox.Name = "toggleSelectAllCheckBox";
            this.toggleSelectAllCheckBox.Size = new System.Drawing.Size(100, 19);
            this.toggleSelectAllCheckBox.TabIndex = 13;
            this.toggleSelectAllCheckBox.Text = "Выбрать все";
            this.toggleSelectAllCheckBox.UseVisualStyleBackColor = true;
            this.toggleSelectAllCheckBox.CheckedChanged += new System.EventHandler(this.toggleSelectAllCheckBox_CheckedChanged);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(6, 165);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(121, 15);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Таймер (секунды):";
            // 
            // timerNumericUpDown
            // 
            this.timerNumericUpDown.Location = new System.Drawing.Point(180, 163);
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
            this.intervalLabel.Location = new System.Drawing.Point(6, 195);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(168, 15);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал уведомлений (сек):";
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(180, 193);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            this.intervalNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.intervalNumericUpDown.TabIndex = 5;
            this.intervalNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(266, 238);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(372, 238);
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
            this.ClientSize = new System.Drawing.Size(484, 281);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.settingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки по умолчанию";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.CheckBox toggleSelectAllCheckBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.NumericUpDown timerNumericUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox serversCheckedListBox;
        private System.Windows.Forms.Label emptyServersListLabel;
    }
}
