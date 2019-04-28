using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EveClientSwitcher
{
    class WindowManager
    {
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

        const int SW_MINIMIZE = 2;
        const int SW_SHOW = 5;
        const int SW_RESTORE = 9;

        private Boolean IsMinimized(IntPtr mainWindowHandle)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(mainWindowHandle, ref placement);
            return placement.showCmd == SW_MINIMIZE;
        }

        public void MinimzeAllEveWindows()
        {
            Process[] processList = Process.GetProcessesByName("exefile");
            Array.Sort(processList,
                    delegate (Process x, Process y) { return x.Id.CompareTo(y.Id); });
            foreach (Process process in processList)
            {
                SetForegroundWindow(process.MainWindowHandle);
                ShowWindow(process.MainWindowHandle, SW_MINIMIZE);
            }
            SetForegroundWindow(GetDesktopWindow());
        }

        int lastActiveProcessId = -1;
        public void SwitchEveWindow()
        {
            Process[] processList = Process.GetProcessesByName("exefile");
            Array.Sort(processList,
                    delegate (Process x, Process y) { return x.Id.CompareTo(y.Id); });

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
    }
}
