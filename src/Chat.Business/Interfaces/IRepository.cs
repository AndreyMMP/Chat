using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Business.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Adicionar(TEntity entity, string key);
        TEntity ObterPorId(string key);        
    }
}
