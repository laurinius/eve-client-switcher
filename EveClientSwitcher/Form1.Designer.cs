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
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.controlKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.altKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.currentKeyMinLabel = new System.Windows.Forms.Label();
            this.keyMinComboBox = new System.Windows.Forms.ComboBox();
            this.controlKeyMinCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftKeyMinCheckBox = new System.Windows.Forms.CheckBox();
            this.altKeyMinCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.keyComboBox);
            this.groupBox1.Controls.Add(this.controlKeyCheckBox);
            this.groupBox1.Controls.Add(this.shiftKeyCheckBox);
            this.groupBox1.Controls.Add(this.altKeyCheckBox);
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
            // keyComboBox
            // 
            this.keyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Items.AddRange(new object[] {
            System.Windows.Forms.Keys.A,
            System.Windows.Forms.Keys.B,
            System.Windows.Forms.Keys.C,
            System.Windows.Forms.Keys.D,
            System.Windows.Forms.Keys.E,
            System.Windows.Forms.Keys.F,
            System.Windows.Forms.Keys.G,
            System.Windows.Forms.Keys.H,
            System.Windows.Forms.Keys.I,
            System.Windows.Forms.Keys.J,
            System.Windows.Forms.Keys.K,
            System.Windows.Forms.Keys.L,
            System.Windows.Forms.Keys.M,
            System.Windows.Forms.Keys.N,
            System.Windows.Forms.Keys.O,
            System.Windows.Forms.Keys.P,
            System.Windows.Forms.Keys.Q,
            System.Windows.Forms.Keys.R,
            System.Windows.Forms.Keys.S,
            System.Windows.Forms.Keys.T,
            System.Windows.Forms.Keys.U,
            System.Windows.Forms.Keys.V,
            System.Windows.Forms.Keys.W,
            System.Windows.Forms.Keys.X,
            System.Windows.Forms.Keys.Y,
            System.Windows.Forms.Keys.Z});
            this.keyComboBox.Location = new System.Drawing.Point(181, 17);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(38, 21);
            this.keyComboBox.TabIndex = 10;
            // 
            // controlKeyCheckBox
            // 
            this.controlKeyCheckBox.AutoSize = true;
            this.controlKeyCheckBox.Location = new System.Drawing.Point(58, 19);
            this.controlKeyCheckBox.Name = "controlKeyCheckBox";
            this.controlKeyCheckBox.Size = new System.Drawing.Size(54, 17);
            this.controlKeyCheckBox.TabIndex = 9;
            this.controlKeyCheckBox.Text = "CTRL";
            this.controlKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftKeyCheckBox
            // 
            this.shiftKeyCheckBox.AutoSize = true;
            this.shiftKeyCheckBox.Location = new System.Drawing.Point(118, 19);
            this.shiftKeyCheckBox.Name = "shiftKeyCheckBox";
            this.shiftKeyCheckBox.Size = new System.Drawing.Size(57, 17);
            this.shiftKeyCheckBox.TabIndex = 8;
            this.shiftKeyCheckBox.Text = "SHIFT";
            this.shiftKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // altKeyCheckBox
            // 
            this.altKeyCheckBox.AutoSize = true;
            this.altKeyCheckBox.Location = new System.Drawing.Point(6, 19);
            this.altKeyCheckBox.Name = "altKeyCheckBox";
            this.altKeyCheckBox.Size = new System.Drawing.Size(46, 17);
            this.altKeyCheckBox.TabIndex = 7;
            this.altKeyCheckBox.Text = "ALT";
            this.altKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentKeyMinLabel);
            this.groupBox2.Controls.Add(this.keyMinComboBox);
            this.groupBox2.Controls.Add(this.controlKeyMinCheckBox);
            this.groupBox2.Controls.Add(this.shiftKeyMinCheckBox);
            this.groupBox2.Controls.Add(this.altKeyMinCheckBox);
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
            // keyMinComboBox
            // 
            this.keyMinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyMinComboBox.FormattingEnabled = true;
            this.keyMinComboBox.Items.AddRange(new object[] {
            System.Windows.Forms.Keys.A,
            System.Windows.Forms.Keys.B,
            System.Windows.Forms.Keys.C,
            System.Windows.Forms.Keys.D,
            System.Windows.Forms.Keys.E,
            System.Windows.Forms.Keys.F,
            System.Windows.Forms.Keys.G,
            System.Windows.Forms.Keys.H,
            System.Windows.Forms.Keys.I,
            System.Windows.Forms.Keys.J,
            System.Windows.Forms.Keys.K,
            System.Windows.Forms.Keys.L,
            System.Windows.Forms.Keys.M,
            System.Windows.Forms.Keys.N,
            System.Windows.Forms.Keys.O,
            System.Windows.Forms.Keys.P,
            System.Windows.Forms.Keys.Q,
            System.Windows.Forms.Keys.R,
            System.Windows.Forms.Keys.S,
            System.Windows.Forms.Keys.T,
            System.Windows.Forms.Keys.U,
            System.Windows.Forms.Keys.V,
            System.Windows.Forms.Keys.W,
            System.Windows.Forms.Keys.X,
            System.Windows.Forms.Keys.Y,
            System.Windows.Forms.Keys.Z});
            this.keyMinComboBox.Location = new System.Drawing.Point(181, 17);
            this.keyMinComboBox.Name = "keyMinComboBox";
            this.keyMinComboBox.Size = new System.Drawing.Size(38, 21);
            this.keyMinComboBox.TabIndex = 10;
            // 
            // controlKeyMinCheckBox
            // 
            this.controlKeyMinCheckBox.AutoSize = true;
            this.controlKeyMinCheckBox.Location = new System.Drawing.Point(58, 19);
            this.controlKeyMinCheckBox.Name = "controlKeyMinCheckBox";
            this.controlKeyMinCheckBox.Size = new System.Drawing.Size(54, 17);
            this.controlKeyMinCheckBox.TabIndex = 9;
            this.controlKeyMinCheckBox.Text = "CTRL";
            this.controlKeyMinCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftKeyMinCheckBox
            // 
            this.shiftKeyMinCheckBox.AutoSize = true;
            this.shiftKeyMinCheckBox.Location = new System.Drawing.Point(118, 19);
            this.shiftKeyMinCheckBox.Name = "shiftKeyMinCheckBox";
            this.shiftKeyMinCheckBox.Size = new System.Drawing.Size(57, 17);
            this.shiftKeyMinCheckBox.TabIndex = 8;
            this.shiftKeyMinCheckBox.Text = "SHIFT";
            this.shiftKeyMinCheckBox.UseVisualStyleBackColor = true;
            // 
            // altKeyMinCheckBox
            // 
            this.altKeyMinCheckBox.AutoSize = true;
            this.altKeyMinCheckBox.Location = new System.Drawing.Point(6, 19);
            this.altKeyMinCheckBox.Name = "altKeyMinCheckBox";
            this.altKeyMinCheckBox.Size = new System.Drawing.Size(46, 17);
            this.altKeyMinCheckBox.TabIndex = 7;
            this.altKeyMinCheckBox.Text = "ALT";
            this.altKeyMinCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(251, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 85);
            this.button1.TabIndex = 9;
            this.button1.Text = "Set\r\n&&\r\nSave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EveClientSwitcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 146);
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
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.CheckBox controlKeyCheckBox;
        private System.Windows.Forms.CheckBox shiftKeyCheckBox;
        private System.Windows.Forms.CheckBox altKeyCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label currentKeyMinLabel;
        private System.Windows.Forms.ComboBox keyMinComboBox;
        private System.Windows.Forms.CheckBox controlKeyMinCheckBox;
        private System.Windows.Forms.CheckBox shiftKeyMinCheckBox;
        private System.Windows.Forms.CheckBox altKeyMinCheckBox;
        private System.Windows.Forms.Button button1;

    }
}

