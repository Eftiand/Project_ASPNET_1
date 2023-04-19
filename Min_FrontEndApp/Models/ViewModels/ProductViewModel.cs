using Min_FrontEndApp.Models.DTO;

namespace Min_FrontEndApp.Models.ViewModels;

public class ProductViewModel
{
    public IEnumerable<Product> AllProducts { get; set; } = new List<Product>();
}