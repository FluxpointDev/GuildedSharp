using GuildedSharp.Commands;
using GuildedSharp.Core;
using GuildedSharp.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
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

            Client = new GuildedClient(ClientMode.Websocket, JObject.Parse(System.IO.File.ReadAllText(File))["Token"].ToString(), new GuildedClientConfig
            {
                DebugEvents = false,
                OwnerIds = new string[]
                {
                    "N4ENvwZd"
                }
            });
            Console.WriteLine("Starting bot.");
            await Client.StartAsync();
            _commands = new CommandService();
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
            Client.OnMessageRecieved += Client_OnMessageRecieved;
            Client.OnMessageUpdated += Client_OnMessageUpdated;
            Client.OnMessageDeleted += Client_OnMessageDeleted;
            Console.WriteLine("Bot connected.");
            // Example on how to send a message ;)
            // await Client.Rest.SendMessageAsync("0000", "Test");

            await Task.Delay(-1);
        }

        private static void Client_OnMessageDeleted(object sender, DeletedMessage e)
        {
            Console.WriteLine("DELETED: " + e.id);
        }

        private static void Client_OnMessageUpdated(object sender, ChatMessage e)
        {
            Console.WriteLine("UPDATED: " + e.content);
        }
        private static CommandService _commands;

        private static void Client_OnMessageRecieved(object sender, ChatMessage e)
        {
            Console.WriteLine("CHAT: " + e.content);
            int argPos = 0;
            if (e.IsSystemMessage() || !e.HasStringPrefix("!", ref argPos))
                return;
            var context = new CommandContext(Client, e);
            _commands.ExecuteAsync( context: context, argPos: argPos, services: null);
        }
    }

    public class TestModule : ModuleBase
    {
        [Command("test")]
        public async Task Test()
        {
            await ReplyAsync("Test");
        }

        [Command("say"), RequireOwner]
        public async Task Say([Remainder] string text)
        {
            await ReplyAsync(text);
        }
    }
}
