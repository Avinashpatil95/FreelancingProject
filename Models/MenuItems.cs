namespace RestaurantWebsite.Models
{
    public class MenuItem
    {
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;


        public decimal Price { get; set; }


        // Image stored directly in SQLite
        public byte[]? ImageData { get; set; }


        // Example: image/jpeg, image/png
        public string? ImageType { get; set; }


        public int CategoryId { get; set; }


        public Category Category { get; set; } = null!;


        public bool IsFeatured { get; set; }


        public bool IsAvailable { get; set; }
    }
}
