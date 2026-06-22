using RateLimiterLLD.Models;
using RateLimiterLLD.Enums;
using RateLimiterLLD.Services;
namespace RateLimiterLLD
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User
            {
                UserId = "user1",
                UserTireType = Enums.UserTireType.freeTire
            };
            User user2 = new User
            {
                UserId = "user2",
                UserTireType = Enums.UserTireType.premiumTire
            };

            RateLimiterService rateLimiterService1 = new RateLimiterService(user1);
            RateLimiterService rateLimiterService2 = new RateLimiterService(user2);

            for (int i = 0; i < 7; i++)
            {
                bool isAllowed1 = rateLimiterService1.IsRequestAllowed();
                Console.WriteLine($"User1 Request {i + 1}: {(isAllowed1 ? "Allowed" : "Blocked")}");
            }
            for (int i = 0; i < 12; i++)
            {
                bool isAllowed2 = rateLimiterService2.IsRequestAllowed();
                Console.WriteLine($"User2 Request {i + 1}: {(isAllowed2 ? "Allowed" : "Blocked")}");
            }
        }
    }
}
