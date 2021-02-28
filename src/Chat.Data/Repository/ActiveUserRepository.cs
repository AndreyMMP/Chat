using Chat.Business.Interfaces;
using Chat.Business.Models;
using Chat.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Data.Repository
{
    public class ActiveUserRepository : Repository<ActiveUser>, IActiveUserRepository
    {
        public ActiveUserRepository(RedisContext redisContext) : base(redisContext) { }

        public List<ActiveUser> ObterTodos()
        {
            List<ActiveUser> users = new List<ActiveUser>();
            var keys = ObterTodasKeys();
            users.AddRange(keys.Select(key => ObterPorId(key)));
            return users;
        }
        private List<string> ObterTodasKeys()
        {
            return _redisContext.redisClient.GetAllKeys();
        }
        public void ExcluirTodosRegistros()
        {
            var keys = ObterTodasKeys(); ;
            _redisContext.redisClient.RemoveAll(keys);
        }

        public void ExcluirRegistro(string key)
        {
            _redisContext.redisClient.Remove(key);
        }
    }
}
