using System;
using System.Collections.Generic;

namespace CQRS.Talk.Sample5.CQRS.Decorator.Query
{
    public interface ICacheProvider
    {
        object Get(string cacheKey);
        void Set(string cacheKey, object cachedResult, TimeSpan cacheDuration);
    }

    class CacheProvider : ICacheProvider
    {
        private Dictionary<String, Object> cachedObjects;

        public CacheProvider()
        {
            cachedObjects = new Dictionary<string, object>();
        }
        public object Get(string cacheKey)
        {
            object result;
            if (cachedObjects.TryGetValue(cacheKey, out result))
            {
                return result;
            }
            return null;
        }

        public void Set(string cacheKey, object cachedResult, TimeSpan cacheDuration)
        {
            cachedObjects[cacheKey] = cachedResult;
            // ignore complications here and cache duration 
            // for simplicity of the sample
        }
    }
}
