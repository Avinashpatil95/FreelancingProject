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

        private readonly IWebHostEnvironment _environment;



        public AdminMenuController(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {

            _context = context;

            _environment = environment;

        }








        public async Task<IActionResult> Index()
        {

            var items =
                await _context.MenuItems
                .Include(x=>x.Category)
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




            if(!ModelState.IsValid)
            {

                return View(model);

            }





            string imagePath = "";






            // FILE UPLOAD

            if(model.MediaFile != null &&
               model.MediaFile.Length > 0)
            {



                string folder =
                    Path.Combine(
                        _environment.WebRootPath,
                        "Images",
                        "Menu");





                if(!Directory.Exists(folder))
                {

                    Directory.CreateDirectory(folder);

                }







                string fileName =
                    Guid.NewGuid().ToString()
                    +
                    Path.GetExtension(
                        model.MediaFile.FileName);






                string filePath =
                    Path.Combine(
                        folder,
                        fileName);







                using(var stream =
                    new FileStream(
                        filePath,
                        FileMode.Create))
                {

                    await model.MediaFile
                    .CopyToAsync(stream);

                }







                imagePath =
                    "/Images/Menu/" + fileName;



                Console.WriteLine(
                    "IMAGE SAVED: "
                    + imagePath);

            }
            else
            {

                Console.WriteLine(
                    "NO FILE RECEIVED");

            }









            MenuItem item = new MenuItem
            {

                Name = model.Name,


                Description = model.Description,


                Price = model.Price,


                CategoryId = model.CategoryId,


                ImageUrl = imagePath,


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
                await _context.MenuItems
                .FindAsync(id);



            if(item != null)
            {


                _context.MenuItems.Remove(item);


                await _context.SaveChangesAsync();

            }




            return RedirectToAction(nameof(Index));

        }



    }

}