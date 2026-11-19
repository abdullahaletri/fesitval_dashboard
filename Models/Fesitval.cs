namespace fesitval_dashboard.Models
{
    public class Fesitval
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Locatie { get; set; } = string.Empty;
        public DateTime Datum { get; set; } = DateTime.Today;

    }
}
