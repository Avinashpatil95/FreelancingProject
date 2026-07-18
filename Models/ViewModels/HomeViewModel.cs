using RestaurantWebsite.Models;

namespace RestaurantWebsite.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<HomeBanner> Banners { get; set; } = new();

        public List<MenuItem> SliderItems { get; set; } = new();

        public List<MenuItem> FeaturedItems { get; set; } = new();

        public List<MenuItem> ChefSpecialItems { get; set; } = new();
    }
}