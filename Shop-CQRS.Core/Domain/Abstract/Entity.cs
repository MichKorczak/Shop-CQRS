namespace Shop_CQRS.Core.Domain.Abstract
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
