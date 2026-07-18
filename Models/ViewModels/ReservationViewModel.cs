using System.ComponentModel.DataAnnotations;

namespace RestaurantWebsite.Models.ViewModels
{
    public class ReservationViewModel
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int Guests { get; set; }
    }
}