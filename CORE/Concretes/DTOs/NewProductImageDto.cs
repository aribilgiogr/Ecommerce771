using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CORE.Concretes.DTOs
{
    public record NewProductImageDto
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        [Display(Name = "Görsel Yolu")]
        [Required(ErrorMessage = "Ürün görseli zorunludur!")]
        [DataType(DataType.Upload)]
        public IFormFile ImageUrl { get; init; } = null!;

        [Display(Name = "Alternatif Metin", Prompt = "Alternatif Metin")]
        public string? AltText { get; set; }
    }
}
