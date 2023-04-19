using Backend_App.Contexts;
using Backend_App.Models.Entities;

namespace Backend_App.Repository;

public class ContactRepository : BaseRepository<ContactEntity>
{
    public ContactRepository(DataContext context) : base(context)
    {
    }
}