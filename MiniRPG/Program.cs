using MiniRPG.Application;

namespace MiniRpgDuel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans Mini RPG Duel !");

            Player player1 = new Player("Joueur 1", 100, 20);
            Player player2 = new Player("Joueur 2", 100, 20);

            Game game = new Game(player1, player2);

            game.Start();
        }
    }
}
