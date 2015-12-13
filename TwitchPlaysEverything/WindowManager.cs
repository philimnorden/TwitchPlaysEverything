using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TwitchPlaysEverything
{
    class WindowManager
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public void SetActiveWindow(string name)
        {
            Process[] p = Process.GetProcessesByName(name);
            SetForegroundWindow(p[0].MainWindowHandle);
        }
    }
}
