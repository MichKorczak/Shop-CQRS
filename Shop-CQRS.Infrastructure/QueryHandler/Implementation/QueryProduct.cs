using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_CQRS.Core.Domain;
using Shop_CQRS.Infrastructure.Context;
using Shop_CQRS.Infrastructure.QueryHandler.Interface;

namespace Shop_CQRS.Infrastructure.QueryHandler.Implementation
{
    public class QueryProduct : IQueryProduct
    {
        private readonly DomainContext context;

        public QueryProduct(DomainContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProductListAsync() => await context.Products.ToListAsync();
    }
}
