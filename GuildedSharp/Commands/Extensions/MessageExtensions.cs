using GuildedSharp.Core;
using System;

namespace GuildedSharp.Commands
{
    /// <summary>
    ///     Provides extension methods for <see cref="IUserMessage" /> that relates to commands.
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        ///     Gets whether the message starts with the provided character.
        /// </summary>
        /// <param name="msg">The message to check against.</param>
        /// <param name="c">The char prefix.</param>
        /// <param name="argPos">References where the command starts.</param>
        /// <returns>
        ///     <c>true</c> if the message begins with the char <paramref name="c"/>; otherwise <c>false</c>.
        /// </returns>
        public static bool HasCharPrefix(this ChatMessage msg, char c, ref int argPos)
        {
            string text = msg.content;
            if (!string.IsNullOrEmpty(text) && text[0] == c)
            {
                argPos = 1;
                return true;
            }
            return false;
        }
        /// <summary>
        ///     Gets whether the message starts with the provided string.
        /// </summary>
        public static bool HasStringPrefix(this ChatMessage msg, string str, ref int argPos, StringComparison comparisonType = StringComparison.Ordinal)
        {
            string text = msg.content;
            if (!string.IsNullOrEmpty(text) && text.StartsWith(str, comparisonType))
            {
                argPos = str.Length;
                return true;
            }
            return false;
        }
    }
}
