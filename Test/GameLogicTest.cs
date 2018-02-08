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
        public void ItShouldBeATieIfBoardIsFilledAndNoThreeInARow()
        {
            // Arrange
            var state = new GameState();

            state.GameTiles = new[,]
            {
                {TileState.X, TileState.O, TileState.O},
                {TileState.O, TileState.Empty, TileState.X},
                {TileState.O, TileState.X, TileState.O}
            }; 
            
            var expectedState = new GameState();

            expectedState.GameTiles = new[,]
            {
                {TileState.X, TileState.O, TileState.O},
                {TileState.O, TileState.X, TileState.X},
                {TileState.O, TileState.X, TileState.O}
            };
            
            var gameLogic = new GameLogic();

            // Act
            var actualState = gameLogic.RunMove(state, new MoveAction(1, 1, TileState.X));
            
            // Assert
            Assert.Equal(Winner.Tie, actualState.Winner);
            Assert.Equal(true, actualState.IsGameOver);
            Assert.Equal(state.GameTiles, actualState.GameTiles);
        }
        
        [Fact]
        public void ItShouldBePossibleToWinAGameWithThreeOFirstColumn()
        {
            // Arrange
            var state = new GameState();

            state.GameTiles = new[,]
            {
                {TileState.Empty, TileState.Empty, TileState.Empty},
                {TileState.O, TileState.Empty, TileState.Empty},
                {TileState.O, TileState.Empty, TileState.Empty}
            }; 
            
            var gameLogic = new GameLogic();

            // Act
            var actualState = gameLogic.RunMove(state, new MoveAction(0, 0, TileState.O));
            
            // Assert
            Assert.Equal(Winner.PlayerO, actualState.Winner);
        }
        
        [Fact]
        public void ItShouldBePossibleToWinAGameWithThreeXMidRow()
        {
            // Arrange
            var state = new GameState();

            state.GameTiles = new[,]
            {
                {TileState.Empty, TileState.Empty, TileState.Empty},
                {TileState.Empty, TileState.X, TileState.X},
                {TileState.Empty, TileState.Empty, TileState.Empty}
            }; 
            
            var gameLogic = new GameLogic();

            // Act
            var actualState = gameLogic.RunMove(state, new MoveAction(0, 1, TileState.X));
            
            // Assert
            Assert.Equal(Winner.PlayerX, actualState.Winner);
        }
    }
}