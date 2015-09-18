using System.Diagnostics;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using CQRS.Talk.Sample4.Decorator;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class TimedCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public TimedCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }


        public void Handle(TCommand command)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            decorated.Handle(command);

            stopwatch.Stop();

            Logger.Info("Command of type {0} finished execution in {1}ms", command.GetType().Name, stopwatch.ElapsedMilliseconds);
        }
    }
}