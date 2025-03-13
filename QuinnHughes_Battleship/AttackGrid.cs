namespace QuinnHughes_Battleship
{
    internal class AttackGrid : ShipGrid
    { //figure out inheritence??????
        private char[,] grid;
        public AttackGrid()
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
            Console.WriteLine("\n"+ player + "'s guesses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(hits + " Hits, ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(misses + " Misses." + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

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

                if ((enemyShipGrid[yPos,xPos] == '~') || (enemyShipGrid[yPos, xPos] == 'S'))
                {
                    isValidGuess = true;
                    break;
                }
            }

            xPos--;
            yPos--;

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
    }
}
