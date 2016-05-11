using System.Diagnostics;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using CQRS.Talk.Sample4.Decorator;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class TimedDecorator<TCommand> : 
        ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public TimedDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }


        public void Handle(TCommand command)
        {
            var stopwatch = Stopwatch.StartNew();

            decorated.Handle(command);

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                Logger.Info("TIMED: Command of type {0} finished execution in {1}ms", 
                    command.GetType().Name, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}