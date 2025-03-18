namespace QuinnHughes_Battleship
{
    internal class AttackGrid : ShipGrid
    {
        /// <summary>
        /// Displays a grid of where the player has previously attacked.
        /// </summary>
        /// <param name="player">Name of player</param>
        public override void Display(string player)
        {
            Console.WriteLine(player + "'s Attacks");
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
                    if (grid[i, j] == 'X')
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
        /// Displays hits and misses of a player.
        /// </summary>
        /// <param name="player">Player's Name</param>
        public void DisplayStats(string player)
        {
            int hits = 0;
            int misses = 0;

            foreach (char c in grid)
            {
                if (c == 'X')
                {
                    hits++;
                }
                else if (c == 'M')
                {
                    misses++;
                }
            }
            Console.WriteLine("\n" + player + "'s guesses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(hits + " Hits, ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(misses + " Misses." + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Fires attack based on player inputs
        /// </summary>
        /// <param name="enemyShipGrid">ShipGrid of the opposing player</param>
        public void FireAttack(char[,] enemyShipGrid)
        {
            int xPos = 0;
            int yPos = 0;
            bool isValidGuess = false;
            //looks at enemy ship grid: if its an S put an X on both boards, if its a ~ put a M on both, if a M or X or out of bounds redo

            while (!isValidGuess)
            {
                Console.WriteLine("What X or Horizontal position will you attack?");
                xPos = InputOutput.Int(1, grid.GetLength(0));
                Console.WriteLine("What Y or Vertical position will you attack?");
                yPos = InputOutput.Int(1, grid.GetLength(1));

                xPos--;
                yPos--;
                if ((enemyShipGrid[yPos, xPos] == '~') || (enemyShipGrid[yPos, xPos] == 'S'))
                {
                    isValidGuess = true;
                    break;
                }
            }

            if (enemyShipGrid[yPos, xPos] == 'S')
            {
                enemyShipGrid[yPos, xPos] = 'X';
                grid[yPos, xPos] = 'X';
            }
            else
            {
                enemyShipGrid[yPos, xPos] = 'M';
                grid[yPos, xPos] = 'M';
            }
        }

        //CPU FireAttack declarations
        int lastHitX;
        int lastHitY;
        bool[] directionHasBeenChecked = { true, true, true, true };
        bool hitRecently = false;
        int directionsChecked = 4; //number of directions
        int attemptedGuesses = 0;
        /// <summary>
        /// Fires attacks automatically in a checkerboard pattern, deviating to check nearby tiles to hits, and eventually turning to pure random.
        /// </summary>
        /// <param name="enemyShipGrid">ShipGrid of the opposing player</param>
        /// <param name="rand">Random</param>
        public void FireAttack(char[,] enemyShipGrid, Random rand)
        {
            int xPos = lastHitX;
            int yPos = lastHitY;
            bool isValidGuess = false;

            while (!isValidGuess)
            {
                if (hitRecently)
                {
                    //"Hunt" area surrounding last hit
                    xPos = lastHitX;
                    yPos = lastHitY;

                    if (!directionHasBeenChecked[0])
                    {
                        xPos = Math.Min(grid.GetLength(0) - 1, lastHitX + 1);
                        directionHasBeenChecked[0] = true;
                        directionsChecked++;
                    }
                    else if (!directionHasBeenChecked[1])
                    {
                        xPos = Math.Max(0, lastHitX - 1);
                        directionHasBeenChecked[1] = true;
                        directionsChecked++;
                    }
                    else if (!directionHasBeenChecked[2])
                    {
                        yPos = Math.Min(grid.GetLength(1) - 1, lastHitY + 1);
                        directionHasBeenChecked[2] = true;
                        directionsChecked++;
                    }
                    else if (!directionHasBeenChecked[3])
                    {
                        yPos = Math.Max(0, lastHitY - 1);
                        directionHasBeenChecked[3] = true;
                        directionsChecked++;
                    }
                }
                if (attemptedGuesses > grid.Length / 2) //Checkerboard can check 50 tiles before repeating.
                {
                    hitRecently = false;
                    //Check randomly
                    xPos = rand.Next(0, grid.GetLength(0));
                    yPos = rand.Next(0, grid.GetLength(1));
                }
                else if (directionsChecked >= directionHasBeenChecked.Length)
                {
                    hitRecently = false;
                    attemptedGuesses++;

                    //Randomly checks a checker board pattern, not wasting adjacent guesses
                    xPos = rand.Next(0, grid.GetLength(0));
                    if (xPos % 2 == 0)
                    {
                        yPos = rand.Next(0, grid.GetLength(1) / 2) * 2;
                    }
                    else
                    {
                        yPos = rand.Next(0, grid.GetLength(1) / 2) * 2 + 1;
                    }
                }
                //Check if guess is valid
                if ((enemyShipGrid[yPos, xPos] == '~') || (enemyShipGrid[yPos, xPos] == 'S'))
                {
                    attemptedGuesses = 0;
                    isValidGuess = true;
                    break;
                }
            }

            //Change grids appropriately
            if (enemyShipGrid[yPos, xPos] == 'S')
            {
                //reset "hunt" mode
                if (directionsChecked >= directionHasBeenChecked.Length)
                {
                    lastHitX = xPos;
                    lastHitY = yPos;
                    for (int i = 0; i < directionHasBeenChecked.Length; i++)
                    {
                        directionHasBeenChecked[i] = false;
                    }
                    directionsChecked = 0;
                }
                enemyShipGrid[yPos, xPos] = 'X';
                grid[yPos, xPos] = 'X';
                hitRecently = true;
            }
            else
            {
                enemyShipGrid[yPos, xPos] = 'M';
                grid[yPos, xPos] = 'M';
            }
        }
    }
}

