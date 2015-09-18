using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring1.Queries.Step5.Mediator;
using CQRS.Talk.Refactoring2.Commands._4.Validators;
using CQRS.Talk.Refactoring2.Queries._3.Interfaces;


namespace CQRS.Talk.Refactoring2.Commands._4.Mediator
{
    public interface IMediator
    {
        TResult Request<TResult>(IQuery<TResult> query);
        List<String> ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }


    public class Mediator : IMediator
    {
        private readonly Container container;

        public Mediator(Container container)
        {
            this.container = container;
        }


        public TResult Request<TResult>(IQuery<TResult> query)
        {
            var handlerType =
                typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }


        public List<String> ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var validator = container.Resolve<ICommandValidator<TCommand>>();

            var errors = validator.GetErrorList(command);

            if (errors.Any())
            {
                return errors;
            }

            var handler = container.Resolve<ICommandHandler<TCommand>>();
            handler.Handle(command);

            return new List<string>();
        }
    }
}
