using Microsoft.AspNetCore.Identity;
using RestaurantWebsite.Models;


namespace RestaurantWebsite.Data
{
    public static class AdminInitializer
    {

        public static async Task Initialize(
            IServiceProvider serviceProvider)
        {


            var userManager =
                serviceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();



            var roleManager =
                serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();





            // create admin role

            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(
                    new IdentityRole("Admin"));
            }






            // create admin account

            var email = "admin@restaurant.com";


            var user =
                await userManager.FindByEmailAsync(email);



            if(user == null)
            {

                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };



                await userManager.CreateAsync(
                    user,
                    "Admin@123"
                );


                await userManager.AddToRoleAsync(
                    user,
                    "Admin"
                );

            }


        }

    }
}