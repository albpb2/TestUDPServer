namespace XsBattleServer.Model
{
    public class Cell
    {
        public Cell(int y, int x)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}