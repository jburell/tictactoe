using System;
using System.Runtime.CompilerServices;

namespace domain
{
    public interface IGameState
    {
        Player PlayerTurn { get; set; }
        bool IsGameOver { get; set; }
        TileState[,] GameTiles { get; set; }
        Winner Winner { get; }
    }

    public enum Winner
    {
        Tie,
        PlayerO,
        PlayerX
    }
}