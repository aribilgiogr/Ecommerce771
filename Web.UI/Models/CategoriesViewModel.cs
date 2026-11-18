using CORE.Concretes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Web.UI.Models
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = [];
        public IEnumerable<SubCategoryDto> SubCategories { get; set; } = [];

        [Display(Name = "Ana Kategori Adı", Prompt = "Örn. Teknoloji, Tekstil vb.")]
        [Required(ErrorMessage = "Kategori adı zorunludur!")]
        [MinLength(3, ErrorMessage = "Kategori adı en az 3 karakter olmalıdır!")]
        [MaxLength(25, ErrorMessage = "Kategori adı en fazla 25 karakter olmalıdır!")]
        public string NewCategoryName { get; set; } = null!;

        public NewSubCategoryViewModel? NewSubCategory { get; set; }
    }

    public class NewSubCategoryViewModel
    {
        public int ParentId { get; set; }

        [Display(Name = "Alt Kategori Adı", Prompt = "Örn. Laptop, Cep Telefonu vb.")]
        [Required(ErrorMessage = "Alt kategori adı zorunludur!")]
        [MinLength(3, ErrorMessage = "Alt kategori adı en az 3 karakter olmalıdır!")]
        [MaxLength(25, ErrorMessage = "Alt kategori adı en fazla 25 karakter olmalıdır!")]
        public string NewSubCategoryName { get; set; } = null!;
    }
}
