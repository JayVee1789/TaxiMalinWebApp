using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaxiMalinWebApp.Models
{
    public enum HeurePourForm
    {
        Une,
        Deux,
        Trois,
        Quatre


    }
    public class Reservation
    {
        public Guid Id { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(75, ErrorMessage = "Le champ [{0}] doit être une chaine de caractères avec une longueur maximale de {1}.")]
        public string? Name { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(75, ErrorMessage = "Le champ [{0}] doit être une chaine de caractères avec une longueur maximale de {1}.")]
        public string? Email { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(75, ErrorMessage = "Le champ [{0}] doit être une chaine de caractères avec une longueur maximale de {1}.")]
        public string? NumeroTelephone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(1, ErrorMessage = "Le champ [{0}] doit être chiffre compris entre 1 et 3.")]
        public string? NbrePassager { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(150, ErrorMessage = "Le champ [{0}] doit être une chaine de caractères avec une longueur maximale de {1}.")]
        public string? AdresseDepart { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [StringLength(150, ErrorMessage = "Le champ [{0}] doit être une chaine de caractères avec une longueur maximale de {1}.")]
        public string? AdresseDestination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? DateReservation { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ [{0}] est obligatoire.")]
        [BindProperty, DataType(DataType.Time)]
        public DateTime SelectTime { get; set; }

        public bool AgreementIsChecked { get; set; }
    }
}