using GuildedSharp.Rest.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public static class RestXpHelper
    {
        public static Task<HttpResponseMessage> GiveUserXpAsync(this GuildedRestClient rest, string userId, int ammount)
        => rest.SendRequestAsync(RequestType.Post, $"members/{userId}/xp", new AwardXpRequest { ammount = ammount });

        public static Task<HttpResponseMessage> GiveRoleXpAsync(this GuildedRestClient rest, string roleId, int ammount)
        => rest.SendRequestAsync(RequestType.Post, $"roles/{roleId}/xp", new AwardXpRequest { ammount = ammount });

    }
}
