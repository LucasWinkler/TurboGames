using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Country/Region")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Street address")]
        public string StreetAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State/Province/Region")]
        public string StateProvinceRegion { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "{0} code must be between {2} and {1}.", MinimumLength = 5)]
        [RegularExpression(@"^(\d{5}((|-)-\d{4})?)|([A-Za-z]\d[A-Za-z][\s\.\-]?(|-)\d[A-Za-z]\d)|[A-Za-z]{1,2}\d{1,2}[A-Za-z]? \d[A-Za-z]{2}$", ErrorMessage = "Postal/zip code is invalid.")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal/zip code")]
        public string PostalCode { get; set; }
    }
}
