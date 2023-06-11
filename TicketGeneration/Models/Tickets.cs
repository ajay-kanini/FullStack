using System.ComponentModel.DataAnnotations;

namespace TicketGeneration.Models
{
    public class Tickets
    {
        [Key]
        public int ticketId { get; set; }
        public string? ticketTitle { get; set; }
        public string? ticketDescription { get; set; }
        public DateTime ticketRaisedDate { get; set; }
        public int internId { get; set; }

    }
}
