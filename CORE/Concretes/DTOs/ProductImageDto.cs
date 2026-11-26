using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Concretes.DTOs
{
    public record ProductImageDto(int Id, int ProductId, string ImageUrl, string? AltText);
}
