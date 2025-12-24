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
            this.serverLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.excludedUsersLabel = new System.Windows.Forms.Label();
            this.serversValueLabel = new System.Windows.Forms.Label();
            this.timerValueLabel = new System.Windows.Forms.Label();
            this.intervalValueLabel = new System.Windows.Forms.Label();
            this.messageValueLabel = new System.Windows.Forms.Label();
            this.excludedUsersValueLabel = new System.Windows.Forms.Label();
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
            this.statusStrip.SuspendLayout();
            this.copyrightStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox.Controls.Add(this.serverLabel);
            this.inputGroupBox.Controls.Add(this.timerLabel);
            this.inputGroupBox.Controls.Add(this.intervalLabel);
            this.inputGroupBox.Controls.Add(this.messageLabel);
            this.inputGroupBox.Controls.Add(this.excludedUsersLabel);
            this.inputGroupBox.Controls.Add(this.serversValueLabel);
            this.inputGroupBox.Controls.Add(this.timerValueLabel);
            this.inputGroupBox.Controls.Add(this.intervalValueLabel);
            this.inputGroupBox.Controls.Add(this.messageValueLabel);
            this.inputGroupBox.Controls.Add(this.excludedUsersValueLabel);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(984, 120);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Параметры";
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(6, 25);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(118, 15);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Выбранные сервера:";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(6, 55);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(52, 15);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "Таймер:";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(230, 55);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(64, 15);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Интервал:";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(6, 75);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(76, 15);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Сообщение:";
            // 
            // excludedUsersLabel
            // 
            this.excludedUsersLabel.AutoSize = true;
            this.excludedUsersLabel.Location = new System.Drawing.Point(6, 95);
            this.excludedUsersLabel.Name = "excludedUsersLabel";
            this.excludedUsersLabel.Size = new System.Drawing.Size(84, 15);
            this.excludedUsersLabel.TabIndex = 19;
            this.excludedUsersLabel.Text = "Исключения:";
            // 
            // serversValueLabel
            // 
            this.serversValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serversValueLabel.Location = new System.Drawing.Point(130, 25);
            this.serversValueLabel.Name = "serversValueLabel";
            this.serversValueLabel.Size = new System.Drawing.Size(848, 15);
            this.serversValueLabel.TabIndex = 21;
            // 
            // timerValueLabel
            // 
            this.timerValueLabel.AutoSize = true;
            this.timerValueLabel.Location = new System.Drawing.Point(64, 55);
            this.timerValueLabel.Name = "timerValueLabel";
            this.timerValueLabel.Size = new System.Drawing.Size(0, 15);
            this.timerValueLabel.TabIndex = 16;
            // 
            // intervalValueLabel
            // 
            this.intervalValueLabel.AutoSize = true;
            this.intervalValueLabel.Location = new System.Drawing.Point(300, 55);
            this.intervalValueLabel.Name = "intervalValueLabel";
            this.intervalValueLabel.Size = new System.Drawing.Size(0, 15);
            this.intervalValueLabel.TabIndex = 17;
            // 
            // messageValueLabel
            // 
            this.messageValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageValueLabel.Location = new System.Drawing.Point(88, 75);
            this.messageValueLabel.Name = "messageValueLabel";
            this.messageValueLabel.Size = new System.Drawing.Size(890, 15);
            this.messageValueLabel.TabIndex = 18;
            // 
            // excludedUsersValueLabel
            // 
            this.excludedUsersValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excludedUsersValueLabel.Location = new System.Drawing.Point(96, 95);
            this.excludedUsersValueLabel.Name = "excludedUsersValueLabel";
            this.excludedUsersValueLabel.Size = new System.Drawing.Size(882, 15);
            this.excludedUsersValueLabel.TabIndex = 20;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 138);
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
            this.stopButton.Location = new System.Drawing.Point(118, 138);
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
            this.clearButton.Location = new System.Drawing.Point(896, 138);
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
            this.outputRichTextBox.Location = new System.Drawing.Point(12, 174);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.ReadOnly = true;
            this.outputRichTextBox.Size = new System.Drawing.Size(984, 492);
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
            this.settingsButton.Location = new System.Drawing.Point(790, 138);
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
            this.ClientSize = new System.Drawing.Size(1008, 725);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.copyrightStatusStrip.ResumeLayout(false);
            this.copyrightStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label excludedUsersLabel;
        private System.Windows.Forms.Label timerValueLabel;
        private System.Windows.Forms.Label intervalValueLabel;
        private System.Windows.Forms.Label messageValueLabel;
        private System.Windows.Forms.Label excludedUsersValueLabel;
        private System.Windows.Forms.Label serversValueLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel spacerStatusLabel;
        private TextProgressBar progressBar;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.StatusStrip copyrightStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel copyrightStatusLabel;
    }
}
