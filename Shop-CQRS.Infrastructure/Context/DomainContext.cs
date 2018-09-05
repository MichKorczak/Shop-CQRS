using Microsoft.EntityFrameworkCore;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Infrastructure.Context
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> 
            options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
