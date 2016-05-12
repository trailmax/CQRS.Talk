using System;
using CQRS.Talk.Refactoring1.Queries.Step4.Interfaces;


namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public class CachedQueryHandlerDecorator<TQuery, TResult> : 
        IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;
        private readonly ICacheProvider cacheProvider;

        public CachedQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated, ICacheProvider cacheProvider)
        {
            this.decorated = decorated;
            this.cacheProvider = cacheProvider;
        }


        public TResult Handle(TQuery query)
        {
            var cachedQuery = query as ICachedQuery;

            if (cachedQuery == null)
            {
                // query is not cached - just executed the actual query handler
                return decorated.Handle(query);
            }

            var cacheKey = cachedQuery.CacheKey;
            var cachedObject = cacheProvider.Get(cacheKey); // try get query results from the cache

            if (cachedObject != null && cachedObject is TResult)
            {
                // got object from the cache
                return (TResult)cachedObject;
            }
            // cache contains nothing for this key

            // requrest actual query handler for the query results
            var cachedResult = decorated.Handle(query);

            // save the result into cache
            cacheProvider.Set(cachedQuery.CacheKey, cachedResult, cachedQuery.CacheDuration);
            return cachedResult;
        }
    }


    public  interface ICacheProvider
    {
        object Get(string cacheKey);
        void Set(string cacheKey, object cachedResult, TimeSpan cacheDuration);
    }
}
