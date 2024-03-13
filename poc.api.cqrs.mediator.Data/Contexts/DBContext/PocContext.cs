using Microsoft.EntityFrameworkCore;
using poc.api.cqrs.mediator.Domain.Models;

namespace poc.api.cqrs.mediator.Infrastructure.Contexts.DBContext
{
    public class PocContext : DbContext
    {
        public PocContext(DbContextOptions<PocContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseInMemoryDatabase("poc");
        }
    }
}

