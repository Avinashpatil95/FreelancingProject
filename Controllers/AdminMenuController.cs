using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;
using RestaurantWebsite.Models.ViewModels;


namespace RestaurantWebsite.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminMenuController : Controller
    {

        private readonly ApplicationDbContext _context;


        public AdminMenuController(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> Index()
        {

            var items =
                await _context.MenuItems
                .Include(x => x.Category)
                .ToListAsync();


            return View(items);

        }





        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Categories =
                await _context.Categories.ToListAsync();


            return View();

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            AdminMenuViewModel model)
        {


            ViewBag.Categories =
                await _context.Categories.ToListAsync();



            if (!ModelState.IsValid)
            {
                return View(model);
            }



            byte[]? imageData = null;

            string? imageType = null;



            if(model.MediaFile != null &&
               model.MediaFile.Length > 0)
            {

                using var memoryStream =
                    new MemoryStream();


                await model.MediaFile
                    .CopyToAsync(memoryStream);



                imageData =
                    memoryStream.ToArray();



                imageType =
                    model.MediaFile.ContentType;

            }





            MenuItem item = new MenuItem
            {

                Name = model.Name,


                Description = model.Description,


                Price = model.Price,


                CategoryId = model.CategoryId,


                ImageData = imageData,


                ImageType = imageType,


                IsFeatured = model.IsFeatured,


                IsAvailable = model.IsAvailable

            };




            _context.MenuItems.Add(item);


            await _context.SaveChangesAsync();



            TempData["Success"] =
                "Menu item added successfully";



            return RedirectToAction(nameof(Index));

        }






        public async Task<IActionResult> Delete(int id)
        {

            var item =
                await _context.MenuItems.FindAsync(id);



            if(item != null)
            {

                _context.MenuItems.Remove(item);


                await _context.SaveChangesAsync();

            }



            return RedirectToAction(nameof(Index));

        }


    }
}
