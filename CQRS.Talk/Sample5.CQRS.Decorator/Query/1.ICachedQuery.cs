using System;


namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public interface ICachedQuery
    {
        String CacheKey { get; }
        TimeSpan CacheDuration { get; }
    }
}
