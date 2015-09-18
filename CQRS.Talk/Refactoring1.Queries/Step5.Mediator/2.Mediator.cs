using CQRS.Talk.Dependencies;


namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    //public interface IMediator
    //{
    //    TResult Handle(TQuery query);
    //}

#region IQuery 

    public interface IQuery<TResult> { }


    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Request(IQuery<TResult> query);
    }

#endregion


#region Mediator

    public interface IMediator
    {
        TResult Request<TResult>(IQuery<TResult> query);
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
    }

#endregion
}
