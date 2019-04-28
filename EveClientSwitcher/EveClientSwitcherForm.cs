using System;
using System.Linq;
using System.Windows.Forms;

namespace EveClientSwitcher
{
    public partial class EveClientSwitcherForm : Form
    {
        private HotkeyManager hotkeyManager = new HotkeyManager();
        private PropertyManager propertyManager = new PropertyManager();

        private PropertyManager.PROPS activeProps;
        private PropertyManager.PROPS standbyProps;
    
        public EveClientSwitcherForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            hotkeyManager.HandleHotkey(this.Handle, ref m);
            base.WndProc(ref m);
        }

        private void RegisterSwitchKey()
        {
            hotkeyManager.RegisterKey(this.Handle, HotkeyManager.HK_SWITCH, activeProps.switchModifier, activeProps.switchKey);
            this.activeSwitchKeyLabel.Text = hotkeyManager.GetKeyString(activeProps.switchModifier, activeProps.switchKey);
            this.switchKeyTextBox.Text = hotkeyManager.GetKeyString(activeProps.switchModifier, activeProps.switchKey);
        }

        private void RegisterMinimizeKey()
        {
            hotkeyManager.RegisterKey(this.Handle, HotkeyManager.HK_MINIMIZE, activeProps.minimizeModifier, activeProps.minimizeKey);
            this.activeMinimizeKeyLabel.Text = hotkeyManager.GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
            this.minimizeKeyTextBox.Text = hotkeyManager.GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
        }

        private void EveClientSwitcherForm_Load(object sender, EventArgs e)
        {
            activeProps = propertyManager.ReadProps();
            standbyProps = propertyManager.CopyProps(activeProps);
            RegisterSwitchKey();
            RegisterMinimizeKey();
            this.Hide();
        }

        private void EveClientSwitcherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotkeyManager.UnregisterKey(this.Handle, HotkeyManager.HK_SWITCH);
            hotkeyManager.UnregisterKey(this.Handle, HotkeyManager.HK_MINIMIZE);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void EveClientSwitcherForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void SetSwitch()
        {
            activeProps.switchModifier = standbyProps.switchModifier;
            activeProps.switchKey = standbyProps.switchKey;
            RegisterSwitchKey();
        }

        private void SetMinimize()
        {
            activeProps.minimizeModifier = standbyProps.minimizeModifier;
            activeProps.minimizeKey = standbyProps.minimizeKey;
            RegisterMinimizeKey();
        }

        private void SetAndSave()
        {
            SetSwitch();
            SetMinimize();
            propertyManager.SaveProps(activeProps);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SetAndSave();
        }

        Keys[] invalidKeys = new[] { Keys.LMenu, Keys.RMenu, Keys.LShiftKey, Keys.RShiftKey, Keys.LControlKey, Keys.RControlKey,
            Keys.LWin, Keys.RWin, Keys.Apps, Keys.LaunchApplication1, Keys.LaunchApplication2 };

        Keys[] modifierKeys = new[] { Keys.Menu, Keys.ShiftKey, Keys.ControlKey };

        private Boolean IsValidKey(Keys key)
        {
            return !invalidKeys.Contains(key);
        }

        private Boolean IsOnlyModifierKey(Keys key)
        {
            return key == Keys.None || modifierKeys.Contains(key);
        }

        private void KeyMinTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Keys modifierKeys = e.Modifiers;
            Keys pressedKey = e.KeyData ^ modifierKeys;
            
                standbyProps.minimizeModifier = activeProps.minimizeModifier;
                standbyProps.minimizeKey = activeProps.minimizeKey;

            if (IsOnlyModifierKey(pressedKey))
            {
                int modifier = hotkeyManager.ConvertModifier(ModifierKeys);
                minimizeKeyTextBox.Text = hotkeyManager.GetKeyString(modifier);
            }
            else if (IsValidKey(pressedKey))
            {
                int modifier = hotkeyManager.ConvertModifier(ModifierKeys);
                standbyProps.minimizeModifier = modifier;
                standbyProps.minimizeKey = pressedKey;
                minimizeKeyTextBox.Text = hotkeyManager.GetKeyString(modifier, pressedKey);
            }
            else
            {
                minimizeKeyTextBox.Text = "> Invalid key <";
            }
            e.Handled = true;
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Keys modifierKeys = e.Modifiers;
            Keys pressedKey = e.KeyData ^ modifierKeys;

            standbyProps.switchModifier = activeProps.switchModifier;
            standbyProps.switchKey = activeProps.switchKey;

            if (IsOnlyModifierKey(pressedKey))
            {
                int modifier = hotkeyManager.ConvertModifier(ModifierKeys);
                switchKeyTextBox.Text = hotkeyManager.GetKeyString(modifier);
            }
            else if (IsValidKey(pressedKey))
            {
                int modifier = hotkeyManager.ConvertModifier(ModifierKeys);
                standbyProps.switchModifier = modifier;
                standbyProps.switchKey = pressedKey;
                switchKeyTextBox.Text = hotkeyManager.GetKeyString(modifier, pressedKey);
            }
            else
            {
                switchKeyTextBox.Text = "> Invalid key <";
            }
            e.Handled = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            standbyProps = propertyManager.CopyProps(activeProps);
            switchKeyTextBox.Text = hotkeyManager.GetKeyString(activeProps.switchModifier, activeProps.switchKey);
            minimizeKeyTextBox.Text = hotkeyManager.GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
        }
    }
}
