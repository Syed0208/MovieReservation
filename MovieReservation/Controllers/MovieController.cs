using Microsoft.AspNetCore.Mvc;
using MovieReservation.DataStore;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [ProducesResponseType(200)]
        [HttpGet("GetAll")]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            return Ok(MovieStore.Movies);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("Search")]
        public ActionResult<List<Movie>> Search(string movieName)
        {
            Movie? movie = GetMovie(movieName);
            if (movie == null)
            {
                return NotFound("No movie found.");
            }

            return Ok(movie);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("Delete")]
        public ActionResult DeleteMovie(DeleteMovieRequest deleteMovie)
        {
            Movie? movieToBeDeleted = GetMovie(deleteMovie.MovieName);
            if (movieToBeDeleted == null)
            {
                return NotFound("No movie found.");
            }

            MovieStore.Movies.Remove(movieToBeDeleted);
            return NoContent();
        }


        private static Movie? GetMovie(string movie)
        {
            return MovieStore.Movies.FirstOrDefault(u => u.MovieName == movie);
        }
    }
}
