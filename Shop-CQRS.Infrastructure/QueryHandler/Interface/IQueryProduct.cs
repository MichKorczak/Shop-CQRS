using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Infrastructure.QueryHandler.Interface
{
    public interface IQueryProduct
    {
        Task<List<Product>> GetProductListAsync();
    }
}
