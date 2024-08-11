namespace MovieReservation.Models
{
    public class Movie
    {
        public int MoviedID { get; set; }

        public string? MovieName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
