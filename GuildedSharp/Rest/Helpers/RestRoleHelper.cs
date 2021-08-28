using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestRoleHelper
    {
        public static Task<HttpResponseMessage> GiveUserRole(this GuildedRestClient rest, string userId, string roleId)
        => rest.SendRequestAsync(RequestType.Put, $"members/{userId}/roles/{roleId}");

        public static Task<HttpResponseMessage> RemoveUserRole(this GuildedRestClient rest, string userId, string roleId)
        => rest.SendRequestAsync(RequestType.Delete, $"members/{userId}/roles/{roleId}");
    }
}
