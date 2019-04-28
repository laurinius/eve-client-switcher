using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EveClientSwitcher
{
    class HotkeyManager
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_SHIFT = 0x0004;
        const int WM_HOTKEY = 0x0312;

        public const int HK_SWITCH = 0;
        public const int HK_MINIMIZE = 1;

        private WindowManager windowManager = new WindowManager();

        public void HandleHotkey(IntPtr formHandle, ref Message m)
        {
            if (m.Msg == WM_HOTKEY && (int)m.WParam == HK_SWITCH)
            {
                windowManager.SwitchEveWindow();
            }
            if (m.Msg == WM_HOTKEY && (int)m.WParam == HK_MINIMIZE)
            {
                windowManager.MinimzeAllEveWindows();
            }
        }

        public void RegisterKey(IntPtr formHandle, int hotkey, int modifier, Keys key)
        {
            UnregisterKey(formHandle, hotkey);
            RegisterHotKey(formHandle, hotkey, modifier, (int)key);
        }

        public void UnregisterKey(IntPtr formHandle, int hotkey)
        {
            UnregisterHotKey(formHandle, hotkey);
        }

        public int ConvertModifier(Keys modifierKeys)
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

        public string GetKeyString(int modifier, Keys key)
        {
            string keyString = GetKeyString(modifier);
            keyString += key;
            return keyString;
        }

        public string GetKeyString(int modifier)
        {
            string keyString = "";
            if ((modifier & (1 << 0)) == HotkeyManager.MOD_ALT)
            {
                keyString += "ALT + ";
            }
            if ((modifier & (1 << 1)) == HotkeyManager.MOD_CONTROL)
            {
                keyString += "CTRL + ";
            }
            if ((modifier & (1 << 2)) == HotkeyManager.MOD_SHIFT)
            {
                keyString += "SHIFT + ";
            }
            return keyString;
        }
    }
}
