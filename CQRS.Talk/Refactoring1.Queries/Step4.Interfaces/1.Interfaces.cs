namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public interface IQuery<TResult>
    {
        // no methods. Marker interface
    }


    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
