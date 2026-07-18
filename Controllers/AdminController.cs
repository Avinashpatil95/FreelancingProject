using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;


namespace RestaurantWebsite.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {


        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ApplicationDbContext _context;



        public AdminController(
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {

            _signInManager = signInManager;

            _context = context;

        }







        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }








        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(
            string email,
            string password)
        {



            var result =
                await _signInManager.PasswordSignInAsync(
                    email,
                    password,
                    false,
                    false);




            if(result.Succeeded)
            {

                return RedirectToAction(nameof(Dashboard));

            }



            ViewBag.Error =
                "Invalid email or password";


            return View();

        }









        public async Task<IActionResult> Dashboard()
        {


            ViewBag.MenuCount =
                await _context.MenuItems.CountAsync();



            ViewBag.CategoryCount =
                await _context.Categories.CountAsync();



            ViewBag.ReservationCount =
                await _context.Reservations.CountAsync();



            ViewBag.FeaturedCount =
                await _context.MenuItems
                .CountAsync(x=>x.IsFeatured);



            return View();

        }








        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();


            return RedirectToAction(nameof(Login));

        }


    }

}