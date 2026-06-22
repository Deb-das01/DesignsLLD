namespace RateLimiterLLD.Models
{
    public class RateLimiterConfig{
        public int maxRequestCount { get; set; }
        public int timeWindowInSeconds { get; set; }
    }
}