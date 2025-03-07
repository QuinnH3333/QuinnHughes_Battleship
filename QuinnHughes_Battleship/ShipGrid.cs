namespace QuinnHughes_Battleship
{
    public class ShipGrid
    {
        private char[,] grid;

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
        public void PlaceShip(string shipName, int xPos, int yPos, string direction)
        {
            //InputHandle.intHandle(0,9);
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
    }
}
