using System.Security.Claims;
using Backend_App.Contexts;
using Backend_App.Factory;
using Backend_App.Helpers.JWT;
using Backend_App.Models.DTO.Authentication;
using Backend_App.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend_App.Services;

public class AuthService
{
    #region Constructor

    private readonly IdentityContext _identityContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly JwtToken _jwt;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(IdentityContext identityContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JwtToken jwt, RoleManager<IdentityRole> roleManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwt = jwt;
        _roleManager = roleManager;
    }

    #endregion

   #region SignUp 
    public async Task<bool> SignUpAsync(RegistrationForm registration)
    {
        registration.RoleName = "productOwner";
        if (registration.Password != registration.ConfirmPassword)
            return false;

        if (!_roleManager.Roles.Any())
        {
            await _roleManager.CreateAsync(IdentityFactory.Create("admin"));
            await _roleManager.CreateAsync(IdentityFactory.Create(registration.RoleName));
        }

        if(!await _userManager.Users.AnyAsync())
            registration.RoleName = "admin";

        var result = await _userManager.CreateAsync(registration, registration.Password);

        if (!result.Succeeded)
            return false;
        
        var user = await _userManager.FindByEmailAsync(registration.Email);
        
        if (user == null)
            return false;
        
        await _userManager.AddToRoleAsync(user!, registration.RoleName);
        
        
        
        return result.Succeeded;
    }
    #endregion
    
    #region SignIn
    public async Task<string> SignInAsync(LoginForm login)
    {
        var identityUser = await _userManager.FindByEmailAsync(login.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, login.Password, false);
            if (signInResult.Succeeded)
            {
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, identityUser.Email!),
                    new Claim(ClaimTypes.Role, (await _userManager.GetRolesAsync(identityUser))[0])
                });

                return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
            }

        }

        return string.Empty;
    }
    #endregion
    
    public async Task<bool> SignOutAsync()
    {
        await _signInManager.SignOutAsync();
        return true;
    }
    
    
    #region GetAllUsers
    public async Task<IEnumerable<AppUser>> GetAllAsync()
    {
        return await _identityContext.Users.ToListAsync(); 
    }
    #endregion
}