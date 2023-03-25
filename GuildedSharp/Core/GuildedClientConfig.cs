namespace GuildedSharp.Core
{
    public class GuildedClientConfig
    {
        public string UserAgent { get; set; } = "GuildedBot v1.2.0 (GuildedSharp)";
        public bool DebugEvents { get; set; }

        public string[] OwnerIds { get; set; }
    }
}
