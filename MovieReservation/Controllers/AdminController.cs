using Microsoft.AspNetCore.Mvc;
using MovieReservation.DataStore;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(UserStore.Users);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpDelete]
        public ActionResult Delete(string email)
        {
            var userToBeDeleted = UserStore.Users.FirstOrDefault(u => u.Email == email);

            if (userToBeDeleted == null)
            {
                return BadRequest("User deos not exist");
            }
            UserStore.Users.Remove(userToBeDeleted);
            return NoContent();
        }
    }
}
