using Chat.Business.Models;
using System.Collections.Generic;

namespace Chat.Business.Interfaces
{
    public interface IActiveUserRepository : IRepository<ActiveUser>
    {
        List<ActiveUser> ObterTodos();
        void ExcluirTodosRegistros();
        void ExcluirRegistro(string key);
    }
}
