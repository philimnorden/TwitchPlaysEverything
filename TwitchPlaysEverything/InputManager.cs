using System;
using System.Runtime.InteropServices;

namespace TwitchPlaysEverything
{
    class InputManager
    {
        public void SendInputWithAPI(MyScanCodes code)
        {
            keybd_event(0, code, 0x0008, 0);
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, MyScanCodes bScan, uint dwFlags, int dwExtraInfo);

        internal enum MyScanCodes : byte
        {
            A = 30,
            B = 48,
            X = 45,
            Y = 21,
            L = 38,
            R = 19,
            Left = 75,
            Right = 77,
            Up = 72,
            Down = 80,
            Enter = 28,
            
        }
    }
}