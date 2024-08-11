using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;
using MovieReservation.DataStore;

namespace MovieReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {   
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var currentUser = UserData.Users.FirstOrDefault(u => u.Email == loginRequest.Email);

            if(currentUser == null)
            {
                return NotFound("Invalid User");
            }
            if(currentUser.Password.Equals(loginRequest.Password))
            {
                return Ok("Login Successful");
            }
            else
            {
                return BadRequest("Invalid Password");
            }
        
        }
    }
}
