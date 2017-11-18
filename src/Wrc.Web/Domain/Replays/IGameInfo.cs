using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public interface IGameInfo
    {
        bool IsNetworkMode { get; }
        string Version { get; }
        IGameMode GameMode { get; }
        IGameMap GameMap { get; }
        int MaxPlayers { get; }
        bool AI { get; }
        IGameType GameType { get; }
        bool IsPrivate { get; }
        int InitMoney { get; }
        int ScoreLimit { get; }
        string ServerName { get; }
        IVictoryCondition VictoryCondition { get; }
        string NationConstraint { get; }
        string ThematicConstraint { get; }
        string DateConstraint { get; }
        int IncomeRate { get; }
        bool AllowObservers { get; }
        string Seed { get; }
        IReadOnlyList<PlayerInfo> Players { get; }
    }
}