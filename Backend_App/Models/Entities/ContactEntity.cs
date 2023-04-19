namespace Backend_App.Models.Entities;

public class ContactEntity : BaseEntity
{
    public string Email { get; set; } = null!;
    public string? Message { get; set; }
}