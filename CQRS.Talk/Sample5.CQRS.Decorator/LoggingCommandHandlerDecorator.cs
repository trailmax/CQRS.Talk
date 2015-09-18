using CQRS.Talk.Refactoring2.Queries._3.Interfaces;
using CQRS.Talk.Sample4.Decorator;
using Newtonsoft.Json;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class LoggedCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public LoggedCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }


        public void Handle(TCommand command)
        {
            var serialisedData = JsonConvert.SerializeObject(command);
            Logger.Info("About to handle command handler of type {0} with data {1}", command.GetType().Name, serialisedData);

            decorated.Handle(command);

            Logger.Info("Finished with command handler of type {0}", command.GetType().Name);
        }
    }
}
