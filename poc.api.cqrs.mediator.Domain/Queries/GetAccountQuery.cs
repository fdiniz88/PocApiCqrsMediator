using MediatR;
using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Domain.Queries
{
    public class GetAccountQuery : IRequest<Account>
    {
        public int AccountId { get; set; }
    }
}
