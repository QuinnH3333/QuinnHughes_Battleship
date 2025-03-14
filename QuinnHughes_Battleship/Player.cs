namespace QuinnHughes_Battleship
{
    internal class Player
    {
        public string name;
        public ShipGrid shipGrid;
        private AttackGrid attackGrid;
       
        public Player(string enteredName)
        {
            shipGrid = new ShipGrid();
            attackGrid = new AttackGrid();
            name = enteredName;
        }

        public virtual void PlaceShips(int shipCount)
        {
            Console.WriteLine(name + " place your ships.");
            shipGrid.Display(name);
            for (int i = 0; i < shipCount; i++)
            {
                shipGrid.PlaceShip();
                shipGrid.Display(name);
            }
        }
        public virtual void Attack(char[,] enemyShipGrid)

        {
            Console.WriteLine("\n" + name + ", Fire!");
            shipGrid.Display(name);
            attackGrid.Display(name);
            attackGrid.FireAttack(enemyShipGrid);
            shipGrid.Display(name);
            attackGrid.Display(name);
            attackGrid.DisplayStats(name);

            }
        }
    }

