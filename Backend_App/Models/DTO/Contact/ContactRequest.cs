using Backend_App.Factory;
using Backend_App.Models.Entities;

namespace Backend_App.Models.DTO.Contact;

public class ContactRequest
{
    public string Email { get; set; } = null!;
    public string? Message { get; set; }

    public static implicit operator ContactEntity(ContactRequest request) =>
        ContactFactory.CreateContactEntity(request);
}