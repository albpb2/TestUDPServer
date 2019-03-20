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

        public static bool operator ==(Cell cell1, Cell cell2)
        {
            return 
                cell1 != null
                && cell2 != null
                && cell1.X == cell2.X 
                && cell1.Y == cell2.Y;
        }

        public static bool operator !=(Cell cell1, Cell cell2)
        {
            return 
                cell1 == null
                || cell2 == null
                || cell1.X != cell2.X 
                || cell1.Y != cell2.Y;
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this == (Cell) obj;
        }
    }
}