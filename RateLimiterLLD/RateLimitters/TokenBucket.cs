using RateLimiterLLD.interfaces;
namespace RateLimiterLLD.limiters
{
    public class TokenBucket : IRateLimiter
    {
        private readonly int _refillRate;
        private int _currentTokenCount;
        private DateTime _windowStartTime;

        public TokenBucket(int maxRequestCount, int timeWindowInSeconds)
        {
            _currentTokenCount = maxRequestCount;
            _refillRate = maxRequestCount / timeWindowInSeconds;
            _windowStartTime = DateTime.UtcNow;
        }

        public void refillTokens()
        {
            var currentTime = DateTime.UtcNow;
            var elapsedTimeInSeconds = (currentTime - _windowStartTime).TotalSeconds;

            if (elapsedTimeInSeconds >= 1)
            {
                int tokensToAdd = (int)(elapsedTimeInSeconds * _refillRate);
                _currentTokenCount = _currentTokenCount + tokensToAdd;
                _windowStartTime = currentTime;
            }
        }
        public bool IsRequestAllowed()
        {
            refillTokens();
            if (_currentTokenCount > 0)
            {
                _currentTokenCount--;
                return true;
            }
            return false;
        }
    }
}