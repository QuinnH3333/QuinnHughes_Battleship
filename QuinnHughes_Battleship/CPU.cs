namespace QuinnHughes_Battleship
{
    internal class CPU : Player
    {
       public AttackGrid attackGrid = new AttackGrid();
        public CPU(string name) : base(name) 
        {
        }
        Random rand = new Random();
        public override void Attack(char[,] enemyShipGrid)
        {
            Console.WriteLine(name + " has attacked.");
            attackGrid.FireAttack(enemyShipGrid, rand);
        }
        public override void PlaceShips(int shipCount)
        {
            for (int i = 0; i < shipCount; i++)
            {
                shipGrid.PlaceShip(rand);
            }
        }
    }
}
