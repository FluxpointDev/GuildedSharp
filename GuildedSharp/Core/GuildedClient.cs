using GuildedSharp.Rest;
using GuildedSharp.Websocket;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GuildedSharp.Core
{
    public class GuildedClient
    {
        public GuildedClient(ClientMode mode, string token, GuildedClientConfig config = null)
        {
            if (string.IsNullOrEmpty(token))
                throw new GuildedException("Your client token is empty.");
            Config = config == null ? new GuildedClientConfig() : config;
            Token = token;
            Serializer = new JsonSerializer();
            Rest = new GuildedRestClient(this);
            if (mode == ClientMode.Websocket)
                Websocket = new GuildedSocketClient(this);
        }
        public string Token { get; internal set; }
        public GuildedRestClient Rest { get; internal set; }
        internal GuildedSocketClient Websocket;
        public GuildedClientConfig Config { get; internal set; }
        internal JsonSerializer Serializer;

        internal async Task StartAsync()
        {

        }
    }
    public enum ClientMode
    {
        Websocket, HttpOnly
    }
}
