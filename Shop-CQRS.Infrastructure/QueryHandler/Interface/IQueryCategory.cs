using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Infrastructure.QueryHandler.Interface
{
    public interface IQueryCategory
    {
        IEnumerable<Category> GetCategoryList();
    }
}
