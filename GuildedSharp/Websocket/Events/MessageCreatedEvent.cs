using GuildedSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
