using GuildedSharp.Core;

namespace GuildedSharp.Commands
{
    /// <summary> The context of a command which may contain the client, user, guild, channel, and message. </summary>
    public class CommandContext
    {
        public GuildedClient Client { get; }
        /// <inheritdoc/>
        public ChatMessage Message { get; }

        public CommandInfo Command { get; set; }

        public string Prefix { get; set; }


        /// <summary>
        ///     Initializes a new <see cref="CommandContext" /> class with the provided client and message.
        /// </summary>
        /// <param name="client">The underlying client.</param>
        /// <param name="msg">The underlying message.</param>
        public CommandContext(GuildedClient client, ChatMessage msg)
        {
            Client = client;
            Message = msg;
        }
    }
}
