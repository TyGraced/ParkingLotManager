namespace Core.Entities
{
    public class PackingTickets : BaseEntity
    {
        public string Name { get; set; }
        public string EntryTime { get; set; }
        public string ExitTime { get; set; }
        public int HoursSpent { get; set; }
        public decimal AmountToPay { get; set; }
        public string Date { get; set; }
    }
}
