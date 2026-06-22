using System;
using System.Collections.Generic;
using RateLimiterLLD.Enums;

namespace RateLimiterLLD.Models
{
public class User
{
    public string ?UserId { get; set; }
    public UserTireType UserTireType { get; set; }
}
}