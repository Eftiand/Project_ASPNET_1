using Backend_App.Models.DTO.Contact;
using Backend_App.Models.DTO.Product;
using Backend_App.Models.Entities;

namespace Backend_App.Factory;

public class ContactFactory
{
    public static ContactEntity CreateContactEntity(ContactRequest contactRequest)
    {
        return new ContactEntity()
        {
            Email = contactRequest.Email,
            Message = contactRequest.Message,
        };
    }
}