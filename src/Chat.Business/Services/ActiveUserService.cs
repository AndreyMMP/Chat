using Chat.Business.Interfaces;
using Chat.Business.Models;
using System.Collections.Generic;

namespace Chat.Business.Services
{
    public class ActiveUserService : IActiveUserService
    {
        private readonly IActiveUserRepository _activeUserRepository;

        public ActiveUserService(IActiveUserRepository activeUserRepository)
        {
            _activeUserRepository = activeUserRepository;
        }

        public void Adicionar(ActiveUser user, string key)
        {
            _activeUserRepository.Adicionar(user, key);
        }

        public void ExcluirTodosRegistros()
        {
            _activeUserRepository.ExcluirTodosRegistros();
        }
        public void ExcluirRegistro(string key)
        {
            _activeUserRepository.ExcluirRegistro(key);
        }

        public ActiveUser ObterPorId(string user)
        {
            return _activeUserRepository.ObterPorId(user);
        }

        public List<ActiveUser> ObterTodos()
        {
            return _activeUserRepository.ObterTodos();
        }
    }
}
