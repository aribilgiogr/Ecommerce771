using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double DiscountRate { get; set; } = 0;
        public double TaxRate { get; set; }

        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; } = null!;

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        public int ModelId { get; set; }
        public virtual Model Model { get; set; } = null!;

        public virtual ICollection<ProductImage> Images { get; set; } = [];
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = [];
        public virtual ICollection<ProductComment> Comments { get; set; } = [];
    }
}
