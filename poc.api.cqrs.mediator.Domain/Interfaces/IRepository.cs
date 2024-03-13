namespace poc.api.cqrs.mediator.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Incluir(TEntity entidade);
        Task<IEnumerable<TEntity>> BuscarTodos();
        Task<TEntity?> BuscarPorId(int id);
        Task<TEntity> Alterar(TEntity entidade);
    }
}
