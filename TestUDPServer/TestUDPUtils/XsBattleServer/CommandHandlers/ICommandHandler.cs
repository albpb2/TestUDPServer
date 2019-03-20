using XsBattleCommon.Commands;

namespace XsBattleServer.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}