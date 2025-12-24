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
            this.serversListBox = new System.Windows.Forms.CheckedListBox(); // Changed from ListBox
            this.emptyServersListLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serversCountLabel = new System.Windows.Forms.Label();
            this.removeServerButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.messageLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.newServerTextBox = new System.Windows.Forms.TextBox();
            this.addServerButton = new System.Windows.Forms.Button();
            this.searchServersButton = new System.Windows.Forms.Button();
            this.excludedUsersLabel = new System.Windows.Forms.Label();
            this.excludedUsersTextBox = new System.Windows.Forms.TextBox();
            this.excludedUsersCheckBox = new System.Windows.Forms.CheckBox();
            this.resetSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.serversListBox);
            this.settingsGroupBox.Controls.Add(this.emptyServersListLabel);
            this.settingsGroupBox.Controls.Add(this.serverLabel);
            this.settingsGroupBox.Controls.Add(this.serversCountLabel);
            this.settingsGroupBox.Controls.Add(this.removeServerButton);
            this.settingsGroupBox.Controls.Add(this.timerLabel);
            this.settingsGroupBox.Controls.Add(this.timerNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.intervalLabel);
            this.settingsGroupBox.Controls.Add(this.intervalNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.messageLabel);
            this.settingsGroupBox.Controls.Add(this.messageTextBox);
            this.settingsGroupBox.Controls.Add(this.newServerTextBox);
            this.settingsGroupBox.Controls.Add(this.addServerButton);
            this.settingsGroupBox.Controls.Add(this.searchServersButton);
            this.settingsGroupBox.Controls.Add(this.excludedUsersLabel);
            this.settingsGroupBox.Controls.Add(this.excludedUsersTextBox);
            this.settingsGroupBox.Controls.Add(this.excludedUsersCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(760, 510);
            this.settingsGroupBox.TabIndex = 0;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Настройки по умолчанию";
            // 
            // serversListBox
            // 
            this.serversListBox.FormattingEnabled = true;
            this.serversListBox.Location = new System.Drawing.Point(180, 52);
            this.serversListBox.Name = "serversListBox";
            this.serversListBox.Size = new System.Drawing.Size(574, 349);
            this.serversListBox.TabIndex = 1;
            // 
            // emptyServersListLabel
            // 
            this.emptyServersListLabel.BackColor = System.Drawing.SystemColors.Window;
            this.emptyServersListLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emptyServersListLabel.Location = new System.Drawing.Point(180, 52);
            this.emptyServersListLabel.Name = "emptyServersListLabel";
            this.emptyServersListLabel.Size = new System.Drawing.Size(574, 349);
            this.emptyServersListLabel.TabIndex = 15;
            this.emptyServersListLabel.Text = "Список пуст. Добавьте сервер!";
            this.emptyServersListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(6, 25);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(59, 15);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Серверы:";
            // 
            // serversCountLabel
            // 
            this.serversCountLabel.AutoSize = true;
            this.serversCountLabel.Location = new System.Drawing.Point(71, 25);
            this.serversCountLabel.Name = "serversCountLabel";
            this.serversCountLabel.Size = new System.Drawing.Size(0, 15);
            this.serversCountLabel.TabIndex = 13;
            //
            // removeServerButton
            //
            this.removeServerButton.Location = new System.Drawing.Point(654, 407);
            this.removeServerButton.Name = "removeServerButton";
            this.removeServerButton.Size = new System.Drawing.Size(100, 25);
            this.removeServerButton.TabIndex = 26;
            this.removeServerButton.Text = "Удалить";
            this.removeServerButton.UseVisualStyleBackColor = true;
            this.removeServerButton.Click += new System.EventHandler(this.removeServerButton_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(6, 438);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(121, 15);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Таймер (секунды):";
            // 
            // timerNumericUpDown
            // 
            this.timerNumericUpDown.Location = new System.Drawing.Point(180, 436);
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
            this.intervalLabel.Location = new System.Drawing.Point(320, 438);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(168, 15);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал уведомлений (сек):";
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(494, 436);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            this.intervalNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.intervalNumericUpDown.TabIndex = 5;
            this.intervalNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            //
            // messageLabel
            //
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(6, 467);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(76, 15);
            this.messageLabel.TabIndex = 16;
            this.messageLabel.Text = "Сообщение:";
            //
            // messageTextBox
            //
            this.messageTextBox.Location = new System.Drawing.Point(180, 464);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(574, 23);
            this.messageTextBox.TabIndex = 17;
            //
            // newServerTextBox
            //
            this.newServerTextBox.Location = new System.Drawing.Point(180, 23);
            this.newServerTextBox.Name = "newServerTextBox";
            this.newServerTextBox.Size = new System.Drawing.Size(388, 23);
            this.newServerTextBox.TabIndex = 18;
            //
            // addServerButton
            //
            this.addServerButton.Location = new System.Drawing.Point(574, 22);
            this.addServerButton.Name = "addServerButton";
            this.addServerButton.Size = new System.Drawing.Size(80, 25);
            this.addServerButton.TabIndex = 19;
            this.addServerButton.Text = "Добавить";
            this.addServerButton.UseVisualStyleBackColor = true;
            this.addServerButton.Click += new System.EventHandler(this.addServerButton_Click);
            //
            // searchServersButton
            //
            this.searchServersButton.Location = new System.Drawing.Point(660, 22);
            this.searchServersButton.Name = "searchServersButton";
            this.searchServersButton.Size = new System.Drawing.Size(94, 25);
            this.searchServersButton.TabIndex = 20;
            this.searchServersButton.Text = "Поиск";
            this.searchServersButton.UseVisualStyleBackColor = true;
            this.searchServersButton.Click += new System.EventHandler(this.searchServersButton_Click);
            //
            // excludedUsersLabel
            //
            this.excludedUsersLabel.AutoSize = true;
            this.excludedUsersLabel.Location = new System.Drawing.Point(6, 496);
            this.excludedUsersLabel.Name = "excludedUsersLabel";
            this.excludedUsersLabel.Size = new System.Drawing.Size(155, 15);
            this.excludedUsersLabel.TabIndex = 21;
            this.excludedUsersLabel.Text = "Исключить пользователей:";
            //
            // excludedUsersTextBox
            //
            this.excludedUsersTextBox.Location = new System.Drawing.Point(306, 493);
            this.excludedUsersTextBox.Name = "excludedUsersTextBox";
            this.excludedUsersTextBox.Size = new System.Drawing.Size(448, 23);
            this.excludedUsersTextBox.TabIndex = 22;
            //
            // excludedUsersCheckBox
            //
            this.excludedUsersCheckBox.AutoSize = true;
            this.excludedUsersCheckBox.Location = new System.Drawing.Point(180, 495);
            this.excludedUsersCheckBox.Name = "excludedUsersCheckBox";
            this.excludedUsersCheckBox.Size = new System.Drawing.Size(120, 19);
            this.excludedUsersCheckBox.TabIndex = 23;
            this.excludedUsersCheckBox.Text = "Вкл. исключения";
            this.excludedUsersCheckBox.UseVisualStyleBackColor = true;
            //
            // resetSettingsButton
            //
            this.resetSettingsButton.Location = new System.Drawing.Point(12, 528);
            this.resetSettingsButton.Name = "resetSettingsButton";
            this.resetSettingsButton.Size = new System.Drawing.Size(130, 30);
            this.resetSettingsButton.TabIndex = 24;
            this.resetSettingsButton.Text = "Сброс настроек";
            this.resetSettingsButton.UseVisualStyleBackColor = true;
            this.resetSettingsButton.Click += new System.EventHandler(this.resetSettingsButton_Click);
            //
            // saveSettingsCheckBox
            //
            this.saveSettingsCheckBox.AutoSize = true;
            this.saveSettingsCheckBox.Checked = true;
            this.saveSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveSettingsCheckBox.Location = new System.Drawing.Point(180, 535);
            this.saveSettingsCheckBox.Name = "saveSettingsCheckBox";
            this.saveSettingsCheckBox.Size = new System.Drawing.Size(140, 19);
            this.saveSettingsCheckBox.TabIndex = 25;
            this.saveSettingsCheckBox.Text = "Сохранять настройки";
            this.saveSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(566, 528);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(672, 528);
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
            this.ClientSize = new System.Drawing.Size(784, 571);
            this.Controls.Add(this.resetSettingsButton);
            this.Controls.Add(this.saveSettingsCheckBox);
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
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label serversCountLabel;
        private System.Windows.Forms.Button removeServerButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.NumericUpDown timerNumericUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox newServerTextBox;
        private System.Windows.Forms.Button addServerButton;
        private System.Windows.Forms.Button searchServersButton;
        private System.Windows.Forms.Label excludedUsersLabel;
        private System.Windows.Forms.TextBox excludedUsersTextBox;
        private System.Windows.Forms.CheckBox excludedUsersCheckBox;
        private System.Windows.Forms.Button resetSettingsButton;
        private System.Windows.Forms.CheckBox saveSettingsCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox serversListBox; // Changed from ListBox
        private System.Windows.Forms.Label emptyServersListLabel;
    }
}
