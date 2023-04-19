using System.ComponentModel.DataAnnotations;

namespace Min_FrontEndApp.Models.ViewModels;

public class AdminAddProductViewModel
{
    [Display(Name = "Namn")]
    [Required(ErrorMessage = "Du måste ange ett namn")]
    public string Name { get; set; } = null!;
    
    [Display(Name = "Beskrivning")]
    public string? Description { get; set; }
    
    [Display(Name = "Pris")]
    [Required(ErrorMessage = "Du måste ange ett pris")]
    public decimal Price { get; set; }
    
    [Display(Name = "Bildlänk")]
    [Required(ErrorMessage = "Du måste ange en bildlänk")]
    public string ImageUrl { get; set; } = null!;
    
    [Display(Name = "Antal Stjärnor")]
    [Required(ErrorMessage = "Du måste ange antal stjärnor")]
    public int StarRating { get; set; }
    
    [Display(Name = "Statuskod: Featured=1, New=2, Popular=3")]
    public int Status { get; set; }
}