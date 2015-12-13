using System.Net.Sockets;
using System.IO;


namespace TwitchPlaysEverything
{
    class ChatClient
    {
        string userName;
        string channel;
        TcpClient tcpClient;
        StreamReader inputStream;
        StreamWriter outputStream;


        public ChatClient(string ip, int port, string userName, string password)
        {

            this.userName = userName;
            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + userName);
            outputStream.WriteLine("USER " + userName + " 8 * :" + userName);
            outputStream.Flush();
        }

        public void joinRoom(string channel)
        {
            this.channel = channel;
            outputStream.WriteLine("JOIN #" + channel);
            outputStream.Flush();
        }

        public void sendMessageHelper(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
        }

        public void sendMessage(string message)
        {
            sendMessageHelper(":" + userName + "!" + userName + "@" + userName + ".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
        }

        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
        }
    }
}
