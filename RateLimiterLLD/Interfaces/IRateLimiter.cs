namespace RateLimiterLLD.interfaces
{
    public interface IRateLimiter
    {
        bool IsRequestAllowed();
    }
}