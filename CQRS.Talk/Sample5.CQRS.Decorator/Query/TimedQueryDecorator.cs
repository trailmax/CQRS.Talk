using System.Diagnostics;
using CQRS.Talk.Dependencies;
using CQRS.Talk.Refactoring1.Queries.Step4.Interfaces;

namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public class TimedQueryDecorator<TQuery, TResult> :
        IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public TimedQueryDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = decorated.Handle(query);
            stopwatch.Stop();
            Logger.Info("TIMED: Querry executed in {0}ms", stopwatch.ElapsedMilliseconds);
            return result;
        }
    }
}
