using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring1.Queries.Step4.Interfaces;
using CQRS.Talk.Refactoring1.Queries.Step5.Mediator;
using CQRS.Talk.Refactoring2.Commands._3.Interfaces;
using CQRS.Talk.Refactoring2.Commands._4.Validators;


namespace CQRS.Talk.Refactoring2.Commands._5.Mediator
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
            var queryHandlerType = typeof(IQueryHandler<,>);

            var resultType = typeof(TResult);

            var handlerType = queryHandlerType.MakeGenericType(query.GetType(), resultType);

            dynamic handler = container.GetInstance(handlerType);

            return handler.Handle(query);
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
