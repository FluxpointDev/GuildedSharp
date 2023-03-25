using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestReactionHelper
    {
        public static Task<HttpResponseMessage> CreateListItemAsync(this GuildedRestClient rest, string channelId, string contentId, string emoteId)
        => rest.SendRequestAsync(RequestType.Put, $"channels/{channelId}/content{contentId}/emotes/{emoteId}");

    }
}
