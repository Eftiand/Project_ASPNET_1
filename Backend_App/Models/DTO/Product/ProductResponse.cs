using Backend_App.Helpers.Enums;
using Backend_App.Models.Entities;

namespace Backend_App.Models.DTO.Product;

public class ProductResponse 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int StarRating { get; set; } = 0;
    public ProductStatusEnum? Status { get; set; }
    
    
    public static implicit operator ProductResponse(ProductEntity productEntity)
    {
        return new ProductResponse
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            ImageUrl = productEntity.ImageUrl,
            Status = productEntity.Status,
        };
    }
}