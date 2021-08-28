using GuildedSharp.Core;

namespace GuildedSharp.Websocket
{
    internal class GuildedSocketClient
    {
        public GuildedSocketClient(GuildedClient client)
        {
            Client = client;
        }
        internal GuildedClient Client;
        internal static string HostUrl = "wss://api.guilded.gg/v1/websocket";
    }
}
