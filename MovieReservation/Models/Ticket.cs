namespace MovieReservation.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        public Movie? Movie { get; set; }

        public string? Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

    }
}
