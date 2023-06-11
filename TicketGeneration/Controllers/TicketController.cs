using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketGeneration.Interfaces;
using TicketGeneration.Models;

namespace TicketGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IRepo<Tickets, int> _repo;

        public TicketController(IRepo<Tickets, int> repo)
        {
            _repo = repo;
        }
        [HttpGet("Get tickets by intern id")]
        public async Task<ActionResult<Tickets>> GetTicketById(int internID)
        {
            var ticket = await _repo.Get(internID);
            if (ticket == null)
            {
                BadRequest("Unable to fetch");
            }
            return Ok(ticket);
        }

        [HttpGet("Get all tickets")]
        public async Task<ActionResult<Tickets>> GetAllTickets()
        {
            var tickets = await _repo.GetAll();
            if (tickets == null)
            {
                BadRequest("Unable to fetch");
            }
            return Ok(tickets);
        }

        [HttpPost("Add tickets")]
        public async Task<ActionResult<Tickets>> AddTickets(Tickets tickets)
        {
            var ticket = await _repo.Add(tickets);
            if (ticket == null)
            {
                return BadRequest("Unable to add");
            }
            return Ok(ticket);
        }


        [HttpPut("Update tickets")]
        public async Task<ActionResult<Tickets>> UpdateTickets(Tickets tickets)
        {
            var ticket = await _repo.Update(tickets);
            if (ticket == null)
            {
                return BadRequest("Unable to update");
            }
            return Ok(ticket);
        }

        [HttpDelete("Delete tickets")]
        public async Task<ActionResult<Tickets>> DeleteTickets(int ticketID)
        {
            var ticket = await _repo.Delete(ticketID);
            if (ticket == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(ticket);
        }
    }
}
