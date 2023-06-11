using LogDetailsAPI.Context;
using LogDetailsAPI.Interfaces;
using LogDetailsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogDetailsAPI.Services
{
    public class LogRepo : IRepo<LogDetails, int>
    {
        private readonly LogContext _context;
        private readonly ILogger<LogRepo> _logger;

        public LogRepo(LogContext context, ILogger<LogRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<LogDetails?> Add(LogDetails item)
        {
            try
            {
                _context.LogDetails.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }


        public async Task<LogDetails?> Delete(int key)
        {
            var log = await Get(key);
            if (log != null)
            {
                _context.LogDetails.Remove(log);
                await _context.SaveChangesAsync();
                return log;
            }
            return null;
        }

        public async Task<LogDetails?> Get(int key)
        {
            var log = await _context.LogDetails.FirstOrDefaultAsync(x => x.logId == key);
            return log;
        }

        public async Task<ICollection<LogDetails>> GetAll()
        {
            var logs = await _context.LogDetails.ToListAsync();
            return logs;
        }

    }
}
