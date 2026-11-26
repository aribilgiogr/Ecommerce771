using System.ComponentModel.DataAnnotations;

namespace CORE.Concretes.DTOs
{
    public record EditProductDto
    {
        public int Id { get; set; }

        [Display(Name = "Başlık", Prompt = "Ürün Başlığı")]
        [Required(ErrorMessage = "Ürün başlığı zorunludur!")]
        [MinLength(5, ErrorMessage = "En az 5 harften oluşan bir ürün adı giriniz!")]
        [MaxLength(150, ErrorMessage = "En fazla 150 harften oluşan bir ürün adı girebilirsiniz!")]
        public required string Title { get; init; }

        [Display(Name = "Açıklama", Prompt = "Ürün Açıklaması")]
        [Required(ErrorMessage = "Ürün açıklaması zorunludur!")]
        [MinLength(20, ErrorMessage = "En az 20 harften oluşan bir ürün açıklaması giriniz!")]
        [MaxLength(500, ErrorMessage = "En fazla 500 harften oluşan bir ürün açıklaması girebilirsiniz!")]
        [DataType(DataType.MultilineText)]
        public required string Description { get; init; }

        [Display(Name = "Fiyat", Prompt = "Ürün Fiyatı")]
        [Required(ErrorMessage = "Ürün fiyatı zorunludur!")]
        [Range(0.01, 99999.99, ErrorMessage = "Fiyat pozitif değer olmalıdır!")]
        public required decimal Price { get; init; }

        [Display(Name = "İndirim Oranı", Prompt = "0 ~ 100 arası değer.")]
        [Range(0, 100, ErrorMessage = "İndirim oranı 0 ~ 100 arası bir değer alabilir!")]
        public double DiscountRate { get; init; } = 0;

        [Display(Name = "Vergi Dilimi", Prompt = "Uygulanacak vergi dilimi.")]
        [AllowedValues(0d, 1d, 10d, 20d, ErrorMessage = "Vergi dilimi sadece 0%, 1%, 10% veya 20% olabilir!")]
        public double TaxRate { get; init; }

        [Display(Name = "Kategori", Prompt = "Ürün Kategorisi")]
        [Required(ErrorMessage = "Kategori seçimi zorunludur!")]
        public int SubCategoryId { get; init; }

        [Display(Name = "Marka", Prompt = "Ürün Markası")]
        [Required(ErrorMessage = "Marka seçimi zorunludur!")]
        public int BrandId { get; init; }

        [Display(Name = "Model", Prompt = "Ürün Modeli")]
        [Required(ErrorMessage = "Model seçimi zorunludur!")]
        public int ModelId { get; init; }

        [Display(Name = "Stok", Prompt = "Ürün stok miktarı")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı sadece pozitif değer alabilir!")]
        public int Stock { get; init; } = 0;

        [Display(Name = "Durum")]
        public bool Active { get; set; }
    }
}
