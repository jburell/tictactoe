using domain;

namespace app
{
    public class GameState : IGameState
    {
        public GameState()
        {
            Winner = Winner.Tie;
            IsGameOver = false;
            GameTiles = new[,]
            {
                {TileState.Empty, TileState.Empty, TileState.Empty},
                {TileState.Empty, TileState.Empty, TileState.Empty},
                {TileState.Empty, TileState.Empty, TileState.Empty}
            };
        }

        public Player PlayerTurn { get; set; }
        public bool IsGameOver { get; set; }

        public TileState[,] GameTiles { get; set; }

        public Winner Winner { get; }
    }
}