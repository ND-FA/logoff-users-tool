using LogoffUsersTool.UI.Controls;

namespace LogoffUsersTool.UI
{
    partial class MainForm
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
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.defaultSettingsButton = new System.Windows.Forms.Button();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serverComboBox = new System.Windows.Forms.ComboBox();
            this.searchServersButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.messageLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new TextProgressBar();
            this.copyrightStatusStrip = new System.Windows.Forms.StatusStrip();
            this.copyrightStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.settingsButton = new System.Windows.Forms.Button();
            this.inputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.copyrightStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox.Controls.Add(this.searchServersButton);
            this.inputGroupBox.Controls.Add(this.defaultSettingsButton);
            this.inputGroupBox.Controls.Add(this.serverLabel);
            this.inputGroupBox.Controls.Add(this.serverComboBox);
            this.inputGroupBox.Controls.Add(this.timerLabel);
            this.inputGroupBox.Controls.Add(this.timerNumericUpDown);
            this.inputGroupBox.Controls.Add(this.intervalLabel);
            this.inputGroupBox.Controls.Add(this.intervalNumericUpDown);
            this.inputGroupBox.Controls.Add(this.messageLabel);
            this.inputGroupBox.Controls.Add(this.messageTextBox);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(984, 180);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Параметры";
            // 
            // defaultSettingsButton
            // 
            this.defaultSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultSettingsButton.Location = new System.Drawing.Point(808, 142);
            this.defaultSettingsButton.Name = "defaultSettingsButton";
            this.defaultSettingsButton.Size = new System.Drawing.Size(170, 30);
            this.defaultSettingsButton.TabIndex = 6;
            this.defaultSettingsButton.Text = "По умолчанию";
            this.defaultSettingsButton.UseVisualStyleBackColor = true;
            this.defaultSettingsButton.Click += new System.EventHandler(this.defaultSettingsButton_Click);
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
            this.serverComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverComboBox.Location = new System.Drawing.Point(180, 22);
            this.serverComboBox.Name = "serverComboBox";
            this.serverComboBox.Size = new System.Drawing.Size(724, 23);
            this.serverComboBox.TabIndex = 1;
            this.serverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            // 
            // searchServersButton
            // 
            this.searchServersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchServersButton.Location = new System.Drawing.Point(910, 21);
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
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(6, 115);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(76, 15);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Сообщение:";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(180, 112);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(798, 23);
            this.messageTextBox.TabIndex = 8;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 198);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 30);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(118, 198);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 30);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(896, 198);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 30);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputRichTextBox.Location = new System.Drawing.Point(12, 234);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.ReadOnly = true;
            this.outputRichTextBox.Size = new System.Drawing.Size(984, 432);
            this.outputRichTextBox.TabIndex = 4;
            this.outputRichTextBox.Text = "";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.spacerStatusLabel,
            new System.Windows.Forms.ToolStripControlHost(this.progressBar) { Name = "progressBarHost" } });
            this.statusStrip.Location = new System.Drawing.Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 14, 5);
            this.statusStrip.Size = new System.Drawing.Size(1008, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 20);
            this.statusLabel.Text = "Готово";
            // 
            // spacerStatusLabel
            // 
            this.spacerStatusLabel.Name = "spacerStatusLabel";
            this.spacerStatusLabel.Size = new System.Drawing.Size(731, 20);
            this.spacerStatusLabel.Spring = true;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(220, 19);
            // 
            // copyrightStatusStrip
            // 
            this.copyrightStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyrightStatusLabel});
            this.copyrightStatusStrip.Location = new System.Drawing.Point(0, 703);
            this.copyrightStatusStrip.Name = "copyrightStatusStrip";
            this.copyrightStatusStrip.Size = new System.Drawing.Size(1008, 22);
            this.copyrightStatusStrip.SizingGrip = false;
            this.copyrightStatusStrip.TabIndex = 6;
            // 
            // copyrightStatusLabel
            // 
            this.copyrightStatusLabel.Name = "copyrightStatusLabel";
            this.copyrightStatusLabel.Size = new System.Drawing.Size(993, 17);
            this.copyrightStatusLabel.Spring = true;
            this.copyrightStatusLabel.Text = "developed by WexSoft";
            this.copyrightStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(790, 198);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 30);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.copyrightStatusStrip);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.inputGroupBox);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Logoff Users Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.copyrightStatusStrip.ResumeLayout(false);
            this.copyrightStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.ComboBox serverComboBox;
        private System.Windows.Forms.Button searchServersButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.NumericUpDown timerNumericUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel spacerStatusLabel;
        private TextProgressBar progressBar;
        private System.Windows.Forms.Button defaultSettingsButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.StatusStrip copyrightStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel copyrightStatusLabel;
    }
}
