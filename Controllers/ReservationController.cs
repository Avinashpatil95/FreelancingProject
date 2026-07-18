using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;
using RestaurantWebsite.Models.ViewModels;

namespace RestaurantWebsite.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // DISPLAY RESERVATION PAGE
        // ==========================
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ReservationViewModel());
        }

        // ==========================
        // SAVE RESERVATION
        // ==========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var reservation = new Reservation
                {
                    CustomerName = model.CustomerName,
                    Email = model.Email,
                    Phone = model.Phone,
                    ReservationDate = model.ReservationDate,
                    Guests = model.Guests,

                    // Default status for new reservations
                    Status = "Pending"
                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                TempData["Success"] = "Your reservation has been submitted successfully. We look forward to serving you!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save your reservation. Please try again.");

                // Optional: remove this after debugging
                Console.WriteLine(ex.Message);

                return View(model);
            }
        }
    }
}