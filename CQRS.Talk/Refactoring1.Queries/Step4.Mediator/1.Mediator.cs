// ReSharper disable TypeParameterCanBeVariant
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring1.Queries.Step3.Interfaces;


namespace CQRS.Talk.Refactoring1.Queries.Step4.Mediator
{
    public interface IMediator
    {
        TResult Handle<TResult>(IQuery<TResult> query);
    }


    public class Mediator : IMediator
    {
        private readonly Container container;

        public Mediator(Container container)
        {
            this.container = container;
        }


        public TResult Handle<TResult>(IQuery<TResult> query)
        {
            var queryHandlerType = typeof(IQueryHandler<,>);

            var resultType = typeof(TResult);

            var handlerType = queryHandlerType.MakeGenericType(query.GetType(), resultType);

            dynamic handler = container.GetInstance(handlerType);

            return handler.Handle(query);
        }
    }
}
