using Castle.Core.Internal;
using Chat.Business.Models;
using System;
using System.Linq;
using Xunit;

namespace Chat.Test.Fixtures
{
    [CollectionDefinition(nameof(ActiveUserCollection))]
    public class ActiveUserCollection : ICollectionFixture<ActiveUserTestsFixture> { }
    
    public class ActiveUserTestsFixture
    {
        private string GerarNickname()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 15)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public ActiveUser GerarUsuario(string nickname = null)
        {
            return new ActiveUser { Nickname = !nickname.IsNullOrEmpty() ? nickname : GerarNickname() };
        }
    }
}
