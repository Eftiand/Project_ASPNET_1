using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Backend_App.Factory;
using Backend_App.Helpers.Enums;
using Backend_App.Models.Entities;

namespace Backend_App.Models.DTO.Product;

public class ProductRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; } 
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string ImageUrl { get; set; } = string.Empty;
    
    [Required]
    public int StarRating { get; set; }
    
    public ProductStatusEnum? Status { get; set; }
    
    
    
    public static implicit operator ProductResponse(ProductRequest productRequest)
    {
        return ProductFactory.CreateProductResponse(productRequest);
    }
    
    public static implicit operator ProductEntity(ProductRequest productRequest)
    {
        return ProductFactory.CreateProductEntity(productRequest);
    }
}