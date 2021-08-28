using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestMessageHelper
    {
        public static Task<HttpResponseMessage> SendMessageAsync(this GuildedRestClient rest, string channelId, string content)
        => rest.SendRequestAsync(RequestType.Post, $"channels/{channelId}/messages", new MessageContentRequest { content = content });

        public static Task<HttpResponseMessage> GetMessagesAsync(this GuildedRestClient rest, string channelId)
            => rest.SendRequestAsync(RequestType.Get, $"channels/{channelId}/messages");

        public static Task<HttpResponseMessage> GetMessageAsync(this GuildedRestClient rest, string channelId, string messageId)
            => rest.SendRequestAsync(RequestType.Get, $"channels/{channelId}/messages/{messageId}");

        public static Task<HttpResponseMessage> UpdateMessageAsync(this GuildedRestClient rest, string channelId, string messageId, string content)
        => rest.SendRequestAsync(RequestType.Put, $"channels/{channelId}/messages/{messageId}", new MessageContentRequest { content = content });

        public static Task<HttpResponseMessage> DeleteMessageAsync(this GuildedRestClient rest, string channelId, string messageId)
            => rest.SendRequestAsync(RequestType.Delete, $"channels/{channelId}/messages/{messageId}");
    }
}
