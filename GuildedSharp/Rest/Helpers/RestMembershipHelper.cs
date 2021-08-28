using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestMembershipHelper
    {
        public static Task<HttpResponseMessage> AddMemberToGroupAsync(this GuildedRestClient rest, string groupId, string userId)
        => rest.SendRequestAsync(RequestType.Put, $"groups/{groupId}/members/{userId}");

        public static Task<HttpResponseMessage> RemoveMemberFromGroupAsync(this GuildedRestClient rest, string groupId, string userId)
        => rest.SendRequestAsync(RequestType.Delete, $"groups/{groupId}/members/{userId}");
    }
}
