
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
            var ticket = await GetByTicketId(key);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }

        public async Task<Tickets?> GetByTicketId(int key)
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
            var ticket = await GetByTicketId(item.ticketId);
            if (ticket != null)
            { 
                ticket.ticketStatus=item.ticketStatus != null ? item.ticketStatus : ticket.ticketStatus;  
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }
        public async Task<Tickets?> GetByInternId(int key)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.internId == key);
            return ticket;
        }
    }
}
