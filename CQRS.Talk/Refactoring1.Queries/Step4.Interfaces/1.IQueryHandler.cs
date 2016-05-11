namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery queryObject);
    }
}
