using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Address
    {
        public Guid ID { get; set; }

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Primary address")]
        public string PrimaryAddress { get; set; }

        [ProtectedPersonalData]
        [Display(Name = "Secondary address")]
        public string SecondaryAddress { get; set; }

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        [ProtectedPersonalData]
        [StringLength(10, ErrorMessage = "{0} code must be between {2} and {1}.", MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Postal/zip code is invalid.")]
        [Display(Name = "Postal/zip code")]
        public string PostalCode { get; set; }
    }
}
