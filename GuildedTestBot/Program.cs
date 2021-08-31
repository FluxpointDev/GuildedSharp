using GuildedSharp.Core;
using GuildedSharp.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace GuildedTestBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Start().GetAwaiter().GetResult();
        }

        public static GuildedClient Client;

        public static async Task Start()
        {
            string File = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/GuildedBots/Config.json";

            Client = new GuildedClient(ClientMode.Websocket, JObject.Parse(System.IO.File.ReadAllText(File))["Token"].ToString());
            Console.WriteLine("Starting bot.");
            await Client.StartAsync();
            Client.OnMessageRecieved += Client_OnMessageRecieved;
            Console.WriteLine("Bot connected.");
            // Example on how to send a message ;)
            // await Client.Rest.SendMessageAsync("0000", "Test");

            await Task.Delay(-1);
        }

        private static void Client_OnMessageRecieved(object sender, ChatMessage e)
        {
            if (e.content == "!hello")
            {
                Client.Rest.SendMessageAsync(e.channelId, "Hello World");
            }
            Console.WriteLine("CHAT: " + e.content);
        }
    }
}
