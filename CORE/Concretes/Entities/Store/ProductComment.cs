using CORE.Abstracts.Bases;

namespace CORE.Concretes.Entities.Store
{
    public class ProductComment : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public int Rating { get; set; }
        public string Comment { get; set; } = null!;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
