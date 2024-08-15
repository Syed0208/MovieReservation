using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.DataStore;
using MovieReservation.Models;

namespace MovieReservation.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [HttpPost("BookTicket")]
        public ActionResult BookTicket(string movieName)
        {
            Movie? movie = GetMovie(movieName);
            if (movie == null)
            {
                return NotFound("No movie found.");
            }

            //int? ticketID = TicketStore.Tickets.Max(t => t.TicketID);
            //ticketID = ticketID ?? 0;

            var ticket = new Ticket
            {
                //TicketID = TicketStore.Tickets.Count != 0
                //  ? TicketStore.Tickets.Max(t => t.TicketID)
                //  : 1,
                TicketID = TicketStore.Tickets
                .DefaultIfEmpty()
                .Max(t => t?.TicketID ?? 1),
                Movie = movie,
                Status = "Confirmed"
            };

            TicketStore.Tickets.Add(ticket);

            return CreatedAtAction("GetTicket", new { ticket.TicketID }, ticket);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{ticketID}",Name ="GetTicketByID")]
        public ActionResult GetTicket(int ticketID)
        {
            Ticket? currentTicket = GetTicketData(ticketID);
            if (currentTicket == null)
            {
                return NotFound("No ticket found.");
            }
            return Ok(currentTicket);
        }
        /*
         * Patch method calling from Postman/Swagger
         
         *  [ {
            "path": "status",
            "op": "replace",
            "value": "Cancelled"
             } ]
         
         */
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpPatch("UpdateTicket")]
        public ActionResult UpdateTicketStatus(int ticketID, JsonPatchDocument<Ticket> ticket)
        {
            Ticket? currentTicket = GetTicketData(ticketID);
            if (currentTicket == null)
            {
                return NotFound("No ticket found.");
            }
            ticket.ApplyTo(currentTicket);
            return NoContent();

        }
        private static Movie? GetMovie(string movie)
        {
            return MovieStore.Movies.FirstOrDefault(u => u.MovieName == movie);
        }

        private static Ticket? GetTicketData(int ticketID)
        {
            return TicketStore.Tickets.FirstOrDefault(u => u.TicketID == ticketID);
        }

    }
}
