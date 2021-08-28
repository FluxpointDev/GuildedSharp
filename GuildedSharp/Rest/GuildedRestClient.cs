using GuildedSharp.Core;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GuildedSharp.Rest
{
    public class GuildedRestClient
    {
        public GuildedRestClient(GuildedClient client)
        {
            Client = client;
            HttpClient = new HttpClient()
            {
                BaseAddress = new System.Uri(HostUrl)
            };
            HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Client.Token);
            HttpClient.DefaultRequestHeaders.Add("User-Agent", Client.Config.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        internal GuildedClient Client;
        internal HttpClient HttpClient;
        internal static string HostUrl = "https://www.guilded.gg/api/v1/";

        public async Task<HttpResponseMessage> SendRequestAsync(RequestType method, string endpoint, GuildedRequest json = null)
        {
            HttpMethod Method = HttpMethod.Get;
            switch (method)
            {
                case RequestType.Post:
                    Method = HttpMethod.Post;
                    break;
                case RequestType.Put:
                    Method = HttpMethod.Put;
                    break;
                case RequestType.Delete:
                    Method = HttpMethod.Delete;
                    break;
            }
            if (json == null)
                return await InternalRequest(Method, endpoint);
            return await InternalJsonRequest(Method, endpoint, json);
        }

        internal async Task<HttpResponseMessage> InternalRequest(HttpMethod method, string endpoint)
        {
            HttpRequestMessage Mes = new HttpRequestMessage(method, endpoint);
            HttpResponseMessage Req = await HttpClient.SendAsync(Mes);
            Req.EnsureSuccessStatusCode();
            return Req;
        }
        internal async Task<HttpResponseMessage> InternalJsonRequest(HttpMethod method, string endpoint, GuildedRequest request)
        {
            HttpRequestMessage Mes = new HttpRequestMessage(method, endpoint);
            Mes.Content = new StringContent(SerializeJson(request), Encoding.UTF8, "application/json");
            HttpResponseMessage Req = await HttpClient.SendAsync(Mes);
            Req.EnsureSuccessStatusCode();
            return Req;
        }
        internal string SerializeJson(object value)
        {
            StringBuilder sb = new StringBuilder(256);
            using (TextWriter text = new StringWriter(sb, CultureInfo.InvariantCulture))
            using (JsonWriter writer = new JsonTextWriter(text))
                Client.Serializer.Serialize(writer, value);
            return sb.ToString();
        }

        // To be added soon 0_o
        internal T DeserializeJson<T>(GuildedRestClient client, Stream jsonStream)
        {
            using (TextReader text = new StreamReader(jsonStream))
            using (JsonReader reader = new JsonTextReader(text))
                return client.Client.Serializer.Deserialize<T>(reader);
        }
    }
    public enum RequestType
    {
        Get, Post, Put, Delete
    }
}
