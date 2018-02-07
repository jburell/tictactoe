using System;
using domain;
using Action = domain.Action;

namespace gui
{
    public class UserInput
    {
        public Action GetNextMove(IGameState state)
        {
            var key = Console.ReadKey(true).Key;
            var currentPlayer = state.PlayerTurn;
            switch (key)
            {
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return new MoveAction(0, 0, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return new MoveAction(1, 0, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return new MoveAction(2, 0, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return new MoveAction(0, 1, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return new MoveAction(1, 1, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return new MoveAction(2, 1, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return new MoveAction(0, 2, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return new MoveAction(1, 2, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return new MoveAction(2, 2, ConvertPlayerToTileState(currentPlayer));
                case ConsoleKey.Q:
                case ConsoleKey.Escape:
                    return new QuitAction();
            }

            throw new NotImplementedException();
        }

        private static TileState ConvertPlayerToTileState(Player currentPlayer)
        {
            return currentPlayer == Player.PlayerO ? TileState.O : TileState.X;
        }
    }
}