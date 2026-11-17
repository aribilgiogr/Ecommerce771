using CORE.Abstracts.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Concretes.Entities.Store
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; } = null!;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
