using System.Linq.Expressions;

namespace QuinnHughes_Battleship
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Title();
            string selectedMode = ModeSelect();
            while (true)
            {
                switch (selectedMode)
                {
                    case "1p":
                        {
                            SinglePlayer();
                            break;
                        }
                    case "vs":
                        {
                            VersesMode();
                            break;
                        };
                    case "simulate":
                        {
                            Simulate();
                            break;
                        }
                }
                PlayAgain();
            }
        }

        /// <summary>
        /// Player VS Player battleship
        /// </summary>
        static void VersesMode()
        {
            int numberOfShips = ShipGrid.allShips.Count;

            Console.WriteLine("Player 1 enter your name:");
            Player player1 = new Player(InputOutput.String());
            Console.WriteLine("Player 2 enter your name:");
            Player player2 = new Player(InputOutput.String());

            player1.PlaceShips(numberOfShips);
            player2.PlaceShips(numberOfShips);

            while (!player1.shipGrid.isLoserCheck() || !player2.shipGrid.isLoserCheck())
            {
                player1.Attack(player2.shipGrid.grid);
                player2.Attack(player1.shipGrid.grid);
            }

            if (player1.shipGrid.isLoserCheck())
            {
                Console.WriteLine(player2.name + " Wins!");
            }
            else
            {
                Console.WriteLine(player1.name + " Wins!");
            }
        }

        /// <summary>
        /// Player plays battleship against a CPU
        /// </summary>
        static void SinglePlayer()
        {
            int numberOfShips = ShipGrid.allShips.Count;

            Console.WriteLine("Enter your name:");
            Player player1 = new Player(InputOutput.String());
            CPU computer = new CPU("SHODAN");

            player1.PlaceShips(numberOfShips);
            computer.PlaceShips(numberOfShips);


            while (!player1.shipGrid.isLoserCheck() || !computer.shipGrid.isLoserCheck())
            {
                player1.Attack(computer.shipGrid.grid);
                computer.Attack(player1.shipGrid.grid);
            }

            if (player1.shipGrid.isLoserCheck())
            {
                Console.WriteLine("You Lose!");
            }
            else
            {
                Console.WriteLine(player1.name + " Wins!");
            }
        }

        /// <summary>
        /// Plays a simulated game of battleship between two of the CPUs
        /// </summary>
        static void Simulate()
        {
            int numberOfShips = ShipGrid.allShips.Count;

            CPU player1 = new CPU("Techna");
            CPU computer = new CPU("SHODAN");

            player1.PlaceShips(numberOfShips);
            computer.PlaceShips(numberOfShips);

            while (!player1.shipGrid.isLoserCheck() && !computer.shipGrid.isLoserCheck())
            {

                player1.Attack(computer.shipGrid.grid);
                player1.shipGrid.Display(player1.name);
                computer.Attack(player1.shipGrid.grid);
                computer.shipGrid.Display(computer.name);
                player1.attackGrid.DisplayStats(player1.name);
            }

            if (player1.shipGrid.isLoserCheck())
            {
                Console.WriteLine("You Lose!");
            }
            else
            {
                Console.WriteLine(player1.name + " Wins!");
            }
        }

        /// <summary>
        /// Title screen which prompts player for an input to start
        /// </summary>
        static void Title()
        {
            Console.WriteLine("Hey look! a title screen for battleship..");
            Console.WriteLine("--Press Space to play--");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }
        }

        /// <summary>
        /// Prompts the player if they want to play again
        /// </summary>
        static void PlayAgain()
        {
            Console.WriteLine("--Press Space to play again--");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }
        }

        /// <summary>
        /// Prompt player to select a mode
        /// </summary>
        /// <returns>Name of selected mode</returns>
        static string ModeSelect()
        {
            List<string> modes = new List<string>
            {
                "1P",
                "VS",
                "Simulate"
            };
            Console.WriteLine("--Select a Mode--");
            return InputOutput.String(modes, true);
        }
    }
}


