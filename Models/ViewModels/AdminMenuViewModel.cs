using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models.ViewModels
{
    public class AdminMenuViewModel
    {

        public int Id { get; set; }



        [Required]
        public string Name { get; set; } = string.Empty;



        public string Description { get; set; } = string.Empty;



        [Required]
        public decimal Price { get; set; }



        [Required]
        public int CategoryId { get; set; }




        // IMAGE / VIDEO FILE

        public IFormFile? MediaFile { get; set; }




        public string? ExistingImageUrl { get; set; }




        public bool IsFeatured { get; set; }




        public bool IsAvailable { get; set; }


    }
}