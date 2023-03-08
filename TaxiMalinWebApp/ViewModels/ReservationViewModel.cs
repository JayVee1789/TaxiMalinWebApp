using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiMalinWebApp.Models;

namespace TaxiMalinWebApp.ViewModels
{
    public class ReservationViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public int? NumeroTelephone { get; set; }

        public int? NbrePassager { get; set; }

        public string? AdresseDepart { get; set; }

        public string? AdresseDestination { get; set; }

        public DateTime? DateReservation { get; set; }

        
    }
}
