namespace MovieReservation.Models
{
    public class Movie
    {
        public int MovieID { get; set; }

        public string? MovieName { get; set; }

        public int? Rating { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
