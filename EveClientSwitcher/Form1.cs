using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace EveClientSwitcher
{
    public partial class EveClientSwitcherForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        const int MOD_ALT = 0x0001;
        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int WM_HOTKEY = 0x0312;

        const int SW_MINIMIZE = 2;
        const int SW_SHOW = 5;
        const int SW_RESTORE = 9;

        const int HK_SWITCH = 1;
        const int HK_MINIMIZE = 2;

        private Boolean IsMinimized(IntPtr mainWindowHandle)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(mainWindowHandle, ref placement);
            return placement.showCmd == SW_MINIMIZE;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && (int)m.WParam == HK_SWITCH)
            {
                SwitchEveWindow();
            }
            if (m.Msg == WM_HOTKEY && (int)m.WParam == HK_MINIMIZE)
            {
                MinimzeAllEveWindows();
            }
            base.WndProc(ref m);
        }

        public EveClientSwitcherForm()
        {
            InitializeComponent();
        }

        private PROPS activeProps;
        private PROPS standbyProps;

        private string GetKeyString(int modifier, Keys key)
        {
            string keyString = GetKeyString(modifier);
            keyString += key;
            return keyString;
        }

        private string GetKeyString(int modifier)
        {
            string keyString = "";
            if ((modifier & (1 << 0)) == MOD_ALT)
            {
                keyString += "ALT + ";
            }
            if ((modifier & (1 << 1)) == MOD_CONTROL)
            {
                keyString += "CTRL + ";
            }
            if ((modifier & (1 << 2)) == MOD_SHIFT)
            {
                keyString += "SHIFT + ";
            }
            return keyString;
        }

        private void RegisterKey(int hotkey)
        {
            UnregisterKey(hotkey);
            if (hotkey == HK_SWITCH)
            {
                this.currentKeyLabel.Text = GetKeyString(activeProps.switchModifier, activeProps.switchKey);
                this.keyTextBox.Text = GetKeyString(activeProps.switchModifier, activeProps.switchKey);
                RegisterHotKey(this.Handle, hotkey, activeProps.switchModifier, (int)activeProps.switchKey);
            } else if (hotkey == HK_MINIMIZE)
            {
                this.currentKeyMinLabel.Text = GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
                this.keyMinTextBox.Text = GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
                RegisterHotKey(this.Handle, hotkey, activeProps.minimizeModifier, (int)activeProps.minimizeKey);
            }
        }

        private void UnregisterKey(int hotkey)
        {
            UnregisterHotKey(this.Handle, hotkey);
        }

        private void EveClientSwitcherForm_Load(object sender, EventArgs e)
        {
            activeProps = ReadProps();
            standbyProps = CopyProps(activeProps);
            RegisterKey(HK_SWITCH);
            RegisterKey(HK_MINIMIZE);
            keyTextBox.Text = GetKeyString(activeProps.switchModifier, activeProps.switchKey);
            keyMinTextBox.Text = GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
            this.Hide();
        }

        private void EveClientSwitcherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterKey(HK_SWITCH);
            UnregisterKey(HK_MINIMIZE);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void EveClientSwitcherForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Hide();
            }
        }

        private void SetAndSaveSwitch()
        {
            activeProps.switchModifier = standbyProps.switchModifier;
            activeProps.switchKey = standbyProps.switchKey;
            RegisterKey(HK_SWITCH);
            SaveProps(activeProps);
        }

        private void SetAndSaveMinimize()
        {
            activeProps.minimizeModifier = standbyProps.minimizeModifier;
            activeProps.minimizeKey = standbyProps.minimizeKey;
            RegisterKey(HK_MINIMIZE);
            SaveProps(activeProps);
        }

        private void SetAndSave()
        {
            SetAndSaveSwitch();
            SetAndSaveMinimize();
        }

        private void MinimzeAllEveWindows()
        {
            Process[] processList = Process.GetProcessesByName("exefile");
            Array.Sort(processList,
                    delegate(Process x, Process y) { return x.Id.CompareTo(y.Id); });
            foreach (Process process in processList)
            {
                SetForegroundWindow(process.MainWindowHandle);
                ShowWindow(process.MainWindowHandle, SW_MINIMIZE);
            }
            SetForegroundWindow(GetDesktopWindow());
        }

        int lastActiveProcessId = -1;
        private void SwitchEveWindow()
        {
            Process[] processList = Process.GetProcessesByName("exefile");
            Array.Sort(processList,
                    delegate(Process x, Process y) { return x.Id.CompareTo(y.Id); });

            if (processList.Length == 1)
            {
                IntPtr mwh = processList[0].MainWindowHandle;
                if (IsMinimized(mwh))
                {
                    ShowWindow(mwh, SW_RESTORE);
                }
                SetForegroundWindow(mwh);
                lastActiveProcessId = processList[0].Id;
            }
            else if (processList.Length > 1)
            {
                Process newActiveProcess = null;

                if (lastActiveProcessId == -1)
                {
                    newActiveProcess = processList[0];
                }
                else
                {
                    foreach (Process process in processList)
                    {
                        if (process.Id > lastActiveProcessId)
                        {
                            newActiveProcess = process;
                            break;
                        }
                    }
                }
                if (newActiveProcess == null)
                {
                    newActiveProcess = processList[0];
                }
                lastActiveProcessId = newActiveProcess.Id;

                ShowWindow(newActiveProcess.MainWindowHandle, SW_RESTORE);
                foreach (Process process in processList)
                {
                    if (process.Id != lastActiveProcessId)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        ShowWindow(process.MainWindowHandle, SW_MINIMIZE);
                    }
                }
                SetForegroundWindow(newActiveProcess.MainWindowHandle);
            }
        }

        private const string propsFile = "ecs.dat";

        private void SaveProps(PROPS props)
        {
            string propsString = "";
            propsString += props.minimizeModifier + ",";
            propsString += (int)props.minimizeKey + ",";
            propsString += props.switchModifier + ",";
            propsString += (int)props.switchKey;
            File.WriteAllText(propsFile, propsString);
        }

        private PROPS ReadProps()
        {
            PROPS props = new PROPS();
            if (!File.Exists(propsFile))
            {
                props.minimizeModifier = 5;
                props.minimizeKey = Keys.X;
                props.switchModifier = 5;
                props.switchKey = Keys.S;
            }
            else
            {
                string[] propsArray = File.ReadAllText(propsFile).Split(',');
                props.minimizeModifier = Convert.ToInt16(propsArray[0]);
                props.minimizeKey = (Keys)Convert.ToInt16(propsArray[1]);
                props.switchModifier = Convert.ToInt16(propsArray[2]);
                props.switchKey = (Keys)Convert.ToInt16(propsArray[3]);
            }
            
            return props;
        }

        private struct PROPS
        {
            public int switchModifier;
            public int minimizeModifier;
            public Keys switchKey;
            public Keys minimizeKey;
        }

        private PROPS CopyProps(PROPS props)
        {
            return new PROPS()
            {
                minimizeModifier = props.minimizeModifier,
                minimizeKey = props.minimizeKey,
                switchModifier = props.switchModifier,
                switchKey = props.switchKey
            };
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SetAndSave();
        }

        private int ConvertModifier(Keys modifierKeys)
        {
            int modifier = 0;
            if ((modifierKeys & Keys.Shift) == Keys.Shift)
            {
                modifier += MOD_SHIFT;
            }
            if ((modifierKeys & Keys.Control) == Keys.Control)
            {
                modifier += MOD_CONTROL;
            }
            if ((modifierKeys & Keys.Alt) == Keys.Alt)
            {
                modifier += MOD_ALT;
            }
            return modifier;
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
                int modifier = ConvertModifier(ModifierKeys);
                keyMinTextBox.Text = GetKeyString(modifier);
            }
            else if (IsValidKey(pressedKey))
            {
                int modifier = ConvertModifier(ModifierKeys);
                standbyProps.minimizeModifier = modifier;
                standbyProps.minimizeKey = pressedKey;
                keyMinTextBox.Text = GetKeyString(modifier, pressedKey);
            }
            else
            {
                keyMinTextBox.Text = "> Invalid key <";
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
                int modifier = ConvertModifier(ModifierKeys);
                keyTextBox.Text = GetKeyString(modifier);
            }
            else if (IsValidKey(pressedKey))
            {
                int modifier = ConvertModifier(ModifierKeys);
                standbyProps.switchModifier = modifier;
                standbyProps.switchKey = pressedKey;
                keyTextBox.Text = GetKeyString(modifier, pressedKey);
            }
            else
            {
                keyTextBox.Text = "> Invalid key <";
            }
            e.Handled = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            standbyProps = CopyProps(activeProps);
            keyTextBox.Text = GetKeyString(activeProps.switchModifier, activeProps.switchKey);
            keyMinTextBox.Text = GetKeyString(activeProps.minimizeModifier, activeProps.minimizeKey);
        }
    }
}
