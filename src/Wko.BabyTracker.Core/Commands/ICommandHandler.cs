namespace Wko.BabyTracker.Core.Commands;

public interface ICommandHandler<in TCommand> where TCommand: ICommand
{
    Task HandleAsync(TCommand command);
}
