using System.Collections.Generic;
using System.Linq;
using XsBattleCommon.Commands;
using XsBattleServer.CommandHandlers;

namespace XsBattleServer.Infrastructure
{
    public class CommandBus
    {
        private IEnumerable<CommandHandlerBase> _commandHandlers;
        
        public CommandBus(IEnumerable<CommandHandlerBase> commandHandlers)
        {
            _commandHandlers = commandHandlers;
        }
        
        public void ExecuteCommand<TCommand>(TCommand command) where TCommand : Command
        {
            if (_commandHandlers.SingleOrDefault(c => c is ICommandHandler<TCommand>) is ICommandHandler<TCommand> commandHandler)
            {
                commandHandler.Execute(command);
            }
        }
    }
}