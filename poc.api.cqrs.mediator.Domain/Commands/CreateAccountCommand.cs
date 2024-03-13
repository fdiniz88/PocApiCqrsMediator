using MediatR;

namespace poc.api.cqrs.mediator.Domain.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public CreateAccountCommand(string accountHolderName)
        {
            AccountHolderName = accountHolderName;
        }

        public string AccountHolderName { get; set; }
    }
}
