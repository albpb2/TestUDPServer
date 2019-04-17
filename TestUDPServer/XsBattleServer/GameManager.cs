using System;
using XsBattleCommon;
using XsBattleServer.Model;

namespace XsBattleServer
{
    public class GameManager
    {
        private Object _locker;
        private Board _board;

        public GameManager(Board board)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _locker = new Object();
        }

        public void MovePlayer(int playerId, Direction direction)
        {
            var playerCharacter = _board.GetPlayerCharacter(playerId);
            MovePlayer(playerCharacter, direction);
        }

        public void MovePlayer(PlayerCharacter playerCharacter, Direction direction)
        {
            var targetCell = _board.GetCellFromCurrent(playerCharacter.Position, direction);
            var targetArrow = _board.GetCellFromCurrent(targetCell, direction);
            lock (_locker)
            {
                if (_board.IsCellFree(targetCell) && _board.IsCellFree(targetArrow))
                {
                    playerCharacter.MoveToCell(targetCell, targetArrow);
                }
            }
        }
    }
}