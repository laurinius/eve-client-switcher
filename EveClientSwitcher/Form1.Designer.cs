namespace EveClientSwitcher
{
    partial class EveClientSwitcherForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EveClientSwitcherForm));
            this.ecsNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ecsNotifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentKeyLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.currentKeyMinLabel = new System.Windows.Forms.Label();
            this.keyMinTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.ecsNotifyMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ecsNotifyIcon
            // 
            this.ecsNotifyIcon.ContextMenuStrip = this.ecsNotifyMenuStrip;
            this.ecsNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ecsNotifyIcon.Icon")));
            this.ecsNotifyIcon.Text = "EVE Client Switcher";
            this.ecsNotifyIcon.Visible = true;
            this.ecsNotifyIcon.DoubleClick += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // ecsNotifyMenuStrip
            // 
            this.ecsNotifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.ecsNotifyMenuStrip.Name = "contextMenuStrip1";
            this.ecsNotifyMenuStrip.Size = new System.Drawing.Size(117, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currentKeyLabel);
            this.groupBox1.Controls.Add(this.keyTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Switch EVE Window";
            // 
            // currentKeyLabel
            // 
            this.currentKeyLabel.AutoSize = true;
            this.currentKeyLabel.Location = new System.Drawing.Point(6, 39);
            this.currentKeyLabel.Name = "currentKeyLabel";
            this.currentKeyLabel.Size = new System.Drawing.Size(28, 13);
            this.currentKeyLabel.TabIndex = 12;
            this.currentKeyLabel.Text = "Test";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(6, 19);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.Size = new System.Drawing.Size(221, 20);
            this.keyTextBox.TabIndex = 14;
            this.keyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentKeyMinLabel);
            this.groupBox2.Controls.Add(this.keyMinTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minimze All EVE Windows";
            // 
            // currentKeyMinLabel
            // 
            this.currentKeyMinLabel.AutoSize = true;
            this.currentKeyMinLabel.Location = new System.Drawing.Point(6, 39);
            this.currentKeyMinLabel.Name = "currentKeyMinLabel";
            this.currentKeyMinLabel.Size = new System.Drawing.Size(28, 13);
            this.currentKeyMinLabel.TabIndex = 12;
            this.currentKeyMinLabel.Text = "Test";
            // 
            // keyMinTextBox
            // 
            this.keyMinTextBox.Location = new System.Drawing.Point(6, 16);
            this.keyMinTextBox.Name = "keyMinTextBox";
            this.keyMinTextBox.ReadOnly = true;
            this.keyMinTextBox.Size = new System.Drawing.Size(221, 20);
            this.keyMinTextBox.TabIndex = 13;
            this.keyMinTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyMinTextBox_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(251, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 85);
            this.button1.TabIndex = 9;
            this.button1.Text = "Set\r\n&&\r\nSave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(251, 109);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 24);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // EveClientSwitcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 146);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EveClientSwitcherForm";
            this.Text = "EVE Client Switcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EveClientSwitcherForm_FormClosing);
            this.Load += new System.EventHandler(this.EveClientSwitcherForm_Load);
            this.Resize += new System.EventHandler(this.EveClientSwitcherForm_Resize);
            this.ecsNotifyMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ecsNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip ecsNotifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label currentKeyLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label currentKeyMinLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox keyMinTextBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Button resetButton;
    }
}

