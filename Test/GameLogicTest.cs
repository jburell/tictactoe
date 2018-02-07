using System;
using app;
using domain;
using Moq;
using Xunit;

namespace Test
{
    public class GameLogicTest
    {
        [Fact]
        public void ItShouldBePossibleToWinAGameWithThreeXMidRow()
        {
            // Arrange
            var state = new Mock<IGameState>();
            state.Setup(s => s.GameTiles).Returns(new[,]
            {
                {TileState.Empty, TileState.Empty, TileState.Empty},
                {TileState.Empty, TileState.X, TileState.X},
                {TileState.Empty, TileState.Empty, TileState.Empty}
            });
            var gameLogic = new GameLogic();

            // Act
            var actualState = gameLogic.RunMove(state.Object, new MoveAction(0, 1, TileState.X));
            
            // Assert
            Assert.Equal(Winner.PlayerX, actualState.Winner);
        }
    }
}