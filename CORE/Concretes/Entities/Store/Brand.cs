using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
