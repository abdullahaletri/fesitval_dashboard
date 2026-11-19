using System.ComponentModel.DataAnnotations;

namespace fesitval_dashboard.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Display(Name = "Festival")]
        public int FestivalId { get; set; }
        public Fesitval? Festival { get; set; }

        [Display(Name = "Tickettype")]
        public int TickettypeId { get; set; }
        public Tickettype? Tickettype { get; set; }

        [Required(ErrorMessage = "Vul de naam van de koper in.")]
        [Display(Name = "Naam koper")]
        public string NaamKoper { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vul een e-mailadres in.")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig e-mailadres.")]
        [Display(Name = "E-mail koper")]
        public string EmailKoper { get; set; } = string.Empty;

        [Range(0.01, 10000, ErrorMessage = "De prijs moet tussen 0,01 en 10.000 liggen.")]
        [DataType(DataType.Currency)]
        public decimal Prijs { get; set; }

        [DataType(DataType.Date)]
        public DateTime Verkoopdatum { get; set; } = DateTime.Today;
    }
}
