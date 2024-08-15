using Microsoft.AspNetCore.Mvc;
using MovieReservation.DataStore;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Register([FromBody] User newUser)
        {
            var currentUser = UserStore.Users.FirstOrDefault(u => u.Email == newUser.Email);

            if (currentUser != null)
            {
                return BadRequest("User already exists");
            }
            newUser.ID = UserStore.Users.Max(u => u.ID) + 1;
            UserStore.Users.Add(newUser);
            return Ok("New User created successfully");
        }
    }
}
