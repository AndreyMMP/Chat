using ServiceStack.Redis;

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
