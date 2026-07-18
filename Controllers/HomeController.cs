using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models.ViewModels;

namespace RestaurantWebsite.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {

            var model = new HomeViewModel();



            // ==========================
            // HOME BANNERS
            // ==========================

            model.Banners = _context.HomeBanners
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToList();





            // ==========================
            // AVAILABLE MENU ITEMS
            // ==========================

            var availableItems = _context.MenuItems
                .Where(x => x.IsAvailable)
                .Include(x => x.Category)
                .ToList();





            var random = new Random();





            // ==========================
            // TODAY'S SPECIAL SLIDER
            // RANDOM 5 ITEMS
            // ==========================

            model.SliderItems = availableItems
                .OrderBy(x => random.Next())
                .Take(5)
                .ToList();







            // ==========================
            // FEATURED MENU
            // ==========================

            model.FeaturedItems = availableItems
                .Where(x => x.IsFeatured)
                .Take(6)
                .ToList();







            // ==========================
            // CHEF'S SPECIAL
            // RANDOM 3 ITEMS
            // ==========================

            model.ChefSpecialItems = availableItems
                .OrderBy(x => random.Next())
                .Take(3)
                .ToList();







            return View(model);

        }


    }
}