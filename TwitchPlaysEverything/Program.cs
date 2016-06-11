using System;
using System.Text.RegularExpressions;

namespace TwitchPlaysEverything
{
    class Program
    {


        static void Main(string[] args)
        {
            string username = "mmustermann";
            string pass = "oauth:12345";
            string room = "mmustermann";
            string application = "bsnes";

            ChatClient chat = new ChatClient("irc.chat.twitch.tv", 6667, username, pass);
            chat.joinRoom(room);
            chat.sendMessage("Application started successfully ...");

            WindowManager window = new WindowManager();
            InputManager input = new InputManager();
            Comands Befehle = new Comands();


            while (true)
            {
                string messageWithName = chat.readMessage();
                string regexPattern = @":[a-zA-Z0-9_]+![a-zA-Z0-9_]+@[a-zA-Z0-9_]+.tmi.twitch.tv PRIVMSG #" + room + " :";
                Regex regex = new Regex(regexPattern);


                string onlyMessage = string.Empty;
                string name = string.Empty;
                try
                {
                    onlyMessage = regex.Replace(messageWithName, "");
                    name = messageWithName.Substring(1, messageWithName.IndexOf(".")-1);

                }
                catch
                {
                    Console.WriteLine("Message could not be evaluated: " + messageWithName);
                }

                switch (onlyMessage.ToLower())
                {
                    case "!help":
                        chat.sendMessage(Befehle.Help());
                        break;
                    case "!readme":
                        chat.sendMessage(Befehle.ReadMe());
                        break;
                    case "!comands":
                        chat.sendMessage(Befehle.Comand());
                        break;
                    case "!github":
                        chat.sendMessage(Befehle.Github());
                        break;
                    case "!license":
                        chat.sendMessage(Befehle.License());
                        break;
                    case "!about":
                        chat.sendMessage(Befehle.License());
                        break;
                    case "a":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.A);
                        break;
                    case "b":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.B);
                        break;
                    case "x":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.X);
                        break;
                    case "y":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Y);
                        break;
                    case "l":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.L);
                        break;
                    case "r":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.R);
                        break;
                    case "left":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Left);
                        break;
                    case "right":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Right);
                        break;
                    case "up":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Up);
                        break;
                    case "down":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Down);
                        break;
                    case "enter":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI(InputManager.MyScanCodes.Enter);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(name + ": " + onlyMessage);
                //Console.WriteLine(messageWithName);

            }
        }
    }
}
