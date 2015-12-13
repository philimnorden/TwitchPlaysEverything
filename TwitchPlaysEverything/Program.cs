using System;
using System.Text.RegularExpressions;

namespace TwitchPlaysEverything
{
    class Program
    {


        static void Main(string[] args)
        {
            string username = "mmustermann";
            string pass = "oauth:1234567890";
            string room = "mmustermann";
            string application = "zsnesw";

            ChatClient chat = new ChatClient("irc.twitch.tv", 6667, username, pass);
            chat.joinRoom(room);
            chat.sendMessage("Application started successfully ...");

            WindowManager window = new WindowManager();
            InputManager input = new InputManager();

            while (true)
            {
                string messageWithName = chat.readMessage();
                string regexPattern = @":[a-zA-Z0-9_]+![a-zA-Z0-9_]+@[a-zA-Z0-9_]+.tmi.twitch.tv PRIVMSG #" + room + " :";
                Regex regex = new Regex(regexPattern);

                string onlyMessage = string.Empty;
                try
                {
                    onlyMessage = regex.Replace(messageWithName, "");
                }
                catch
                {
                    Console.WriteLine("Message could not be evaluated: " + messageWithName);
                }

                switch (onlyMessage.ToLower())
                {
                    case "a":
                        window.SetActiveWindow(application);
                        input.SendInputWithAPI();
                        break;
                    default:
                        break;
                }

                Console.WriteLine(onlyMessage);

            }
        }
    }
}
