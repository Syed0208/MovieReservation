namespace MovieReservation.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        public Movie? Movie { get; set; }

        public string? Status { get; set; }

    }
}
