using domain;

namespace app
{
    public interface IGameLogic
    {
        IGameState RunMove(IGameState state, MoveAction moveAction);
    }
}