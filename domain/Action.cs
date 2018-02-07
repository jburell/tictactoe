using System;

namespace domain
{
    public class Action
    {
        
    }
    
    public class MoveAction: Action
    {
        public (int x, int y) Coordinate { get; }
        public TileState TileState { get; }
        public MoveAction(int x, int y, TileState state)
        {
            Coordinate = (x, y);
            TileState = state;
        }
    }

    public class QuitAction: Action
    {
        
    }
}