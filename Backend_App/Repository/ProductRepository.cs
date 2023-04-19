using Backend_App.Contexts;
using Backend_App.Models.Entities;

namespace Backend_App.Repository;

public class ProductRepository : BaseRepository<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}