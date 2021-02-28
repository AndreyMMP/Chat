using Chat.Business.Interfaces;
using Chat.Data.Context;

namespace Chat.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        protected readonly RedisContext _redisContext;
        public Repository(RedisContext redisContext)
        {
            _redisContext = redisContext;
        }

        public void Adicionar(TEntity entity, string key)
        {
            _redisContext.redisClient.Set<TEntity>(key, entity);
        }
        public TEntity ObterPorId(string key)
        {
            return _redisContext.redisClient.Get<TEntity>(key);
        }
    }
}
