using poc.api.cqrs.mediator.Application.ViewModels;
using poc.api.cqrs.mediator.Domain.Commands;
using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<int> CreateAccountAsync(CreateAccountCommand command);
        Task<Account> GetAccountAsync(int accountId);
    }
}

