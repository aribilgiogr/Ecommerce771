using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
