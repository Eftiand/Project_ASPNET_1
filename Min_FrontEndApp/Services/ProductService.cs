using Min_FrontEndApp.Models.DTO;

namespace Min_FrontEndApp.Services;

public class ProductService : ApiService<Product>
{
    public ProductService() 
    {
         Url += "products/";
    }
}
