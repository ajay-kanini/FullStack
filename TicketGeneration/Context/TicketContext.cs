using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketGeneration.Models;

namespace TicketGeneration.Context
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Tickets> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>()
                .Property(e => e.ticketRaisedDate)
                .HasColumnType("date");
        }
    }
}
