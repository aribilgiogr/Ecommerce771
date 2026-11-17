using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; } = null!;
        public string? AltText { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
