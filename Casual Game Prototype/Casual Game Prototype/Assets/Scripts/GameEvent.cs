using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameEvent
{
    public const string GAME_STARTED = "GAME_STARTED";
    public const string GAME_PAUSED = "GAME_PAUSED";
    public const string GAME_UNPAUSED = "GAME_UNPAUSED";
    public const string GAME_OVER = "GAME_OVER";
    public const string GAME_RETRY = "GAME_RETRY";
    public const string CHANGE_SPEED = "CHANGE_SPEED";
}
