using Charisma.Core.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Charisma.Infra.Data.Sql.Commands.Common
{
    public class CharismaCommandDbContext : BaseCommandDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public CharismaCommandDbContext(DbContextOptions<CharismaCommandDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
