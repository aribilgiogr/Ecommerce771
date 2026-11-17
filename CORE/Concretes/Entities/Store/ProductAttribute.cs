using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
