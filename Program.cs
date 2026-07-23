using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;
using RestaurantWebsite.Models;


var builder = WebApplication.CreateBuilder(args);



// =======================
// DATABASE CONFIGURATION
// SQLITE
// =======================


var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlite(connectionString);

});





// =======================
// IDENTITY CONFIGURATION
// ADMIN LOGIN
// =======================


builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {

        options.Password.RequireDigit = true;

        options.Password.RequireLowercase = true;

        options.Password.RequireUppercase = true;

        options.Password.RequireNonAlphanumeric = true;

        options.Password.RequiredLength = 8;


    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();






// =======================
// MVC SERVICES
// =======================


builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();






// =======================
// SESSION
// =======================


builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession();






// =======================
// BUILD APP
// =======================


var app = builder.Build();







// =======================
// DATABASE MIGRATION
// + INITIAL DATA
// + CREATE ADMIN
// =======================


using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;


    try
    {

        var db = services
            .GetRequiredService<ApplicationDbContext>();


        // Apply migrations

        db.Database.Migrate();



        // Existing restaurant seed data

        DbInitializer.Initialize(db, app.Environment);




        // Create admin account

        await AdminInitializer.Initialize(services);


    }
    catch(Exception ex)
    {

        Console.WriteLine("DATABASE ERROR:");

        Console.WriteLine(ex.Message);

    }

}








// =======================
// ERROR HANDLING
// =======================


if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");


    app.UseHsts();

}







// =======================
// HTTP PIPELINE
// =======================


app.UseHttpsRedirection();


app.UseStaticFiles();



app.UseRouting();



app.UseSession();



// IMPORTANT FOR IDENTITY

app.UseAuthentication();


app.UseAuthorization();







// =======================
// ROUTES
// =======================


app.MapControllerRoute(

    name:"default",

    pattern:"{controller=Home}/{action=Index}/{id?}"

);



app.MapRazorPages();







// =======================
// START
// =======================


app.Run();