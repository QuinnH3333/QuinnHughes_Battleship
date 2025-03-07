namespace QuinnHughes_Battleship
{
    internal class EnemyGrid : ShipGrid
    { //figure out inheritence??????


       public void DisplayGrid()
        {
            //pretty board
        }
       public void DisplayStats()
        {
            // count hits/misses on board, output them
        }
       public void FireAttack(char[,] enemyShipGrid) 
        { 
            //looks at enemy ship grid: if its an S put an X on both boards, if its a ~ put a M on both, if a M or X or out of bounds redo
        }
    }
}
