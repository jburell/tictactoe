using System;
using domain;

namespace gui
{
    public class Gui
    {
        private const int BoardHeight = 14;
        private const int CellWidth = 6;
        private const int BoarderWidth = 1;
        private const int CellHeight = 3;

        private string[] MarkerX = {
            " X  X ",
            "  XX  ",
            " X  X "
        };
        
        private string[] MarkerO = {
            "  OO  ",
            " O  O ",
            "  OO  "
        };

        public void Render(IGameState gamestate)
        {
            Console.SetWindowSize(30, 20);
            Console.SetCursorPosition(0,0);
            Console.WriteLine("----------------------");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("----------------------");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("----------------------");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("|      |      |      |");
            Console.WriteLine("----------------------");

            var tiles = gamestate.GameTiles;
            for (var y = 0; y < 3; y++){
                for (var x = 0; x < 3; x++)
                {
                    var tile = tiles[x,y];
                    switch (tile)
                    {
                        case TileState.Empty:
                            // NOP
                            break;
                        case TileState.O:
                            RenderMarker(x, y, Player.PlayerO);
                            break;
                        case TileState.X:
                            RenderMarker(x, y, Player.PlayerX);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            
            Console.SetCursorPosition(0,BoardHeight);
        }

        private void RenderMarker(int x, int y, Player player)
        {
            for (var i = 0; i < MarkerO.Length; i++)
            {
                Console.SetCursorPosition(((CellWidth + BoarderWidth) * x) + BoarderWidth,
                    ((CellHeight + BoarderWidth) * y) + BoarderWidth + i);
                Console.Write(player == Player.PlayerO ? MarkerO[i] : MarkerX[i]);
            }
        }
    }
}