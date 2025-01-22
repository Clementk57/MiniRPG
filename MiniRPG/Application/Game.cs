using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRPG.Application
{
    public class Game
    {
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void Start()
        {
            Player currentPlayer = Player1;
            Player opponent = Player2;

            while (Player1.IsAlive() && Player2.IsAlive())
            {
                Console.WriteLine($"\nC'est au tour de {currentPlayer.Name}.");
                Console.WriteLine("Choisissez une action : 1. Attaquer  2. Défendre  3. Soigner");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        currentPlayer.Attack(opponent);
                        break;
                    case "2":
                        currentPlayer.Defend();
                        break;
                    case "3":
                        currentPlayer.Heal(10);
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Vous perdez votre tour !");
                        break;
                }

                if (!opponent.IsAlive())
                {
                    Console.WriteLine(
                        $"\n{opponent.Name} est mort. {currentPlayer.Name} a gagné !"
                    );
                    break;
                }

                var temp = currentPlayer;
                currentPlayer = opponent;
                opponent = temp;
            }
        }
    }
}
