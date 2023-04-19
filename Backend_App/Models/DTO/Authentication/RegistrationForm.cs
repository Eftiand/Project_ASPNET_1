using System.ComponentModel.DataAnnotations;
using Backend_App.Factory;
using Backend_App.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Backend_App.Models.DTO.Authentication;

public class RegistrationForm
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = string.Empty;
    
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string RoleName { get; set; } = "productOwner";
    
    public static implicit operator AppUser(RegistrationForm registrationForm) => IdentityFactory.Create(registrationForm);
}