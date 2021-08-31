using GuildedSharp.Core;
using GuildedSharp.Rest;
using GuildedSharp.Websocket.Events;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildedSharp.Websocket
{
    internal class GuildedSocketClient
    {
        public GuildedSocketClient(GuildedClient client)
        {
            Client = client;
            CancellationToken = new CancellationToken();
        }
        internal GuildedClient Client;
        internal ClientWebSocket WebSocket;
        internal static string HostUrl = "wss://api.guilded.gg/v1/websocket";

        public CancellationToken CancellationToken;

        internal async Task SetupWebsocket()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                using (WebSocket = new ClientWebSocket())
                {
                    WebSocket.Options.SetRequestHeader("Authorization", "Bearer " + Client.Token);
                    try
                    {
                        await WebSocket.ConnectAsync(new Uri(HostUrl), CancellationToken);
                        await Send(WebSocket, "data", CancellationToken);
                        await Receive(WebSocket, CancellationToken);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"WebSocket Error - {ex}");
                        await Task.Delay(5000);
                    }
                }
            }
        }

        private async Task Send(ClientWebSocket socket, string data, CancellationToken stoppingToken) =>
       await socket.SendAsync(Encoding.UTF8.GetBytes(data), WebSocketMessageType.Text, true, stoppingToken);

        private async Task Receive(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            while (!cancellationToken.IsCancellationRequested)
            {
                WebSocketReceiveResult result;
                using (var ms = new MemoryStream())
                {
                    do
                    {
                        result = await socket.ReceiveAsync(buffer, cancellationToken);
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Close)
                        break;

                    ms.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(ms, Encoding.UTF8))
                    {
                        WebSocketMessage(await reader.ReadToEndAsync());
                    }
                }
            };
        }

        private async Task WebSocketMessage(string json)
        {
            JToken Payload = Newtonsoft.Json.JsonConvert.DeserializeObject<JToken>(json);
            if (Client.Config.DebugEvents)
                Console.WriteLine("Json - " + json);
            switch ((int)Payload["op"])
            {
                case 1:
                    Console.WriteLine("WebSocket Hello!");
                    break;
                case 0:
                    {
                        switch ((string)Payload["t"])
                        {
                            case "ChatMessageCreated":
                                {
                                    MessageCreatedEvent Event = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseMessageCreatedEvent>(json).d;

                                    Client.InvokeMessageRecieved(Event.message);
                                }
                                break;
                            case "ChatMessageUpdated":
                                {
                                    MessageUpdatedEvent Event = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseMessageUpdatedEvent>(json).d;

                                    Client.InvokeMessageUpdated(Event.message);
                                }
                                break;
                            case "ChatMessageDeleted":
                                {
                                    MessageDeletedEvent Event = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseMessageDeletedEvent>(json).d;

                                    Client.InvokeMessageDeleted(Event.message);
                                }
                                break;
                            case "TeamXpAdded":
                                {
                                    TeamXpEvent Event = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseTeamXpEvent>(json).d;
                                }
                                break;
                        }
                    }
                    break;
            }

        }
    }
}
