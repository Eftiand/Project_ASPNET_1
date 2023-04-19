using Backend_App.Models.DTO.Contact;
using Backend_App.Models.Entities;
using Backend_App.Repository;

namespace Backend_App.Services;

public class ContactService
{
    private readonly ContactRepository _contactRepository;

    public ContactService(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public async Task<ContactEntity> CreateAsync(ContactRequest contactEntity)
    {
        return await _contactRepository.AddAsync(contactEntity);
    }
    
}