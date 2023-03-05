namespace TaxiMalinWebApp.Models
{
    public class ObjetPerduMessageModel
    {

        public Guid Id { get; set; }
        public string? Nom { get; set; }

        public string? Email { get; set; }
        public string? NumeroTelephone { get; set; }

        public string? Sujet { get; set; }
        public string? Message { get; set; }
    }
}
