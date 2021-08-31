using GuildedSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedSharp.Websocket.Events
{
    internal class BaseTeamXpEvent
    {
        public TeamXpEvent d;
    }
    internal class TeamXpEvent
    {
        public string[] userIds;
        public int amount;
    }
}
