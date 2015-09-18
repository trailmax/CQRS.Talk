using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public interface ICachedQuery
    {
        String CacheKey { get; }
        TimeSpan CacheDuration { get; }
    }

}
