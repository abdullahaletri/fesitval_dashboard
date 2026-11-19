using fesitval_dashboard.Models;

namespace fesitval_dashboard.Data
{
    public static class SeedData
    {
        public static void VulDatabase(FestivalDbContext context)
        {
            // Stap 1: festivals (alleen toevoegen als de naam nog niet bestaat)
            var festivalGegevens = new[]
            {
                (Naam: "Zomerfestival", Locatie: "Arnhem",    Datum: new DateTime(2027, 6, 18)),
                (Naam: "Rocknacht",     Locatie: "Utrecht",    Datum: new DateTime(2027, 7, 3)),
                (Naam: "Danceplein",    Locatie: "Rotterdam",  Datum: new DateTime(2027, 7, 24)),
                (Naam: "Jazzavond",     Locatie: "Amsterdam",  Datum: new DateTime(2027, 8, 14)),
                (Naam: "Foodfest",      Locatie: "Eindhoven",  Datum: new DateTime(2027, 9, 4)),
            };

            foreach (var gegevens in festivalGegevens)
            {
                if (!context.Fesitvals.Any(f => f.Naam == gegevens.Naam))
                {
                    context.Fesitvals.Add(new Fesitval
                    {
                        Naam = gegevens.Naam,
                        Locatie = gegevens.Locatie,
                        Datum = gegevens.Datum
                    });
                }
            }

            // Stap 2: tickettypes
            foreach (var naam in new[] { "Standaard", "VIP", "Weekend" })
            {
                if (!context.Tickettypes.Any(type => type.Naam == naam))
                    context.Tickettypes.Add(new Tickettype { Naam = naam });
            }

            // Opslaan, zodat de Id's beschikbaar zijn
            context.SaveChanges();

            // Stap 3: tickets (alleen als er nog geen tickets zijn)
            if (context.Tickets.Any())
                return;

            var voornamen = new[] { "Sanne", "Daan", "Emma", "Lucas", "Noa", "Finn", "Mila", "Sem", "Julia", "Bram", "Lisa", "Thijs", "Eva", "Jesse", "Fleur" };
            var achternamen = new[] { "de Vries", "Jansen", "Bakker", "Visser", "Smit", "Meijer", "de Boer", "Mulder", "Bos", "Vos" };

            var willekeurig = new Random(42);
            var festivals = context.Fesitvals.ToList();
            var typen = context.Tickettypes.ToList();

            for (int nummer = 1; nummer <= 500; nummer++)
            {
                var festival = festivals[willekeurig.Next(festivals.Count)];
                var type = typen[willekeurig.Next(typen.Count)];

                // Prijs past bij het tickettype
                decimal prijs = type.Naam switch
                {
                    "VIP" => willekeurig.Next(120, 181),
                    "Weekend" => willekeurig.Next(80, 111),
                    _ => willekeurig.Next(35, 56)
                };

                context.Tickets.Add(new Ticket
                {
                    FestivalId = festival.Id,
                    TickettypeId = type.Id,
                    NaamKoper = $"{voornamen[willekeurig.Next(voornamen.Length)]} {achternamen[willekeurig.Next(achternamen.Length)]}",
                    EmailKoper = $"bezoeker{nummer}@voorbeeld.nl",
                    Prijs = prijs,
                    // Verkocht in de afgelopen 8 weken
                    Verkoopdatum = DateTime.Today.AddDays(-willekeurig.Next(0, 56))
                });
            }

            context.SaveChanges();
        }
    }
}
