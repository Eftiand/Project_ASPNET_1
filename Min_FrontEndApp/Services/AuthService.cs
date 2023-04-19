using System.Text;
using Inl_uppgift_ASPNET_1.ViewModels;
using Min_FrontEndApp.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Min_FrontEndApp.Services;

public class AuthService : ApiService<LoginViewModel>
{
    public AuthService()
    {
        Url += "auth/";
    }
    
    public async Task<string> LoginAsync(LoginViewModel loginViewModel)
    {
        Url += "signin/";
        using var http = GetHttpClient();
        
        var json = JsonConvert.SerializeObject(loginViewModel);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await http.PostAsync(Url, data);
        
        if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            return string.Empty;
            
        return await result.Content.ReadAsStringAsync();
    }
    
    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    {
        Url += "signup/";
        
        using var http = GetHttpClient();
        
        var json = JsonConvert.SerializeObject(registerViewModel);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await http.PostAsync(Url, data);
        
        return result.IsSuccessStatusCode;
    }
    
    public async Task<bool> LogoutAsync()
    {
        Url += "signout/";
        
        using var http = GetHttpClient();
        
        var result = await http.PostAsync(Url, null);
        
        return result.IsSuccessStatusCode;
    }
    

}