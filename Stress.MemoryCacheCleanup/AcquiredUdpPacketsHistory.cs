namespace Stress.MemoryCacheCleanup
{
    using System;
    using System.Collections.Specialized;
    using System.Runtime.Caching;
    using System.Threading;

    class AcquiredUdpPacketsHistory
    {

        static readonly object Singleton = new object();

        public bool Acquire(Guid id)
        {
            MemoryCache cache = Cache.Value;
            string key = id.ToString("N");
            object raw = cache.Get(key);
            if (raw == null)
            {
                cache.Add(key, Singleton, new CacheItemPolicy()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow + TimeSpan.FromSeconds(5), TimeSpan.Zero),
                });
                return true;
            }
            else
            {
                return false;
            }
        }


        static Lazy<MemoryCache> Cache = new Lazy<MemoryCache>(() =>
        {
            var config = new NameValueCollection();
            config.Add("pollingInterval", "00:01:00");
            // config.Add("physicalMemoryLimitPercentage", "0");
            config.Add("cacheMemoryLimitMegabytes", "1");
            var ret = new MemoryCache("api", config);
            return ret;
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }
}