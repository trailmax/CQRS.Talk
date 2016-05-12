namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    public interface ICommand
    {
    }


    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
