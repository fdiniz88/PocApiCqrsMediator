using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IDisposable> BeginTransactionAsync();
        Task CommitTransactionAsync(IDisposable transaction);
        Task<Account> GetByIdAsync(int accountId);
        void Add(Account account);
        Task RollbackTransactionAsync(IDisposable transaction);
    }
}
