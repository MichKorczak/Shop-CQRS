using System.Collections.Generic;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Core.Response.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
