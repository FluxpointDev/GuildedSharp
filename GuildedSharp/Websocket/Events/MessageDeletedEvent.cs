using GuildedSharp.Core;

namespace GuildedSharp.Websocket.Events
{
    internal class BaseMessageDeletedEvent
    {
        public MessageDeletedEvent d;
    }
    internal class MessageDeletedEvent
    {
        public DeletedMessage message;
    }
}
