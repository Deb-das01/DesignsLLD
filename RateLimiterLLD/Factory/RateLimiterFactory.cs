using RateLimiterLLD.Enums;
using RateLimiterLLD.limiters;
using RateLimiterLLD.interfaces;
using RateLimiterLLD.Models;

namespace RateLimiterLLD.Factory
{
    public class RateLimiterFactory
    {
        public static IRateLimiter GetRateLimiter(RateLimiterType rateLimiterType, RateLimiterConfig config)
        {
            switch (rateLimiterType)
            {
                case RateLimiterType.TokenBucket:
                    return new TokenBucket(config.maxRequestCount, config.timeWindowInSeconds);
                case RateLimiterType.SlidingWindow:
                    return new SlidingWindow(config.maxRequestCount, config.timeWindowInSeconds);
                default:
                    throw new ArgumentException("Invalid rate limiter type");
            }
        }
    }
}