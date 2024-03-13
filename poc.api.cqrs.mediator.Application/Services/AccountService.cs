using poc.api.cqrs.mediator.Application.Services.Interfaces;
using poc.api.cqrs.mediator.Domain.Commands;
using poc.api.cqrs.mediator.Domain.Interfaces;
using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMongoRepository _mongoRepository;

        public AccountService(IAccountRepository accountRepository, IAccountMongoRepository mongoRepository)
        {
            _accountRepository = accountRepository;
            _mongoRepository = mongoRepository;
        }

        public async Task<int> CreateAccountAsync(CreateAccountCommand command)
        {
            using var transaction = await _accountRepository.BeginTransactionAsync();

            try
            {
                var account = new Account { HolderName = command.AccountHolderName };
                _accountRepository.Add(account);

                await _mongoRepository.IncluirAsync(new Account
                {
                    HolderName = command.AccountHolderName
                });

                await _accountRepository.CommitTransactionAsync(transaction);

                return account.Id;
            }
            catch (Exception ex)
            {
                await _accountRepository.RollbackTransactionAsync(transaction);
                throw;
            }
        }
        public async Task<Account> GetAccountAsync(int accountId)
        {
            var account = await _mongoRepository.BuscarPorId(accountId);
            return new Account
            {
                Id = account.Id,
                HolderName = account.HolderName
            };
        }
    }
}
