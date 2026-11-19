using CORE.Concretes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Web.UI.Models
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = [];
        public IEnumerable<SubCategoryDto> SubCategories { get; set; } = [];
        public NewCategoryViewModel? NewCategory { get; set; }
        public NewSubCategoryViewModel? NewSubCategory { get; set; }
        public CategoryDto? SelectedCategory { get; set; }
    }

    public class NewCategoryViewModel
    {
        [Display(Name = "Yeni Kategori Adı:", Prompt = "Örn. Teknoloji, Tekstil vb.")]
        [Required(ErrorMessage = "Kategori adı zorunludur!")]
        [MinLength(3, ErrorMessage = "Kategori adı en az 3 karakter olmalıdır!")]
        [MaxLength(25, ErrorMessage = "Kategori adı en fazla 25 karakter olmalıdır!")]
        public string Name { get; set; } = null!;
    }

    public class NewSubCategoryViewModel
    {
        public int ParentId { get; set; }

        [Display(Name = "Yeni Alt Kategori Adı:", Prompt = "Örn. Teknoloji, Tekstil vb.")]
        [Required(ErrorMessage = "Alt kategori adı zorunludur!")]
        [MinLength(3, ErrorMessage = "Alt kategori adı en az 3 karakter olmalıdır!")]
        [MaxLength(25, ErrorMessage = "Alt kategori adı en fazla 25 karakter olmalıdır!")]
        public string Name { get; set; } = null!;
    }
}
