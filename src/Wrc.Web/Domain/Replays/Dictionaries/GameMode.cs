﻿namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class GameMode : IGameMode
    {
        public GameMode(string publicCode, string name)
        {
            PublicCode = publicCode;
            Name = name;
        }

        public string PublicCode { get; }

        public string Name { get; }
    }
}