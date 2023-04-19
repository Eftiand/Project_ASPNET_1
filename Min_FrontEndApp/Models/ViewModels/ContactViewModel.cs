using System.ComponentModel.DataAnnotations;
using Min_FrontEndApp.Models.DTO;

namespace Min_FrontEndApp.Models.ViewModels;

public class ContactViewModel
{
    [Display(Name = "E-postadress")]
    [Required(ErrorMessage = "Du måste ange en e-postadress")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    
    [Display(Name = "Meddelande")]
    public string? Message { get; set; }
    
    public static implicit operator Contact(ContactViewModel contactViewModel)
    {
        return new Contact
        {
            Email = contactViewModel.Email,
            Message = contactViewModel.Message
        };
    }
}