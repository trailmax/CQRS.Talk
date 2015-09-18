using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using CQRS.Talk.Sample4.Decorator;
using Newtonsoft.Json;


namespace CQRS.Talk.Sample5.CQRS.Decorator
{
    public class LoggedDecorator<TCommand> : 
        ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public LoggedDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }


        public void Handle(TCommand command)
        {
            var serialisedData = JsonConvert.SerializeObject(command);
            var commmandName = command.GetType().Name;

            Logger.Info("Start handler {0} with data {1}", commmandName, serialisedData);

            decorated.Handle(command);

            Logger.Info("Finished with command {0}", commmandName);
        }
    }
}
