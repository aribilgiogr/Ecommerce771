using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<SubCategory> SubCategories { get; set; } = [];
    }
}
