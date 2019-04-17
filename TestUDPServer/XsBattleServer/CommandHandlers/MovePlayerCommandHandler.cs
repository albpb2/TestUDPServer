using System;
using XsBattleCommon.Commands;

namespace XsBattleServer.CommandHandlers
{
    public class MovePlayerCommandHandler : CommandHandlerBase, ICommandHandler<MovePlayerCommand>
    {
        private GameManager _gameManager;
        
        public MovePlayerCommandHandler(GameManager gameManager)
        {
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
        }
        
        public void Execute(MovePlayerCommand command)
        {
            _gameManager.MovePlayer(command.PlayerId, command.Direction);
        }
    }
}