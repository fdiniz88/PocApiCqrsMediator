using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Domain.Interfaces
{
    public interface IAccountMongoRepository
    {             
        Task<IEnumerable<Account>> BuscarTodos();
        Task<Account> BuscarPorId(int id);
        Task<Account> IncluirAsync(Account entidade);
       
    }
}
