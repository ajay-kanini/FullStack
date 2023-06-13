using System.ComponentModel.DataAnnotations;

namespace LogDetailsAPI.Models
{
    public class LogDetails
    {
        [Key]
        public int logId { get; set; }
        public string? logInTime { get; set; }
        public string? logOutTime { get; set; }
        public int internID { get; set; }
    }
}
