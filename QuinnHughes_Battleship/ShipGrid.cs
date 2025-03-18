namespace QuinnHughes_Battleship
{
    public class ShipGrid
    {
        public char[,] grid;
        public static List<Ship> allShips = new List<Ship>
            {
                new Ship("Carrier", 5),
                new Ship("Battleship", 4),
                new Ship("Cruiser", 3),
                new Ship("Submarine", 3),
                new Ship("Destroyer", 2)
            };

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
        /// Displays the ship grid 
        /// </summary>
        /// <param name="player">Name of the player</param>
        public virtual void Display(string player)
        {
            Console.WriteLine(player + "'s Ships");
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
        /// Prompts then places ships on a ship board using the players responses.
        /// </summary>
        public List<string> notUsedShips = new List<string>();
        public List<string> usedShips = new List<string>();
        public virtual void PlaceShip()
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
                xPos = InputOutput.Int(1, grid.GetLength(0));
                Console.WriteLine("What Y or Vertical position should it start?");
                yPos = InputOutput.Int(1, grid.GetLength(1));
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
        /// Automated ship placement
        /// </summary>
        /// <param name="number"></param>
        public void PlaceShip(Random rand)
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
                shipName = notUsedShips[rand.Next(notUsedShips.Count)];
                xPos = rand.Next(1, grid.GetLength(0));
                yPos = rand.Next(1, grid.GetLength(1));
                direction = directions[rand.Next(directions.Length)];


                isShipPlaced = PlaceAndVerify(shipName, xPos, yPos, direction);
                if (isShipPlaced)
                {
                    usedShips.Add(shipName);
                }
            }
        }

        /// <summary>
        /// Checks if there are any ships left on the board.
        /// </summary>
        /// <returns>Returns if player has lost</returns>
        public bool isLoserCheck()
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

        /// <summary>
        /// Verifies if a ship can be placed, then alters the grid with the ship's position.
        /// </summary>
        /// <param name="ship">Ship being placed</param>
        /// <param name="X">Starting X position</param>
        /// <param name="Y">Starting Y position</param>
        /// <param name="direction">Direction the ship flows</param>
        /// <returns></returns>
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
                        if (iterateY < shipLength)
                        {
                            isValidPlacement = false;
                            break;
                        }

                        for (int i = 0; i < shipLength; i++)
                        {
                            //check if bound is valid first, then check for overwrite

                            if (!(grid[iterateY - 1, iterateX - 1] == '~')) //out of bounds check fails?
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

                        if ((grid.GetLength(1) - iterateY) < shipLength)
                        {
                            isValidPlacement = false;
                            break;
                        }

                        for (int i = 0; i < shipLength; i++)
                        {
                            if (!(grid[iterateY - 1, iterateX - 1] == '~'))
                            {
                                isValidPlacement = false;
                                break;
                            }
                            iterateY++;
                        }


                        if (isValidPlacement)
                        {
                            iterateY = Y;
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

                        if (iterateX < shipLength)
                        {
                            isValidPlacement = false;
                            break;
                        }

                        for (int i = 0; i < shipLength; i++)
                        {
                            if (!(grid[iterateY - 1, iterateX - 1] == '~'))
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

                        if ((grid.GetLength(1) - iterateX) < shipLength)
                        {
                            isValidPlacement = false;
                            break;
                        }

                        for (int i = 0; i < shipLength; i++)
                        {
                            if (!(grid[iterateY - 1, iterateX - 1] == '~'))
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
