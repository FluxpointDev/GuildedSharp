using GuildedSharp.Core;

namespace GuildedSharp.Websocket.Events
{
    internal class BaseMessageUpdatedEvent
    {
        public MessageUpdatedEvent d;
    }
    internal class MessageUpdatedEvent
    {
        public ChatMessage message;
    }
}
