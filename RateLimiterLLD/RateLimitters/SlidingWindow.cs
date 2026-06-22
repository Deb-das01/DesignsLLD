using RateLimiterLLD.interfaces;
namespace RateLimiterLLD.limiters
{
    public class SlidingWindow : IRateLimiter
    {
        private readonly int _maxRequestCount;
        private readonly int _timeWindowInSeconds;
        private readonly Queue<DateTime> _requestTimestamps;

        public SlidingWindow(int maxRequestCount, int timeWindowInSeconds)
        {
            _maxRequestCount = maxRequestCount;
            _timeWindowInSeconds = timeWindowInSeconds;
            _requestTimestamps = new Queue<DateTime>();
        }

        public bool IsRequestAllowed()
        {
            var currentTime = DateTime.UtcNow;

            // Remove timestamps that are outside the time window
            while (_requestTimestamps.Count > 0 && (currentTime - _requestTimestamps.Peek()).TotalSeconds > _timeWindowInSeconds)
            {
                _requestTimestamps.Dequeue();
            }

            if (_requestTimestamps.Count < _maxRequestCount)
            {
                _requestTimestamps.Enqueue(currentTime);
                return true;
            }

            return false;
        }
    }
}