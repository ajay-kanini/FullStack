using LogDetailsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LogDetailsAPI.Context
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<LogDetails> LogDetails { get; set; }   

    }
}
