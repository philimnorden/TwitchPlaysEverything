using System;
using System.Runtime.InteropServices;

namespace TwitchPlaysEverything
{
    class InputManager
    {
        public void SendInputWithAPI(MyScanCodes code,int zeit)
        {
            if (zeit > 10000)//größer 10 Sekunden vorerst nicht zulässig
            { 
                zeit = 100;
            }
            keybd_event(0, code, MyFlags.Keydown, 0);
            System.Threading.Thread.Sleep(zeit);
            keybd_event(0, code, MyFlags.Keyup, 0);
        }

        public string CheckLetter(string argument, MyScanCodes code)
        {
            int zeit = 100;
            if(String.IsNullOrEmpty(argument))
            {
                SendInputWithAPI(code, zeit);
                return null;
            }
            try
            {
                zeit = Int32.Parse(argument);
            }
            catch
            {
                return " Fehler in CheckLetter() mit " + code + "\r\nKonnte Argument nicht Parsen.";
            }
            SendInputWithAPI(code, zeit);
            return null;
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, MyScanCodes bScan, MyFlags dwFlags, int dwExtraInfo);

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

        internal enum MyFlags : uint
        {
            Keydown = 0x0008,
            Keyup = 0x0002,
        }

        public void Push(string argument)
        {
            switch (argument.ToLower())
            {
                case "up":
                    SendPushWithAPI(argument, MyScanCodes.Up);
                    break;
                case "down":
                    SendPushWithAPI(argument, MyScanCodes.Down);
                    break;
                case "right":
                    SendPushWithAPI(argument, MyScanCodes.Right);
                    break;
                case "left":
                    SendPushWithAPI(argument, MyScanCodes.Left);
                    break;
                default:
                    break;
            }
        }

        public void Pull(string argument)
        {
            switch (argument.ToLower())
            {
                case "up":
                    SendPushWithAPI(argument, MyScanCodes.Up);
                    break;
                case "down":
                    SendPushWithAPI(argument, MyScanCodes.Down);
                    break;
                case "right":
                    SendPushWithAPI(argument,MyScanCodes.Right);
                    break;
                case "left":
                    SendPushWithAPI(argument, MyScanCodes.Left);
                    break;
                default:
                    break;
            }
        }

        public void SendPushWithAPI(string argument, MyScanCodes code)
        {
            keybd_event(0, MyScanCodes.A, MyFlags.Keydown, 0);
            keybd_event(0, code, MyFlags.Keydown, 0);
            System.Threading.Thread.Sleep(1000);
            keybd_event(0, code, MyFlags.Keyup, 0);
            keybd_event(0, code, MyFlags.Keyup, 0);


        }
    }
}