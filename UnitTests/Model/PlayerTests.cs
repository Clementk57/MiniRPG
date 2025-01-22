namespace UnitTests.Model
{
    public class PlayerTests
    {
        private Player CreatePlayer(string name, int health, int attackPower)
        {
            return new Player(name, health, attackPower);
        }

        [Theory]
        [InlineData("Hero", 100, 20)]
        [InlineData("Warrior", 120, 25)]
        public void Player_ShouldInitializeCorrectly(string name, int health, int attackPower)
        {
            // Act
            Player player = CreatePlayer(name, health, attackPower);

            // Assert
            Assert.Equal(name, player.Name);
            Assert.Equal(health, player.Health);
            Assert.Equal(attackPower, player.AttackPower);
            Assert.False(player.IsDefending);
        }

        [Theory]
        [InlineData(100, 20, 100, 80)]
        [InlineData(80, 30, 100, 70)]
        public void Attack_ShouldReduceOpponentHealth(
            int attackerHealth,
            int attackerPower,
            int opponentHealth,
            int expectedOpponentHealth
        )
        {
            // Arrange
            Player attacker = CreatePlayer("Attacker", attackerHealth, attackerPower);
            Player opponent = CreatePlayer("Opponent", opponentHealth, 15);

            // Act
            attacker.Attack(opponent);

            // Assert
            Assert.Equal(expectedOpponentHealth, opponent.Health);
        }

        [Fact]
        public void Defend_ShouldReduceDamageTaken()
        {
            // Arrange
            Player attacker = CreatePlayer("Attacker", 100, 20);
            Player defender = CreatePlayer("Defender", 100, 15);

            // Act
            defender.Defend();
            attacker.Attack(defender);

            // Assert
            Assert.Equal(90, defender.Health);
        }

        [Theory]
        [InlineData(80, 10, 90)]
        [InlineData(50, 20, 70)]
        public void Heal_ShouldIncreaseHealth(int initialHealth, int healAmount, int expectedHealth)
        {
            // Arrange
            Player player = CreatePlayer("Healer", initialHealth, 15);

            // Act
            player.Heal(healAmount);

            // Assert
            Assert.Equal(expectedHealth, player.Health);
        }

        [Theory]
        [InlineData(100, 25, 75)]
        [InlineData(50, 30, 20)]
        public void TakeDamage_ShouldReduceHealth(int initialHealth, int damage, int expectedHealth)
        {
            // Arrange
            Player player = CreatePlayer("Target", initialHealth, 20);

            // Act
            player.TakeDamage(damage);

            // Assert
            Assert.Equal(expectedHealth, player.Health);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(0, false)]
        [InlineData(-5, false)]
        public void IsAlive_ShouldReturnCorrectValue(int health, bool expectedIsAlive)
        {
            // Arrange
            Player player = CreatePlayer("Survivor", health, 20);

            // Act
            bool result = player.IsAlive();

            // Assert
            Assert.Equal(expectedIsAlive, result);
        }
    }
}
