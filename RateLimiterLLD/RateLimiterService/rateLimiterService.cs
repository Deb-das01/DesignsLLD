using RateLimiterLLD.Models;
using RateLimiterLLD.Enums;
using RateLimiterLLD.interfaces;
using RateLimiterLLD.Factory;

namespace RateLimiterLLD.Services
{
    public class RateLimiterService
    {
        
        public User _user;
        public IRateLimiter _rateLimiter;

        public RateLimiterService(User user)
        {
            _user = user;
            _rateLimiter = getRateLimiter();
        }

        public IRateLimiter getRateLimiter()
        {
            UserTireType userTireType = _user.UserTireType;

            if(userTireType == UserTireType.freeTire)
            {
                return RateLimiterFactory.GetRateLimiter(RateLimiterType.TokenBucket, new RateLimiterConfig { maxRequestCount = 5, timeWindowInSeconds = 60 });
            }
            else if(userTireType == UserTireType.premiumTire)
            {
                return RateLimiterFactory.GetRateLimiter(RateLimiterType.SlidingWindow, new RateLimiterConfig { maxRequestCount = 10, timeWindowInSeconds = 60 });
            }
            else
            {
                throw new ArgumentException("Invalid user tire type");
            }
        }
        public bool IsRequestAllowed()
        {
            return _rateLimiter.IsRequestAllowed();
        }
    }
}