namespace CQRS.Talk.Refactoring1.Queries.Step5.Mediator
{
    public interface ISimpleMediator
    {
        object Process(object query);
    }
}
