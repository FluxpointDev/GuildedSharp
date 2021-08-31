using GuildedSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
