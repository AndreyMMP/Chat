using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Data.Context
{
    public class RedisContext
    {
        protected string Host { get; private set; } = "localhost:6379";
        public readonly RedisClient redisClient;
        public RedisContext()
        {
            redisClient = new RedisClient(Host);
        }
    }
}
