using MediatR;
using Microsoft.AspNetCore.Mvc;
using poc.api.cqrs.mediator.Domain.Commands;
using poc.api.cqrs.mediator.Domain.Queries;

namespace poc.api.cqrs.mediator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            try
            {
                var accountId = await _mediator.Send(command);
                return Ok(accountId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar conta: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount(int AccountId)
        {
            try
            {
                var user = await _mediator.Send(new GetAccountQuery { AccountId = AccountId });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter conta: {ex.Message}");
            }
        }
    }
}