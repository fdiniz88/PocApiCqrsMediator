using MediatR;
using poc.api.cqrs.mediator.Application.Services.Interfaces;
using poc.api.cqrs.mediator.Application.ViewModels;
using poc.api.cqrs.mediator.Domain.Models;
using poc.api.cqrs.mediator.Domain.Queries;

namespace poc.api.cqrs.mediator.Application.QueryHandlers
{
    public class GetAccountQueryHandler : IRequest<Account>
    {
        private readonly IAccountService _accountService;

        public GetAccountQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccountAsync(request.AccountId);
        }
    }
}
