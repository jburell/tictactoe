using System;
using System.Data;
using domain;

namespace app
{
    public class GameLogic : IGameLogic
    {
        public IGameState RunMove(IGameState state, MoveAction moveAction)
        {
            switch (moveAction.TileState)
            {
                case TileState.O:
                    state.Winner = Winner.PlayerO;
                    break;
                case TileState.X:
                    state.Winner = Winner.PlayerX;
                    break;
            }

            return state;
        }

        private IGameState placeMarker(IGameState state, MoveAction moveAction)
        {
            
        }
    }
}