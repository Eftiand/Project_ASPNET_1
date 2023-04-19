using Backend_App.Models.DTO.Authentication;
using Backend_App.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Backend_App.Factory;

public class IdentityFactory
{
    public static AppUser Create(RegistrationForm registrationForm) => new()
    {
        Email = registrationForm.Email,
        UserName = registrationForm.Email,
        FirstName = registrationForm.FirstName,
        LastName = registrationForm.LastName
    };
    
    public static IdentityRole Create(string roleName)
    {
        return new IdentityRole(roleName);
    }
}