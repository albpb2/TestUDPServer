namespace XsBattleCommon.Commands
{
    public class MovePlayerCommand : Command
    {
        public int PlayerId { get; set; }

        public Direction Direction { get; set; }
    }
}