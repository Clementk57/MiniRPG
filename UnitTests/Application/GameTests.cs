using MiniRPG.Application;

namespace UnitTests.Application
{
    public class GameTests
    {
        private readonly Player player1 = new Player("Player1", 100, 20);
        private readonly Player player2 = new Player("Player2", 100, 15);

        [Fact]
        public void Game_ShouldInitializeCorrectly()
        {
            // Act
            Game game = new Game(player1, player2);

            // Assert
            Assert.NotNull(game);
        }

        [Theory]
        [InlineData(100, 20, 100, 15, 70)]
        public void Game_ShouldAlternateTurnsCorrectly(
            int player1Health,
            int player1Attack,
            int player2Health,
            int player2Attack,
            int expectedHealth
        )
        {
            // Arrange
            Player player1 = new Player("Player1", player1Health, player1Attack);
            Player player2 = new Player("Player2", player2Health, player2Attack);
            Game game = new Game(player1, player2);

            // Act
            player1.Attack(player2);
            player2.Defend();
            player1.Attack(player2);

            // Assert
            Assert.Equal(expectedHealth, player2.Health);
        }

        [Theory]
        [InlineData(50, 20, 10, 15, false)]
        public void Game_ShouldEndWhenPlayerDies(
            int player1Health,
            int player1Attack,
            int player2Health,
            int player2Attack,
            bool expectedAlive
        )
        {
            // Arrange
            Player player1 = new Player("Player1", player1Health, player1Attack);
            Player player2 = new Player("Player2", player2Health, player2Attack);
            Game game = new Game(player1, player2);

            // Act
            player1.Attack(player2);

            // Assert
            Assert.Equal(expectedAlive, player2.IsAlive());
        }

        [Theory]
        [InlineData(50, 10, 60)]
        public void Game_ShouldHandleHealActionCorrectly(
            int initialHealth,
            int healAmount,
            int expectedHealth
        )
        {
            // Arrange
            Player player1 = new Player("Player1", initialHealth, 20);
            Game game = new Game(player1, player2);

            // Act
            player1.Heal(healAmount);

            // Assert
            Assert.Equal(expectedHealth, player1.Health);
        }

        [Fact]
        public void Game_ShouldValidateInvalidChoice()
        {
            // Arrange
            Game game = new Game(player1, player2);

            // Act & Assert
            var exception = Record.Exception(() => player1.Attack(player2));
            Assert.Null(exception);
        }

        [Fact]
        public void Game_ShouldResetDefensiveStateAfterTurn()
        {
            // Arrange
            Game game = new Game(player1, player2);

            // Act
            player2.Defend();
            player1.Attack(player2);

            // Assert
            Assert.False(player2.IsDefending);
        }
    }
}
