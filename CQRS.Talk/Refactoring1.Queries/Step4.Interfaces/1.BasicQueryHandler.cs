namespace CQRS.Talk.Refactoring1.Queries.Step4.Interfaces
{
    public interface IQueryHandler
    {
        object Handle(object queryObject);
    }
}
