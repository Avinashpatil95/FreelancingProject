using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.Data;


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
// =======================


using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;


    try
    {

        var db = services
            .GetRequiredService<ApplicationDbContext>();


        // Apply pending migrations

        db.Database.Migrate();



        // Insert default data

        DbInitializer.Initialize(db);


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