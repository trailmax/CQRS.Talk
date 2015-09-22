using System;
using System.Threading;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using NUnit.Framework;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class SlowRunningCommand : ICommand
    {
        public string SomeParameter { get; }

        public SlowRunningCommand(String someParameter)
        {
            this.SomeParameter = someParameter;
        }
    }
    public class SlowRunningCommandHandler : ICommandHandler<SlowRunningCommand>
    {
        public void Handle(SlowRunningCommand command)
        {
            Thread.Sleep(1234);
        }
    }


    class CommandHandlerFactory
    {
        public static ICommandHandler<SlowRunningCommand> CreateHandler()
        {
            var commandHandler = new SlowRunningCommandHandler();
            var timedDecorator = new TimedDecorator<SlowRunningCommand>(commandHandler);
            var loggedDecorator = new LoggingDecorator<SlowRunningCommand>(timedDecorator);

            return loggedDecorator;
        }
    }


    class ExecuteSample
    {
        [Test]
        public void Execute()
        {
            var command = new SlowRunningCommand("our parameter");
            var commandHandler = CommandHandlerFactory.CreateHandler();

            commandHandler.Handle(command);
        }
    }
}
