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

        private List<string> notUsedShips = new List<string>();
        private List<string> usedShips = new List<string>();


        public ShipGrid()
        {
            grid = new char[10, 10]
               {
                    {'~','~','~','~','~','~','~','~','~','~'},
                    {'~','~','~','~','~','~','~','~','~','~'},
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void Display(string player)
        {
            Console.WriteLine(player +"'s Ships");
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
        /// <summary>
        /// 
        /// </summary>
        public void PlaceShip()
        {
            string[] directions = ["up", "down", "left", "right"];
            foreach (Ship ship in allShips)
            {
                if ((!usedShips.Contains(ship.Name.ToLower())) && (!notUsedShips.Contains(ship.Name.ToLower())))
                {
                    notUsedShips.Add(ship.Name.ToLower());
                }
                else if (usedShips.Contains(ship.Name.ToLower()))
                {
                    notUsedShips.Remove(ship.Name.ToLower());
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
                isShipPlaced = PlaceAndVerify(shipName, xPos, yPos, direction);
                //This only places when its correct
                if (isShipPlaced)
                {
                    usedShips.Add(shipName);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cant put that there, cheater.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }


            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        public bool PlaceAndVerify(string ship, int X, int Y, string direction)
        {
            int shipLength = 0;
            foreach (Ship s in allShips)
            {
                if (s.Name.ToLower() == ship)
                {
                    shipLength = s.Length;
                }
            }

            bool isValidPlacement = true;
            Console.ForegroundColor = ConsoleColor.Green;
            int iterateX;
            int iterateY;
            switch (direction)
            {

                case "up":
                    iterateX = X;
                    iterateY = Y;
                    {
                        for (int i = 0; i < shipLength; i++)
                        {

                            if ((iterateY < 0) || (!(grid[iterateY - 1, iterateX - 1] == '~'))) //out of bounds check fails?

                            {
                                isValidPlacement = false;
                                break;
                            }
                            iterateY--;
                        }
                        if (isValidPlacement)
                        {
                            iterateY = Y;
                            for (int i = 0; i < shipLength; i++)
                            {
                                grid[iterateY - 1, iterateX - 1] = 'S';
                                iterateY--;
                            }
                        }

                        break;
                    }
                case "down":
                    {
                        iterateX = X;
                        iterateY = Y;
                        for (int i = 0; i < shipLength; i++)
                        {

                            if ((iterateY > 9) || (!(grid[iterateY - 1, iterateX - 1] == '~')))
                            {
                                isValidPlacement = false;
                                break;
                            }
                            iterateY++;
                        }
                        iterateY = Y;
                        if (isValidPlacement)
                        {
                            for (int i = 0; i < shipLength; i++)
                            {
                                grid[iterateY - 1, iterateX - 1] = 'S';
                                iterateY++;
                            }
                        }

                        break;
                    }
                case "left":
                    {
                        iterateX = X;
                        iterateY = Y;
                        for (int i = 0; i < shipLength; i++)
                        {

                            if ((iterateX < 0) || (!(grid[iterateY - 1, iterateX - 1] == '~')))
                            {
                                isValidPlacement = false;
                                break;
                            }
                            iterateX--;
                        }
                        if (isValidPlacement)
                        {
                            iterateX = X;
                            for (int i = 0; i < shipLength; i++)
                            {
                                grid[iterateY - 1, iterateX - 1] = 'S';
                                iterateX--;
                            }
                        }

                        break;
                    }
                case "right":
                    {
                        iterateX = X;
                        iterateY = Y;
                        for (int i = 0; i < shipLength; i++)
                        {

                            if ((iterateX > 9) || !(grid[iterateY - 1, iterateX - 1] == '~'))
                            {
                                isValidPlacement = false;
                                break;
                            }
                            iterateX++;
                        }

                        if (isValidPlacement)
                        {
                            iterateX = X;
                            for (int i = 0; i < shipLength; i++)
                            {
                                grid[iterateY - 1, iterateX - 1] = 'S';
                                iterateX++;
                            }
                        }

                        break;
                    }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            return isValidPlacement;


        }
    }
}
