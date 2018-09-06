using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_CQRS.Core.Domain;
using Shop_CQRS.Infrastructure.Context;
using Shop_CQRS.Infrastructure.QueryHandler.Interface;

namespace Shop_CQRS.Infrastructure.QueryHandler.Implementation
{
    public class QueryCategory : IQueryCategory
    {
        private readonly DomainContext context;

        public QueryCategory(DomainContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategoryList() => context.Categories.AsEnumerable();
    }
}
