namespace CQRS.Talk.Refactoring2.Commands._3.Interfaces
{
    public interface ICommand
    {
    }


    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
