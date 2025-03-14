namespace QuinnHughes_Battleship
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //PrintTitle(); exit on button press
            //Single(); or Verses();
            //Replay?(); 

            VersesMode();

        }
        static void VersesMode()
        {
            int numberOfShips = 1;

            //place ships
            Player player1 = new Player("Hombre");
            Player player2 = new Player("Steeeeeve");

            player1.PlaceShips(numberOfShips);
            player2.PlaceShips(numberOfShips);

            //Actual turns
            while (!player1.shipGrid.isLoserCheck() || !player2.shipGrid.isLoserCheck())
            {
                player1.Attack(player2.shipGrid.grid);
                player2.Attack(player1.shipGrid.grid);
            }

                //Win-Lose
            if (player1.shipGrid.isLoserCheck())
            {
                Console.WriteLine(player2.name + " Wins!");
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
    }
}
    
