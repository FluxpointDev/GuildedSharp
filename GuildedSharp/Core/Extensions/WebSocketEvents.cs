using System;

namespace GuildedSharp.Core
{
    public class WebSocketEvents
    {
        public event EventHandler<ChatMessage> OnMessageRecieved;
        internal void InvokeMessageRecieved(ChatMessage msg)
        {
            OnMessageRecieved?.Invoke(this, msg);
        }

        public event EventHandler<ChatMessage> OnMessageUpdated;
        internal void InvokeMessageUpdated(ChatMessage msg)
        {
            OnMessageUpdated?.Invoke(this, msg);
        }

        public event EventHandler<DeletedMessage> OnMessageDeleted;
        internal void InvokeMessageDeleted(DeletedMessage msg)
        {
            OnMessageDeleted?.Invoke(this, msg);
        }
    }
}
