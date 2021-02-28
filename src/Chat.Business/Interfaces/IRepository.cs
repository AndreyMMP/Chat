namespace Chat.Business.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Adicionar(TEntity entity, string key);
        TEntity ObterPorId(string key);        
    }
}
