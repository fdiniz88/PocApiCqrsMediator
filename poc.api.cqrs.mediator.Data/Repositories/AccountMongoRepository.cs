using MongoDB.Driver;
using poc.api.cqrs.mediator.Domain.Interfaces;
using poc.api.cqrs.mediator.Domain.Models;
using poc.api.cqrs.mediator.Infrastructure.Contexts.DBContext;

namespace poc.api.cqrs.mediator.Infrastructure.Repositories
{
    public class AccountMongoRepository : IAccountMongoRepository
    {
        private readonly PocMongoContext _pocContext;

        public AccountMongoRepository(PocMongoContext pocContext)
        {
            _pocContext = pocContext;
        }

        public async Task<Account> BuscarPorId(int id)
        {
            return await _pocContext.Account.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> BuscarTodos()
        {
            return await _pocContext.Account.Find(account => true).ToListAsync();
        }

        public async Task<Account> IncluirAsync(Account entidade)
        {
            await _pocContext.Account.InsertOneAsync(entidade);
            return entidade;
        }
    }
}
