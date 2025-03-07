using System.Collections.Generic;

namespace QuinnHughes_Battleship
{
    internal class InputOutput
    {
        /// <summary>
        /// Outputs int after parsing player input and checking its within an inclusive range
        /// </summary>
        /// <param name="rangeMin">Minimum number allowed</param>
        /// <param name="rangeMax">Maximum number allowed</param>
        /// <returns>Int within range</returns>
        public static int Int(int rangeMin, int rangeMax)
        {
            int parsedInt = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                if (int.TryParse(Console.ReadLine(), out int playerInput)) //If parse success, move onto range check
                {
                    if ((playerInput >= rangeMin) && (playerInput <= rangeMax))
                    {
                        parsedInt = playerInput;
                        isValidInput = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Number out of bounds. Pick between " + rangeMin + "-" + rangeMax);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return parsedInt;
        }

        /// <summary>
        /// Outputs int after parsing player input and checking it matches something within a given list
        /// </summary>
        /// <param name="list">List of possible ints</param>
        /// <param name="outputOptions">Toggles the console display of the list</param>
        /// <returns>Int within list</returns>
        public static int Int(List<int> list, bool outputOptions)
        {
            if (outputOptions)
            {
                Console.WriteLine("Options: ");
                foreach (int num in list)
                {
                    Console.WriteLine(num);
                }
            }

            int parsedInt = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                if (int.TryParse(Console.ReadLine(), out int playerInput)) //If parse success, move onto range check
                {
                    if (list.Contains(playerInput))
                    {
                        parsedInt = playerInput;
                        isValidInput = true;
                        break;
                    }
                }
                Console.WriteLine("Invalid input. Try again.");
            }
            return parsedInt;
        }

        /// <summary>
        /// Outputs string after checking it matches something within a given list
        /// </summary>
        /// <param name="list">List of possible strings</param>
        /// <param name="outputOptions">Toggles the console display of the list</param>
        /// <returns>String within list</returns>
        public static string String(List<string> list, bool outputOptions)
        {
            if (outputOptions)
            {
                Console.WriteLine("Options: ");
                foreach (string str in list)
                {
                    Console.WriteLine(str);
                }
            }

            List<string> lowerList = new List<string>();
            foreach (string str in list)
            {
                lowerList.Add(str.ToLower());
            }
            
            string inputString = "";
            bool isValidInput = false;
            while (!isValidInput)
            {
                inputString = Console.ReadLine();
                inputString = inputString.ToLower();

                if (!string.IsNullOrEmpty(inputString) && lowerList.Contains(inputString))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return inputString;
        }
     

        /// <summary>
        /// Outputs string after checking it matches something within a given array
        /// </summary>
        /// <param name="array">List of possible strings</param>
        /// <param name="outputOptions">Toggles the console display of the array</param>
        /// <returns>String within list</returns>
        public static string String(string[] array, bool outputOptions)
        {
            if (outputOptions)
            {
                Console.WriteLine("Options: ");
                foreach (string str in array)
                {
                    Console.WriteLine(str);
                }
            }

            List<string> lowerArray = new List<string>();
            foreach (string str in array)
            {
                lowerArray.Add(str.ToLower());
            }

            string inputString = "";
            bool isValidInput = false;
            while (!isValidInput)
            {
                inputString = Console.ReadLine();
                inputString = inputString.ToLower();

                if (!string.IsNullOrEmpty(inputString) && lowerArray.Contains(inputString))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return inputString;
        }

    }
}
