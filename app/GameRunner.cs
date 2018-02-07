using System;
using domain;
using gui;

namespace app
{
    public class GameRunner
    {
        private IGameLogic _gameLogic;
        private IGameState _gameState;
        private Gui _gui;
        private UserInput _input;

        public Winner Winner => _gameState.Winner;

        public GameRunner(IGameState state, IGameLogic gameLogic, Gui gui, UserInput input)
        {
            _gameState = state;
            _gameLogic = gameLogic;
            _gui = gui;
            _input = input;
        }

        public void GameLoop()
        {
            while (!_gameState.IsGameOver)
            {
                _gui.Render(_gameState);
                switch (_input.GetNextMove(_gameState))
                {
                    case QuitAction _:
                        _gameState.IsGameOver = true;
                        break;
                    case MoveAction m:
                    {
                        var newState = UseMoveOnBoard(_gameState, m);
                        _gameState = _gameLogic.RunMove(newState, m);
                    }
                        break;
                }
            }
        }

        private IGameState UseMoveOnBoard(IGameState gameState, MoveAction action)
        {
            var currTiles = gameState.GameTiles;
            currTiles[action.Coordinate.x, action.Coordinate.y] = action.TileState;
            gameState.GameTiles = currTiles;
            return gameState;
        }

        public static void Main(string[] args)
        {
            var game = new GameRunner(new GameState(), new GameLogic(), new Gui(), new UserInput());

            game.GameLoop();

            Console.WriteLine("The winner is: " + game.Winner);
            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }
    }

    public class QuitApplicationException : Exception
    {
    }
}