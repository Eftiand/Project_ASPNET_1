namespace Min_FrontEndApp.Models.DTO;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int StarRating { get; set; }
    public int Status { get; set; }
}