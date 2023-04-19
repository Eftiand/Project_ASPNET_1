using Backend_App.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend_App.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    //Put models here later
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
}