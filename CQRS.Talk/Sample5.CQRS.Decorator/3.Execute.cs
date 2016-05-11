using System;
using System.Threading;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using NUnit.Framework;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class SlowRunningCommand : ICommand
    {
        public int Delay { get; }

        public SlowRunningCommand(int delay)
        {
            this.Delay = delay;
        }
    }
    public class SlowRunningCommandHandler : ICommandHandler<SlowRunningCommand>
    {
        public void Handle(SlowRunningCommand command)
        {
            Console.WriteLine($"COMMAND: Delaying for {command.Delay}");
            Thread.Sleep(command.Delay);
        }
    }



    class ExecuteSample
    {
        [Test]
        public void Execute_OnlyCommand()
        {
            var commandHandler = new SlowRunningCommandHandler();

            commandHandler.Handle(new SlowRunningCommand(1234));
        }


        [Test]
        public void AddLogging()
        {
            var commandHandler = new SlowRunningCommandHandler();
            var loggingDecorator = new LoggingDecorator<SlowRunningCommand>(commandHandler);

            loggingDecorator.Handle(new SlowRunningCommand(1234));
        }

        [Test]
        public void MeasureTime()
        {
            var commandHandler = new SlowRunningCommandHandler();
            var timedDecorator = new TimedDecorator<SlowRunningCommand>(commandHandler);
            var loggedDecorator = new LoggingDecorator<SlowRunningCommand>(timedDecorator);

            loggedDecorator.Handle(new SlowRunningCommand(1234));
        }
    }
}
