
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketGeneration.Context;
using TicketGeneration.Interfaces;
using TicketGeneration.Models;

namespace TicketGeneration.Services
{
    public class TicketRepo : IRepo<Tickets, int>
    {
        private readonly TicketContext _context;
        private readonly ILogger<TicketRepo> _logger;

        public TicketRepo(TicketContext context, ILogger<TicketRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Tickets?> Add(Tickets item)
        {
            try
            {
                _context.Tickets.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tickets?> Delete(int key)
        {
            var ticket = await Get(key);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }

        public async Task<Tickets?> Get(int key)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.ticketId == key);
            return ticket;
        }

        public async Task<ICollection<Tickets>> GetAll()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<Tickets?> Update(Tickets item)
        {
            var ticket = await Get(item.ticketId);
            if (ticket != null)
            {
                ticket.ticketId = item.ticketId;          
                ticket.ticketTitle = item.ticketTitle;
                ticket.ticketDescription = item.ticketDescription;
                ticket.ticketRaisedDate = item.ticketRaisedDate;
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }
    }
}
