﻿namespace GuildedSharp.Websocket.Events
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
