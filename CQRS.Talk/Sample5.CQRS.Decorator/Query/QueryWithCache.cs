using System;
using System.Threading;
using CQRS.Talk.Refactoring1.Queries.Step4.Interfaces;
using NUnit.Framework;

namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public class QueryWithCache : IQuery<String>, ICachedQuery
    {
        public string CacheKey => "MyCachedQuery";
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(5);
    }

    public class QueryWithCacheHandler : IQueryHandler<QueryWithCache, String>
    {
        public string Handle(QueryWithCache query)
        {
            Thread.Sleep(1234);
            return "Hello World";
        }
    }


    public class Consumer
    {
        [Test]
        public void ExecuteTwice()
        {
            var query = new QueryWithCache();
            var handler = new QueryWithCacheHandler();
            var cachedHandler = new CachedQueryHandlerDecorator<QueryWithCache, String>(handler, new CacheProvider());
            var timedHandler = new TimedQueryDecorator<QueryWithCache, String>(cachedHandler);

            // Execute
            var result = timedHandler.Handle(query);
            Console.WriteLine($"First execution result: {result}");
            Console.WriteLine();

            // execute second time
            var cachedResult = timedHandler.Handle(query);
            Console.WriteLine($"Cached execution: {cachedResult}");
        }
    }
}
