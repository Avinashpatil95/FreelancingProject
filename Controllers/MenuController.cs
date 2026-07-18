using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models.ViewModels;


namespace RestaurantWebsite.Controllers
{
    public class MenuController : Controller
    {

        private readonly ApplicationDbContext _context;


        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {


            var categories = _context.Categories
                .ToList();



            var menuItems = _context.MenuItems
                .Include(x => x.Category)
                .Where(x => x.IsAvailable)
                .OrderBy(x => x.Name)
                .ToList();





            var model = new MenuViewModel
            {

                Categories = categories,

                MenuItems = menuItems

            };



            return View(model);

        }







        public IActionResult Filter(int categoryId)
        {


            var menuItems = _context.MenuItems
                .Include(x => x.Category)
                .Where(x => x.IsAvailable);





            if(categoryId != 0)
            {

                menuItems = menuItems
                    .Where(x => x.CategoryId == categoryId);

            }





            var result = menuItems
                .OrderBy(x => x.Name)
                .ToList();





            return PartialView("_MenuItems", result);

        }



    }
}