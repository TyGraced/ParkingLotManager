using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Request
{
    public class CreatePackingTicket
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EntryTime { get; set; }
        [Required]
        public string ExitTime { get; set; }
        public int HoursSpent { get; set; }
        public decimal AmountToPay { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
