namespace MovieReservation.Models
{
    public class DeleteMovieRequest
    {
        public int MovieID { get; set; }

        public string? MovieName { get; set; }

        public int DeletedBy { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}
