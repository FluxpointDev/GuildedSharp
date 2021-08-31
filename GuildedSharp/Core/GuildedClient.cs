using GuildedSharp.Rest;
using GuildedSharp.Websocket;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GuildedSharp.Core
{
    public class GuildedClient : WebSocketEvents
    {
        public GuildedClient(ClientMode mode, string token, GuildedClientConfig config = null)
        {
            try
            {
                DisableConsoleQuickEdit.Go();
            }
            catch { }

            if (string.IsNullOrEmpty(token))
                throw new GuildedException("Your client token is empty.");
            Config = config == null ? new GuildedClientConfig() : config;
            Token = token;
            Serializer = new JsonSerializer();
            Rest = new GuildedRestClient(this);
            if (mode == ClientMode.Websocket)
            {
                Websocket = new GuildedSocketClient(this);
            }
        }

        public string Token { get; internal set; }
        public GuildedRestClient Rest { get; internal set; }
        internal GuildedSocketClient Websocket;
        public GuildedClientConfig Config { get; internal set; }
        internal JsonSerializer Serializer;

        public async Task StartAsync()
        {
            if (Websocket == null)
                throw new GuildedException("Client is in http-only mode.");

            if (Websocket.WebSocket != null)
                return;
            Websocket.SetupWebsocket();
            while (Websocket.WebSocket == null || Websocket.WebSocket.State != System.Net.WebSockets.WebSocketState.Open) { }
        }

        public async Task StopAsync()
        {
            if (Websocket == null)
                throw new GuildedException("Client is in http-only mode.");

            if (Websocket.WebSocket != null)
            {
                await Websocket.WebSocket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "", Websocket.CancellationToken);
            }
        }
    }
    public enum ClientMode
    {
        HttpOnly, Websocket
    }
}
