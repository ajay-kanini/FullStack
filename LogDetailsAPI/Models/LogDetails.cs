using System.ComponentModel.DataAnnotations;

namespace LogDetailsAPI.Models
{
    public class LogDetails
    {
        [Key]
        public int logId { get; set; }
        public DateTime? logInTime { get; set; }
        public DateTime? logOutTime { get; set; }
        public int internID { get; set; }
    }
}
