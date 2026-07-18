using RestaurantWebsite.Models;

namespace RestaurantWebsite.Models.ViewModels
{
    public class MenuViewModel
    {

        public List<Category> Categories { get; set; }
            = new List<Category>();


        public List<MenuItem> MenuItems { get; set; }
            = new List<MenuItem>();


    }
}