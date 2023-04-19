using System.Text;
using Min_FrontEndApp.Models.DTO;
using Min_FrontEndApp.Models.ViewModels;
using Newtonsoft.Json;

namespace Min_FrontEndApp.Services;

public class AdminService : ApiService<Product>
{
    public AdminService()
    {
        Url += "Admin/";
    }
    
    
    public async Task<bool> IsAuthorizedUser(string authToken)
    {
        Url += "CheckUser";
        
        using var http = GetHttpClient(authToken: authToken);
        
        var result = await http.GetAsync(Url);
        
        Url = Url.Replace("CheckUser", "");
        
        return result.IsSuccessStatusCode;
    }
    
    public async Task<bool> AddProductAsync(AdminAddProductViewModel model, string authToken)
    {
        Url += "AddProduct";
        
        using var http = GetHttpClient(authToken: authToken);
        
        var json = JsonConvert.SerializeObject(model);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        
        var result = await http.PostAsync(Url, data);
        
        return result.IsSuccessStatusCode;
    }
}