using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop_CQRS.Core.Domain.Abstract;

namespace Shop_CQRS.Core.Domain
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Collection { get; set; }
    }
}
