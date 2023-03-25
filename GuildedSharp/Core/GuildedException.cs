using System;

namespace GuildedSharp.Core
{
    internal class GuildedException : Exception
    {
        public GuildedException(string message, int code = 0)
        {
            Message = message;
            Code = code;
        }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
