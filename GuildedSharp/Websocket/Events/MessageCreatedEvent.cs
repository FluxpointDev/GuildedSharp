using GuildedSharp.Core;

namespace GuildedSharp.Websocket.Events
{
    internal class BaseMessageCreatedEvent
    {
        public MessageCreatedEvent d;
    }
    internal class MessageCreatedEvent
    {
        public ChatMessage message;
    }
}
