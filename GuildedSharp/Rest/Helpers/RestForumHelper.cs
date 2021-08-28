using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestForumHelper
    {
        public static Task<HttpResponseMessage> CreateForumThreadAsync(this GuildedRestClient rest, string channelId, string title, string content)
        => rest.SendRequestAsync(RequestType.Post, $"channels/{channelId}/forum", new CreateForumThreadRequest { title = title, content = content });

    }
}
