using Min_FrontEndApp.Models.DTO;

namespace Min_FrontEndApp.Services;

public class ContactService:ApiService<Contact>
{
    public ContactService( ) 
    {
        Url += "contact/";
    }
    
    
}