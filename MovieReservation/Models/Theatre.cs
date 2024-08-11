namespace MovieReservation.Models
{
    public class Theatre
    {
        public int TheatreId { get; set; }

        public string? TheatreName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
