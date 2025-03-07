namespace QuinnHughes_Battleship
{
    internal class Ship
    {
        public string Name { get; set; } //get; set; means you have read and write functionality with this field
        public int Length { get; set; }

        public Ship(string name , int length)
        {
            Name = name;
            Length = length;
        }


    }
}
