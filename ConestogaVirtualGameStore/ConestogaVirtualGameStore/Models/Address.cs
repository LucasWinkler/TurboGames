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
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string PrimaryAddress { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address 2 (optional)")]
        public string SecondaryAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "{0} code must be between {2} and {1}.", MinimumLength = 5)]
        [RegularExpression(@"^(\d{5}((|-)-\d{4})?)|([A-Za-z]\d[A-Za-z][\s\.\-]?(|-)\d[A-Za-z]\d)|[A-Za-z]{1,2}\d{1,2}[A-Za-z]? \d[A-Za-z]{2}$", ErrorMessage = "Postal/zip code is invalid.")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal/zip code")]
        public string PostalCode { get; set; }
    }
}
