using Backend_App.Helpers.Enums;

namespace Backend_App.Models.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    
    public int StarRating { get; set; } = 0;
    public ProductStatusEnum? Status { get; set; }
}