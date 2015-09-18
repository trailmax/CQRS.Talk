using System.Threading;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using NUnit.Framework;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class DelayedTimerCommand : ICommand
    {
        public DelayedTimerCommand(int delayByMilliseconds)
        {
            DelayByMilliseconds = delayByMilliseconds;
        }


        public int DelayByMilliseconds { get; private set; }
    }
    public class DelayedTimerCommandHanlder : ICommandHandler<DelayedTimerCommand>
    {
        public void Handle(DelayedTimerCommand command)
        {
            Thread.Sleep(command.DelayByMilliseconds);
        }
    }


    class CommandHandlerFactory
    {
        public static ICommandHandler<DelayedTimerCommand> CreateHandler()
        {
            var commandHandler = new DelayedTimerCommandHanlder();
            var timedDecorator = new TimedDecorator<DelayedTimerCommand>(commandHandler);
            var loggedDecorator = new LoggedDecorator<DelayedTimerCommand>(timedDecorator);

            return loggedDecorator;
        }
    }


    class ExecuteSample
    {
        [Test]
        public void Execute()
        {
            var command = new DelayedTimerCommand(1234);
            ICommandHandler<DelayedTimerCommand> commandHandler = 
                CommandHandlerFactory.CreateHandler();

            commandHandler.Handle(command);
        }
    }
}
