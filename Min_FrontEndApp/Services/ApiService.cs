using System.Net.Http.Headers;
using System.Text;
using Min_FrontEndApp.Models.DTO;
using Newtonsoft.Json;

namespace Min_FrontEndApp.Services;

public abstract class ApiService<T> where T : class
{
    public string Url;
    public ApiService()
    {
        Url = "https://localhost:7256/api/";
    }

    public async Task<IEnumerable<T>> GetAllAsync(string authToken = "")
    {
        var result = await GetAsync(authToken: authToken);
        return result;
    }
    
    public async Task<IEnumerable<T>> GetStatusAsync(string url = "")
    {
        var tempUrl = "status/" + url;
        
        var result = await GetAsync(tempUrl);
        
        return result;
    }
    
    public async Task<T> GetByIdAsync(string id)
    {
        var result = await GetSingleAsync(id);
        
        return result;
    }

    public async Task PostAsync(T obj)
    {
        using var http = GetHttpClient();
        
        var json = JsonConvert.SerializeObject(obj);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        
        var result = await http.PostAsync(Url, data);
        
        result.EnsureSuccessStatusCode();
        
    }

    private async Task<IEnumerable<T>> GetAsync(string urlAddition = "", string authToken = "")
    {
        using var http = GetHttpClient(authToken);
        
        var response = await http.GetFromJsonAsync<IEnumerable<T>>($"{Url}{urlAddition}");

        return response!;

    }

    private async Task<T> GetSingleAsync(string urlAddition)
    {
        using var http = GetHttpClient();
        var response = await http.GetFromJsonAsync<T>($"{Url}{urlAddition}");
        
        return response!;
    }

    public HttpClient GetHttpClient(string authToken = "")
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("ApiKey", "755d128a-d2ae-43f9-a521-41712709f1b5");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        if(authToken != "")
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        
        return client;
    }
    
    
}