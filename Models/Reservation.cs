public class Reservation
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime ReservationDate { get; set; }

    public int Guests { get; set; }

    public string Status { get; set; } = "Pending";
}