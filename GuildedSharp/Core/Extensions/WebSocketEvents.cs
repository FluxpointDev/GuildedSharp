using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedSharp.Core
{
    public class WebSocketEvents
    {
        public event EventHandler<ChatMessage> OnMessageRecieved;
        internal void InvokeMessageRecieved(ChatMessage msg)
        {
            OnMessageRecieved.Invoke(this, msg);
        }

        public event EventHandler<ChatMessage> OnMessageUpdated;
        internal void InvokeMessageUpdated(ChatMessage msg)
        {
            OnMessageUpdated.Invoke(this, msg);
        }

        public event EventHandler<DeletedMessage> OnMessageDeleted;
        internal void InvokeMessageDeleted(DeletedMessage msg)
        {
            OnMessageDeleted.Invoke(this, msg);
        }
    }
}
