using Microsoft.AspNetCore.Mvc;
using MovieReservation.DataStore;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Register([FromBody] User newUser)
        {
            var currentUser = UserData.Users.FirstOrDefault(u => u.Email == newUser.Email);

            if (currentUser != null)
            {
                return BadRequest("User already exists");
            }
            newUser.ID = UserData.Users.Max(u => u.ID) + 1;
            UserData.Users.Add(newUser);
            return Ok("New User created successfully");
        }
    }
}
