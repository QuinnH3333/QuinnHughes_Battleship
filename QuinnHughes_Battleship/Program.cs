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
            //place ships
            ShipGrid p1ShipGrid = new ShipGrid();
            Console.WriteLine("Player 1 place your ships.");
            p1ShipGrid.Display("Player 1");
            for (int i = 0; i < 5; i++)
            {
                p1ShipGrid.PlaceShip();
                p1ShipGrid.Display("Player 1");
            }
            ShipGrid p2ShipGrid = new ShipGrid();
            Console.WriteLine("Player 2 place your ships.");
            p2ShipGrid.Display("Player 2");
            for (int i = 0; i < 5; i++)
            {
                p2ShipGrid.PlaceShip();
                p2ShipGrid.Display("Player 2");
            }
            //Actual turns
            while(!p1ShipGrid.CheckLoss() || !p2ShipGrid.CheckLoss())
            {
                Console.WriteLine("Player 1, Fire!");
                p1ShipGrid.Display("Player 1");
                
            }
            if (p1ShipGrid.CheckLoss())
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
    
