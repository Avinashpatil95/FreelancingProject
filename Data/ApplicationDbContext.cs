using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Models;


namespace RestaurantWebsite.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }



        public DbSet<Category> Categories { get; set; }


        public DbSet<MenuItem> MenuItems { get; set; }


        public DbSet<Reservation> Reservations { get; set; }


        public DbSet<HomeBanner> HomeBanners { get; set; }


    }
}