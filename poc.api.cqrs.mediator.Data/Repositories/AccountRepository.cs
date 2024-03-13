using poc.api.cqrs.mediator.Infrastructure.Contexts.DBContext;
using poc.api.cqrs.mediator.Domain.Interfaces;
using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PocContext _pocContext;

        public AccountRepository(PocContext pocContext)
        {
            _pocContext = pocContext;
        }
        public async void Add(Account entity)
        {
            _pocContext.Accounts.Add(entity);
           await _pocContext.SaveChangesAsync();
        }

        public Task<IDisposable> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(IDisposable transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(IDisposable transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
