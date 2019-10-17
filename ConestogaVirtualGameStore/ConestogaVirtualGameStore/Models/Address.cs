using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string PrimaryAddress { get; set; }

        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Address 2 (optional)")]
        public string SecondaryAddress { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        [ProtectedPersonalData]
        [StringLength(12, ErrorMessage = "{0} code must be between {2} and {1}.", MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Postal/zip code is invalid.")]
        [DataType(DataType.Text)]
        [Display(Name = "Postal/zip code")]
        public string PostalCode { get; set; }
    }
}
