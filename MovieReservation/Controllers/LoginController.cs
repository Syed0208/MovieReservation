using Microsoft.AspNetCore.Mvc;
using MovieReservation.Models;
using MovieReservation.DataStore;

namespace MovieReservation.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {   
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            User? currentUser = GetCurrentUser(loginRequest.Email);

            if (currentUser == null)
            {
                return NotFound("Invalid User");
            }
            if (currentUser.Password != null && currentUser.Password.Equals(loginRequest.Password))
            {
                return Ok("Login Successful");
            }
            else
            {
                return BadRequest("Invalid Password");
            }

        }

        [HttpPost("ForgotPassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult ForgotPassword([FromBody] string email)
        {
            User? currentUser = GetCurrentUser(email);
            if (currentUser == null)
            {
                return NotFound("Invalid User");
            }

            var resetLink = Url.Action("ResetPassword", "Login", new { email }, Request.Scheme);

            return Ok("Please use the link below to reset the password: " + resetLink);

           //return RedirectToAction(actionName:"ResetPassword", controllerName:"Login",, routeValues: routeValues, preserveMethod:true);
        }

        [HttpPost("ResetPassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult ResetPassword([FromBody] ResetPassword resetPassword)
        {
            User? currentUser = GetCurrentUser(resetPassword.Email);
            if (currentUser == null) 
            {
                return NotFound("Invalid User");
            }

            if(resetPassword.NewPassword != null &&resetPassword.NewPassword.Equals(resetPassword.ConfirmPassword))
            {
                currentUser.Password = resetPassword.NewPassword;
            }
            else
            {
                return BadRequest("Password and confirm password should match");
            }

            return Ok("Password Reset succesfully");

        }
        private static User? GetCurrentUser(string? email)
        {
            return UserStore.Users.FirstOrDefault(u => u.Email == email);
        }

    }
}
