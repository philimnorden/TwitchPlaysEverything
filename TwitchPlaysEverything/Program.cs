using System;
using System.Text.RegularExpressions;

namespace TwitchPlaysEverything
{
    class Program
    {

        static void Main(string[] args)
        {
            string username = "Pumpitx";
            string pass = "oauth:0b86wmbg1x5wy2qtjst582g6s7yf8p";
            string room = "pumpitx";
            string application = "notepad";

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

                string ConsoleInput = string.Empty;
                string error = string.Empty;
                string SecArgument = string.Empty;
                string onlyMessage = string.Empty;
                string name = string.Empty;
                try
                {

                    onlyMessage = regex.Replace(messageWithName, "");

                    if (onlyMessage.Contains(" "))
                    {
                        SecArgument = onlyMessage.Substring(onlyMessage.IndexOf(" "));
                    }
                    else
                    {
                        SecArgument = String.Empty;
                    }
                    name = messageWithName.Substring(1, messageWithName.IndexOf(".")-1);

                }
                catch
                {
                    Console.WriteLine("Message could not be evaluated: " + messageWithName);
                }

               // Console.WriteLine("Zum Senden von Nachrichten an Chat bitte '/send [Nachricht]' eintippen");
                switch (onlyMessage.ToLower())
                {
                    case "!help":
                        for (int i = 0; i < Befehle.befehle.Length ; i++)
                        {
                            chat.sendMessage(Befehle.Help(i)); //Testen der Schleife, i als Parameter für array
                        }
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
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.A);
                        break;
                    case "b":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.B);
                        break;
                    case "x":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.X);
                        break;
                    case "y":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Y);
                        break;
                    case "l":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.L);
                        break;
                    case "r":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.R);
                        break;
                    case "left":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Left);
                        break;
                    case "right":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Right);
                        break;
                    case "up":
                        window.SetActiveWindow(application);
                      error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Up);
                        break;
                    case "down":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Down);
                        break;
                    case "enter":
                        window.SetActiveWindow(application);
                       error = input.CheckLetter(SecArgument, InputManager.MyScanCodes.Enter);
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine(error);
                    error = string.Empty;
                }

             /*   //ermöglicht Eingaben durch Konsole und senden an TwitchChat via Bot
                ConsoleInput = Console.ReadLine();
                if (ConsoleInput.Contains("/send"))
                {
                    ConsoleInput = ConsoleInput.Substring(ConsoleInput.IndexOf(" "));
                    chat.sendMessage(ConsoleInput);
                }
                */
                //sendet Nachrichten mit Namen aus Chat an Konsole
                Console.WriteLine(name + ": " + onlyMessage);

            }
        }
    }
}
