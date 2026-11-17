using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Concretes.DTOs
{
    public record ProductListItemDto(int Id,
                                     string Title,
                                     decimal ListPrice,
                                     decimal DiscountedPrice,
                                     int BrandId,
                                     string BrandName,
                                     int CategoryId,
                                     string CategoryName,
                                     int SubCategoryId,
                                     string SubCategoryName,
                                     int ModelId,
                                     string ModelName,
                                     string CoverImageUrl,
                                     int CommentCount,
                                     int Rating);
}
