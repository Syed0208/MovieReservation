using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private List<User> users =
        [
            new() {ID = 1, Name = "Syed", Email = "syed@02", Password = "Test@123"},
            new() {ID = 2, Name ="Gopi", Email = "gopi@02", Password= "Test@456"}

        ];

        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var currentUser = users.FirstOrDefault(u => u.Email == loginRequest.Email);

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
