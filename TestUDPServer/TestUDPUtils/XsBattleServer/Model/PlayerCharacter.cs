namespace XsBattleServer.Model
{
    public class PlayerCharacter
    {
        public int PlayerId { get; set; }

        public Cell Position { get; set; }
        
        public Cell ArrowPosition { get; set; }

        public bool IsOccupyingCell(Cell cell)
        {
            return Position == cell || ArrowPosition == cell;
        }

        public void MoveToCell(Cell cell, Cell arrow)
        {
            Position = cell;
            ArrowPosition = arrow;
        }
    }
}