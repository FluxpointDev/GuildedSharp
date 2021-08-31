using GuildedSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
