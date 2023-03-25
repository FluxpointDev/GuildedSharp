namespace GuildedSharp.Core
{
    public class ChatMessage
    {
        public string id;
        public string type;
        public bool IsSystemMessage()
        {
            return type == "system";
        }
        public string channelId;
        public string content;
        public string createdAt;
        public string createdBy;
        public string? createdByBotId;
        public string? createdByWebhookId;
        public string? updatedAt;
    }
}
