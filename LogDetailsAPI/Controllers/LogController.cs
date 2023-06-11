using LogDetailsAPI.Interfaces;
using LogDetailsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IRepo<LogDetails, int> _repo;

        public LogController(IRepo<LogDetails, int> repo)
        {
            _repo = repo;
        }

        [HttpPost("Add log")]
        public async Task<ActionResult<LogDetails>> AddLog(LogDetails logDetails)
        {
            var details = await _repo.Add(logDetails);
            if (details == null)
            {
                BadRequest("Unable to Add");
            }
            return Ok(details);
        }

        [HttpDelete("Delete log")]

        public async Task<ActionResult<LogDetails>> DeleteLog(int logId)
        {
            var details = await _repo.Delete(logId);
            if (details == null)
            {
                BadRequest("Unable to delete");
            }
            return Ok(details);
        }

        [HttpGet("Get log by id")]

        public async Task<ActionResult<LogDetails>> GetLogById(int logId)
        {
            var details = await _repo.Get(logId);
            if (details == null)
            {
                BadRequest("Unable to fetch");
            }
            return Ok(details);
        }

        [HttpGet("Get all logs")]

        public async Task<ActionResult<LogDetails>> GetAllLogs()
        {
            var details = await _repo.GetAll();
            if (details == null)
            {
                BadRequest("Unable to delete");
            }
            return Ok(details);
        }

    }
}
