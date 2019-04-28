using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void RegisterKeySwitch(int hotkey, int modifier, Keys key)
        {
            UnregisterKey(hotkey);
            string keyString = "";
            if ((modifier & (1 << 0)) == MOD_ALT)
            {
                this.altKeyCheckBox.Checked = true;
                keyString += "ALT + ";
            }
            else
            {
                this.altKeyCheckBox.Checked = false;
            }
            if ((modifier & (1 << 1)) == MOD_CONTROL)
            {
                this.controlKeyCheckBox.Checked = true;
                keyString += "CTRL + ";
            }
            else
            {
                this.controlKeyCheckBox.Checked = false;
            }
            if ((modifier & (1 << 2)) == MOD_SHIFT)
            {
                this.shiftKeyCheckBox.Checked = true;
                keyString += "SHIFT + ";
            }
            else
            {
                this.shiftKeyCheckBox.Checked = false;
            }
            keyString += key;
            this.keyComboBox.SelectedItem = key;
            this.currentKeyLabel.Text = keyString;
            RegisterHotKey(this.Handle, hotkey, modifier, (int)key);
        }

        private void RegisterKeyMinimize(int hotkey, int modifier, Keys key)
        {
            UnregisterKey(hotkey);
            string keyString = "";
            if ((modifier & (1 << 0)) == MOD_ALT)
            {
                this.altKeyMinCheckBox.Checked = true;
                keyString += "ALT + ";
            }
            else
            {
                this.altKeyMinCheckBox.Checked = false;
            }
            if ((modifier & (1 << 1)) == MOD_CONTROL)
            {
                this.controlKeyMinCheckBox.Checked = true;
                keyString += "CTRL + ";
            }
            else
            {
                this.controlKeyMinCheckBox.Checked = false;
            }
            if ((modifier & (1 << 2)) == MOD_SHIFT)
            {
                this.shiftKeyMinCheckBox.Checked = true;
                keyString += "SHIFT + ";
            }
            else
            {
                this.shiftKeyMinCheckBox.Checked = false;
            }
            keyString += key;
            this.keyMinComboBox.SelectedItem = key;
            this.currentKeyMinLabel.Text = keyString;
            RegisterHotKey(this.Handle, hotkey, modifier, (int)key);
        }

        private void UnregisterKey(int hotkey)
        {
            UnregisterHotKey(this.Handle, hotkey);
        }

        private void EveClientSwitcherForm_Load(object sender, EventArgs e)
        {
            activeProps = ReadProps();
            RegisterKeySwitch(HK_SWITCH, activeProps.switchModifier, activeProps.switchKey);
            RegisterKeyMinimize(HK_MINIMIZE, activeProps.minimizeModifier, activeProps.minimizeKey);
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

        private void SetAndSaveSwitch() {
            int modifier = 0;
            if (this.altKeyCheckBox.Checked)
            {
                modifier += MOD_ALT;
            }
            if (this.controlKeyCheckBox.Checked)
            {
                modifier += MOD_CONTROL;
            }
            if (this.shiftKeyCheckBox.Checked)
            {
                modifier += MOD_SHIFT;
            }
            activeProps.switchKey = (Keys)this.keyComboBox.SelectedItem;
            activeProps.switchModifier = modifier;
            RegisterKeySwitch(HK_SWITCH, activeProps.switchModifier, activeProps.switchKey);
            SaveProps(activeProps);
        }

        private void SetAndSaveMinimize()
        {
            int modifier = 0;
            if (this.altKeyMinCheckBox.Checked)
            {
                modifier += MOD_ALT;
            }
            if (this.controlKeyMinCheckBox.Checked)
            {
                modifier += MOD_CONTROL;
            }
            if (this.shiftKeyMinCheckBox.Checked)
            {
                modifier += MOD_SHIFT;
            }
            activeProps.minimizeKey = (Keys)this.keyMinComboBox.SelectedItem;
            activeProps.minimizeModifier = modifier;
            RegisterKeyMinimize(HK_MINIMIZE, activeProps.minimizeModifier, activeProps.minimizeKey);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            SetAndSave();
        }
    }
}
