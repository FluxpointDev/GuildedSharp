using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestListHelper
    {
        public static Task<HttpResponseMessage> CreateListItemAsync(this GuildedRestClient rest, string channelId, string message, string note = "")
        => rest.SendRequestAsync(RequestType.Post, $"channels/{channelId}/list", new CreateListItemRequest { message = message, note = note });

    }
}
