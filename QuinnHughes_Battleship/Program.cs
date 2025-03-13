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
            ShipGrid p1ShipGrid = new ShipGrid();
            Console.WriteLine("Player 1 place your ships.");
            p1ShipGrid.Display("Player 1");
            for (int i = 0; i < numberOfShips; i++)
            {
                p1ShipGrid.PlaceShip();
                p1ShipGrid.Display("Player 1");
            }
            ShipGrid p2ShipGrid = new ShipGrid();
            Console.WriteLine("Player 2 place your ships.");
            p2ShipGrid.Display("Player 2");
            for (int i = 0; i < numberOfShips; i++)
            {
                p2ShipGrid.PlaceShip();
                p2ShipGrid.Display("Player 2");
            }

            //Actual turns
            AttackGrid p1AttackGrid = new AttackGrid();
            AttackGrid p2AttackGrid = new AttackGrid();

            while(!p1ShipGrid.isLoserCheck() || !p2ShipGrid.isLoserCheck())
            {
                Console.WriteLine("\n"+"Player 1, Fire!");
                p1ShipGrid.Display("Player 1");
                p1AttackGrid.Display("Player 1");
                p1AttackGrid.FireAttack(p2ShipGrid.grid);
                p1ShipGrid.Display("Player 1");
                p1AttackGrid.Display("Player 1");
                p1AttackGrid.DisplayStats("Player 1");

                Console.WriteLine("\n"+"Player 2, Fire!");
                p2ShipGrid.Display("Player 2");
                p2AttackGrid.Display("Player 2");
                p2AttackGrid.FireAttack(p1ShipGrid.grid);
                p2ShipGrid.Display("Player 2");
                p2AttackGrid.Display("Player 2");
                p2AttackGrid.DisplayStats("Player 2");
            }

            //Win-Lose
            if (p1ShipGrid.isLoserCheck())
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else
            { 
                Console.WriteLine("Player 1 Wins!"); 
            }
               
        }
    }
}
    
