using Backend_App.Helpers.Enums;
using Backend_App.Models.DTO.Product;
using Backend_App.Models.Entities;

namespace Backend_App.Factory;

public class ProductFactory
{
    public static ProductResponse CreateProductResponse(ProductEntity productEntity)
    {
        return new ProductResponse()
        {
            Id= productEntity.Id,
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            ImageUrl = productEntity.ImageUrl,
            StarRating = productEntity.StarRating,
            Status = productEntity.Status,
        };
    }
    
    public static ProductEntity CreateProductEntity(ProductRequest productRequest)
    {
        return new ProductEntity()
        {
            Name = productRequest.Name,
            Description = productRequest.Description,
            Price = productRequest.Price,
            ImageUrl = productRequest.ImageUrl,
            StarRating = productRequest.StarRating,
            Status = productRequest.Status,
        };
    }
}