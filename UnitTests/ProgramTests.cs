namespace MiniRpgDuel.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Program_ShouldInitializePlayersCorrectly()
        {
            // Arrange
            Player player1 = new Player("Joueur 1", 100, 20);
            Player player2 = new Player("Joueur 2", 100, 20);

            // Act & Assert
            Assert.Equal("Joueur 1", player1.Name);
            Assert.Equal(100, player1.Health);
            Assert.Equal(20, player1.AttackPower);

            Assert.Equal("Joueur 2", player2.Name);
            Assert.Equal(100, player2.Health);
            Assert.Equal(20, player2.AttackPower);
        }
    }
}
