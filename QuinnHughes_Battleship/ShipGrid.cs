namespace QuinnHughes_Battleship
{
    public class ShipGrid
    {
        private char[,] grid;
        private static List<Ship> allShips = new List<Ship>
            {
                new Ship("Carrier", 5),
                new Ship("Battleship", 4),
                new Ship("Cruiser", 3),
                new Ship("Submarine", 3),
                new Ship("Destroyer", 2)
            };
        private List<string> usedShips = new List<string>();
            

        public ShipGrid()
        { //Remember to fix the RED debug
            grid = new char[10, 10]
               {
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','S','X','M','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'}
               };

        }

        public void Display()
        {
            Console.WriteLine("   01 02 03 04 05 06 07 08 09 10");
            for (int i = 0; i < grid.GetLength(0); i++) //the 0 or 1 here refer to the dimension, since its 2D you only have 0 or 1 referring to x and y
            { //for each column
                Console.ForegroundColor = ConsoleColor.Gray;
                if (i == 9)
                {
                    Console.Write((i + 1) + " ");
                }
                else
                {
                    Console.Write("0" + (i + 1) + " ");
                }

                for (int j = 0; j < grid.GetLength(1); j++)
                { //do the whole row

                    // add more colors if you need
                    if (grid[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (grid[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (grid[i, j] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write(grid[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        public void PlaceShip()
        {
            string[] directions = ["up", "down", "left", "right"];
            List<string> notUsedShips = new List<string>();
            
            foreach (var ship in allShips)
            {
                if (!usedShips.Contains(ship.Name))
                {
                    notUsedShips.Add(ship.Name);
                }
            }



            string shipName;
            int xPos;
            int yPos;
            string direction;
            bool isShipPlaced = false;

            while (!isShipPlaced)
            {
                //prompt player
                Console.WriteLine("What ship would you like to place?");
                shipName = InputOutput.String(notUsedShips, true);
                Console.WriteLine("What X or Horizontal position should it start?");
                xPos = InputOutput.Int(1, 10);
                Console.WriteLine("What Y or Vertical position should it start?");
                yPos = InputOutput.Int(1, 10);
                Console.WriteLine("What direction should the rest of the ship follow?");
                direction = InputOutput.String(directions, true);

                //Can it fit?
                PlaceAndVerify(shipName,xPos,yPos,direction);

            }
            


        }
        public bool CheckLoss()
        {
            bool isLoss = true;
            foreach (char c in grid)
            {
                if (c == 'S')
                {
                    isLoss = false;
                }
            }
            return isLoss;
        }
         public void PlaceAndVerify(string ship, int X, int Y, string direction)
        {
            int shipLength=0;
            foreach (Ship s in allShips)
            {
                if (s.Name.ToLower() == ship)
                {
                    shipLength = s.Length;
                }
            }
            // x y always within bounds
            //check shipLength number of times that grid char is ~ in given direction, and replace with green s and reset color after

            bool isValidPlacement = true;
            Console.ForegroundColor = ConsoleColor.Green;
            switch (direction)
            {
                
                case "up":
                {
                        int x = X;
                        int y = Y;
                        for (int i = 0; i < shipLength; i++)
                        {
                            
                            if (!(grid[x-1,y-1] == '~'))
                            {
                                isValidPlacement = false;
                                break;
                            }
                            Y--;
                        }
                        for (int i = 0; i < shipLength; i++)
                        {
                                grid[x - 1, y - 1] = 'S';
                                y--;
                        }
                        break;
                }
                 

            }
            Console.ForegroundColor = ConsoleColor.Gray;





        }
    }
}
