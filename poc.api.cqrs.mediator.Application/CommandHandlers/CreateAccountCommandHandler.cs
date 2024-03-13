using MediatR;
using poc.api.cqrs.mediator.Application.Services.Interfaces;
using poc.api.cqrs.mediator.Domain.Commands;

namespace poc.api.cqrs.mediator.Application.CommandHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAccountService _accountService;

        public CreateAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.CreateAccountAsync(request);
        }
    }
}
