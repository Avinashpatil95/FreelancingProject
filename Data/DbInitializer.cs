using Microsoft.AspNetCore.Hosting;
using RestaurantWebsite.Models;


namespace RestaurantWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {


            // =======================
            // Categories
            // =======================

            if (!context.Categories.Any())
            {

                context.Categories.AddRange(

                    new Category
                    {
                        Name = "Starters"
                    },


                    new Category
                    {
                        Name = "Main Course"
                    },


                    new Category
                    {
                        Name = "Desserts"
                    },


                    new Category
                    {
                        Name = "Drinks"
                    }

                );


                context.SaveChanges();

            }





            // =======================
            // Helper for loading images
            // =======================

            byte[]? LoadImage(string fileName)
            {

                string path = Path.Combine(
                    environment.WebRootPath,
                    "images",
                    "menu",
                    fileName
                );


                if (!File.Exists(path))
                {
                    Console.WriteLine(
                        "Image not found: " + path
                    );

                    return null;
                }


                return File.ReadAllBytes(path);

            }





            // =======================
            // Menu Items
            // =======================

            if (!context.MenuItems.Any())
            {


                var starters =
                    context.Categories
                    .First(x => x.Name == "Starters");



                var mainCourse =
                    context.Categories
                    .First(x => x.Name == "Main Course");



                var desserts =
                    context.Categories
                    .First(x => x.Name == "Desserts");



                var drinks =
                    context.Categories
                    .First(x => x.Name == "Drinks");





                context.MenuItems.AddRange(


                    new MenuItem
                    {

                        Name = "Paneer Tikka",

                        Description =
                        "Grilled paneer with Indian spices.",

                        Price = 250,


                        ImageData =
                        LoadImage("paneer-tikka.jpg"),

                        ImageType =
                        "image/jpeg",


                        CategoryId = starters.Id,

                        IsFeatured = true,

                        IsAvailable = true

                    },




                    new MenuItem
                    {

                        Name = "Chicken Biryani",

                        Description =
                        "Aromatic basmati rice with traditional spices.",

                        Price = 350,


                        ImageData =
                        LoadImage("biryani.jpg"),

                        ImageType =
                        "image/jpeg",


                        CategoryId = mainCourse.Id,

                        IsFeatured = true,

                        IsAvailable = true

                    },





                    new MenuItem
                    {

                        Name = "Butter Chicken",

                        Description =
                        "Creamy tomato based chicken curry.",

                        Price = 450,


                        ImageData =
                        LoadImage("butter-chicken.jpg"),

                        ImageType =
                        "image/jpeg",


                        CategoryId = mainCourse.Id,

                        IsFeatured = true,

                        IsAvailable = true

                    },





                    new MenuItem
                    {

                        Name = "Chocolate Cake",

                        Description =
                        "Rich chocolate dessert.",

                        Price = 180,


                        ImageData =
                        LoadImage("chocolate-cake.jpg"),

                        ImageType =
                        "image/jpeg",


                        CategoryId = desserts.Id,

                        IsFeatured = false,

                        IsAvailable = true

                    },





                    new MenuItem
                    {

                        Name = "Fresh Lime Soda",

                        Description =
                        "Refreshing lime drink.",

                        Price = 80,


                        ImageData =
                        LoadImage("lime-soda.jpg"),

                        ImageType =
                        "image/jpeg",


                        CategoryId = drinks.Id,

                        IsFeatured = false,

                        IsAvailable = true

                    }


                );



                context.SaveChanges();

            }





            // =======================
            // Home Banners
            // =======================

            if (!context.HomeBanners.Any())
            {

                context.HomeBanners.AddRange(

                    new HomeBanner
                    {
                        Title =
                        "Taste That Creates Memories",

                        Subtitle =
                        "Experience handcrafted dishes prepared with passion",

                        MediaUrl =
                        "/Images/banner1.jpg",

                        MediaType =
                        "image",

                        ButtonText =
                        "Book A Table",

                        ButtonLink =
                        "/Reservation",

                        IsActive = true,

                        DisplayOrder = 1
                    },


                    new HomeBanner
                    {
                        Title =
                        "Fine Dining Experience",

                        Subtitle =
                        "Fresh ingredients and unforgettable flavours",

                        MediaUrl =
                        "/Videos/banner2.mp4",

                        MediaType =
                        "video",

                        ButtonText =
                        "Explore Menu",

                        ButtonLink =
                        "/Menu",

                        IsActive = true,

                        DisplayOrder = 2
                    }

                );


                context.SaveChanges();

            }

        }
    }
}
