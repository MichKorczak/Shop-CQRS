using System.ComponentModel.DataAnnotations;
using Shop_CQRS.Core.Domain.Abstract;

namespace Shop_CQRS.Core.Domain
{
    public class Product : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int NumberOfIrems { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
