using Chat.Business.Models;
using System.Collections.Generic;

namespace Chat.Business.Interfaces
{
    public interface IActiveUserService
    {
        void Adicionar(ActiveUser user, string key);
        void ExcluirTodosRegistros();
        void ExcluirRegistro(string key);
        List<ActiveUser> ObterTodos();
        ActiveUser ObterPorId(string user);
    }
}
