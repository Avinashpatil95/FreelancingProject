namespace RestaurantWebsite.Models
{
    public class HomeBanner
    {
        public int Id { get; set; }


        public string Title { get; set; } = string.Empty;


        public string Subtitle { get; set; } = string.Empty;


        public string MediaUrl { get; set; } = string.Empty;


        public string MediaType { get; set; } = "image";


        public string ButtonText { get; set; } = string.Empty;


        public string ButtonLink { get; set; } = string.Empty;


        public bool IsActive { get; set; } = true;


        public int DisplayOrder { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public DateTime? UpdatedDate { get; set; }
    }
}