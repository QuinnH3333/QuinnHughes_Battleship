namespace QuinnHughes_Battleship
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Simulate();

        }
        static void VersesMode()
        {
            int numberOfShips = ShipGrid.allShips.Count;

            Console.WriteLine("Player 1 enter your name:");
            Player player1 = new Player( InputOutput.String());
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
        static void SinglePlayer()
        {
            int numberOfShips = 2; //ShipGrid.allShips.Count;

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
        static void Simulate()
        {
            int numberOfShips = 5; //ShipGrid.allShips.Count;

            Console.WriteLine("Enter your name:");
            CPU player1 = new CPU("Alexa");
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

        static void Title()
        {

        }
        static void PlayAgain()
        {

        }
        static void ModeSelect()
        {

        }
    }
}
    
