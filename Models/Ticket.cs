namespace fesitval_dashboard.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public int TickettypeId { get; set; }

        public string NaamKoper { get; set; } = string.Empty;
        public string EmailKoper { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public DateTime Verkoopdatum { get; set; } = DateTime.Today;
    }
}
