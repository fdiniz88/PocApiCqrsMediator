namespace poc.api.cqrs.mediator.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string HolderName { get; set; } = string.Empty;
    }
}
