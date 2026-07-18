using RestaurantWebsite.Models;


namespace RestaurantWebsite.Data
{


    public static class DbInitializer
    {


        public static void Initialize(ApplicationDbContext context)
        {


            // Categories

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





            // Menu Items

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

                        ImageUrl =
                        "/images/menu/paneer-tikka.jpg",

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

                        ImageUrl =
                        "/images/menu/biryani.jpg",

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

                        ImageUrl =
                        "/images/menu/butter-chicken.jpg",

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

                        ImageUrl =
                        "/images/menu/chocolate-cake.jpg",

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

                        ImageUrl =
                        "/images/menu/lime-soda.jpg",

                        CategoryId = drinks.Id,

                        IsFeatured = false,

                        IsAvailable = true

                    }


                );



                context.SaveChanges();


            }

            if (!context.HomeBanners.Any())
            {

                context.HomeBanners.AddRange(

                    new HomeBanner
                    {
                        Title = "Taste That Creates Memories",

                        Subtitle = "Experience handcrafted dishes prepared with passion",

                        MediaUrl = "/Images/banner1.jpg",

                        MediaType = "image",

                        ButtonText = "Book A Table",

                        ButtonLink = "/Reservation",

                        IsActive = true,

                        DisplayOrder = 1
                    },


                    new HomeBanner
                    {
                        Title = "Fine Dining Experience",

                        Subtitle = "Fresh ingredients and unforgettable flavours",

                        MediaUrl = "/Videos/banner2.mp4",

                        MediaType = "video",

                        ButtonText = "Explore Menu",

                        ButtonLink = "/Menu",

                        IsActive = true,

                        DisplayOrder = 2
                    }

                );


                context.SaveChanges();

            }

        }


    }


}